using System;
using System.Collections.Generic;
using transformer_generator.src.Model;
using transformer_generator.src.Model.ControllerResult;
using transformer_generator.src.Utils.FileExplorer;

namespace transformer_generator.src.Services.ManageFileTypes
{
    /// <summary>
    /// Gestiona la lectura y escritura de ficheros CSV. Utiliza listas de objetos Column.
    /// </summary>
    internal class CSVFiles : FileManagement
    {
        #region "Attributes"

        /// <summary>
        /// Delimitador de campos del fichero CSV.
        /// </summary>
        private string _delimiter;

        #endregion "Attributes"

        #region "Constructors"

        /// <summary>
        /// Constructor de la clase, inicializa la ruta del fichero CSV a gestionar.
        /// </summary>
        /// <param name="param_file_path">Ruta del fichero CSV a gestionar.</param>
        /// <param name="param_delimiter">Delimitador de campos en el archivo. Por defecto nulo porque solo se usa para CSV.</param>
        public CSVFiles(string param_file_path, string param_delimiter) : base(param_file_path)
        {
            _delimiter = param_delimiter;
        }

        #endregion "Constructors"

        #region "Virtual methods"

        /// <summary>
        /// Formatea el listado de objetos de tipo Column a un formato CSV y lo escribe en un fichero de destino.
        /// </summary>
        /// <param name="param_columns">Listado de columnas a escribir en el fichero CSV.</param>
        /// <returns>True si el fichero se ha escrito correctamente, false en caso contrario.</returns>
        public override bool WriteFile(List<Column> param_columns)
        {
            if (param_columns == null || param_columns.Count == 0)
            {
                return false;
            }

            try
            {
                List<string> lines = new List<string>();
                string header_line = string.Join(_delimiter, param_columns.ConvertAll(column => column.Name));
                lines.Add(header_line);
                for (int row = 0; row < param_columns[0].Values.Count; row++)
                {
                    List<string> values = new List<string>();
                    foreach (Column column in param_columns)
                    {
                        string value = row < column.Values.Count ? column.Values[row] : string.Empty;
                        values.Add(value);
                    }
                    string line = string.Join(_delimiter, values);
                    lines.Add(line);
                }
                Files.WriteFileLines(_file_path, lines.ToArray());
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Lee la información de un fichero CSV y devuelve un listado de objetos Column.
        /// </summary>
        /// <returns>Listado de objetos de tipo column con la tabla que representa el CSV.</returns>
        public override ColumnsResult ReadFile()
        {
            if (string.IsNullOrEmpty(_file_path) || string.IsNullOrEmpty(_delimiter))
            {
                return new ColumnsResult(false,
                    "No se ha podido leer el fichero.",
                    "Los datos de entrada (delimitador o ruta del archivo) son nulos o vacíos.",
                    null);
            }

            List<Column> columns = new List<Column>();
            try
            {
                string[] lines = Files.ReadFileLines(_file_path);
                columns = ReadHeaders(lines);
                columns = ReadValues(columns, lines);
            }
            catch (Exception exception)
            {
                return new ColumnsResult(false,
                    "No se ha podido leer el fichero CSV.",
                    exception.Message,
                    null);
            }

            foreach (Column column in columns)
            {
                column.Type = InferDataType(column.Values);
            }

            return new ColumnsResult(true, 
                "Fichero CSV leído correctamente.", 
                null, 
                columns);
        }

        #endregion "Virtual methods"

        #region "Private methods"

        /// <summary>
        /// Lee la primera línea del fichero CSV y crea un listado de columnas.
        /// </summary>
        /// <param name="param_lines">Lineas que conforman el fichero</param>
        /// <returns>Listado de columnas con el nombre de cada una relleno.</returns>
        private List<Column> ReadHeaders(string[] param_lines)
        {
            List<Column> ret_columns = new List<Column>();
            string[] headers = param_lines[0].Split(_delimiter.ToCharArray());

            foreach (string header in headers)
            {
                Column column = new Column();
                column.Name = header;
                ret_columns.Add(column);
            }

            return ret_columns;
        }

        /// <summary>
        /// Lee los valores de un fichero csv.
        /// </summary>
        /// <param name="param_columns">Listado de columnas con los nombres de cada columna rellenos.</param>
        /// <param name="param_lines">Filas del fichero CSV.</param>
        /// <returns>Listado de columnas con los valores de cada una de las columnas rellenos.</returns>
        /// <exception cref="Exception">No se han leído previamente las cabeceras de las columnas.</exception>
        private List<Column> ReadValues(List<Column> param_columns, string[] param_lines)
        {
            if (param_lines.Length < 2)
            {
                return param_columns;
            }

            if (param_columns == null || param_columns.Count == 0)
            {
                throw new Exception("No se han generado las columnas del fichero antes de leer los valores de este.");
            }

            for (int row = 1; row < param_lines.Length; row++)
            {
                string[] values = param_lines[row].Split(_delimiter.ToCharArray());

                for (int column = 0; column < param_columns.Count; column++)
                {
                    string value = column < values.Length ? values[column] : string.Empty;
                    param_columns[column].Values.Add(value);
                }
            }

            return param_columns;
        }
        
        #endregion "Private methods"
    }
}
