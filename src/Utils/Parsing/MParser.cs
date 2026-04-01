using System;
using System.Collections.Generic;
using System.Linq;
using transformer_generator.src.Model;
using transformer_generator.src.Model.ControllerResult;

namespace transformer_generator.src.Utils.Parsing
{
    /// <summary>
    /// Clase encargada de analizar sintácticamente el lenguaje M y traducirlo a información manejable por la aplicación, en este caso, un objeto QueryModel.
    /// </summary>
    /// <remarks>
    /// Esta clase asume que el lenguaje M está bien formado. Si el formato no es correcto, el resultado es indefinido.
    /// Esta clase solo extrae la información de las ordenes manejables por la aplicación, estas ordenes se definen en el modelo Step la enumeración OperationType.
    /// </remarks>
    internal class MParser
    {
        #region "Métodos públicos"
        /// <summary>
        /// Comprueba si el texto está escrito en lenguaje M.
        /// </summary>
        /// <param name="param_text">Texto a comprobar.</param>
        /// <returns>True si es lenguaje M, false si no lo es.</returns>
        static public bool CheckMLenguage(string param_text)
        {
            if (string.IsNullOrWhiteSpace(param_text))
            {
                return false;
            }

            List<string> lines = param_text.Split('\n')
                .Select(line => line.Trim())
                .Where(line => !string.IsNullOrEmpty(line))
                .ToList();

            if (lines.Count == 0)
            {
                return false;
            }

            bool hasLet = lines.First().Equals("let", StringComparison.OrdinalIgnoreCase) || 
                lines.First().StartsWith("let ", StringComparison.OrdinalIgnoreCase);
            bool hasIn = lines.Any(line => line.StartsWith("in "));

            return hasLet && hasIn;
        }

        /// <summary>
        /// Análisis sintáctico del lenguaje M para obtener datos manejables por la aplicación.
        /// </summary>
        /// <param name="param_text">Texto cargado que, supuestamente está en lenguaje M.</param>
        /// <returns>Objeto que dice si la función es correcta o no y si es correcta devuelve el objeto QueryModel.</returns>
        static public QueryModelResult Parse(string param_text)
        {
            if (string.IsNullOrWhiteSpace(param_text))
            {
                return new QueryModelResult(false,
                    "Error en el proceso de lectura.",
                    "El fichero está vacío o no se ha leído correctamente.",
                    null);
            }

            if (!CheckMLenguage(param_text))
            {
                return new QueryModelResult(false,
                    "Error en el proceso de lectura.",
                    "El texto cargado no es un formato de lenguaje M.",
                    null);
            }

            return ParseText(param_text);
        }
        #endregion "Métodos públicos"

        #region "Métodos privados"
        /// <summary>
        /// Extrae los argumentos de la expresión del lenguaje M.
        /// </summary>
        /// <remarks>
        /// Este método asume que el lenguaje M está bien formado. Si el formato no es correcto, el resultado puede ser erróneo o vacío.
        /// </remarks>
        /// <param name="param_arguments">Porción de lenguaje M que debería tener los argumentos.</param>
        /// <returns>Listado de argumentos separadios por condición y columna.</returns>
        static private Dictionary<string, string> ExtractArguments(string param_arguments, Step.OperationType param_operation)
        {
            Dictionary<string, string> ret_args = new Dictionary<string, string>();

            switch (param_operation)
            {
                case Step.OperationType.SelectRows:
                    {
                        int each_index = param_arguments.IndexOf("each");
                        if (each_index != -1)
                        {
                            string condition = param_arguments.Substring(each_index).Trim();
                            ret_args["condition"] = condition;
                        }
                        break;
                    }
                case Step.OperationType.AddColumn:
                    {
                        var parts = GetArgumentsInsideParentheses(param_arguments);
                        if (parts.Count >= 2)
                        {
                            ret_args["columnName"] = parts[1].Replace("\"", "").Trim();
                        }
                        if (parts.Count >= 3 && parts[2].Contains("each"))
                        {
                            ret_args["expression"] = parts[2].Trim();
                        }

                        break;
                    }
                case Step.OperationType.SelectColumns:
                case Step.OperationType.RemoveColumns:
                    {
                        int start = param_arguments.IndexOf('{');
                        int end = param_arguments.IndexOf('}');

                        if (start != -1 && end != -1 && end > start)
                        {
                            string columns = param_arguments.Substring(start + 1, end - start - 1);
                            ret_args["columns"] = columns;
                        }

                        break;
                    }
                default:
                    break;
            }

            return ret_args;
        }

        /// <summary>
        /// Extrae todos los argumentos que hay entre dos paréntesis, separados por comas. Los devuelve en una lista.
        /// </summary>
        /// <param name="param_expression">Porción de código en lenguaje M que hay que procesar.</param>
        /// <returns>Lista de argumentos que se han encontrado en la expresión.</returns>
        static private List<string> GetArgumentsInsideParentheses(string param_expression)
        {
            int start = param_expression.IndexOf('(');
            int end = param_expression.LastIndexOf(')');

            if (start == -1 || end == -1 || end <= start)
            {
                return new List<string>();
            }

            string inside = param_expression.Substring(start + 1, end - start - 1);
            return inside.Split(',').Select(param => param.Trim()).ToList();
        }

