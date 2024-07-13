namespace TP5
{
    partial class LoginUI
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
            button1 = new Button();
            UserText = new TextBox();
            PasswordText = new TextBox();
            DBBox = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(161, 119);
            button1.Name = "button1";
            button1.Size = new Size(83, 33);
            button1.TabIndex = 0;
            button1.Text = "Ingresar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // UserText
            // 
            UserText.Location = new Point(102, 27);
            UserText.Name = "UserText";
            UserText.Size = new Size(100, 23);
            UserText.TabIndex = 1;
            // 
            // PasswordText
            // 
            PasswordText.Location = new Point(102, 56);
            PasswordText.Name = "PasswordText";
            PasswordText.PasswordChar = '*';
            PasswordText.Size = new Size(100, 23);
            PasswordText.TabIndex = 2;
            // 
            // DBBox
            // 
            DBBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            DBBox.AutoCompleteSource = AutoCompleteSource.ListItems;
            DBBox.FormattingEnabled = true;
            DBBox.Items.AddRange(new object[] { "SA_TP5", "SA_3_AS_2024" });
            DBBox.Location = new Point(102, 85);
            DBBox.Name = "DBBox";
            DBBox.Size = new Size(121, 23);
            DBBox.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(46, 30);
            label1.Name = "label1";
            label1.Size = new Size(50, 15);
            label1.TabIndex = 4;
            label1.Text = "Usuario:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(21, 59);
            label2.Name = "label2";
            label2.Size = new Size(75, 15);
            label2.TabIndex = 5;
            label2.Text = "Constraseña:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 88);
            label3.Name = "label3";
            label3.Size = new Size(84, 15);
            label3.TabIndex = 6;
            label3.Text = "Seleccione BD:";
            // 
            // LoginUI
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(256, 164);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(DBBox);
            Controls.Add(PasswordText);
            Controls.Add(UserText);
            Controls.Add(button1);
            Name = "LoginUI";
            Text = "Iniciar sesión";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private TextBox UserText;
        private TextBox PasswordText;
        private ComboBox DBBox;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}