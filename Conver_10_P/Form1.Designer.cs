namespace Work1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            labelNumber = new Label();
            labelBase = new Label();
            textBoxNumber = new TextBox();
            textBoxBase = new TextBox();
            textBoxPrecision = new TextBox();
            buttonConvert = new Button();
            labelResult = new Label();
            label1 = new Label();
            buttonCopy_Click = new Button();
            ToolStripMenuItem = new MenuStrip();
            exitMenuItem_Click = new ToolStripMenuItem();
            historyMenuItem_Click = new ToolStripMenuItem();
            helpMenuItem_Click = new ToolStripMenuItem();
            label2 = new Label();
            ToolStripMenuItem.SuspendLayout();
            SuspendLayout();
            // 
            // labelNumber
            // 
            labelNumber.AutoSize = true;
            labelNumber.Location = new Point(15, 39);
            labelNumber.Name = "labelNumber";
            labelNumber.Size = new Size(186, 15);
            labelNumber.TabIndex = 0;
            labelNumber.Text = "Введите число для конвертации:";
            // 
            // labelBase
            // 
            labelBase.AutoSize = true;
            labelBase.Location = new Point(15, 72);
            labelBase.Name = "labelBase";
            labelBase.Size = new Size(273, 15);
            labelBase.TabIndex = 1;
            labelBase.Text = "Выберите основание системы счисления (2-16):";
            // 
            // textBoxNumber
            // 
            textBoxNumber.Location = new Point(198, 36);
            textBoxNumber.Name = "textBoxNumber";
            textBoxNumber.Size = new Size(116, 23);
            textBoxNumber.TabIndex = 2;
            textBoxNumber.Validating += textBoxNumber_Validating;
            // 
            // textBoxBase
            // 
            textBoxBase.Location = new Point(285, 69);
            textBoxBase.Name = "textBoxBase";
            textBoxBase.Size = new Size(167, 23);
            textBoxBase.TabIndex = 3;
            textBoxBase.Validating += textBoxBase_Validating;
            // 
            // textBoxPrecision
            // 
            textBoxPrecision.Location = new Point(135, 97);
            textBoxPrecision.Name = "textBoxPrecision";
            textBoxPrecision.Size = new Size(109, 23);
            textBoxPrecision.TabIndex = 4;
            // 
            // buttonConvert
            // 
            buttonConvert.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            buttonConvert.Location = new Point(162, 176);
            buttonConvert.Name = "buttonConvert";
            buttonConvert.Size = new Size(152, 50);
            buttonConvert.TabIndex = 5;
            buttonConvert.Text = "Конвертировать";
            buttonConvert.UseVisualStyleBackColor = true;
            buttonConvert.Click += buttonConvert_Click;
            // 
            // labelResult
            // 
            labelResult.AutoSize = true;
            labelResult.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            labelResult.Location = new Point(15, 148);
            labelResult.Name = "labelResult";
            labelResult.Size = new Size(90, 21);
            labelResult.TabIndex = 6;
            labelResult.Text = "Результат:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 100);
            label1.Name = "label1";
            label1.Size = new Size(123, 15);
            label1.TabIndex = 7;
            label1.Text = "Точность результата:";
            // 
            // buttonCopy_Click
            // 
            buttonCopy_Click.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, 204);
            buttonCopy_Click.Location = new Point(162, 229);
            buttonCopy_Click.Name = "buttonCopy_Click";
            buttonCopy_Click.Size = new Size(152, 23);
            buttonCopy_Click.TabIndex = 8;
            buttonCopy_Click.Text = "Копировать результат";
            buttonCopy_Click.UseVisualStyleBackColor = true;
            buttonCopy_Click.Click += buttonCopy_Click_Click;
            // 
            // ToolStripMenuItem
            // 
            ToolStripMenuItem.BackColor = SystemColors.ControlLight;
            ToolStripMenuItem.Items.AddRange(new ToolStripItem[] { exitMenuItem_Click, historyMenuItem_Click, helpMenuItem_Click });
            ToolStripMenuItem.Location = new Point(0, 0);
            ToolStripMenuItem.Name = "ToolStripMenuItem";
            ToolStripMenuItem.Size = new Size(470, 24);
            ToolStripMenuItem.TabIndex = 9;
            ToolStripMenuItem.Text = "menuStrip1";
            // 
            // exitMenuItem_Click
            // 
            exitMenuItem_Click.Name = "exitMenuItem_Click";
            exitMenuItem_Click.Size = new Size(54, 20);
            exitMenuItem_Click.Text = "Выход";
            exitMenuItem_Click.Click += exitMenuItem_Click_Click;
            // 
            // historyMenuItem_Click
            // 
            historyMenuItem_Click.Name = "historyMenuItem_Click";
            historyMenuItem_Click.Size = new Size(66, 20);
            historyMenuItem_Click.Text = "История";
            historyMenuItem_Click.Click += historyMenuItem_Click_Click;
            // 
            // helpMenuItem_Click
            // 
            helpMenuItem_Click.Name = "helpMenuItem_Click";
            helpMenuItem_Click.Size = new Size(65, 20);
            helpMenuItem_Click.Text = "Справка";
            helpMenuItem_Click.Click += helpMenuItem_Click_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 5.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label2.Location = new Point(378, 245);
            label2.Name = "label2";
            label2.Size = new Size(87, 10);
            label2.TabIndex = 10;
            label2.Text = "Версия программы: v.1.0";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonFace;
            ClientSize = new Size(470, 258);
            Controls.Add(label2);
            Controls.Add(buttonCopy_Click);
            Controls.Add(label1);
            Controls.Add(labelBase);
            Controls.Add(labelResult);
            Controls.Add(buttonConvert);
            Controls.Add(textBoxPrecision);
            Controls.Add(textBoxBase);
            Controls.Add(textBoxNumber);
            Controls.Add(labelNumber);
            Controls.Add(ToolStripMenuItem);
            MainMenuStrip = ToolStripMenuItem;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Конвертор Conver_10_P";
            FormClosing += Form1_FormClosing;
            ToolStripMenuItem.ResumeLayout(false);
            ToolStripMenuItem.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        //
        // Элементы на форме
        //
        private Label labelNumber;
        private Label labelBase;
        private TextBox textBoxNumber;
        private TextBox textBoxBase;
        private TextBox textBoxPrecision;
        private Button buttonConvert;
        private Label labelResult;
        private Label label1;
        private Button buttonCopy_Click;
        private MenuStrip ToolStripMenuItem;
        private ToolStripMenuItem exitMenuItem_Click;
        private ToolStripMenuItem historyMenuItem_Click;
        private ToolStripMenuItem helpMenuItem_Click;
        private Label label2;
    }
}
