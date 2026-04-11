using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using transformer_generator.src.Controller;
using transformer_generator.src.Model;

namespace transformer_generator.src.View
{
    /// <summary>
    /// Clase para consultar la tabla a modificar con el lenguaje M.
    /// </summary>
    public partial class TableInfoForm : Form
    {
        #region "Move Form Info"
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HTCAPTION = 0x2;

        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        #endregion "Move Form Info"

        #region "Constructor"

        /// <summary>
        /// Constructor de la clase, inicializa el formulario y rellena el DataGridView.
        /// </summary>
        /// <param name="param_columns">Tabla a mostrar.</param>
        public TableInfoForm(List<Column> param_columns)
        {
            InitializeComponent();
            FillTableInfo(param_columns);
        }

        #endregion "Constructor"

        #region "Events"

        /// <summary>
        /// Cierra el formulario.
        /// </summary>
        /// <param name="sender">Componente que lanza el evento.</param>
        /// <param name="e">Argumentos asociados al evento.</param>
        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Arrastra el formulario al dejar pulsado el botón izquierdo del ratón sobre el título.
        /// </summary>
        /// <param name="sender">Componente que lanza el evento.</param>
        /// <param name="e">Argumentos asociados al evento.</param>
        private void labelTitle_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        #endregion "Events"

        #region "Private Methods"

        /// <summary>
        /// Limpia toda la información que se muestra en el DataGridView.
        /// </summary>
        private void ClearTableInfo()
        {
            dataGridViewTableInfo.Columns.Clear();
            dataGridViewTableInfo.Rows.Clear();
        }

        /// <summary>
        /// Rellena el DataGridView con la información de las columnas pasada por parámetro.
        /// </summary>
        /// <param name="param_columns">Lista de columnas a mostrar en el DataGridView.</param>
        private void FillTableInfo(List<Column> param_columns)
        {
            // Limpia el DataGridView
            ClearTableInfo();

            // Configura el DataGridView
            DataGridView grid = dataGridViewTableInfo;
            grid.AllowUserToAddRows = false;
            grid.RowHeadersVisible = false;

            // Agrega las columnas al DataGridView
            string[] column_names = new string[param_columns.Count];
            foreach (Column column in param_columns)
            { 
                string column_name = "column_" + column.Name.Trim().Replace(" ", "_");
                grid.Columns.Add(column_name, column.Name);
            }

            // Agrega las filas al DataGridView
            int maxRowCount = param_columns.Max(column => column.Values.Count);
            grid.Rows.Add(maxRowCount);

            // Agrega los valores de cada columna a la fila correspondiente
            for (int column_index = 0; column_index < param_columns.Count; column_index++)
            {
                var column = param_columns[column_index];
                for (int row_index = 0; row_index < column.Values.Count; row_index++)
                {
                    grid.Rows[row_index].Cells[column_index].Value = column.Values[row_index];
                }
            }
        }
        #endregion "Private Methods"
    }
}
