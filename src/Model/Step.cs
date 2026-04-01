using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace transformer_generator.src.Model
{
    /// <summary>
    /// Clase que almacena la información sobre cada paso definido en el lenguaje M.
    /// </summary>
    public class Step
    {
        public enum OperationType
        {
            None = 0,       ///<summary>Ninguna operación asignada.</summary>
            SelectRows,
            AddColumn,
            RemoveColumns,
            SelectColumns
        }

        /// <summary>
        /// Nombre de la variable en el lenguaje M (ej: Filtered)
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Paso del que se parte para realizar la operación (ej: Source).
        /// </summary>
        public string Input { get; set; }

        /// <summary>
        /// Operación a realizar.
        /// </summary>
        public OperationType Operation { get; set; }

        /// <summary>
        /// Lista de argumentos asociados a la operación.
        /// </summary>
        public Dictionary<string, string> Arguments { get; set; }

        /// <summary>
        /// Constructor, inicializa atributos a vacío.
        /// </summary>
        [JsonConstructor]
        public Step()
        {
            Name = string.Empty;
            Input = string.Empty;
            Operation = OperationType.None;
            Arguments = new Dictionary<string, string>();
        }

        /// <summary>
        /// Constructor inicializa los atributos.
        /// </summary>
        /// <param name="param_name">Nombre de la variable en el lenguaje M (ej: Filtered).</param>
        /// <param name="param_input">Paso del que se parte para realizar la operación (ej: Source).</param>
        /// <param name="param_operation">Tipo de operación a realizar</param>
        /// <param name="param_arguments">Argumentos asociados a la operación.</param>
        public Step(string param_name, 
            string param_input,
            OperationType param_operation, 
            Dictionary<string, string> param_arguments)
        {
            Name = param_name;
            Input = param_input;
            Operation = param_operation;
            Arguments = param_arguments;
        }
    }
}
