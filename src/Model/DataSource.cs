using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace transformer_generator.src.Model
{
    /// <summary>
    /// Define la información necesaria para leer y entender una fuente de datos.
    /// </summary>
    public class DataSource
    {
        /// <summary>
        /// Enumeración con los distintos tipos de datos que puede leer el generador de código.
        /// </summary>
        public enum DataSourceType
        {
            None = 0,           ///<summary>Valor por defecto, sin tipo definido.</summary>
            CSV = 1,            ///<summary>Archivo CSV, con delimitador definido.</summary>
            XLSX = 2,           ///<summary>Archivo XLSX.</summary>
        }

        ///<summary>
        ///Tipo de dato en lenguaje M (CSV, JSON, DB...)
        ///</summary>
        public DataSourceType Type { get; set; }

        ///<summary>
        ///Nombre en lenguaje M
        ///</summary>
        public string Name { get; set; }

        ///<summary>
        ///Ruta del origen de datos
        ///</summary>
        public string Path { get; set; }

        ///<summary>
        ///Delimitador para archivos CSV
        ///</summary>
        public string Delimiter { get; set; }

        ///<summary>
        ///Lista de columnas que se van a leer del origen de datos
        ///</summary>
        public List <Column> Columns { get; set; }  

        /// <summary>
        /// Constructor de la clase, inicializa atributos a vacío.
        /// </summary>
        [JsonConstructor]
        public DataSource()
        {
            Type = DataSourceType.None;
            Name = string.Empty;
            Path = string.Empty;
            Delimiter = string.Empty;
            Columns = new List<Column>();
        }

        /// <summary>
        /// Constructor de la clase, inicializa atributos.
        /// </summary>
        /// <param name="type">Tipo de fichero que se va a leer.</param>
        /// <param name="name">Nombre del fichero donde están los datos a leer.</param>
        /// <param name="path">Ruta del origen de los datos.</param>
        /// <param name="delimiter">Delimitador por el que se separan los datos en los textos planos.</param>
        public DataSource(DataSourceType param_type, 
            string param_name, 
            string param_path, 
            string param_delimiter,
            List<Column> param_columns)
        {
            Type = param_type;
            Name = param_name;
            Path = param_path;
            Delimiter = param_delimiter;
            Columns = param_columns;
        }

    }
}
