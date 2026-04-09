using System;
using System.IO;
using System.Text;
using transformer_generator.src.Model;
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
        /// <param name="param_query_model">Ordenes traducidas de lenguaje M.</param>
        public CppGenerator(Metadata param_metadata, QueryModel param_query_model) : 
            base(param_metadata, param_query_model)
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
                // Traducir instrucciones del objeto QueryModel al código C++
                string instructions = GenerateInstructions();

                // Generar Main 
                string main = Cpp.MainCpp
                    .Replace("{Instrucciones}", instructions)
                    .Replace("{Fecha}", DateTime.Now.ToString("yyyy-MM-dd"));

                // Generar TableManagment
                string table_managment_h = Cpp.TableManagmentH
                    .Replace("{Fecha}", DateTime.Now.ToString("yyyy-MM-dd"));
                string table_managment_cpp = Cpp.TableManagmentCpp
                    .Replace("{Fecha}", DateTime.Now.ToString("yyyy-MM-dd"));

                // Generar CMakeLists
                string cmake_lists_txt = Cpp.CMakeLists;

                // Crear estructura de directorios
                string basePath = _metadata.Configuration.OutputPath;
                string srcPath = Path.Combine(basePath, "src");

                Directory.CreateDirectory(basePath);
                Directory.CreateDirectory(srcPath);

                // Generar ficheros
                File.WriteAllText(Path.Combine(basePath, "main.cpp"), main);
                File.WriteAllText(Path.Combine(srcPath, "TableManagment.h"), table_managment_h);
                File.WriteAllText(Path.Combine(srcPath, "TableManagment.cpp"), table_managment_cpp);
                File.WriteAllText(Path.Combine(basePath, "CMakeLists.txt"), cmake_lists_txt);

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
        /// Genera las instrucciones en C++ a partir de las órdenes traducidas del lenguaje M.
        /// </summary>
        /// <returns>Código c++ con las instrucciones que se han configurado en lenguaje M.</returns>
        private string GenerateInstructions()
        {
            StringBuilder string_builder = new StringBuilder();

            foreach (var step in _query_model.Steps)
            {
                string_builder.AppendLine(GenerateStep(step));
            }

            return string_builder.ToString();
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
        /// Genera el código en c++ para la orden de seleccionar filas.
        /// </summary>
        /// <param name="param_step">Objeto de tipo Step con toda la información para generar una orden en c++.</param>
        /// <returns>Orden de selección de filas en c++.</returns>
        private string GenerateSelectRows(Step param_step)
        {
            string condition = param_step.Arguments["condition"];

            condition = condition.Replace("each", "").Trim();
            condition = TransformRowAccess(condition);

            return $"auto {param_step.Name} = TableManagment::SelectRow({param_step.Input}, [](const TableManagment::Row& row) {{ return {condition}; }});";
        }

        /// <summary>
        /// Genera el código en c++ para la orden de seleccionar columnas.
        /// </summary>
        /// <param name="param_step">Objeto de tipo Step con toda la información para generar una orden en c++.</param>
        /// <returns>Orden de selección de columnas en c++.</returns>
        private string GenerateSelectColumns(Step param_step)
        {
            string columns = param_step.Arguments["columns"];

            return $"auto {param_step.Name} = TableManagment::SelectColumns({param_step.Input}, {{{columns}}});";
        }

        /// <summary>
        /// Genera el código en c++ para la orden de eliminación de columnas.
        /// </summary>
        /// <param name="param_step">Objeto de tipo Step con toda la información para generar una orden en c++.</param>
        /// <returns>Orden de eliminación de columnas en c++.</returns>
        private string GenerateRemoveColumns(Step param_step)
        {
            string columns = param_step.Arguments["columns"];

            return $"auto {param_step.Name} = TableManagment::RemoveColumns({param_step.Input}, {{{columns}}});";
        }

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

            return $"auto {param_step.Name} = TableManagment::AddColumn({param_step.Input}, \"{column_name}\", [](const TableManagment::Row& row) {{ return {expression}; }});";
        }

        /// <summary>
        /// Transforma una expresión de tipo string almacenada en el objeto QueryModel a su equivalente en c++ para el código generado.
        /// </summary>
        /// <param name="param_expression">Expresión traducida del lenguaje M.</param>
        /// <returns>Texto traducido a código legible por c++.</returns>
        private string TransformRowAccess(string param_expression)
        {
            return param_expression
                .Replace("[", "row.at(\"")
                .Replace("]", "\")");
        }
        #endregion "Private Methods"
    }
}
