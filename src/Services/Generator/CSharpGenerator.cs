using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using transformer_generator.src.Model;
using transformer_generator.Templates;

namespace transformer_generator.src.Utils.Generator
{
    /// <summary>
    /// Clase para generar un proyecto c# compilable con visual studio.
    /// </summary>
    internal class CSharpGenerator : CodeGenerator
    {
        #region "Constructor"
        /// <summary>
        /// Constructor, inicializa atributos.
        /// </summary>
        /// <param name="param_metadata">Metadatos para crear una salida controlada.</param>
        public CSharpGenerator(Metadata param_metadata) : 
            base(param_metadata, param_metadata.QueryModel)
        {
            
        }
        #endregion "Constructor"

        #region "Virtual Methods"

        /// <summary>
        /// Genera los directorios y ficheros del proyecto y el programa con las instrucciones.
        /// </summary>
        /// <returns>Objeto Result con información sobre el resultado del proceso.</returns>
        public override Result GenerateCode()
        {
            try
            {
                // Genera las instrucciones. Se hace aquí para que, si da excepción no se creen directorios ni ficheros,.
                string instructions = GenerateInstructions();
                string program = CSharp.Program.Replace("{Instructions}", instructions);

                // Crea la estructura de carpetas para el proyecto.
                string base_path = _metadata.Configuration.OutputPathCode;
                Directory.CreateDirectory(base_path);
                Directory.CreateDirectory(Path.Combine(base_path, "src"));
                Directory.CreateDirectory(Path.Combine(base_path, "src", "Model"));
                Directory.CreateDirectory(Path.Combine(base_path, "src", "Services"));
                Directory.CreateDirectory(Path.Combine(base_path, "src", "Services", "Metadata"));
                Directory.CreateDirectory(Path.Combine(base_path, "src", "Services", "TableManagment"));

                // Crea los ficheros de modelo del proyecto.
                File.WriteAllText(Path.Combine(base_path, "src", "Model", "Column.cs"           ), CSharp.Column);
                File.WriteAllText(Path.Combine(base_path, "src", "Model", "DataSource.cs"       ), CSharp.DataSource);
                File.WriteAllText(Path.Combine(base_path, "src", "Model", "MainConfiguration.cs"), CSharp.MainConfiguration);
                File.WriteAllText(Path.Combine(base_path, "src", "Model", "Metadata.cs"         ), CSharp.Metadata);
                File.WriteAllText(Path.Combine(base_path, "src", "Model", "QueryModel.cs"       ), CSharp.QueryModel);
                File.WriteAllText(Path.Combine(base_path, "src", "Model", "Step.cs"             ), CSharp.Step);
                File.WriteAllText(Path.Combine(base_path, "src", "Model", "Column.cs"           ), CSharp.Column);

                // Crea los ficheros de servicios del proyecto.
                File.WriteAllText(Path.Combine(base_path, "src", "Services", "Metadata"         , "MetadataDAO.cs"   ), CSharp.MetadataDAO); 
                File.WriteAllText(Path.Combine(base_path, "src", "Services", "TableManagment"   , "TableManagment.cs"), CSharp.TableManagment);

                // Crea el programa principal del proyecto y los ficheros de proyecto.
                File.WriteAllText(Path.Combine(base_path, "Program.cs"), program);
                File.WriteAllText(Path.Combine(base_path, "test-proyect-c-sharp.csproj"), CSharp.Csproj);
                File.WriteAllText(Path.Combine(base_path, "test-proyect-c-sharp.slnx"), CSharp.Slnx);
            }
            catch (Exception exception)
            {
                return new Result(false,
                    "Error generando código.",
                    exception.Message);
            }

            return new Result(true, 
                "Código generado correctamente.", 
                string.Empty);
        }

        #endregion "Virtual Methods"

        #region "Private Methods"

