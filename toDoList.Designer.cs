namespace toDoList
{
    partial class toDoList
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.inserting = new System.Windows.Forms.Button();
            this.exit = new System.Windows.Forms.Button();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.delete = new System.Windows.Forms.Button();
            this.showAllToDosButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(123, 102);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(519, 20);
            this.textBox1.TabIndex = 0;
            //this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(120, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "ToDos Hinzufügen";
            // 
            // inserting
            // 
            this.inserting.Location = new System.Drawing.Point(675, 99);
            this.inserting.Name = "inserting";
            this.inserting.Size = new System.Drawing.Size(75, 23);
            this.inserting.TabIndex = 2;
            this.inserting.Text = "Hinzufügen";
            this.inserting.UseVisualStyleBackColor = true;
            this.inserting.Click += new System.EventHandler(this.inserting_Click);
            // 
            // exit
            // 
            this.exit.Location = new System.Drawing.Point(675, 398);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(75, 23);
            this.exit.TabIndex = 4;
            this.exit.Text = "Beenden";
            this.exit.UseVisualStyleBackColor = true;
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(123, 137);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(519, 259);
            this.checkedListBox1.TabIndex = 5;
            this.checkedListBox1.SelectedIndexChanged += new System.EventHandler(this.checkedListBox1_SelectedIndexChanged);
            // 
            // delete
            // 
            this.delete.Location = new System.Drawing.Point(675, 352);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(75, 23);
            this.delete.TabIndex = 6;
            this.delete.Text = "Löschen";
            this.delete.UseVisualStyleBackColor = true;
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // showAllToDosButton
            // 
            this.showAllToDosButton.Location = new System.Drawing.Point(675, 137);
            this.showAllToDosButton.Name = "showAllToDosButton";
            this.showAllToDosButton.Size = new System.Drawing.Size(75, 45);
            this.showAllToDosButton.TabIndex = 7;
            this.showAllToDosButton.Text = "Alle ToDos Anzeigen";
            this.showAllToDosButton.UseVisualStyleBackColor = true;
            this.showAllToDosButton.Click += new System.EventHandler(this.showAllToDosButton_Click);
            // 
            // toDoList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.showAllToDosButton);
            this.Controls.Add(this.delete);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.exit);
            this.Controls.Add(this.inserting);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Name = "toDoList";
            this.Text = "ToDoListe";
            this.Load += new System.EventHandler(this.toDoList_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button inserting;
        private System.Windows.Forms.Button exit;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Button delete;
        private System.Windows.Forms.Button showAllToDosButton;
    }
}

