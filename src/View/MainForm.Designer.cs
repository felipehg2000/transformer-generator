namespace transformer_generator.src.View
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.configuraciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cargarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelMainButtons = new System.Windows.Forms.Panel();
            this.buttonNext = new System.Windows.Forms.Button();
            this.panelMPath = new System.Windows.Forms.Panel();
            this.labelPathMFile = new System.Windows.Forms.Label();
            this.labelArgument = new System.Windows.Forms.Label();
            this.dataGridViewArgument = new System.Windows.Forms.DataGridView();
            this.ColumnArgumentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnArgumentInfo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelOutput = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.textBoxInput = new System.Windows.Forms.TextBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.labelSteps = new System.Windows.Forms.Label();
            this.listBoxSteps = new System.Windows.Forms.ListBox();
            this.buttonMPath = new System.Windows.Forms.Button();
            this.textBoxMPath = new System.Windows.Forms.TextBox();
            this.panelConfiguration = new System.Windows.Forms.Panel();
            this.panelCenterConfiguration = new System.Windows.Forms.Panel();
            this.textBoxDelimiter = new System.Windows.Forms.TextBox();
            this.labelDelimiterType = new System.Windows.Forms.Label();
            this.buttonViewTable = new System.Windows.Forms.Button();
            this.buttonFindOutputFolderPath = new System.Windows.Forms.Button();
            this.buttonFindInputFilePath = new System.Windows.Forms.Button();
            this.panelOutputFileType = new System.Windows.Forms.Panel();
            this.radioButtonCSharp = new System.Windows.Forms.RadioButton();
            this.radioButtonCpp = new System.Windows.Forms.RadioButton();
            this.labelOutputType = new System.Windows.Forms.Label();
            this.labelFileType = new System.Windows.Forms.Label();
            this.panelInputTypeFile = new System.Windows.Forms.Panel();
            this.radioButtonCSV = new System.Windows.Forms.RadioButton();
            this.textBoxOutputFolderPath = new System.Windows.Forms.TextBox();
            this.labelTablePath = new System.Windows.Forms.Label();
            this.labelEndFolder = new System.Windows.Forms.Label();
            this.textBoxInputFilePath = new System.Windows.Forms.TextBox();
            this.panelButtonsConfiguration = new System.Windows.Forms.Panel();
            this.buttonBackConfiguration = new System.Windows.Forms.Button();
            this.menu.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.panelMainButtons.SuspendLayout();
            this.panelMPath.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewArgument)).BeginInit();
            this.panelConfiguration.SuspendLayout();
            this.panelCenterConfiguration.SuspendLayout();
            this.panelOutputFileType.SuspendLayout();
            this.panelInputTypeFile.SuspendLayout();
            this.panelButtonsConfiguration.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configuraciónToolStripMenuItem});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(709, 24);
            this.menu.TabIndex = 0;
            this.menu.Text = "menuStrip1";
            // 
            // configuraciónToolStripMenuItem
            // 
            this.configuraciónToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cargarToolStripMenuItem,
            this.guardarToolStripMenuItem});
            this.configuraciónToolStripMenuItem.Name = "configuraciónToolStripMenuItem";
            this.configuraciónToolStripMenuItem.Size = new System.Drawing.Size(95, 20);
            this.configuraciónToolStripMenuItem.Text = "Configuración";
            // 
            // cargarToolStripMenuItem
            // 
            this.cargarToolStripMenuItem.Name = "cargarToolStripMenuItem";
            this.cargarToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.cargarToolStripMenuItem.Text = "Cargar";
            this.cargarToolStripMenuItem.Click += new System.EventHandler(this.cargarToolStripMenuItem_Click);
            // 
            // guardarToolStripMenuItem
            // 
            this.guardarToolStripMenuItem.Name = "guardarToolStripMenuItem";
            this.guardarToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.guardarToolStripMenuItem.Text = "Guardar";
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.panelMainButtons);
            this.panelMain.Controls.Add(this.panelMPath);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 24);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(709, 307);
            this.panelMain.TabIndex = 1;
            // 
            // panelMainButtons
            // 
            this.panelMainButtons.BackColor = System.Drawing.Color.White;
            this.panelMainButtons.Controls.Add(this.buttonNext);
            this.panelMainButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelMainButtons.Location = new System.Drawing.Point(0, 269);
            this.panelMainButtons.Name = "panelMainButtons";
            this.panelMainButtons.Size = new System.Drawing.Size(709, 38);
            this.panelMainButtons.TabIndex = 0;
            // 
            // buttonNext
            // 
            this.buttonNext.Location = new System.Drawing.Point(612, 6);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(75, 23);
            this.buttonNext.TabIndex = 0;
            this.buttonNext.Text = "Siguiente ➡ ";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // panelMPath
            // 
            this.panelMPath.BackColor = System.Drawing.Color.White;
            this.panelMPath.Controls.Add(this.labelPathMFile);
            this.panelMPath.Controls.Add(this.labelArgument);
            this.panelMPath.Controls.Add(this.dataGridViewArgument);
            this.panelMPath.Controls.Add(this.labelOutput);
            this.panelMPath.Controls.Add(this.labelName);
            this.panelMPath.Controls.Add(this.textBoxInput);
            this.panelMPath.Controls.Add(this.textBoxName);
            this.panelMPath.Controls.Add(this.labelSteps);
            this.panelMPath.Controls.Add(this.listBoxSteps);
            this.panelMPath.Controls.Add(this.buttonMPath);
            this.panelMPath.Controls.Add(this.textBoxMPath);
            this.panelMPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMPath.Location = new System.Drawing.Point(0, 0);
            this.panelMPath.Name = "panelMPath";
            this.panelMPath.Size = new System.Drawing.Size(709, 307);
            this.panelMPath.TabIndex = 1;
            // 
            // labelPathMFile
            // 
            this.labelPathMFile.AutoSize = true;
            this.labelPathMFile.Location = new System.Drawing.Point(13, 8);
            this.labelPathMFile.Name = "labelPathMFile";
            this.labelPathMFile.Size = new System.Drawing.Size(88, 13);
            this.labelPathMFile.TabIndex = 11;
            this.labelPathMFile.Text = "Ruta al fichero M";
            // 
            // labelArgument
            // 
            this.labelArgument.AutoSize = true;
            this.labelArgument.Location = new System.Drawing.Point(174, 97);
            this.labelArgument.Name = "labelArgument";
            this.labelArgument.Size = new System.Drawing.Size(63, 13);
            this.labelArgument.TabIndex = 10;
            this.labelArgument.Text = "Argumentos";
            // 
            // dataGridViewArgument
            // 
            this.dataGridViewArgument.AllowUserToAddRows = false;
            this.dataGridViewArgument.AllowUserToDeleteRows = false;
            this.dataGridViewArgument.AllowUserToResizeColumns = false;
            this.dataGridViewArgument.AllowUserToResizeRows = false;
            this.dataGridViewArgument.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewArgument.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewArgument.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewArgument.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewArgument.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnArgumentName,
            this.ColumnArgumentInfo});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewArgument.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewArgument.Enabled = false;
            this.dataGridViewArgument.EnableHeadersVisualStyles = false;
            this.dataGridViewArgument.GridColor = System.Drawing.SystemColors.WindowFrame;
            this.dataGridViewArgument.Location = new System.Drawing.Point(177, 113);
            this.dataGridViewArgument.MultiSelect = false;
            this.dataGridViewArgument.Name = "dataGridViewArgument";
            this.dataGridViewArgument.ReadOnly = true;
            this.dataGridViewArgument.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridViewArgument.RowHeadersVisible = false;
            this.dataGridViewArgument.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewArgument.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewArgument.Size = new System.Drawing.Size(510, 149);
            this.dataGridViewArgument.TabIndex = 9;
            // 
            // ColumnArgumentName
            // 
            this.ColumnArgumentName.Frozen = true;
            this.ColumnArgumentName.HeaderText = "Argumento";
            this.ColumnArgumentName.Name = "ColumnArgumentName";
            this.ColumnArgumentName.ReadOnly = true;
            this.ColumnArgumentName.Width = 255;
            // 
            // ColumnArgumentInfo
            // 
            this.ColumnArgumentInfo.Frozen = true;
            this.ColumnArgumentInfo.HeaderText = "Información";
            this.ColumnArgumentInfo.Name = "ColumnArgumentInfo";
            this.ColumnArgumentInfo.ReadOnly = true;
            this.ColumnArgumentInfo.Width = 255;
            // 
            // labelOutput
            // 
            this.labelOutput.AutoSize = true;
            this.labelOutput.Location = new System.Drawing.Point(400, 55);
            this.labelOutput.Name = "labelOutput";
            this.labelOutput.Size = new System.Drawing.Size(36, 13);
            this.labelOutput.TabIndex = 8;
            this.labelOutput.Text = "Salida";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(174, 55);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(44, 13);
            this.labelName.TabIndex = 7;
            this.labelName.Text = "Nombre";
            // 
            // textBoxInput
            // 
            this.textBoxInput.Location = new System.Drawing.Point(403, 71);
            this.textBoxInput.Name = "textBoxInput";
            this.textBoxInput.Size = new System.Drawing.Size(207, 20);
            this.textBoxInput.TabIndex = 6;
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(177, 71);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(207, 20);
            this.textBoxName.TabIndex = 5;
            // 
            // labelSteps
            // 
            this.labelSteps.AutoSize = true;
            this.labelSteps.Location = new System.Drawing.Point(13, 47);
            this.labelSteps.Name = "labelSteps";
            this.labelSteps.Size = new System.Drawing.Size(94, 13);
            this.labelSteps.TabIndex = 4;
            this.labelSteps.Text = "Pasos procesados";
            // 
            // listBoxSteps
            // 
            this.listBoxSteps.FormattingEnabled = true;
            this.listBoxSteps.Location = new System.Drawing.Point(16, 63);
            this.listBoxSteps.Name = "listBoxSteps";
            this.listBoxSteps.Size = new System.Drawing.Size(127, 199);
            this.listBoxSteps.TabIndex = 3;
            this.listBoxSteps.SelectedIndexChanged += new System.EventHandler(this.listBoxSteps_SelectedIndexChanged);
            // 
            // buttonMPath
            // 
            this.buttonMPath.Location = new System.Drawing.Point(667, 23);
            this.buttonMPath.Name = "buttonMPath";
            this.buttonMPath.Size = new System.Drawing.Size(19, 20);
            this.buttonMPath.TabIndex = 2;
            this.buttonMPath.Text = "🔎";
            this.buttonMPath.UseVisualStyleBackColor = true;
            this.buttonMPath.Click += new System.EventHandler(this.buttonMPath_Click);
            // 
            // textBoxMPath
            // 
            this.textBoxMPath.BackColor = System.Drawing.SystemColors.Info;
            this.textBoxMPath.Enabled = false;
            this.textBoxMPath.Location = new System.Drawing.Point(16, 24);
            this.textBoxMPath.Name = "textBoxMPath";
            this.textBoxMPath.Size = new System.Drawing.Size(645, 20);
            this.textBoxMPath.TabIndex = 1;
            // 
            // panelConfiguration
            // 
            this.panelConfiguration.BackColor = System.Drawing.Color.White;
            this.panelConfiguration.Controls.Add(this.panelCenterConfiguration);
            this.panelConfiguration.Controls.Add(this.panelButtonsConfiguration);
            this.panelConfiguration.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelConfiguration.Location = new System.Drawing.Point(0, 24);
            this.panelConfiguration.Name = "panelConfiguration";
            this.panelConfiguration.Size = new System.Drawing.Size(709, 307);
            this.panelConfiguration.TabIndex = 3;
            // 
            // panelCenterConfiguration
            // 
            this.panelCenterConfiguration.Controls.Add(this.textBoxDelimiter);
            this.panelCenterConfiguration.Controls.Add(this.labelDelimiterType);
            this.panelCenterConfiguration.Controls.Add(this.buttonViewTable);
            this.panelCenterConfiguration.Controls.Add(this.buttonFindOutputFolderPath);
            this.panelCenterConfiguration.Controls.Add(this.buttonFindInputFilePath);
            this.panelCenterConfiguration.Controls.Add(this.panelOutputFileType);
            this.panelCenterConfiguration.Controls.Add(this.labelOutputType);
            this.panelCenterConfiguration.Controls.Add(this.labelFileType);
            this.panelCenterConfiguration.Controls.Add(this.panelInputTypeFile);
            this.panelCenterConfiguration.Controls.Add(this.textBoxOutputFolderPath);
            this.panelCenterConfiguration.Controls.Add(this.labelTablePath);
            this.panelCenterConfiguration.Controls.Add(this.labelEndFolder);
            this.panelCenterConfiguration.Controls.Add(this.textBoxInputFilePath);
            this.panelCenterConfiguration.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCenterConfiguration.Location = new System.Drawing.Point(0, 0);
            this.panelCenterConfiguration.Name = "panelCenterConfiguration";
            this.panelCenterConfiguration.Size = new System.Drawing.Size(709, 269);
            this.panelCenterConfiguration.TabIndex = 5;
            // 
            // textBoxDelimiter
            // 
            this.textBoxDelimiter.Location = new System.Drawing.Point(630, 40);
            this.textBoxDelimiter.Name = "textBoxDelimiter";
            this.textBoxDelimiter.Size = new System.Drawing.Size(21, 20);
            this.textBoxDelimiter.TabIndex = 12;
            this.textBoxDelimiter.Text = ",";
            this.textBoxDelimiter.Visible = false;
            // 
            // labelDelimiterType
            // 
            this.labelDelimiterType.AutoSize = true;
            this.labelDelimiterType.Location = new System.Drawing.Point(565, 42);
            this.labelDelimiterType.Name = "labelDelimiterType";
            this.labelDelimiterType.Size = new System.Drawing.Size(59, 13);
            this.labelDelimiterType.TabIndex = 11;
            this.labelDelimiterType.Text = "Delimitador";
            this.labelDelimiterType.Visible = false;
            // 
            // buttonViewTable
            // 
            this.buttonViewTable.Location = new System.Drawing.Point(19, 239);
            this.buttonViewTable.Name = "buttonViewTable";
            this.buttonViewTable.Size = new System.Drawing.Size(102, 23);
            this.buttonViewTable.TabIndex = 10;
            this.buttonViewTable.Text = "Ver tabla 👁";
            this.buttonViewTable.UseVisualStyleBackColor = true;
            this.buttonViewTable.Click += new System.EventHandler(this.buttonConfigureTable_Click);
            // 
            // buttonFindOutputFolderPath
            // 
            this.buttonFindOutputFolderPath.Location = new System.Drawing.Point(657, 146);
            this.buttonFindOutputFolderPath.Name = "buttonFindOutputFolderPath";
            this.buttonFindOutputFolderPath.Size = new System.Drawing.Size(25, 20);
            this.buttonFindOutputFolderPath.TabIndex = 9;
            this.buttonFindOutputFolderPath.Text = "🔎";
            this.buttonFindOutputFolderPath.UseVisualStyleBackColor = true;
            this.buttonFindOutputFolderPath.Click += new System.EventHandler(this.buttonFindOutputFolderPath_Click);
            // 
            // buttonFindInputFilePath
            // 
            this.buttonFindInputFilePath.Location = new System.Drawing.Point(657, 100);
            this.buttonFindInputFilePath.Name = "buttonFindInputFilePath";
            this.buttonFindInputFilePath.Size = new System.Drawing.Size(25, 20);
            this.buttonFindInputFilePath.TabIndex = 8;
            this.buttonFindInputFilePath.Text = "🔎";
            this.buttonFindInputFilePath.UseVisualStyleBackColor = true;
            this.buttonFindInputFilePath.Click += new System.EventHandler(this.buttonFindInputFilePath_Click);
            // 
            // panelOutputFileType
            // 
            this.panelOutputFileType.Controls.Add(this.radioButtonCSharp);
            this.panelOutputFileType.Controls.Add(this.radioButtonCpp);
            this.panelOutputFileType.Location = new System.Drawing.Point(16, 199);
            this.panelOutputFileType.Name = "panelOutputFileType";
            this.panelOutputFileType.Size = new System.Drawing.Size(635, 26);
            this.panelOutputFileType.TabIndex = 7;
            // 
            // radioButtonCSharp
            // 
            this.radioButtonCSharp.AutoSize = true;
            this.radioButtonCSharp.Location = new System.Drawing.Point(66, 3);
            this.radioButtonCSharp.Name = "radioButtonCSharp";
            this.radioButtonCSharp.Size = new System.Drawing.Size(39, 17);
            this.radioButtonCSharp.TabIndex = 1;
            this.radioButtonCSharp.TabStop = true;
            this.radioButtonCSharp.Text = "C#";
            this.radioButtonCSharp.UseVisualStyleBackColor = true;
            // 
            // radioButtonCpp
            // 
            this.radioButtonCpp.AutoSize = true;
            this.radioButtonCpp.Location = new System.Drawing.Point(16, 3);
            this.radioButtonCpp.Name = "radioButtonCpp";
            this.radioButtonCpp.Size = new System.Drawing.Size(44, 17);
            this.radioButtonCpp.TabIndex = 0;
            this.radioButtonCpp.TabStop = true;
            this.radioButtonCpp.Text = "C++";
            this.radioButtonCpp.UseVisualStyleBackColor = true;
            // 
            // labelOutputType
            // 
            this.labelOutputType.AutoSize = true;
            this.labelOutputType.Location = new System.Drawing.Point(16, 183);
            this.labelOutputType.Name = "labelOutputType";
            this.labelOutputType.Size = new System.Drawing.Size(96, 13);
            this.labelOutputType.TabIndex = 6;
            this.labelOutputType.Text = "Lenguaje de salida";
            // 
            // labelFileType
            // 
            this.labelFileType.AutoSize = true;
            this.labelFileType.Location = new System.Drawing.Point(16, 21);
            this.labelFileType.Name = "labelFileType";
            this.labelFileType.Size = new System.Drawing.Size(105, 13);
            this.labelFileType.TabIndex = 5;
            this.labelFileType.Text = "Tipo de fichero leído";
            // 
            // panelInputTypeFile
            // 
            this.panelInputTypeFile.Controls.Add(this.radioButtonCSV);
            this.panelInputTypeFile.Location = new System.Drawing.Point(19, 37);
            this.panelInputTypeFile.Name = "panelInputTypeFile";
            this.panelInputTypeFile.Size = new System.Drawing.Size(505, 25);
            this.panelInputTypeFile.TabIndex = 4;
            // 
            // radioButtonCSV
            // 
            this.radioButtonCSV.AutoSize = true;
            this.radioButtonCSV.Location = new System.Drawing.Point(16, 3);
            this.radioButtonCSV.Name = "radioButtonCSV";
            this.radioButtonCSV.Size = new System.Drawing.Size(84, 17);
            this.radioButtonCSV.TabIndex = 0;
            this.radioButtonCSV.TabStop = true;
            this.radioButtonCSV.Text = "Fichero CSV";
            this.radioButtonCSV.UseVisualStyleBackColor = true;
            this.radioButtonCSV.CheckedChanged += new System.EventHandler(this.radioButtonCSV_CheckedChanged);
            // 
            // textBoxOutputFolderPath
            // 
            this.textBoxOutputFolderPath.BackColor = System.Drawing.SystemColors.Info;
            this.textBoxOutputFolderPath.Enabled = false;
            this.textBoxOutputFolderPath.Location = new System.Drawing.Point(16, 146);
            this.textBoxOutputFolderPath.Name = "textBoxOutputFolderPath";
            this.textBoxOutputFolderPath.Size = new System.Drawing.Size(635, 20);
            this.textBoxOutputFolderPath.TabIndex = 3;
            // 
            // labelTablePath
            // 
            this.labelTablePath.AutoSize = true;
            this.labelTablePath.Location = new System.Drawing.Point(16, 83);
            this.labelTablePath.Name = "labelTablePath";
            this.labelTablePath.Size = new System.Drawing.Size(108, 13);
            this.labelTablePath.TabIndex = 0;
            this.labelTablePath.Text = "Fichero con los datos";
            // 
            // labelEndFolder
            // 
            this.labelEndFolder.AutoSize = true;
            this.labelEndFolder.Location = new System.Drawing.Point(16, 130);
            this.labelEndFolder.Name = "labelEndFolder";
            this.labelEndFolder.Size = new System.Drawing.Size(104, 13);
            this.labelEndFolder.TabIndex = 1;
            this.labelEndFolder.Text = "Directorio de destino";
            // 
            // textBoxInputFilePath
            // 
            this.textBoxInputFilePath.BackColor = System.Drawing.SystemColors.Info;
            this.textBoxInputFilePath.Enabled = false;
            this.textBoxInputFilePath.Location = new System.Drawing.Point(16, 100);
            this.textBoxInputFilePath.Name = "textBoxInputFilePath";
            this.textBoxInputFilePath.Size = new System.Drawing.Size(635, 20);
            this.textBoxInputFilePath.TabIndex = 2;
            // 
            // panelButtonsConfiguration
            // 
            this.panelButtonsConfiguration.Controls.Add(this.buttonBackConfiguration);
            this.panelButtonsConfiguration.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButtonsConfiguration.Location = new System.Drawing.Point(0, 269);
            this.panelButtonsConfiguration.Name = "panelButtonsConfiguration";
            this.panelButtonsConfiguration.Size = new System.Drawing.Size(709, 38);
            this.panelButtonsConfiguration.TabIndex = 4;
            // 
            // buttonBackConfiguration
            // 
            this.buttonBackConfiguration.Location = new System.Drawing.Point(16, 6);
            this.buttonBackConfiguration.Name = "buttonBackConfiguration";
            this.buttonBackConfiguration.Size = new System.Drawing.Size(75, 23);
            this.buttonBackConfiguration.TabIndex = 0;
            this.buttonBackConfiguration.Text = "⬅ Atrás";
            this.buttonBackConfiguration.UseVisualStyleBackColor = true;
            this.buttonBackConfiguration.Click += new System.EventHandler(this.buttonBackConfiguration_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(709, 331);
            this.Controls.Add(this.panelConfiguration);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.menu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MainMenuStrip = this.menu;
            this.Name = "MainForm";
            this.Text = "Transformador de código";
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.panelMain.ResumeLayout(false);
            this.panelMainButtons.ResumeLayout(false);
            this.panelMPath.ResumeLayout(false);
            this.panelMPath.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewArgument)).EndInit();
            this.panelConfiguration.ResumeLayout(false);
            this.panelCenterConfiguration.ResumeLayout(false);
            this.panelCenterConfiguration.PerformLayout();
            this.panelOutputFileType.ResumeLayout(false);
            this.panelOutputFileType.PerformLayout();
            this.panelInputTypeFile.ResumeLayout(false);
            this.panelInputTypeFile.PerformLayout();
            this.panelButtonsConfiguration.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem configuraciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cargarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarToolStripMenuItem;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelConfiguration;
        private System.Windows.Forms.Panel panelMainButtons;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.Panel panelMPath;
        private System.Windows.Forms.Button buttonMPath;
        private System.Windows.Forms.TextBox textBoxMPath;
        private System.Windows.Forms.Label labelSteps;
        private System.Windows.Forms.ListBox listBoxSteps;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxInput;
        private System.Windows.Forms.Label labelOutput;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelArgument;
        private System.Windows.Forms.DataGridView dataGridViewArgument;
        private System.Windows.Forms.Label labelPathMFile;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnArgumentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnArgumentInfo;
        private System.Windows.Forms.Label labelEndFolder;
        private System.Windows.Forms.Label labelTablePath;
        private System.Windows.Forms.Panel panelCenterConfiguration;
        private System.Windows.Forms.TextBox textBoxInputFilePath;
        private System.Windows.Forms.Panel panelButtonsConfiguration;
        private System.Windows.Forms.TextBox textBoxOutputFolderPath;
        private System.Windows.Forms.Button buttonBackConfiguration;
        private System.Windows.Forms.Label labelFileType;
        private System.Windows.Forms.Panel panelInputTypeFile;
        private System.Windows.Forms.RadioButton radioButtonCSV;
        private System.Windows.Forms.Label labelOutputType;
        private System.Windows.Forms.Panel panelOutputFileType;
        private System.Windows.Forms.RadioButton radioButtonCSharp;
        private System.Windows.Forms.RadioButton radioButtonCpp;
        private System.Windows.Forms.Button buttonFindOutputFolderPath;
        private System.Windows.Forms.Button buttonFindInputFilePath;
        private System.Windows.Forms.Button buttonViewTable;
        private System.Windows.Forms.Label labelDelimiterType;
        private System.Windows.Forms.TextBox textBoxDelimiter;
    }
}