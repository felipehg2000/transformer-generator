using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using transformer_generator.src.Controller;
using transformer_generator.src.Model;
using transformer_generator.src.Model.ControllerResult;
using transformer_generator.src.Services.FileExplorer;
using transformer_generator.src.Utils.FileExplorer;
using transformer_generator.src.Utils.Generator;

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
            FillListBoxSteps(_controller.Metadata.QueryModel.Steps);
        }

        /// <summary>
        /// Comprueba si el objeto QueryModel está cargado y si lo está pasa al panel de configuración.
        /// </summary>
        /// <param name="sender">Componente que lanza el evento.</param>
        /// <param name="e">Argumentos asociados al evento.</param>
        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (_controller.Metadata.QueryModel == null)
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
        /// Carga los Metadatos de un fichero JSON y rellena la vista con la información de estos.
        /// </summary>
        /// <param name="sender">Componente que lanza el evento.</param>
        /// <param name="e">Argumentos asociados al evento.</param>
        private void cargarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MetadataResult result = _controller.ReadMetadataFile();
            if (!result.Correct)
            {
                MessageBox.Show(result.UserText,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            textBoxMPath.Text = _controller.Metadata.QueryModel.InputFile;
            textBoxDelimiter.Text = _controller.Metadata.Source.Delimiter;
            textBoxInputFilePath.Text = _controller.Metadata.Source.Path;
            textBoxOutputFolderPath.Text = _controller.Metadata.Configuration.OutputPathCode;
            FillListBoxSteps(_controller.Metadata.QueryModel.Steps);

            if (_controller.Metadata.Source.Type == DataSource.DataSourceType.CSV)
            {
                radioButtonCSV.Checked = true;
            }

            if (_controller.Metadata.Configuration.Type == MainConfiguration.OutputType.CSharp)
            {
                radioButtonCSharp.Checked = true;
            }
            else if (_controller.Metadata.Configuration.Type == MainConfiguration.OutputType.Cpp)
            {
                radioButtonCpp.Checked = true;
            }
        }

        /// <summary>
        /// Guarda los metadatos en un fichero JSON, obteniendo la información de la vista. Muestra un mensaje al usuario según el resultado obtenido.
        /// </summary>
        /// <param name="sender">Componente que lanza el evento.</param>
        /// <param name="e">Argumentos asociados al evento.</param>
        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FillModelWithViewData();
            if (!_controller.WriteMetadataFile())
            {
                MessageBox.Show("Error al guardar el archivo de metadatos.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Archivo de metadatos guardado correctamente.",
                    "Información",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Según la opción seleccionada muestra los datos asociados a la operación.
        /// </summary>
        /// <param name="sender">Componente que lanza el evento.</param>
        /// <param name="e">Argumentos asociados al evento.</param>
        private void listBoxSteps_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxName.Text = _controller.Metadata.QueryModel.Steps[listBoxSteps.SelectedIndex].Name.ToString();
            textBoxInput.Text = _controller.Metadata.QueryModel.Steps[listBoxSteps.SelectedIndex].ToString();

            dataGridViewArgument.Rows.Clear();
            Dictionary<string, string> tmp = _controller.Metadata.QueryModel.Steps[listBoxSteps.SelectedIndex].Arguments;
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
        /// Muestra un formulario donde el usuario puede ver y configurar la tabla que ha leído del archivo de entrada.
        /// </summary>
        /// <param name="sender">Componente que lanza el evento.</param>
        /// <param name="e">Argumentos asociados al evento.</param>
        private void buttonConfigureTable_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxInputFilePath.Text))
            {
                MessageBox.Show("Debe seleccionar un archivo de entrada para configurar la tabla.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            TableInfoForm table_info_form = new TableInfoForm(_controller);
            table_info_form.ShowDialog();
        }

        /// <summary>
        /// Obtiene la ruta a un fichero de tipo CSV, mostrando el explorador de archivos. Lee los datos del fichero.
        /// </summary>
        /// <param name="sender">Componente que lanza el evento.</param>
        /// <param name="e">Argumentos asociados al evento.</param>
        private void buttonFindInputFilePath_Click(object sender, EventArgs e)
        {
            DataSource.DataSourceType file_type = GetFileType();
            if (file_type == DataSource.DataSourceType.None)
            {
                MessageBox.Show("Debe seleccionar el formato del archivo de entrada para continuar.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            string delimiter = null;
            if (radioButtonCSV.Checked) 
            {
                delimiter = textBoxDelimiter.Text;
            }

            Result result = _controller.ReadInputFile(file_type, delimiter);
            if (!result.Correct)
            {
                MessageBox.Show(result.DeveloperText,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            
            textBoxInputFilePath.Text = _controller.Metadata.Source.Path;
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

        /// <summary>
        /// Genera la salida y muestra un mensaje al usuario según el resultado obtenido.
        /// </summary>
        /// <param name="sender">Componente que lanza el evento.</param>
        /// <param name="e">Argumentos asociados al evento.</param>
        private void buttonGenerateOutput_Click(object sender, EventArgs e)
        {
            FillModelWithViewData();
            Result result = _controller.GenerateOutput();
            
            if (!result.Correct)
            {
                MessageBox.Show(result.DeveloperText,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Código generado correctamente.",
                    "Información",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Muestra u oculta el campo de texto para introducir el delimitador.
        /// </summary>
        /// <param name="sender">Componente que lanza el evento.</param>
        /// <param name="e">Argumentos asociados al evento.</param>
        private void radioButtonCSV_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonCSV.Checked)
            {
                textBoxDelimiter.Visible = true;
                labelDelimiterType.Visible = true;
            }
            else
            {
                textBoxDelimiter.Visible = false;
                labelDelimiterType.Visible = false;
            }
        }

        #endregion "Event PanelConfiguration"

        #endregion"Events"

        #region "Private Methods"

        /// <summary>
        /// Según la opción seleccionada por el usuario devuelve un tipo de archivo.
        /// </summary>
        /// <returns>Tipo de archivo manejable por la aplicación.</returns>
        private DataSource.DataSourceType GetFileType()
        {
            if (radioButtonCSV.Checked)
                return DataSource.DataSourceType.CSV;
            if (radioButtonXLSX.Checked)
                return DataSource.DataSourceType.XLSX;

            return DataSource.DataSourceType.None;
        }

        /// <summary>
        /// Rellena el listBox de pasos con los datos obtenidos del archivo de entrada.
        /// </summary>
        /// <param name="param_steps">Lista de pasos a mostrar en el listBox.</param>
        private void FillListBoxSteps(List<Step> param_steps)
        {
            listBoxSteps.Items.Clear();

            foreach (Step step in param_steps)
            {
                listBoxSteps.Items.Add(step.GetOperationTypeText());
            }
        }

        /// <summary>
        /// Rellena los modelos de metadatos con los datos configurables por el usuario en la vista.
        /// </summary>
        private void FillModelWithViewData()
        {
            _controller.Metadata.QueryModel.InputFile = textBoxMPath.Text;
            _controller.Metadata.Source.Delimiter = textBoxDelimiter.Text;
            _controller.Metadata.Source.Path = textBoxInputFilePath.Text;
            _controller.Metadata.Configuration.OutputPathCode = textBoxOutputFolderPath.Text;
            if (radioButtonCSV.Checked)
            {
                _controller.Metadata.Source.Type = DataSource.DataSourceType.CSV;
            }
            else if (radioButtonXLSX.Checked)
            {
                _controller.Metadata.Source.Type = DataSource.DataSourceType.XLSX;
            }

            if (radioButtonCSharp.Checked)
            {
                _controller.Metadata.Configuration.Type = MainConfiguration.OutputType.CSharp;
            }
            else if (radioButtonCpp.Checked)
            {
                _controller.Metadata.Configuration.Type = MainConfiguration.OutputType.Cpp;
            }
        }

        #endregion "Private Methods"
    }
}
