using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using transformer_generator.src.Controller;
using transformer_generator.src.Model;
using transformer_generator.src.Services.FileExplorer;
using transformer_generator.src.Utils.FileExplorer;

namespace transformer_generator.src.View
{
    /// <summary>
    /// Formulario principal de la aplicación.
    /// </summary>
    public partial class MainForm : Form
    {
        #region "Attributes"

        /// <summary>
        /// Controlador asociado a la vista, encargado de gestionar la lógica de negocio.
        /// </summary>
        private MainFormController _controller;

        #endregion "Attributes"

        #region "Enumerations"

        /// <summary>
        /// Enumeración que representa la tabla de argumentos del panel main.
        /// </summary>
        enum ColumnsDataGridView
        {
            Argument = 0,           ///<summary>Columna que representa el nombre del argumento.</summary>
            Information = 1         ///<summary>Columna que representa los parámeros del argumento.</summary>
        }

        #endregion "Enumerations"

        #region "Constructor"

        /// <summary>
        /// Constructor de la clase, inicializa los componentes y prepara la vista.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            _controller = new MainFormController();

            int ancho_data_grid = dataGridViewArgument.Width - SystemInformation.VerticalScrollBarWidth;
            dataGridViewArgument.Columns[(int)ColumnsDataGridView.Argument].Width = (int)(ancho_data_grid * 0.5);
            dataGridViewArgument.Columns[(int)ColumnsDataGridView.Information].Width = (int)(ancho_data_grid * 0.5);

            panelMain.Visible = true;
            panelMain.Enabled = true;
            panelMain.BringToFront();

            panelConfiguration.Visible = false;
            panelConfiguration.Enabled = false;
            panelConfiguration.SendToBack();
        }

        #endregion "Constructor"

        #region "Events"

        #region "Event PanelMain"

        /// <summary>
        /// Abre el explorador de archivos y selecciona la ruta del archivo de entrada.
        /// Llama a método del controlador y muestra la respuesta según el resultado obtenido.
        /// </summary>
        /// <param name="sender">Componente que lanza el evento.</param>
        /// <param name="e">Argumentos asociados al evento.</param>
        private void buttonMPath_Click(object sender, EventArgs e)
        {
            string path = Files.GetFilePath("Seleccionar archivo M.",
                "Archivos TXT (*.txt)|*.txt|Todos los archivos (*.*)|*.*");
            if (string.IsNullOrEmpty(path))
                return;

            Result result = _controller.ParserDocument(path);
            if (!result.Correct)
            {
                MessageBox.Show(result.DeveloperText, 
                    "Error", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
                return;
            }
            
            textBoxMPath.Text = path;
            listBoxSteps.Items.Clear();
            foreach (Step step in _controller.QueryModel.Steps)
                listBoxSteps.Items.Add(step.GetOperationTypeText());
        }

        /// <summary>
        /// Comprueba si el objeto QueryModel está cargado y si lo está pasa al panel de configuración.
        /// </summary>
        /// <param name="sender">Componente que lanza el evento.</param>
        /// <param name="e">Argumentos asociados al evento.</param>
        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (_controller.QueryModel == null)
            {
                MessageBox.Show("Debe seleccionar un archivo de entrada para continuar.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            panelMain.Visible = false;
            panelMain.Enabled = false;
            panelMain.SendToBack();

            panelConfiguration.Visible = true;
            panelConfiguration.Enabled = true;
            panelConfiguration.BringToFront();
        }

        /// <summary>
        /// Según la opción seleccionada muestra los datos asociados a la operación.
        /// </summary>
        /// <param name="sender">Componente que lanza el evento.</param>
        /// <param name="e">Argumentos asociados al evento.</param>
        private void listBoxSteps_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxName.Text = _controller.QueryModel.Steps[listBoxSteps.SelectedIndex].Name.ToString();
            textBoxInput.Text = _controller.QueryModel.Steps[listBoxSteps.SelectedIndex].Input.ToString();

            dataGridViewArgument.Rows.Clear();
            Dictionary<string, string> tmp = _controller.QueryModel.Steps[listBoxSteps.SelectedIndex].Arguments;
            foreach (KeyValuePair<string, string> argument in tmp)
            {
                dataGridViewArgument.Rows.Add(argument.Key, argument.Value);
            }
        }

        #endregion "Event PanelMain"

        #region "Event PanelConfiguration"

        /// <summary>
        /// Muestra la pantalla anterior, la principal y oculta la pantalla de configuración.
        /// </summary>
        /// <param name="sender">Componente que lanza el evento.</param>
        /// <param name="e">Argumentos asociados al evento.</param>
        private void buttonBackConfiguration_Click(object sender, EventArgs e)
        {
            panelConfiguration.Visible = false;
            panelConfiguration.Enabled = false;
            panelConfiguration.SendToBack();

            panelMain.Visible = true;
            panelMain.Enabled = true;
            panelMain.BringToFront();
        }

        /// <summary>
        /// Obtiene la ruta a un fichero de tipo CSV, mostrando el explorador de archivos. Lee los datos del fichero.
        /// </summary>
        /// <param name="sender">Componente que lanza el evento.</param>
        /// <param name="e">Argumentos asociados al evento.</param>
        private void buttonFindInputFilePath_Click(object sender, EventArgs e)
        {
            if (!radioButtonCSV.Checked)
            {
                MessageBox.Show("Debe seleccionar el formato del archivo de entrada para continuar.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            string path = Files.GetFilePath("Seleccionar archivo CSV..",
                "Archivos CSV (*.csv)|*.csv|Todos los archivos (*.*)|*.*");
            if (string.IsNullOrEmpty(path))
                return;

            throw new NotImplementedException();
            //_controller.ReadDocument(path);

            textBoxInputFilePath.Text = path;
        }

        /// <summary>
        /// Obtiene la dirección a un directorio, y la muestra en un campo de texto.
        /// </summary>
        /// <param name="sender">Componente que lanza el evento.</param>
        /// <param name="e">Argumentos asociados al evento.</param>
        private void buttonFindOutputFolderPath_Click(object sender, EventArgs e)
        {
            string path = Folder.GetFolderPath("Seleccionar carpeta de salida..");
            if (string.IsNullOrEmpty(path))
                return;

            textBoxOutputFolderPath.Text = path;
        }

        #endregion "Event PanelConfiguration"

        #endregion"Events"

        #region "Private Methods"

        #endregion "Private Methods"
    }
}
