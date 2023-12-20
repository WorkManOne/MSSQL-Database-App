namespace RecipeDBApp
{
    partial class searchCategoryViews
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
            this.dataGridSearch = new System.Windows.Forms.DataGridView();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridSearch
            // 
            this.dataGridSearch.AllowUserToAddRows = false;
            this.dataGridSearch.AllowUserToDeleteRows = false;
            this.dataGridSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridSearch.Location = new System.Drawing.Point(12, 90);
            this.dataGridSearch.Name = "dataGridSearch";
            this.dataGridSearch.ReadOnly = true;
            this.dataGridSearch.RowHeadersWidth = 82;
            this.dataGridSearch.RowTemplate.Height = 33;
            this.dataGridSearch.Size = new System.Drawing.Size(862, 505);
            this.dataGridSearch.TabIndex = 0;
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxSearch.Location = new System.Drawing.Point(434, 27);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(440, 44);
            this.textBoxSearch.TabIndex = 1;
            this.textBoxSearch.TextChanged += new System.EventHandler(this.textBoxSearch_TextChanged);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblSearch.Location = new System.Drawing.Point(12, 29);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(114, 37);
            this.lblSearch.TabIndex = 2;
            this.lblSearch.Text = "Поиск:";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "id",
            "name",
            "howMuch"});
            this.comboBox1.Location = new System.Drawing.Point(132, 27);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(279, 39);
            this.comboBox1.TabIndex = 3;
            // 
            // searchCategoryViews
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 607);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.dataGridSearch);
            this.Name = "searchCategoryViews";
            this.Text = "searchCategoryViews";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.searchCategoryViews_FormClosed);
            this.Load += new System.EventHandler(this.searchCategoryViews_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridSearch)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridSearch;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}