        /// <summary>
        /// Hace el análisis sintáctico de todo el texto recibido por parámetro.
        /// </summary>
        /// <remarks>
        /// Este método asume que el lenguaje M está bien formado. Si el formato no es correcto, el resultado es indefinido.
        /// </remarks>
        /// <param name="param_text">Texto a analizar.</param>
        /// <returns>Objeto que informa sobre el proceso y devuelve un objeto relleno si el proceso es correcto.</returns>
        static private QueryModelResult ParseText(string param_text)
        {
            List<Step> steps = new List<Step>();
            string output = string.Empty;
            bool inside_let = false;

            try
            {
                List<string> lines = param_text.Split('\n')
                    .Select(line => line.Trim())
                    .Where(line => !string.IsNullOrEmpty(line))
                    .ToList();

                foreach (string line in lines)
                {
                    if (line.StartsWith("let"))
                    {
                        inside_let = true;
                        continue;
                    }

                    if (line.StartsWith("in "))
                    {
                        output = line.Substring(2).Trim();
                        break;
                    }

                    if (inside_let)
                    {
                        StepResult result = ParseStep(line);
                        if (!result.Correct || result.StepInfo.Operation == Step.OperationType.None)
                        {
                            return new QueryModelResult(false,
                                "Error procesando el fichero.",
                                result.DeveloperText,
                                null);

                        }

                        if (result.StepInfo != null)
                        {
                            steps.Add(result.StepInfo);
                        }
                    }
                }

                return new QueryModelResult(true,
                    "Análisis correcto.",
                    "El lenguaje M se ha parseado correctamente.",
                    new QueryModel(steps, output));
            }
            catch (Exception ex)
            {
                return new QueryModelResult(false,
                    "Error procesando el fichero.",
                    ex.Message,
                    null);
            }
        }

        /// <summary>
        /// Detecta las ordenes manejables por la aplicación a partir de la expresión de lenguaje M.
        /// </summary>
        /// <param name="param_expression">Expresión a analizar sintácticamente.</param>
        /// <returns></returns>
        static private Step.OperationType DetectOperation(string param_expression)
        {
            if (param_expression.Contains("Table.SelectRows"))
            {
                return Step.OperationType.SelectRows;
            }
            else if (param_expression.Contains("Table.AddColumn"))
            {
                return Step.OperationType.AddColumn;
            }
            else if (param_expression.Contains("Table.RemoveColumns"))
            {
                return Step.OperationType.RemoveColumns;
            }
            else if (param_expression.Contains("Table.SelectColumns"))
            {
                return Step.OperationType.SelectColumns;
            }
            else
            {
                return Step.OperationType.None;
            }
        }

        /// <summary>
        /// Hace el análisis sintáctico de una única orden definida en lenguaje M
        /// </summary>
        /// <remarks>
        /// Este método asume que el lenguaje M está bien formado. Si el formato no es correcto, el resultado puede ser erróneo o nulo.
        /// Además, este método solo extrae los argumentos de las ordenes manejables por la aplicación.
        /// </remarks>
        /// <param name="pram_line">Orden a analizar.</param>
        /// <returns>Si la orden no se reconoce devuelve un mensaje de error, si se reconoce mensaje correcto con objeto Step interno.</returns>
        static private StepResult ParseStep(string pram_line)
        {
            if (!pram_line.Contains("="))
            {
                return new StepResult(false,
                    "Formato incorrecto.",
                    $"La línea '{pram_line}' no contiene '='.",
                    null);
            }

            int index = pram_line.IndexOf('=');

            string name = pram_line.Substring(0, index).Trim();
            string expression = pram_line.Substring(index + 1).Trim().TrimEnd(',');
            string input = ExtractInput(expression);
            Step.OperationType operation = DetectOperation(expression);
            if (operation == Step.OperationType.None)
            {
                return new StepResult(false,
                    "Orden no reconocida.",
                    $"La orden '{expression}' no es reconocida por la aplicación.",
                    null);
            }

            Dictionary<string, string> arguments = ExtractArguments(expression, operation);

            return new StepResult(true,
                "Orden parseada correctamente.",
                $"La orden '{expression}' se ha parseado correctamente.",
                new Step(name, input, operation, arguments));
        }

        /// <summary>
        /// Extrae el input de la expresión de lenguaje M, es decir, el nombre del paso anterior al que se le aplica la orden.
        /// </summary>
        /// <remarks>
        /// Este método asume que el lenguaje M está bien formado. Si el formato no es correcto, el resultado puede ser erróneo o vacío.
        /// </remarks>
        /// <param name="param_expression">Porción de lenguaje M que debería tener el input</param>
        /// <returns>Nombre del paso anterior al que se aplica la orden.</returns>
        static private string ExtractInput(string param_expression)
        {
            int start = param_expression.IndexOf('(');
            int end = param_expression.IndexOf(',');
            if (end == -1)
            {
                end = param_expression.IndexOf(')');
            }

            if (start == -1 || end == -1 || end <= start)
            {
                return string.Empty;
            }

            return param_expression.Substring(start + 1, end - start - 1).Trim();
        }
        #endregion "Metodos privados"
    }
}
