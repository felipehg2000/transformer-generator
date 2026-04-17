using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using transformer_generator.src.Model;
using transformer_generator.src.Services.ManageFileTypes;
using transformer_generator.Templates;

namespace transformer_generator.src.Utils.Generator
{
    /// <summary>
    /// Clase para generar un proyecto c++ compilable con CMake que traduzca el objeto QueryModel a código c++.
    /// </summary>
    internal class CppGenerator : CodeGenerator
    {
        #region "Constructor"
        /// <summary>
        /// Constructor, inicializa atributos.
        /// </summary>
        /// <param name="param_metadata">Metadatos para crear una salida controlada.</param>
        public CppGenerator(Metadata param_metadata) : 
            base(param_metadata, param_metadata.QueryModel)
        {

        }
        #endregion "Constructor"

        #region "Virtual Methods"
        /// <summary>
        /// Genera los diferentes ficheros y directorios para obtener un proyecto C++ compilable con CMake.
        /// </summary>
        /// <returns>Objeto Result con información sobre el resultado del proceso.</returns>
        public override Result GenerateCode()
        {
            try
            {
                // Inicializa atributos y rellena configuración
                string base_path = _metadata.Configuration.OutputPathCode;
                string src_path = Path.Combine(base_path, "src");
                _metadata.Configuration.OutputPathMetadata = Path.Combine(base_path, DateTime.Now.ToString("yyyyMMddHHmmss") + ".csv");

                // Traducir instrucciones del objeto QueryModel al código C++
                string instructions = GenerateInstructions();

                // Generar Main 
                string main = Cpp.MainCpp
                    .Replace("{Instrucciones}", instructions)
                    .Replace("{Fecha}", DateTime.Now.ToString("yyyy-MM-dd"));

                // Generar ficheros src
                string table_managment_h = Cpp.TableManagmentH.Replace("{Fecha}", DateTime.Now.ToString("yyyy-MM-dd"));
                string table_managment_cpp = Cpp.TableManagmentCpp.Replace("{Fecha}", DateTime.Now.ToString("yyyy-MM-dd"));
                string table_output_h = Cpp.TableOutputH.Replace("{Fecha}", DateTime.Now.ToString("yyyy-MM-dd"));
                string table_output_cpp = Cpp.TableOutputCpp.Replace("{Fecha}", DateTime.Now.ToString("yyyy-MM-dd"));

                // Crear estructura de directorios
                Directory.CreateDirectory(base_path);
                Directory.CreateDirectory(src_path);

                // Generar ficheros
                File.WriteAllText(Path.Combine(base_path, "m-transformer.cpp"), main);
                File.WriteAllText(Path.Combine(src_path, "TableManagment.h"), table_managment_h);
                File.WriteAllText(Path.Combine(src_path, "TableManagment.cpp"), table_managment_cpp);
                File.WriteAllText(Path.Combine(src_path, "TableOutput.h"), table_output_h);
                File.WriteAllText(Path.Combine(src_path, "TableOutput.cpp"), table_output_cpp);

                // Generar ficheros de proyecto
                File.WriteAllText(Path.Combine(base_path, "m-transformer.slnx"), Cpp.MTransformerSlnx);
                File.WriteAllText(Path.Combine(base_path, "m-transformer.vcxproj"), Cpp.MTransformerVcxproj);
                File.WriteAllText(Path.Combine(base_path, "m-transformer.vcxproj.filters"), Cpp.MTransformerFilters);
                File.WriteAllText(Path.Combine(base_path, "m-transformer.vcxproj.user"), Cpp.MTransformerUser);

                // Genera fichero CSV que leerá el código creado
                CSVFiles csv_file = new CSVFiles(_metadata.Configuration.OutputPathMetadata, ",");
                csv_file.WriteFile(_metadata.Source.Columns);

                return new Result(true,
                    "Código C++ generado correctamente.",
                    "Generación completada sin errores.");
            }
            catch (Exception ex)
            {
                return new Result(false,
                    "Error generando código.",
                    ex.Message);
            }
        }
        #endregion "Virtual Methods"

        #region "Private Methods"

        /// <summary>
        /// Genera el código en c++ para la orden de agregación de columnas.
        /// </summary>
        /// <param name="param_step">Objeto de tipo Step con toda la información para generar una orden en c++.</param>
        /// <returns>Orden de agregación de columnas en c++</returns>
        private string GenerateAddColumn(Step param_step)
        {
            string column_name = param_step.Arguments["columnName"];
            string expression = param_step.Arguments["expression"];

            expression = expression.Replace("each", "").Trim();
            expression = TransformRowAccess(expression);

            return $"\t// AddColumn Order\n" +
                $"\tTableManagment::Table {param_step.Name} = TableManagment::AddColumn({param_step.Input}, \n" +
                $"\t\t\"{column_name}\", \n" +
                $"\t\t[](const TableManagment::Row& row) \n" +
                $"\t\t{{ \n" +
                $"\t\t\treturn \"{expression}\"; \n" +
                $"\t\t}});\n";
        }

        /// <summary>
        /// Genera las instrucciones en C++ a partir de las órdenes traducidas del lenguaje M.
        /// </summary>
        /// <returns>Código c++ con las instrucciones que se han configurado en lenguaje M.</returns>
        private string GenerateInstructions()
        {
            StringBuilder instructions = new StringBuilder();

            instructions.AppendLine(GenerateReadTable(_query_model.Steps[0]));
            foreach (var step in _query_model.Steps)
            {
                instructions.AppendLine(GenerateStep(step));
            }

            int step_index = _query_model.Steps.Count - 1;
            instructions.AppendLine(GeneratePrintTable(_query_model.Steps[step_index].Name));
            instructions.AppendLine(this.GenerateTableOutputFile(_query_model.Steps[step_index].Name));

            return instructions.ToString();
        }

