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
    /// Clase para consultar la tabla a modificar con el lenguaje M. Permite tipar las columnas.
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

        #region "Attributes"

        /// <summary>
        /// Controlador del formulario main, se utiliza para acceder a la información de las columnas y gestionar la persistencia de manera centralizada.
        /// </summary>
        private MainFormController _controller;

        #endregion "Attributes"

        #region "Constructor"

        /// <summary>
        /// Constructor de la clase, inicializa el formulario y rellena el DataGridView.
        /// </summary>
        /// <param name="param_controller"></param>
        public TableInfoForm(MainFormController param_controller)
        {
            InitializeComponent();
            _controller = param_controller;
            FillTableInfo(_controller.Metadata.Source.Columns);
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
        /// Guarda los tipos de columnas seleccionados por el usuario y cierra el formulario.
        /// </summary>
        /// <param name="sender">Componente que lanza el evento.</param>
        /// <param name="e">Argumentos asociados al evento.</param>
        private void buttonSave_Click(object sender, EventArgs e)
        {
            UpdateColumnTypes(_controller.Metadata.Source.Columns);

            MessageBox.Show("Los tipos de las columnas se han actualizado correctamente.",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

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
            int maxRowCount = param_columns.Max(column => column.Values.Count) + 1;
            grid.Rows.Add(maxRowCount);

            // Agrega ComboBox de tipos de datos en la primera fila
            foreach (DataGridViewColumn grid_column in grid.Columns)
            {
                DataGridViewComboBoxCell combo = new DataGridViewComboBoxCell();
                combo.Items.AddRange(Enum.GetValues(typeof(Column.DataType))
                    .Cast<object>()
                    .ToArray());

                var column = param_columns[grid_column.Index];
                combo.Value = column.Type.ToString();

                grid.Rows[0].Cells[grid_column.Index] = combo;
            }
            grid.Rows[0].DefaultCellStyle.BackColor = Color.LightGray;

            // Agrega los valores de cada columna a la fila correspondiente
            for (int column_index = 0; column_index < param_columns.Count; column_index++)
            {
                var column = param_columns[column_index];
                for (int row_index = 0; row_index < column.Values.Count; row_index++)
                {
                    grid.Rows[row_index + 1].Cells[column_index].Value = column.Values[row_index];
                }
            }
        }

        /// <summary>
        /// Actualiza el tipo de dato de cada columna.
        /// </summary>
        /// <param name="param_columns"></param>
        private void UpdateColumnTypes(List<Column> param_columns)
        {
            for (int column = 0; column < param_columns.Count; column++)
            {
                DataGridViewComboBoxCell cell = dataGridViewTableInfo.Rows[0].Cells[column] as DataGridViewComboBoxCell;
                if (cell?.Value != null)
                {
                    param_columns[column].Type = (Column.DataType)Enum.Parse(typeof(Column.DataType), cell.Value.ToString());
                }
            }
        }

        #endregion "Private Methods"
    }
}
