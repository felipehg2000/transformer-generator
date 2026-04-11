using System;
using transformer_generator.src.Model;

namespace transformer_generator.src.Services.ManageFileTypes
{
    /// <summary>
    /// Clase Factory para la gestión de diferentes tipos de ficheros. Crea objetos de tipo FileManagement según la extensión de los ficheros.
    /// </summary>
    internal class FileManagmentFactory
    {
        /// <summary>
        /// Método factoría. Crea el tipo de objeto según la extensión del fichero.
        /// </summary>
        /// <param name="param_file_type">Tipo de fichero a gestionar.</param>
        /// <param name="param_file_path">Ruta del fichero.</param>
        /// <param name="param_delimiter">Delimitador de campos en el archivo. Por defecto nulo porque solo se usa para CSV.</param>
        /// <returns>Objeto de tipo FileManagement correspondiente a la extensión del fichero.</returns>
        /// <exception cref="ArgumentException">Se lanza cuando el tipo de fichero no es válido.</exception>
        public static FileManagement CreateFileManagement(DataSource.DataSourceType param_file_type, string param_file_path, string param_delimiter = null)
        {
            FileManagement file_management = null;
            switch (param_file_type)
            {
                case DataSource.DataSourceType.CSV:
                    file_management = new CSVFiles(param_file_path, param_delimiter);
                    break;
                default:
                    throw new ArgumentException("Invalid file type.");
            }

            return file_management;
        }
    }
}
