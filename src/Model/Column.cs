using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace transformer_generator.src.Model
{
    /// <summary>
    /// Define la estructura de una columna, con su nombre y tipo de dato.
    /// </summary>
    public class Column
    {
        ///<summary>
        ///Nombre de la columna en lenguaje M
        ///</summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Valores que tiene la columna.
        /// </summary>
        public List<string> Values { get; set; }

        /// <summary>
        /// Constructor, inicializa atributos a vacío.
        /// </summary>
        [JsonConstructor]
        public Column()
        {
            Name = string.Empty;
            Values = new List<string>();
        }

        /// <summary>
        /// Constlructor, inicializa atributos.
        /// </summary>
        /// <param name="param_name">Nombre de la columna.</param>
        /// <param name="param_values">Valores que tiene la columna.</param>
        public Column(string param_name, 
            List<string> param_values)
        {
            Name = param_name;
            Values = param_values;
        }
    }
}
