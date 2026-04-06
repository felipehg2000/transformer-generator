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
            this.menu = new System.Windows.Forms.MenuStrip();
            this.configuraciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cargarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelMetadata = new System.Windows.Forms.Panel();
            this.panelConfiguration = new System.Windows.Forms.Panel();
            this.panelMainButtons = new System.Windows.Forms.Panel();
            this.buttonNext = new System.Windows.Forms.Button();
            this.panelMPath = new System.Windows.Forms.Panel();
            this.panelTittleMPath = new System.Windows.Forms.Panel();
            this.labelTitleMPath = new System.Windows.Forms.Label();
            this.textBoxMPath = new System.Windows.Forms.TextBox();
            this.buttonMPath = new System.Windows.Forms.Button();
            this.listBoxSteps = new System.Windows.Forms.ListBox();
            this.labelSteps = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxInput = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.labelOutput = new System.Windows.Forms.Label();
            this.dataGridViewArgument = new System.Windows.Forms.DataGridView();
            this.ColumnArgumentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnArgumentInfo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelArgument = new System.Windows.Forms.Label();
            this.menu.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.panelMainButtons.SuspendLayout();
            this.panelMPath.SuspendLayout();
            this.panelTittleMPath.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewArgument)).BeginInit();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configuraciónToolStripMenuItem});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(589, 24);
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
            // 
            // guardarToolStripMenuItem
            // 
            this.guardarToolStripMenuItem.Name = "guardarToolStripMenuItem";
            this.guardarToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.guardarToolStripMenuItem.Text = "Guardar";
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.panelMPath);
            this.panelMain.Controls.Add(this.panelMainButtons);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 24);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(589, 352);
            this.panelMain.TabIndex = 1;
            // 
            // panelMetadata
            // 
            this.panelMetadata.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMetadata.Location = new System.Drawing.Point(0, 24);
            this.panelMetadata.Name = "panelMetadata";
            this.panelMetadata.Size = new System.Drawing.Size(589, 352);
            this.panelMetadata.TabIndex = 2;
            // 
            // panelConfiguration
            // 
            this.panelConfiguration.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelConfiguration.Location = new System.Drawing.Point(0, 24);
            this.panelConfiguration.Name = "panelConfiguration";
            this.panelConfiguration.Size = new System.Drawing.Size(589, 352);
            this.panelConfiguration.TabIndex = 3;
            // 
            // panelMainButtons
            // 
            this.panelMainButtons.Controls.Add(this.buttonNext);
            this.panelMainButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelMainButtons.Location = new System.Drawing.Point(0, 314);
            this.panelMainButtons.Name = "panelMainButtons";
            this.panelMainButtons.Size = new System.Drawing.Size(589, 38);
            this.panelMainButtons.TabIndex = 0;
            // 
            // buttonNext
            // 
            this.buttonNext.Location = new System.Drawing.Point(489, 3);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(75, 23);
            this.buttonNext.TabIndex = 0;
            this.buttonNext.Text = "Siguiente ➡ ";
            this.buttonNext.UseVisualStyleBackColor = true;
            // 
            // panelMPath
            // 
            this.panelMPath.BackColor = System.Drawing.Color.White;
            this.panelMPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
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
            this.panelMPath.Controls.Add(this.panelTittleMPath);
            this.panelMPath.Location = new System.Drawing.Point(31, 20);
            this.panelMPath.Name = "panelMPath";
            this.panelMPath.Size = new System.Drawing.Size(533, 269);
            this.panelMPath.TabIndex = 1;
            // 
            // panelTittleMPath
            // 
            this.panelTittleMPath.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelTittleMPath.Controls.Add(this.labelTitleMPath);
            this.panelTittleMPath.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTittleMPath.Location = new System.Drawing.Point(0, 0);
            this.panelTittleMPath.Name = "panelTittleMPath";
            this.panelTittleMPath.Size = new System.Drawing.Size(531, 35);
            this.panelTittleMPath.TabIndex = 0;
            // 
            // labelTitleMPath
            // 
            this.labelTitleMPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelTitleMPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitleMPath.Location = new System.Drawing.Point(0, 0);
            this.labelTitleMPath.Name = "labelTitleMPath";
            this.labelTitleMPath.Size = new System.Drawing.Size(531, 35);
            this.labelTitleMPath.TabIndex = 0;
            this.labelTitleMPath.Text = "Ruta del Fichero M";
            this.labelTitleMPath.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxMPath
            // 
            this.textBoxMPath.BackColor = System.Drawing.SystemColors.Info;
            this.textBoxMPath.Enabled = false;
            this.textBoxMPath.Location = new System.Drawing.Point(16, 41);
            this.textBoxMPath.Name = "textBoxMPath";
            this.textBoxMPath.Size = new System.Drawing.Size(478, 20);
            this.textBoxMPath.TabIndex = 1;
            // 
            // buttonMPath
            // 
            this.buttonMPath.Location = new System.Drawing.Point(500, 41);
            this.buttonMPath.Name = "buttonMPath";
            this.buttonMPath.Size = new System.Drawing.Size(19, 20);
            this.buttonMPath.TabIndex = 2;
            this.buttonMPath.Text = "🔎";
            this.buttonMPath.UseVisualStyleBackColor = true;
            this.buttonMPath.Click += new System.EventHandler(this.buttonMPath_Click);
            // 
            // listBoxSteps
            // 
            this.listBoxSteps.FormattingEnabled = true;
            this.listBoxSteps.Location = new System.Drawing.Point(16, 90);
            this.listBoxSteps.Name = "listBoxSteps";
            this.listBoxSteps.Size = new System.Drawing.Size(127, 160);
            this.listBoxSteps.TabIndex = 3;
            this.listBoxSteps.SelectedIndexChanged += new System.EventHandler(this.listBoxSteps_SelectedIndexChanged);
            // 
            // labelSteps
            // 
            this.labelSteps.AutoSize = true;
            this.labelSteps.Location = new System.Drawing.Point(13, 74);
            this.labelSteps.Name = "labelSteps";
            this.labelSteps.Size = new System.Drawing.Size(94, 13);
            this.labelSteps.TabIndex = 4;
            this.labelSteps.Text = "Pasos procesados";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(177, 98);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(100, 20);
            this.textBoxName.TabIndex = 5;
            // 
            // textBoxInput
            // 
            this.textBoxInput.Location = new System.Drawing.Point(299, 98);
            this.textBoxInput.Name = "textBoxInput";
            this.textBoxInput.Size = new System.Drawing.Size(100, 20);
            this.textBoxInput.TabIndex = 6;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(174, 82);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(44, 13);
            this.labelName.TabIndex = 7;
            this.labelName.Text = "Nombre";
            // 
            // labelOutput
            // 
            this.labelOutput.AutoSize = true;
            this.labelOutput.Location = new System.Drawing.Point(296, 82);
            this.labelOutput.Name = "labelOutput";
            this.labelOutput.Size = new System.Drawing.Size(36, 13);
            this.labelOutput.TabIndex = 8;
            this.labelOutput.Text = "Salida";
            // 
            // dataGridViewArgument
            // 
            this.dataGridViewArgument.AllowUserToAddRows = false;
            this.dataGridViewArgument.AllowUserToDeleteRows = false;
            this.dataGridViewArgument.AllowUserToResizeColumns = false;
            this.dataGridViewArgument.AllowUserToResizeRows = false;
            this.dataGridViewArgument.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewArgument.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewArgument.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnArgumentName,
            this.ColumnArgumentInfo});
            this.dataGridViewArgument.EnableHeadersVisualStyles = false;
            this.dataGridViewArgument.GridColor = System.Drawing.SystemColors.InactiveCaption;
            this.dataGridViewArgument.Location = new System.Drawing.Point(177, 140);
            this.dataGridViewArgument.MultiSelect = false;
            this.dataGridViewArgument.Name = "dataGridViewArgument";
            this.dataGridViewArgument.ReadOnly = true;
            this.dataGridViewArgument.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridViewArgument.RowHeadersVisible = false;
            this.dataGridViewArgument.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.dataGridViewArgument.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewArgument.Size = new System.Drawing.Size(342, 110);
            this.dataGridViewArgument.TabIndex = 9;
            // 
            // ColumnArgumentName
            // 
            this.ColumnArgumentName.Frozen = true;
            this.ColumnArgumentName.HeaderText = "Argumento";
            this.ColumnArgumentName.Name = "ColumnArgumentName";
            this.ColumnArgumentName.ReadOnly = true;
            // 
            // ColumnArgumentInfo
            // 
            this.ColumnArgumentInfo.Frozen = true;
            this.ColumnArgumentInfo.HeaderText = "Información";
            this.ColumnArgumentInfo.Name = "ColumnArgumentInfo";
            this.ColumnArgumentInfo.ReadOnly = true;
            // 
            // labelArgument
            // 
            this.labelArgument.AutoSize = true;
            this.labelArgument.Location = new System.Drawing.Point(174, 124);
            this.labelArgument.Name = "labelArgument";
            this.labelArgument.Size = new System.Drawing.Size(63, 13);
            this.labelArgument.TabIndex = 10;
            this.labelArgument.Text = "Argumentos";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 376);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelMetadata);
            this.Controls.Add(this.panelConfiguration);
            this.Controls.Add(this.menu);
            this.MainMenuStrip = this.menu;
            this.Name = "MainForm";
            this.Text = "Transformador de código";
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.panelMain.ResumeLayout(false);
            this.panelMainButtons.ResumeLayout(false);
            this.panelMPath.ResumeLayout(false);
            this.panelMPath.PerformLayout();
            this.panelTittleMPath.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewArgument)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem configuraciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cargarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarToolStripMenuItem;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelMetadata;
        private System.Windows.Forms.Panel panelConfiguration;
        private System.Windows.Forms.Panel panelMainButtons;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.Panel panelMPath;
        private System.Windows.Forms.Panel panelTittleMPath;
        private System.Windows.Forms.Label labelTitleMPath;
        private System.Windows.Forms.Button buttonMPath;
        private System.Windows.Forms.TextBox textBoxMPath;
        private System.Windows.Forms.Label labelSteps;
        private System.Windows.Forms.ListBox listBoxSteps;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxInput;
        private System.Windows.Forms.Label labelOutput;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelArgument;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnArgumentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnArgumentInfo;
        private System.Windows.Forms.DataGridView dataGridViewArgument;
    }
}