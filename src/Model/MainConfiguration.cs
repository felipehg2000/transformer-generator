using System.Text.Json.Serialization;
using transformer_generator.src.Model;

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
        /// Ruta del directorio donde se almacenará el archivo de salida.
        /// </summary>
        public string OutputPathFile { get; set; }

        /// <summary>
        /// Ruta del directorio donde se almacenará el código generado.
        /// </summary>
        public string OutputPathCode { get; set; }

        /// <summary>
        /// Constructor, inicializa los atributos a vacío.
        /// </summary>
        [JsonConstructor]
        public MainConfiguration()
        {
            Type = OutputType.None;
            OutputPathFile = string.Empty;
            OutputPathCode = string.Empty;
        }

        /// <summary>
        /// Constructor, inicializa atributos.
        /// </summary>
        /// <param name="param_type">Tipo de salida que se va a generar.</param>
        /// <param name="param_output_path_file">Ruta del archivo de salida.</param>
        /// <param name="param_output_path_code">Ruta del código de salida.</param>
        /// <param name="param_input_m_lenguage_path">Ruta del archivo de lenguaje de entrada.</param>
        public MainConfiguration(OutputType param_type,
            string param_output_path_file,
            string param_output_path_code,
            string param_input_m_lenguage_path)
        {
            Type = param_type;
            OutputPathFile = param_output_path_file;
            OutputPathCode = param_output_path_code;
        }
    }
}
