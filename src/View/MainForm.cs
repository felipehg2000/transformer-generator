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
using transformer_generator.src.Utils.FileExplorer;

namespace transformer_generator.src.View
{
    public partial class MainForm : Form
    {
        #region "Attributes"

        /// <summary>
        /// Controlador asociado a la vista, encargado de gestionar la lógica de negocio.
        /// </summary>
        private MainFormController _controller;

        #endregion "Attributes"

        #region "Constructor"
        public MainForm()
        {
            InitializeComponent();
            _controller = new MainFormController();

            panelMain.Visible = true;
            panelMain.Enabled = true;
            panelMain.BringToFront();
        }

        #endregion "Constructor"

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

        #endregion "Event PanelMain"

        #region "Private Methods"

        #endregion "Private Methods"

        private void listBoxSteps_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxName .Text = _controller.QueryModel.Steps[listBoxSteps.SelectedIndex].Name.ToString();
            textBoxInput.Text = _controller.QueryModel.Steps[listBoxSteps.SelectedIndex].Input.ToString();

            dataGridViewArgument.Rows.Clear();
            Dictionary<string, string> tmp = _controller.QueryModel.Steps[listBoxSteps.SelectedIndex].Arguments;
            foreach (KeyValuePair<string, string> argument in tmp)
            {
                dataGridViewArgument.Rows.Add(argument.Key, argument.Value);
            }
        }
    }
}