        /// <summary>
        /// Genera el código en c# para añadir una columna a una tabla.
        /// </summary>
        /// <param name="param_step">Información sobre la orden de agregación de columnas.</param>
        /// <returns>Orden en c# para agregar una columna a una tabla.</returns>
        private string GenerateAddColumn(Step param_step)
        {
            string column_name = param_step.Arguments["columnName"];
            string expression = param_step.Arguments["expression"];

            expression = expression.Replace("each", "").Trim();
            expression = TransformRowAccess(expression);

            return $"List<Column> {param_step.Name} = TableManagment.AddColumn({param_step.Input}, \n" +
                $"\t\t\"{column_name}\", \n" +
                $"\t\trow => \"{expression}\");\n";
        }

        /// <summary>
        /// Método para generar las instrucciones c# leídas del fichero M
        /// </summary>
        /// <returns>Texto con las instrucciones en c#</returns>
        private string GenerateInstructions()
        {
            StringBuilder instructions = new StringBuilder();
            instructions.AppendLine(GenerateReadMetadata(_query_model.Steps[0]));

            foreach (Step step in _query_model.Steps)
            {
                instructions.AppendLine(GenerateStep(step));
            }

            return instructions.ToString();
        }

        /// <summary>
        /// Genera la instrucción para leer los metadatos.
        /// </summary>
        /// <param name="param_step">Paso posterior a la lectura de la tabla.</param>
        /// <returns>Orden de lectura de metadatos.</returns>
        private string GenerateReadMetadata(Step param_step)
        {
            return $"Console.WriteLine(\"Introduzca la ruta del archivo de metadatos (enter para continuar):\"); \n" +
                $"string path = Console.ReadLine() ?? string.Empty;\n" +
                $"Metadata metadata = MetadataDAO.ReadFile(path);\n" +
                $"List<Column> {param_step.Input} = metadata.Source.Columns;\n";
        }

        /// <summary>
        /// Genera la instrucción para borrar una columna de una tabla.
        /// </summary>
        /// <param name="param_step">Información sobre la orden de eliminación de columnas.</param>
        /// <returns>Orden en c# para eliminar una columna de una tabla</returns>
        private string GenerateRemoveColumns(Step param_step)
        {
            string[] columns = param_step.Arguments["columns"].Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            string[] checked_columns = new string[columns.Length];
            foreach (string column in columns)
            {
                checked_columns[Array.IndexOf(columns, column)] = $"\"{CheckColumnName(column)}\"";
            }

            return $"List<Column> {param_step.Name} = TableManagment.RemoveColumns({param_step.Input},\n" +
                $"\tnew List<string> {{ {string.Join(", ", checked_columns)} }});\n";
        }

        /// <summary>
        /// Genera la instrucción para seleccionar columnas de una tabla
        /// </summary>
        /// <param name="param_step">Información sobre la orden de selección de columnas</param>
        /// <returns>Orden en c# para seleccionar columnas de una tabla.</returns>
        private string GenerateSelectColumns(Step param_step)
        {
            string[] columns = param_step.Arguments["columns"].Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            string[] checked_columns = new string[columns.Length];
            foreach (string column in columns)
            {
                checked_columns[Array.IndexOf(columns, column)] = $"\"{CheckColumnName(column)}\"";
            }

            return $"List<Column> {param_step.Name} = TableManagment.SelectColumns({param_step.Input},\n" +
                $"\tnew List<string> {{ {string.Join(", ", checked_columns)} }});\n";
        }

        /// <summary>
        /// Genera la instrucción para seleccionar filas de una tabla.
        /// </summary>
        /// <param name="param_step">Información sobre la orden de selección de filas.</param>
        /// <returns>Orden en c# para seleccionar filas de una tabla.</returns>
        /// <exception cref="Exception">No se encuentran filtros para la selección de filas.</exception>
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

            return $"List<Column> {param_step.Name} = TableManagment.SelectRows({param_step.Input}, \n" +
                $"row => row.ContainsKey(\"{column_name}\") && row[\"{column_name}\"].CompareTo({value}) {comparator} 0);\n";
        }
                
        /// <summary>
        /// Fabrica de generación de ordenes. Selecciona el tipo de orden a crear según Step.OperationType
        /// </summary>
        /// <param name="param_step">Información de la orden a generar.</param>
        /// <returns>Orden generada en código c#</returns>
        /// <exception cref="Exception">Operación no soportada por la solución.</exception>
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

        #endregion "Private Methods"
    }
}
