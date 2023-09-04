namespace Std
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.tmoBox = new System.Windows.Forms.GroupBox();
            this.Diff1Button = new System.Windows.Forms.Button();
            this.UnionButton = new System.Windows.Forms.Button();
            this.ClearButton = new System.Windows.Forms.Button();
            this.SelectFigure = new System.Windows.Forms.Button();
            this.transformationBox = new System.Windows.Forms.GroupBox();
            this.kTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SetCenterButton = new System.Windows.Forms.Button();
            this.alfaTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.RcButton = new System.Windows.Forms.Button();
            this.SPcButton = new System.Windows.Forms.Button();
            this.move = new System.Windows.Forms.Button();
            this.SxyfButton = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.DelFigureButton = new System.Windows.Forms.Button();
            this.Str1Button = new System.Windows.Forms.Button();
            this.ER = new System.Windows.Forms.Button();
            this.LineButton = new System.Windows.Forms.Button();
            this.ZvButton = new System.Windows.Forms.Button();
            this.hText = new System.Windows.Forms.Label();
            this.hTextBox = new System.Windows.Forms.TextBox();
            this.labelH2 = new System.Windows.Forms.Label();
            this.textBoxH2 = new System.Windows.Forms.TextBox();
            this.figureBox = new System.Windows.Forms.GroupBox();
            this.tmoBox.SuspendLayout();
            this.transformationBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.figureBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // tmoBox
            // 
            this.tmoBox.Controls.Add(this.Diff1Button);
            this.tmoBox.Controls.Add(this.UnionButton);
            this.tmoBox.Location = new System.Drawing.Point(1203, 672);
            this.tmoBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tmoBox.Name = "tmoBox";
            this.tmoBox.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tmoBox.Size = new System.Drawing.Size(363, 132);
            this.tmoBox.TabIndex = 23;
            this.tmoBox.TabStop = false;
            this.tmoBox.Text = "ТМО";
            // 
            // Diff1Button
            // 
            this.Diff1Button.Location = new System.Drawing.Point(12, 29);
            this.Diff1Button.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Diff1Button.Name = "Diff1Button";
            this.Diff1Button.Size = new System.Drawing.Size(141, 38);
            this.Diff1Button.TabIndex = 6;
            this.Diff1Button.Text = "Разность";
            this.Diff1Button.UseVisualStyleBackColor = true;
            this.Diff1Button.Click += new System.EventHandler(this.diff_Click);
            // 
            // UnionButton
            // 
            this.UnionButton.Location = new System.Drawing.Point(12, 78);
            this.UnionButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.UnionButton.Name = "UnionButton";
            this.UnionButton.Size = new System.Drawing.Size(142, 38);
            this.UnionButton.TabIndex = 9;
            this.UnionButton.Text = "Пересечение";
            this.UnionButton.UseVisualStyleBackColor = true;
            this.UnionButton.Click += new System.EventHandler(this.cross_Click);
            // 
            // ClearButton
            // 
            this.ClearButton.Location = new System.Drawing.Point(1402, 585);
            this.ClearButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(142, 38);
            this.ClearButton.TabIndex = 4;
            this.ClearButton.Text = "Очистка";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearBox_Click);
            // 
            // SelectFigure
            // 
            this.SelectFigure.Location = new System.Drawing.Point(1212, 585);
            this.SelectFigure.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SelectFigure.Name = "SelectFigure";
            this.SelectFigure.Size = new System.Drawing.Size(144, 38);
            this.SelectFigure.TabIndex = 3;
            this.SelectFigure.Text = "Выделить";
            this.SelectFigure.UseVisualStyleBackColor = true;
            this.SelectFigure.Click += new System.EventHandler(this.SelectFigure_Click);
            // 
            // transformationBox
            // 
            this.transformationBox.Controls.Add(this.kTextBox);
            this.transformationBox.Controls.Add(this.label2);
            this.transformationBox.Controls.Add(this.SetCenterButton);
            this.transformationBox.Controls.Add(this.alfaTextBox);
            this.transformationBox.Controls.Add(this.label1);
            this.transformationBox.Controls.Add(this.RcButton);
            this.transformationBox.Controls.Add(this.SPcButton);
            this.transformationBox.Controls.Add(this.move);
            this.transformationBox.Controls.Add(this.SxyfButton);
            this.transformationBox.Location = new System.Drawing.Point(1203, 342);
            this.transformationBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.transformationBox.Name = "transformationBox";
            this.transformationBox.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.transformationBox.Size = new System.Drawing.Size(363, 234);
            this.transformationBox.TabIndex = 17;
            this.transformationBox.TabStop = false;
            this.transformationBox.Text = "Преобразования";
            // 
            // kTextBox
            // 
            this.kTextBox.Location = new System.Drawing.Point(246, 131);
            this.kTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.kTextBox.Name = "kTextBox";
            this.kTextBox.Size = new System.Drawing.Size(94, 26);
            this.kTextBox.TabIndex = 14;
            this.kTextBox.TextChanged += new System.EventHandler(this.ktextBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(212, 135);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 20);
            this.label2.TabIndex = 13;
            this.label2.Text = "k";
            // 
            // SetCenterButton
            // 
            this.SetCenterButton.Location = new System.Drawing.Point(200, 31);
            this.SetCenterButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SetCenterButton.Name = "SetCenterButton";
            this.SetCenterButton.Size = new System.Drawing.Size(142, 35);
            this.SetCenterButton.TabIndex = 12;
            this.SetCenterButton.Text = "Задать центр";
            this.SetCenterButton.UseVisualStyleBackColor = true;
            this.SetCenterButton.Click += new System.EventHandler(this.SetCenterButton_Click);
            // 
            // alfaTextBox
            // 
            this.alfaTextBox.Location = new System.Drawing.Point(246, 82);
            this.alfaTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.alfaTextBox.Name = "alfaTextBox";
            this.alfaTextBox.Size = new System.Drawing.Size(94, 26);
            this.alfaTextBox.TabIndex = 11;
            this.alfaTextBox.TextChanged += new System.EventHandler(this.alfaTextBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(201, 86);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "alfa";
            // 
            // RcButton
            // 
            this.RcButton.Location = new System.Drawing.Point(10, 75);
            this.RcButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.RcButton.Name = "RcButton";
            this.RcButton.Size = new System.Drawing.Size(142, 38);
            this.RcButton.TabIndex = 9;
            this.RcButton.Text = "Rс";
            this.RcButton.UseVisualStyleBackColor = true;
            this.RcButton.Click += new System.EventHandler(this.RfButton_Click);
            // 
            // SPcButton
            // 
            this.SPcButton.Location = new System.Drawing.Point(9, 171);
            this.SPcButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SPcButton.Name = "SPcButton";
            this.SPcButton.Size = new System.Drawing.Size(144, 38);
            this.SPcButton.TabIndex = 8;
            this.SPcButton.Text = "Rс30";
            this.SPcButton.UseVisualStyleBackColor = true;
            this.SPcButton.Click += new System.EventHandler(this.SHButton_Click);
            // 
            // move
            // 
            this.move.Location = new System.Drawing.Point(10, 29);
            this.move.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.move.Name = "move";
            this.move.Size = new System.Drawing.Size(142, 38);
            this.move.TabIndex = 1;
            this.move.Text = "Перемещение";
            this.move.UseVisualStyleBackColor = true;
            this.move.Click += new System.EventHandler(this.MoveButton_Click);
            // 
            // SxyfButton
            // 
            this.SxyfButton.Location = new System.Drawing.Point(10, 125);
            this.SxyfButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SxyfButton.Name = "SxyfButton";
            this.SxyfButton.Size = new System.Drawing.Size(142, 38);
            this.SxyfButton.TabIndex = 2;
            this.SxyfButton.Text = "Sxyf";
            this.SxyfButton.UseVisualStyleBackColor = true;
            this.SxyfButton.Click += new System.EventHandler(this.SxyfButton_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.Color.White;
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox.Location = new System.Drawing.Point(18, 18);
            this.pictureBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(1175, 784);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
            this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
            // 
            // DelFigureButton
            // 
            this.DelFigureButton.Location = new System.Drawing.Point(1212, 631);
            this.DelFigureButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.DelFigureButton.Name = "DelFigureButton";
            this.DelFigureButton.Size = new System.Drawing.Size(144, 35);
            this.DelFigureButton.TabIndex = 24;
            this.DelFigureButton.Text = "Удалить";
            this.DelFigureButton.UseVisualStyleBackColor = true;
            this.DelFigureButton.Click += new System.EventHandler(this.DelFigureButton_Click);
            // 
            // Str1Button
            // 
            this.Str1Button.Location = new System.Drawing.Point(12, 90);
            this.Str1Button.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Str1Button.Name = "Str1Button";
            this.Str1Button.Size = new System.Drawing.Size(178, 45);
            this.Str1Button.TabIndex = 1;
            this.Str1Button.Text = "Угол";
            this.Str1Button.UseVisualStyleBackColor = true;
            this.Str1Button.Click += new System.EventHandler(this.FlagButton_Click);
            // 
            // ER
            // 
            this.ER.Location = new System.Drawing.Point(12, 172);
            this.ER.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ER.Name = "ER";
            this.ER.Size = new System.Drawing.Size(178, 42);
            this.ER.TabIndex = 2;
            this.ER.Text = "Безье";
            this.ER.UseVisualStyleBackColor = true;
            this.ER.Click += new System.EventHandler(this.SplineButton_Click);
            // 
            // LineButton
            // 
            this.LineButton.Location = new System.Drawing.Point(12, 222);
            this.LineButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.LineButton.Name = "LineButton";
            this.LineButton.Size = new System.Drawing.Size(178, 42);
            this.LineButton.TabIndex = 9;
            this.LineButton.Text = "Линия";
            this.LineButton.UseVisualStyleBackColor = true;
            this.LineButton.Click += new System.EventHandler(this.LineButton_Click);
            // 
            // ZvButton
            // 
            this.ZvButton.Location = new System.Drawing.Point(12, 35);
            this.ZvButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ZvButton.Name = "ZvButton";
            this.ZvButton.Size = new System.Drawing.Size(178, 45);
            this.ZvButton.TabIndex = 10;
            this.ZvButton.Text = "Параллелепипед";
            this.ZvButton.UseVisualStyleBackColor = true;
            this.ZvButton.Click += new System.EventHandler(this.TgrButton_Click);
            // 
            // hText
            // 
            this.hText.AutoSize = true;
            this.hText.ForeColor = System.Drawing.SystemColors.ControlText;
            this.hText.Location = new System.Drawing.Point(210, 48);
            this.hText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.hText.Name = "hText";
            this.hText.Size = new System.Drawing.Size(18, 20);
            this.hText.TabIndex = 11;
            this.hText.Text = "h";
            // 
            // hTextBox
            // 
            this.hTextBox.Location = new System.Drawing.Point(245, 48);
            this.hTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.hTextBox.Name = "hTextBox";
            this.hTextBox.Size = new System.Drawing.Size(78, 26);
            this.hTextBox.TabIndex = 13;
            this.hTextBox.TextChanged += new System.EventHandler(this.hTextBox_TextChanged);
            // 
            // labelH2
            // 
            this.labelH2.AutoSize = true;
            this.labelH2.Location = new System.Drawing.Point(210, 90);
            this.labelH2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelH2.Name = "labelH2";
            this.labelH2.Size = new System.Drawing.Size(27, 20);
            this.labelH2.TabIndex = 15;
            this.labelH2.Text = "h2";
            // 
            // textBoxH2
            // 
            this.textBoxH2.Location = new System.Drawing.Point(245, 90);
            this.textBoxH2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxH2.Name = "textBoxH2";
            this.textBoxH2.Size = new System.Drawing.Size(79, 26);
            this.textBoxH2.TabIndex = 16;
            this.textBoxH2.TextChanged += new System.EventHandler(this.textBoxH2_TextChanged);
            // 
            // figureBox
            // 
            this.figureBox.Controls.Add(this.textBoxH2);
            this.figureBox.Controls.Add(this.labelH2);
            this.figureBox.Controls.Add(this.hTextBox);
            this.figureBox.Controls.Add(this.hText);
            this.figureBox.Controls.Add(this.ZvButton);
            this.figureBox.Controls.Add(this.LineButton);
            this.figureBox.Controls.Add(this.ER);
            this.figureBox.Controls.Add(this.Str1Button);
            this.figureBox.Location = new System.Drawing.Point(1204, 18);
            this.figureBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.figureBox.Name = "figureBox";
            this.figureBox.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.figureBox.Size = new System.Drawing.Size(363, 278);
            this.figureBox.TabIndex = 18;
            this.figureBox.TabStop = false;
            this.figureBox.Text = "Фигуры";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(1586, 822);
            this.Controls.Add(this.DelFigureButton);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.SelectFigure);
            this.Controls.Add(this.tmoBox);
            this.Controls.Add(this.transformationBox);
            this.Controls.Add(this.figureBox);
            this.Controls.Add(this.pictureBox);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tmoBox.ResumeLayout(false);
            this.transformationBox.ResumeLayout(false);
            this.transformationBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.figureBox.ResumeLayout(false);
            this.figureBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.GroupBox tmoBox;
        private System.Windows.Forms.Button Diff1Button;
        private System.Windows.Forms.Button UnionButton;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.Button SelectFigure;
        private System.Windows.Forms.GroupBox transformationBox;
        private System.Windows.Forms.Button move;
        private System.Windows.Forms.Button SxyfButton;
        private System.Windows.Forms.Button SPcButton;
        private System.Windows.Forms.Button RcButton;
        private System.Windows.Forms.Button DelFigureButton;
        private System.Windows.Forms.TextBox alfaTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button SetCenterButton;
        private System.Windows.Forms.TextBox kTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Str1Button;
        private System.Windows.Forms.Button ER;
        private System.Windows.Forms.Button LineButton;
        private System.Windows.Forms.Button ZvButton;
        private System.Windows.Forms.Label hText;
        private System.Windows.Forms.TextBox hTextBox;
        private System.Windows.Forms.Label labelH2;
        private System.Windows.Forms.TextBox textBoxH2;
        private System.Windows.Forms.GroupBox figureBox;
    }
}

