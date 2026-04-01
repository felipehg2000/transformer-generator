using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace transformer_generator.src.Model
{
    /// <summary>
    /// Clase que almacena todos los pasos a seguir para generar una salida.
    /// </summary>
    public class QueryModel
    {
        /// <summary>
        /// Lista de pasos a seguir para generar la salida.
        /// </summary>
        public List<Step> Steps { get; set; }

        /// <summary>
        /// Variable final del bloque 'in' del lenguaje M
        /// </summary>
        public string Output { get; set; }

        /// <summary>
        /// Constructor, inicializa los atributos a vacío.
        /// </summary>
        [JsonConstructor]
        public QueryModel()
        {
            Steps = new List<Step>();
            Output = string.Empty;
        }

        /// <summary>
        /// Constructor, inicializa atributos.
        /// </summary>
        /// <param name="param_steps">Lista de pasos.</param>
        /// <param name="param_output">Variable final del bloque 'in' del lenguaje M.</param>
        public QueryModel(List<Step> param_steps, 
            string param_output)
        {
            Steps = param_steps;
            Output = param_output;
        }
    }
}
