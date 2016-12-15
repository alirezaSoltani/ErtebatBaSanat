namespace FarsiCalendarComponent
{
    partial class FarsiDatePicker
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FarsiDatePicker));
            this.defaultErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.defaultMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.DropButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.defaultErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // defaultErrorProvider
            // 
            this.defaultErrorProvider.ContainerControl = this;
            resources.ApplyResources(this.defaultErrorProvider, "defaultErrorProvider");
            // 
            // defaultMaskedTextBox
            // 
            this.defaultMaskedTextBox.AccessibleDescription = null;
            this.defaultMaskedTextBox.AccessibleName = null;
            resources.ApplyResources(this.defaultMaskedTextBox, "defaultMaskedTextBox");
            this.defaultMaskedTextBox.BackgroundImage = null;
            this.defaultErrorProvider.SetError(this.defaultMaskedTextBox, resources.GetString("defaultMaskedTextBox.Error"));
            this.defaultMaskedTextBox.Font = null;
            this.defaultErrorProvider.SetIconAlignment(this.defaultMaskedTextBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("defaultMaskedTextBox.IconAlignment"))));
            this.defaultErrorProvider.SetIconPadding(this.defaultMaskedTextBox, ((int)(resources.GetObject("defaultMaskedTextBox.IconPadding"))));
            this.defaultMaskedTextBox.Name = "defaultMaskedTextBox";
            this.defaultMaskedTextBox.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.defaultMaskedTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.defaultMaskedTextBox_KeyDown);
            this.defaultMaskedTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.maskedTextBox1_KeyPress);
            // 
            // DropButton
            // 
            this.DropButton.AccessibleDescription = null;
            this.DropButton.AccessibleName = null;
            resources.ApplyResources(this.DropButton, "DropButton");
            this.DropButton.BackgroundImage = null;
            this.defaultErrorProvider.SetError(this.DropButton, resources.GetString("DropButton.Error"));
            this.DropButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.DropButton.Font = null;
            this.defaultErrorProvider.SetIconAlignment(this.DropButton, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("DropButton.IconAlignment"))));
            this.defaultErrorProvider.SetIconPadding(this.DropButton, ((int)(resources.GetObject("DropButton.IconPadding"))));
            this.DropButton.Name = "DropButton";
            this.DropButton.UseVisualStyleBackColor = true;
            this.DropButton.Click += new System.EventHandler(this.DropButton_Click);
            // 
            // FarsiDatePicker
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add(this.DropButton);
            this.Controls.Add(this.defaultMaskedTextBox);
            this.defaultErrorProvider.SetError(this, resources.GetString("$this.Error"));
            this.Font = null;
            this.defaultErrorProvider.SetIconAlignment(this, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("$this.IconAlignment"))));
            this.defaultErrorProvider.SetIconPadding(this, ((int)(resources.GetObject("$this.IconPadding"))));
            this.MaximumSize = new System.Drawing.Size(1000, 21);
            this.Name = "FarsiDatePicker";
            this.Load += new System.EventHandler(this.FarsiDatePicker_Load);
            this.Resize += new System.EventHandler(this.FarsiDatePicker_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.defaultErrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ErrorProvider defaultErrorProvider;
        private System.Windows.Forms.MaskedTextBox defaultMaskedTextBox;
        private System.Windows.Forms.Button DropButton;



    }
}
