using System.Text.Json.Serialization;

namespace transformer_generator.src.Model
{
    /// <summary>
    /// Define la estructura de una columna, con su nombre y tipo de dato.
    /// </summary>
    public class Column
    {
        /// <summary>
        /// Enumeración con los posibles tipos de datos que gestiona el generador de código.
        /// </summary>
        public enum DataType
        {
            None = 0,            ///<summary>Valor por defecto, sin tipo definido</summary>
            Text = 1,           ///<summary>Tipo de dato texto</summary>
            Number = 2,         ///<summary>Tipo de dato numérico</summary>
            Double = 3,         ///<summary>Tipo de dato numérico con decimales</summary>
            Date = 4,           ///<summary>Tipo de dato fecha</summary>
            Boolean = 5,        ///<summary>Tipo de dato booleano</summary>
        }

        ///<summary>
        ///Nombre de la columna en lenguaje M
        ///</summary>
        public string Name { get; set; }

        ///<summary>
        ///Tipo de dato en lenguaje M (Text, Number, Date...)
        ///</summary>
        public DataType Type { get; set; }    

        /// <summary>
        /// Constructor, inicializa atributos a vacío.
        /// </summary>
        [JsonConstructor]
        public Column()
        {
            Name = string.Empty;
            Type = DataType.None;
        }

        /// <summary>
        /// Constlructor, inicializa atributos.
        /// </summary>
        /// <param name="param_name">Nombre de la columna.</param>
        /// <param name="param_type">Tipo de dato de la columna.</param>
        public Column(string param_name, 
            DataType param_type)
        {
            Name = param_name;
            Type = param_type;
        }
    }
}
