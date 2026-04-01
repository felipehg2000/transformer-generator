using System.Text.Json.Serialization;

namespace transformer_generator.src.Utils.Generator
{
    /// <summary>
    /// Almacena los datos que puede configurar el usuario en la herramienta.
    /// </summary>
    public class MainConfiguration
    {
        /// <summary>
        /// Enumeración con los posibles tipos de salida para el código generado.
        /// </summary>
        public enum OutputType
        {
            None = 0,           ///<summary>Indica que no se generará ningún código.</summary>
            CSharp = 1,         ///<summary>Indica que se generará código en C#.</summary>
            Cpp = 2,            ///<summary>Indica que se generará código en C++.</summary>
        }

        /// <summary>
        /// Tipo de salida que se va a generar.
        /// </summary>
        public OutputType Type { get; set; }

        /// <summary>
        /// Ruta del directorio donde se almacenará la información de salida.
        /// </summary>
        public string OutputPath { get; set; }

        /// <summary>
        /// Nombre del fichero donde se almacenará la información de salida.
        /// </summary>
        public string OutputFileName { get; set; }

        /// <summary>
        /// Constructor, inicializa los atributos a vacío.
        /// </summary>
        [JsonConstructor]
        public MainConfiguration()
        {
            Type = OutputType.None;
            OutputPath = string.Empty;
            OutputFileName = string.Empty;
        }

        /// <summary>
        /// Constructor, inicializa atributos.
        /// </summary>
        /// <param name="param_type">Tipo de salida.</param>
        /// <param name="param_output_path">Ruta del directorio de salida.</param>
        /// <param name="param_output_file_name">Nombre del archivo de salida.</param>
        public MainConfiguration(OutputType param_type,
            string param_output_path, 
            string param_output_file_name)
        {
            Type = param_type;
            OutputPath = param_output_path;
            OutputFileName = param_output_file_name;
        }
    }
}
