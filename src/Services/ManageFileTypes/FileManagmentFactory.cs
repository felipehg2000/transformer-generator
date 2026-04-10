using System;

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
        /// <param name="param_file_path">Ruta del fichero.</param>
        /// <returns>Objeto de tipo FileManagement correspondiente a la extensión del fichero.</returns>
        /// <exception cref="ArgumentException">Se lanza cuando el tipo de fichero no es válido.</exception>
        public static FileManagement CreateFileManagement(string param_file_path)
        {
            FileManagement file_management = null;
            string file_extension = System.IO.Path.GetExtension(param_file_path).ToLower();
            switch (file_extension)
            {
                case ".csv":
                    file_management = new CSVFiles(param_file_path);
                    break;
                default:
                    throw new ArgumentException("Invalid file type.");
            }

            return file_management;
        }
    }
}
