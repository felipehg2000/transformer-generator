using System;
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

        /// <summary>
        /// Detecta el tipo de dato según los valores leidos de la tabla.
        /// </summary>
        /// <param name="param_values">Valores de una columna</param>
        /// <returns>tipo de dato que muestra la columna</returns>
        protected Column.DataType InferDataType(List<string> param_values)
        {
            bool is_int     = true;
            bool is_double  = true;
            bool is_date    = true;
            bool is_bool    = true;

            foreach (string value in param_values)
            {
                if (string.IsNullOrWhiteSpace(value))
                    continue;

                if (!int.TryParse(value, out _))
                    is_int = false;

                if (!double.TryParse(value, out _))
                    is_double = false;

                if (!DateTime.TryParse(value, out _))
                    is_date = false;

                if (!bool.TryParse(value, out _))
                    is_bool = false;
            }

            if (is_int) 
                return Column.DataType.Number;
            else if (is_double) 
                return Column.DataType.Double;
            else if (is_date) 
                return Column.DataType.Date;
            else if (is_bool) 
                return Column.DataType.Boolean;
            
            return Column.DataType.Text;
        }
    }
}
