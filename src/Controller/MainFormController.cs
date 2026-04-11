using System;
using transformer_generator.src.Model;
using transformer_generator.src.Model.ControllerResult;
using transformer_generator.src.Services.FileExplorer;
using transformer_generator.src.Services.ManageFileTypes;
using transformer_generator.src.Utils.FileExplorer;
using transformer_generator.src.Utils.MetadataDAO;
using transformer_generator.src.Utils.Parsing;

namespace transformer_generator.src.Controller
{
    /// <summary>
    /// Controlador asociado a la vista principal. Gestiona la lógica de negocio relacionada con esta vista.
    /// </summary>
    public class MainFormController
    {
        #region "Attributes"

        /// <summary>
        /// Datos adicionales para la generación de la salida.
        /// </summary>
        public Metadata Metadata { get; set; }

        #endregion "Attributes"

        #region "Constructor"

        /// <summary>
        /// Constructor de la clase, inicializa los atributos a vacío.
        /// </summary>
        public MainFormController()
        {
            Metadata = new Metadata();
        }

        #endregion "Constructor"

        #region "Public Methods"

        /// <summary>
        /// Crea un fichero de metadatos con el timestamp actual y lo almacena en la ruta seleccionada por el usuario.
        /// </summary>
        /// <returns>True si el proceso es correcto, false si no.</returns>
        public bool WriteMetadataFile()
        {
            string path = Folder.GetFolderPath("Seleccionar carpeta para guardar el archivo de metadatos..");
            if (string.IsNullOrEmpty(path))
            {
                return false;
            }

            try
            {
                MetadataDAO.SaveFile(path, Metadata);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

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
            catch (Exception exception)
            {
                return new Result(false, "Error al leer el archivo de entrada.", exception.Message);
            }

            QueryModelResult result = MParser.Parse(text);
            if (result.Correct)
            {
                Metadata.QueryModel.InputFile = param_m_file_path;
                Metadata.QueryModel = result.QueryModelInfo;
            }

            return result;
        }

        /// <summary>
        /// Busca la ruta de un fichero de entrada, lo lee y almacena la información de este.
        /// </summary>
        /// <param name="param_file_type">Tipo de archivo a leer.</param>
        /// <param name="param_delimiter">Delimitador de campos en el archivo. Por defecto nulo porque solo se usa para CSV.</param>
        /// <returns>Resultado de la operación de lectura del archivo.</returns>
        public Result ReadInputFile(DataSource.DataSourceType param_file_type, string param_delimiter = null)
        {
            // Busca ruta del archivo
            string path = Files.GetFilePath("Seleccionar archivo CSV..",
                "Archivos CSV (*.csv)|*.csv|Todos los archivos (*.*)|*.*");
            if (string.IsNullOrEmpty(path))
            {
                return new Result(false,
                    "No se seleccionó ningún archivo.",
                    "No se seleccionó ningún archivo.");
            }

            // Lee el archivo y lo transforma a una lista de Columns
            ColumnsResult ret_result = new ColumnsResult();
            try
            {
                FileManagement fileManagment = FileManagmentFactory.CreateFileManagement(param_file_type, path, param_delimiter);
                ret_result = fileManagment.ReadFile();
            }
            catch (Exception exception)
            {
                return new Result(false,
                    "Error al leer el archivo de entrada.",
                    exception.Message);
            }

            // Carga los datos del archivo en el atributo Metadata.
            Metadata.Source = new DataSource(param_file_type,
                System.IO.Path.GetFileName(path),
                path,
                true,
                param_delimiter,
                ret_result.Columns);

            return ret_result;
        }

        /// <summary>
        /// Lee un fichero de metadatos seleccionado por el usuario. Lo procesa, almacena y muestra al usuairo el resultado del proceso.
        /// </summary>
        /// <returns>Objeto MetadataResult con el resultado del proceso.</returns>
        public MetadataResult ReadMetadataFile()
        {
            // Busca ruta del archivo
            string path = Files.GetFilePath("Seleccionar archivo de metadatos..",
                "Archivos JSON (*.json)|*.json|Todos los archivos (*.*)|*.*");
            if (string.IsNullOrEmpty(path))
            {
                return new MetadataResult(true,
                    "No se ha seleccionado ninguna ruta.",
                    "No se ha seleccionado ninguna ruta.",
                    null);
            }

            Metadata = null;
            try
            {
                Metadata = MetadataDAO.ReadFile(path);
            }
            catch (Exception exception)
            {
                return new MetadataResult(false,
                    "Error al leer el archivo de metadatos.",
                    exception.Message,
                    null);
            }

            return new MetadataResult(true,
                "Archivo de metadatos leído correctamente.",
                "Archivo de metadatos leído correctamente.",
                Metadata);
        }
                
        #endregion "Public Methods"
    }
}