        /// <summary>
        /// Genera la instrucción en C++ para mostrar la tabla resultante.
        /// </summary>
        /// <param name="param_table">Nombre de la variable donde se almacena la tabla.</param>
        /// <returns>Orden para imprimir la tabla por consola.</returns>
        private string GeneratePrintTable(string param_table)
        {
            return $"\t// PrintTable order\n" +
                $"\tTableOutput::PrintTable({param_table});\n";
        }

        /// <summary>
        /// Orden para leer un fichero CSV con c++
        /// </summary>
        /// <param name="param_step">Orden del objeto QueryModel con la información a traducid a C++</param>
        /// <returns></returns>
        private string GenerateReadTable(Step param_step)
        {
            return $"\t// ReadTable order\n" +
                $"\tTableManagment::Table {param_step.Input} = TableManagment::ReadCSV(\"{_metadata.Configuration.OutputPathMetadata.Replace("\\", "\\\\")}\");\n";
        }

        /// <summary>
        /// Genera el código en c++ para la orden de eliminación de columnas.
        /// </summary>
        /// <param name="param_step">Objeto de tipo Step con toda la información para generar una orden en c++.</param>
        /// <returns>Orden de eliminación de columnas en c++.</returns>
        private string GenerateRemoveColumns(Step param_step)
        {
            string[] columns = param_step.Arguments["columns"].Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            string[] checked_columns = new string[columns.Length];
            foreach (string column in columns)
            {
                checked_columns[Array.IndexOf(columns, column)] = $"\"{CheckColumnName(column)}\"";
            }

            return $"\t// RemoveColumns order\n" +
                $"\tTableManagment::Table {param_step.Name} = TableManagment::RemoveColumns({param_step.Input}, \n" +
                $"\t\t{{{string.Join(", ", checked_columns)}}});\n";
        }

        /// <summary>
        /// Genera el código en c++ para la orden de seleccionar columnas.
        /// </summary>
        /// <param name="param_step">Objeto de tipo Step con toda la información para generar una orden en c++.</param>
        /// <returns>Orden de selección de columnas en c++.</returns>
        private string GenerateSelectColumns(Step param_step)
        {
            string[] columns = param_step.Arguments["columns"].Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            string[] checked_columns = new string[columns.Length];
            foreach (string column in columns)
            {
                checked_columns[Array.IndexOf(columns, column)] = $"\"{CheckColumnName(column)}\"";
            }

            return $"\t// SelectColumns order\n" +
                $"\tTableManagment::Table {param_step.Name} = TableManagment::SelectColumns({param_step.Input}, \n" +
                $"\t\t{{{string.Join(", ", checked_columns)}}});\n";
        }

        /// <summary>
        /// Genera el código en c++ para la orden de seleccionar filas.
        /// </summary>
        /// <param name="param_step">Objeto de tipo Step con toda la información para generar una orden en c++.</param>
        /// <returns>Orden de selección de filas en c++.</returns>
        private string GenerateSelectRows(Step param_step)
        {
            string condition = param_step.Arguments["condition"];

            condition = condition.Replace("each", "").Trim();
            var match = Regex.Match(condition,
                @"\[(.*?)\]\s*(=|<>|>=|<=|>|<)\s*(.+)");

            if (!match.Success)
                throw new Exception("Condición no soportada: " + condition);

            string column_name = CheckColumnName(match.Groups[1].Value.Trim());
            string comparator = match.Groups[2].Value.Trim();
            string value = match.Groups[3].Value.Trim().TrimEnd(')');

            return $"\t// SelectRows order\n" +
                $"\tstd::string column_name = \"{column_name}\";\n" +
                $"\tstd::string value = \"{value}\";\n" +
                $"\tTableManagment::Table {param_step.Name} = TableManagment::SelectRow({param_step.Input}, \n" +
                $"\t\t[column_name, value](const TableManagment::Row& row) \n" +
                $"\t\t{{ \n" +
                $"\t\t\treturn row.find(column_name) != row.end() && row.at(column_name) {comparator} value; \n" +
                $"\t\t}});\n";
        }

        /// <summary>
        /// Función para decidir, según el tipo de operación, qué código de c++ hay que generar para cada paso. Llama a funciones específicas según el tipo de operación.
        /// </summary>
        /// <param name="param_step">Orden del objeto QueryModel que hay que traducir a C++.</param>
        /// <returns>Una única orden de lenguaje M escrita en c++.</returns>
        /// <exception cref="Exception">Operación no reconocida por el generador de código.</exception>
        private string GenerateStep(Step param_step)
        {
            switch (param_step.Operation)
            {
                case Step.OperationType.SelectRows:
                    return GenerateSelectRows(param_step);
                case Step.OperationType.AddColumn:
                    return GenerateAddColumn(param_step);
                case Step.OperationType.SelectColumns:
                    return GenerateSelectColumns(param_step);
                case Step.OperationType.RemoveColumns:
                    return GenerateRemoveColumns(param_step);
                default:
                    throw new Exception($"Operación no soportada por el generador de código: {param_step.Operation}");
            }
        }
        
        /// <summary>
        /// Función para generar la operación de impresión de tabla por consola.
        /// </summary>
        /// <param name="param_table">Tabla a imprimir por pantalla.</param>
        /// <returns>Orden para imprimir una tabla por pantalla.</returns>
        private string GenerateTableOutputFile(string param_table)
        {
            return $"\t// PrintTable order\n" +
                $"\tTableOutput::ExportTableToCSV({param_table});\n";
        }

        #endregion "Private Methods"
    }
}
