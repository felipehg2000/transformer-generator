using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using transformer_generator.src.Model;
using transformer_generator.src.Model.ControllerResult;
using transformer_generator.src.Utils.Parsing;

namespace transformer_generator.src.Controller
{
    internal class MainFormController
    {
        #region "Attributes"
        public QueryModel QueryModel { get; set; }

        public Metadata Metadata { get; set; }

        #endregion "Attributes"

        #region "Constructor"

        /// <summary>
        /// Constructor de la clase, inicializa los atributos a vacío.
        /// </summary>
        public MainFormController()
        {
            QueryModel = new QueryModel();
            Metadata = new Metadata();
        }

        #endregion "Constructor"

        #region "Public Methods"

        /// <summary>
        /// Llama al método encargado del análisis sintáctico, si es correcto almacena la información traducida.
        /// </summary>
        /// <param name="param_m_file_path">Ruta al fichero de lenguaje M a procesar.</param>
        /// <returns>Retorna el resultado del proceso de análisis sintáctico.</returns>
        public Result ParserDocument(string param_m_file_path)
        {
            string text = string.Empty;
            try
            {
                text = System.IO.File.ReadAllText(param_m_file_path);
            }
            catch(Exception exception)
            {
                return new Result(false, "Error al leer el archivo de entrada.", exception.Message);
            }

            QueryModelResult result = MParser.Parse(text);
            if (result.Correct)
            {
                QueryModel = result.QueryModelInfo;
            }

            return result;
        }

        #endregion "Public Methods"
    }
}
