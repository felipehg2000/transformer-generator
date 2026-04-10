using System.Collections.Generic;
using transformer_generator.src.Model;
using transformer_generator.src.Model.ControllerResult;

namespace transformer_generator.src.Services.ManageFileTypes
{
    /// <summary>
    /// Clase padre de gestión de fichero, habilita el polimorfismo para el patrón Factory. 
    /// </summary>
    internal abstract class FileManagement
    {
        /// <summary>
        /// Ruta del fichero a gestionar.
        /// </summary>
        protected string _file_path { get; }

        /// <summary>
        /// Constructor de la clase, inicializa la ruta del fichero a gestionar.
        /// </summary>
        /// <param name="param_file_path">Ruta del fichero a gestionar.</param>
        public FileManagement(string param_file_path)
        {
            _file_path = param_file_path;
        }

        /// <summary>
        /// Función virtual de lectura de ficheros que los hijos deberán implementar.
        /// </summary>
        /// <param name="param_columns">Listado de objetos de tipo Column que representan una tabla.</param>
        /// <returns>True si el proceso ha sido correcto, false si no.</returns>
        public abstract bool WriteFile(List<Column> param_columns);

        /// <summary>
        /// Función virtual de escritura de ficheros que los hijos deberán implementar.
        /// </summary>
        /// <returns>Objeto que identifica si el proceso ha sido correcto o no, devuelve información sobre el proceso y un listado de objetos Column que representan la tabla leída.</returns>
        public abstract ColumnsResult ReadFile();
    }
}
