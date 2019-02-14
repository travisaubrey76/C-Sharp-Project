namespace SortOMatic
{
    partial class Form_Menu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Menu));
            this.GenerateIntegers = new System.Windows.Forms.Button();
            this.GenerateDoubles = new System.Windows.Forms.Button();
            this.BeginSortingButton = new System.Windows.Forms.Button();
            this.menuTitle = new System.Windows.Forms.Label();
            this.OrderingComboBox = new System.Windows.Forms.ComboBox();
            this.AlgorithmSelectComboBox = new System.Windows.Forms.ComboBox();
            this.sortingLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // GenerateIntegers
            // 
            this.GenerateIntegers.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GenerateIntegers.Location = new System.Drawing.Point(12, 62);
            this.GenerateIntegers.Name = "GenerateIntegers";
            this.GenerateIntegers.Size = new System.Drawing.Size(220, 40);
            this.GenerateIntegers.TabIndex = 1;
            this.GenerateIntegers.Text = "Integer Generation";
            this.GenerateIntegers.UseVisualStyleBackColor = true;
            this.GenerateIntegers.Click += new System.EventHandler(this.GenerateIntegers_Click);
            // 
            // GenerateDoubles
            // 
            this.GenerateDoubles.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GenerateDoubles.Location = new System.Drawing.Point(12, 108);
            this.GenerateDoubles.Name = "GenerateDoubles";
            this.GenerateDoubles.Size = new System.Drawing.Size(220, 40);
            this.GenerateDoubles.TabIndex = 2;
            this.GenerateDoubles.Text = "Double Generation";
            this.GenerateDoubles.UseVisualStyleBackColor = true;
            this.GenerateDoubles.Click += new System.EventHandler(this.GenerateDoubles_Click);
            // 
            // BeginSortingButton
            // 
            this.BeginSortingButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BeginSortingButton.Location = new System.Drawing.Point(12, 209);
            this.BeginSortingButton.Name = "BeginSortingButton";
            this.BeginSortingButton.Size = new System.Drawing.Size(220, 40);
            this.BeginSortingButton.TabIndex = 4;
            this.BeginSortingButton.Text = "Sort";
            this.BeginSortingButton.UseVisualStyleBackColor = true;
            this.BeginSortingButton.Click += new System.EventHandler(this.BeginSortingButton_Click);
            // 
            // menuTitle
            // 
            this.menuTitle.AutoSize = true;
            this.menuTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuTitle.Location = new System.Drawing.Point(65, 9);
            this.menuTitle.Name = "menuTitle";
            this.menuTitle.Size = new System.Drawing.Size(118, 20);
            this.menuTitle.TabIndex = 5;
            this.menuTitle.Text = "Sort-O-Matic";
            // 
            // OrderingComboBox
            // 
            this.OrderingComboBox.BackColor = System.Drawing.SystemColors.Window;
            this.OrderingComboBox.ForeColor = System.Drawing.SystemColors.WindowText;
            this.OrderingComboBox.FormattingEnabled = true;
            this.OrderingComboBox.Items.AddRange(new object[] {
            "Random",
            "Ascending",
            "Descending"});
            this.OrderingComboBox.Location = new System.Drawing.Point(12, 35);
            this.OrderingComboBox.Name = "OrderingComboBox";
            this.OrderingComboBox.Size = new System.Drawing.Size(220, 21);
            this.OrderingComboBox.TabIndex = 0;
            this.OrderingComboBox.Text = "Random";
            this.OrderingComboBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OrderingComboBox_KeyPress);
            // 
            // AlgorithmSelectComboBox
            // 
            this.AlgorithmSelectComboBox.BackColor = System.Drawing.SystemColors.Window;
            this.AlgorithmSelectComboBox.ForeColor = System.Drawing.SystemColors.WindowText;
            this.AlgorithmSelectComboBox.FormattingEnabled = true;
            this.AlgorithmSelectComboBox.Items.AddRange(new object[] {
            "Insertion",
            "Quick",
            "Merge",
            "Selection",
            "Shell"});
            this.AlgorithmSelectComboBox.Location = new System.Drawing.Point(13, 182);
            this.AlgorithmSelectComboBox.Name = "AlgorithmSelectComboBox";
            this.AlgorithmSelectComboBox.Size = new System.Drawing.Size(219, 21);
            this.AlgorithmSelectComboBox.TabIndex = 3;
            this.AlgorithmSelectComboBox.Text = "Insertion";
            this.AlgorithmSelectComboBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AlgorithmSelectComboBox_KeyPress);
            // 
            // sortingLabel
            // 
            this.sortingLabel.AutoSize = true;
            this.sortingLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sortingLabel.Location = new System.Drawing.Point(75, 164);
            this.sortingLabel.Name = "sortingLabel";
            this.sortingLabel.Size = new System.Drawing.Size(99, 15);
            this.sortingLabel.TabIndex = 7;
            this.sortingLabel.Text = "Algorithm Select:";
            // 
            // Form_Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(244, 261);
            this.Controls.Add(this.sortingLabel);
            this.Controls.Add(this.AlgorithmSelectComboBox);
            this.Controls.Add(this.OrderingComboBox);
            this.Controls.Add(this.menuTitle);
            this.Controls.Add(this.BeginSortingButton);
            this.Controls.Add(this.GenerateDoubles);
            this.Controls.Add(this.GenerateIntegers);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form_Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sort-O-Matic";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button GenerateIntegers;
        private System.Windows.Forms.Button GenerateDoubles;
        private System.Windows.Forms.Button BeginSortingButton;
        private System.Windows.Forms.Label menuTitle;
        private System.Windows.Forms.ComboBox OrderingComboBox;
        private System.Windows.Forms.ComboBox AlgorithmSelectComboBox;
        private System.Windows.Forms.Label sortingLabel;
    }
}

