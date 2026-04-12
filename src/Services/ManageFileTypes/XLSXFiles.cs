using System;
using OfficeOpenXml;
using System.Collections.Generic;
using System.IO;
using transformer_generator.src.Model;
using transformer_generator.src.Model.ControllerResult;

namespace transformer_generator.src.Services.ManageFileTypes
{
    /// <summary>
    /// Gestiona la lectura y escritura de ficheros XLSX. Utiliza listas de objetos Column.
    /// </summary>
    /// <remarks>
    /// No se prevee el uso de la escritura, se deja sin implementar ese método.
    /// </remarks>
    internal class XLSXFiles : FileManagement
    {
        #region "Constructors"

        /// <summary>
        /// Constructor de la clase, inicializa la ruta del fichero XLSX a gestionarl.
        /// </summary>
        /// <param name="param_file_path"></param>
        public XLSXFiles(string param_file_path) : base(param_file_path)
        {

        }

        #endregion "Constructors"

        #region "Virtual methods"

        /// <summary>
        /// No se prevee su uso en la herramienta, no se implementa.
        /// </summary>¡
        /// <exception cref="NotImplementedException">Excepción de método no implementado, por si se intenta utilizar.</exception>
        public override bool WriteFile(List<Column> param_columns)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Lee los datos de un fichero XMLSX y crea un listado de objetos de tipo Column con los datos de la tabla leída
        /// </summary>
        /// <remarks>
        /// Se ha instalado el paquete EPPlus de NuGet para la lectura de estos ficheros. 
        /// </remarks>
        /// <returns>Objeto de tipo ColumnsResult con un listado de objetos Column e información del proceso.</returns>
        public override ColumnsResult ReadFile()
        {
            if (!File.Exists(_file_path))
            {
                return new ColumnsResult(false,
                    "El fichero no existe.",
                    $"Ruta no encontrada: {_file_path}",
                    null);
            }

            ColumnsResult result = new ColumnsResult();
            try
            {
                ExcelPackage.License.SetNonCommercialPersonal("Test");

                using (var package = new ExcelPackage(new FileInfo(_file_path)))
                {
                    var worksheet = package.Workbook.Worksheets[0];

                    if (worksheet.Dimension == null)
                    {
                        return new ColumnsResult(false,
                            "El fichero está vacío.",
                            "Worksheet sin dimensiones.",
                            null);
                    }

                    int row_count = worksheet.Dimension.Rows;
                    int col_count = worksheet.Dimension.Columns;

                    List<Column> columns = new List<Column>();

                    // Crea las columnas por la cabecera
                    for (int column = 1; column <= col_count; column++)
                    {
                        string column_name = worksheet.Cells[1, column].Text;

                        columns.Add(new Column(string.IsNullOrEmpty(column_name) ? $"Column{column}" : column_name,
                            Column.DataType.None,
                            new List<string>()));
                    }

                    // Lee los valores de cada columna
                    for (int row = 2; row <= row_count; row++)
                    {
                        for (int column = 1; column <= col_count; column++)
                        {
                            string value = worksheet.Cells[row, column].Text;
                            columns[column - 1].Values.Add(value);
                        }
                    }

                    // Predice los tipos de datos
                    foreach (var column in columns)
                    {
                        column.Type = InferDataType(column.Values);
                    }

                    return new ColumnsResult(true,
                        "Lectura correcta.",
                        string.Empty,
                        columns);
                }
            }
            catch (Exception ex)
            {
                return new ColumnsResult(false,
                    "Error al leer el fichero.",
                    ex.Message,
                    null);
            }
        }

        #endregion "Virtual methods"
    }
}
