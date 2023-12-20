namespace RecipeDBApp
{
    partial class AddRecipe
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
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.lblName = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.dataGridUser = new System.Windows.Forms.DataGridView();
            this.dataGridGroup = new System.Windows.Forms.DataGridView();
            this.dataGridCountry = new System.Windows.Forms.DataGridView();
            this.dataGridConv = new System.Windows.Forms.DataGridView();
            this.dataGridSeason = new System.Windows.Forms.DataGridView();
            this.dataGridProducts = new System.Windows.Forms.DataGridView();
            this.textBoxUser = new System.Windows.Forms.TextBox();
            this.textBoxCountry = new System.Windows.Forms.TextBox();
            this.textBoxSeason = new System.Windows.Forms.TextBox();
            this.textBoxConv = new System.Windows.Forms.TextBox();
            this.textBoxGroup = new System.Windows.Forms.TextBox();
            this.textBoxDescr = new System.Windows.Forms.TextBox();
            this.comboBoxUser = new System.Windows.Forms.ComboBox();
            this.comboBoxCountry = new System.Windows.Forms.ComboBox();
            this.comboBoxSeason = new System.Windows.Forms.ComboBox();
            this.comboBoxGroup = new System.Windows.Forms.ComboBox();
            this.comboBoxConv = new System.Windows.Forms.ComboBox();
            this.btnAddProduct = new System.Windows.Forms.Button();
            this.btnDelProduct = new System.Windows.Forms.Button();
            this.dataGridProductsOnly = new System.Windows.Forms.DataGridView();
            this.textBoxAmount = new System.Windows.Forms.TextBox();
            this.lblAmount = new System.Windows.Forms.Label();
            this.btnUpdAmount = new System.Windows.Forms.Button();
            this.comboBoxProductsOnly = new System.Windows.Forms.ComboBox();
            this.textBoxProductsOnly = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCountry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridConv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridSeason)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridProductsOnly)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(462, 1360);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(160, 49);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.monthCalendar1);
            this.groupBox1.Controls.Add(this.lblName);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Location = new System.Drawing.Point(13, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1060, 428);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Создание:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(693, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(355, 46);
            this.label1.TabIndex = 25;
            this.label1.Text = "Дата публикации:";
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(717, 98);
            this.monthCalendar1.MaxSelectionCount = 1;
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 24;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblName.Location = new System.Drawing.Point(13, 29);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(370, 46);
            this.lblName.TabIndex = 3;
            this.lblName.Text = "Название рецепта:";
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox2.Location = new System.Drawing.Point(21, 98);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(546, 59);
            this.textBox2.TabIndex = 2;
            // 
            // dataGridUser
            // 
            this.dataGridUser.AllowUserToAddRows = false;
            this.dataGridUser.AllowUserToDeleteRows = false;
            this.dataGridUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridUser.Location = new System.Drawing.Point(1091, 68);
            this.dataGridUser.Name = "dataGridUser";
            this.dataGridUser.ReadOnly = true;
            this.dataGridUser.RowHeadersWidth = 82;
            this.dataGridUser.RowTemplate.Height = 33;
            this.dataGridUser.Size = new System.Drawing.Size(352, 212);
            this.dataGridUser.TabIndex = 7;
            this.dataGridUser.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridUser_CellContentClick);
            // 
            // dataGridGroup
            // 
            this.dataGridGroup.AllowUserToAddRows = false;
            this.dataGridGroup.AllowUserToDeleteRows = false;
            this.dataGridGroup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridGroup.Location = new System.Drawing.Point(2007, 68);
            this.dataGridGroup.Name = "dataGridGroup";
            this.dataGridGroup.ReadOnly = true;
            this.dataGridGroup.RowHeadersWidth = 82;
            this.dataGridGroup.RowTemplate.Height = 33;
            this.dataGridGroup.Size = new System.Drawing.Size(545, 212);
            this.dataGridGroup.TabIndex = 8;
            // 
            // dataGridCountry
            // 
            this.dataGridCountry.AllowUserToAddRows = false;
            this.dataGridCountry.AllowUserToDeleteRows = false;
            this.dataGridCountry.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridCountry.Location = new System.Drawing.Point(1449, 68);
            this.dataGridCountry.Name = "dataGridCountry";
            this.dataGridCountry.ReadOnly = true;
            this.dataGridCountry.RowHeadersWidth = 82;
            this.dataGridCountry.RowTemplate.Height = 33;
            this.dataGridCountry.Size = new System.Drawing.Size(552, 212);
            this.dataGridCountry.TabIndex = 9;
            // 
            // dataGridConv
            // 
            this.dataGridConv.AllowUserToAddRows = false;
            this.dataGridConv.AllowUserToDeleteRows = false;
            this.dataGridConv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridConv.Location = new System.Drawing.Point(1091, 333);
            this.dataGridConv.Name = "dataGridConv";
            this.dataGridConv.ReadOnly = true;
            this.dataGridConv.RowHeadersWidth = 82;
            this.dataGridConv.RowTemplate.Height = 33;
            this.dataGridConv.Size = new System.Drawing.Size(697, 225);
            this.dataGridConv.TabIndex = 10;
            // 
            // dataGridSeason
            // 
            this.dataGridSeason.AllowUserToAddRows = false;
            this.dataGridSeason.AllowUserToDeleteRows = false;
            this.dataGridSeason.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridSeason.Location = new System.Drawing.Point(1794, 333);
            this.dataGridSeason.Name = "dataGridSeason";
            this.dataGridSeason.ReadOnly = true;
            this.dataGridSeason.RowHeadersWidth = 82;
            this.dataGridSeason.RowTemplate.Height = 33;
            this.dataGridSeason.Size = new System.Drawing.Size(758, 225);
            this.dataGridSeason.TabIndex = 11;
            // 
            // dataGridProducts
            // 
            this.dataGridProducts.AllowUserToAddRows = false;
            this.dataGridProducts.AllowUserToDeleteRows = false;
            this.dataGridProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridProducts.Location = new System.Drawing.Point(1091, 564);
            this.dataGridProducts.Name = "dataGridProducts";
            this.dataGridProducts.ReadOnly = true;
            this.dataGridProducts.RowHeadersWidth = 82;
            this.dataGridProducts.RowTemplate.Height = 33;
            this.dataGridProducts.Size = new System.Drawing.Size(1461, 358);
            this.dataGridProducts.TabIndex = 12;
            // 
            // textBoxUser
            // 
            this.textBoxUser.Location = new System.Drawing.Point(1218, 21);
            this.textBoxUser.Name = "textBoxUser";
            this.textBoxUser.Size = new System.Drawing.Size(225, 31);
            this.textBoxUser.TabIndex = 13;
            this.textBoxUser.TextChanged += new System.EventHandler(this.textBoxUser_TextChanged);
            // 
            // textBoxCountry
            // 
            this.textBoxCountry.Location = new System.Drawing.Point(1597, 21);
            this.textBoxCountry.Name = "textBoxCountry";
            this.textBoxCountry.Size = new System.Drawing.Size(404, 31);
            this.textBoxCountry.TabIndex = 14;
            this.textBoxCountry.TextChanged += new System.EventHandler(this.textBoxCountry_TextChanged);
            // 
            // textBoxSeason
            // 
            this.textBoxSeason.Location = new System.Drawing.Point(1921, 286);
            this.textBoxSeason.Name = "textBoxSeason";
            this.textBoxSeason.Size = new System.Drawing.Size(631, 31);
            this.textBoxSeason.TabIndex = 15;
            this.textBoxSeason.TextChanged += new System.EventHandler(this.textBoxSeason_TextChanged);
            // 
            // textBoxConv
            // 
            this.textBoxConv.Location = new System.Drawing.Point(1218, 288);
            this.textBoxConv.Name = "textBoxConv";
            this.textBoxConv.Size = new System.Drawing.Size(570, 31);
            this.textBoxConv.TabIndex = 17;
            this.textBoxConv.TextChanged += new System.EventHandler(this.textBoxConv_TextChanged);
            // 
            // textBoxGroup
            // 
            this.textBoxGroup.Location = new System.Drawing.Point(2134, 19);
            this.textBoxGroup.Name = "textBoxGroup";
            this.textBoxGroup.Size = new System.Drawing.Size(418, 31);
            this.textBoxGroup.TabIndex = 16;
            this.textBoxGroup.TextChanged += new System.EventHandler(this.textBoxGroup_TextChanged);
            // 
            // textBoxDescr
            // 
            this.textBoxDescr.Location = new System.Drawing.Point(13, 446);
            this.textBoxDescr.Multiline = true;
            this.textBoxDescr.Name = "textBoxDescr";
            this.textBoxDescr.Size = new System.Drawing.Size(1060, 908);
            this.textBoxDescr.TabIndex = 18;
            // 
            // comboBoxUser
            // 
            this.comboBoxUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxUser.FormattingEnabled = true;
            this.comboBoxUser.Items.AddRange(new object[] {
            "id",
            "name"});
            this.comboBoxUser.Location = new System.Drawing.Point(1091, 21);
            this.comboBoxUser.Name = "comboBoxUser";
            this.comboBoxUser.Size = new System.Drawing.Size(121, 33);
            this.comboBoxUser.TabIndex = 19;
            // 
            // comboBoxCountry
            // 
            this.comboBoxCountry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCountry.FormattingEnabled = true;
            this.comboBoxCountry.Items.AddRange(new object[] {
            "id",
            "name",
            "primaryNation"});
            this.comboBoxCountry.Location = new System.Drawing.Point(1449, 21);
            this.comboBoxCountry.Name = "comboBoxCountry";
            this.comboBoxCountry.Size = new System.Drawing.Size(142, 33);
            this.comboBoxCountry.TabIndex = 20;
            // 
            // comboBoxSeason
            // 
            this.comboBoxSeason.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSeason.FormattingEnabled = true;
            this.comboBoxSeason.Items.AddRange(new object[] {
            "id",
            "name",
            "dateStart",
            "dateEnd"});
            this.comboBoxSeason.Location = new System.Drawing.Point(1794, 286);
            this.comboBoxSeason.Name = "comboBoxSeason";
            this.comboBoxSeason.Size = new System.Drawing.Size(121, 33);
            this.comboBoxSeason.TabIndex = 21;
            // 
            // comboBoxGroup
            // 
            this.comboBoxGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxGroup.FormattingEnabled = true;
            this.comboBoxGroup.Items.AddRange(new object[] {
            "id",
            "name",
            "priority"});
            this.comboBoxGroup.Location = new System.Drawing.Point(2007, 19);
            this.comboBoxGroup.Name = "comboBoxGroup";
            this.comboBoxGroup.Size = new System.Drawing.Size(121, 33);
            this.comboBoxGroup.TabIndex = 22;
            // 
            // comboBoxConv
            // 
            this.comboBoxConv.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxConv.FormattingEnabled = true;
            this.comboBoxConv.Items.AddRange(new object[] {
            "id",
            "valMain",
            "valOther"});
            this.comboBoxConv.Location = new System.Drawing.Point(1091, 288);
            this.comboBoxConv.Name = "comboBoxConv";
            this.comboBoxConv.Size = new System.Drawing.Size(121, 33);
            this.comboBoxConv.TabIndex = 23;
            // 
            // btnAddProduct
            // 
            this.btnAddProduct.Location = new System.Drawing.Point(2134, 1037);
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.Size = new System.Drawing.Size(281, 71);
            this.btnAddProduct.TabIndex = 24;
            this.btnAddProduct.Text = "Добавить продукт";
            this.btnAddProduct.UseVisualStyleBackColor = true;
            this.btnAddProduct.Click += new System.EventHandler(this.btnAddProduct_Click);
            // 
            // btnDelProduct
            // 
            this.btnDelProduct.Location = new System.Drawing.Point(2134, 1191);
            this.btnDelProduct.Name = "btnDelProduct";
            this.btnDelProduct.Size = new System.Drawing.Size(281, 71);
            this.btnDelProduct.TabIndex = 25;
            this.btnDelProduct.Text = "Удалить продукт";
            this.btnDelProduct.UseVisualStyleBackColor = true;
            this.btnDelProduct.Click += new System.EventHandler(this.btnDelProduct_Click);
            // 
            // dataGridProductsOnly
            // 
            this.dataGridProductsOnly.AllowUserToAddRows = false;
            this.dataGridProductsOnly.AllowUserToDeleteRows = false;
            this.dataGridProductsOnly.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridProductsOnly.Location = new System.Drawing.Point(1091, 987);
            this.dataGridProductsOnly.Name = "dataGridProductsOnly";
            this.dataGridProductsOnly.ReadOnly = true;
            this.dataGridProductsOnly.RowHeadersWidth = 82;
            this.dataGridProductsOnly.RowTemplate.Height = 33;
            this.dataGridProductsOnly.Size = new System.Drawing.Size(910, 422);
            this.dataGridProductsOnly.TabIndex = 26;
            // 
            // textBoxAmount
            // 
            this.textBoxAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxAmount.Location = new System.Drawing.Point(2007, 987);
            this.textBoxAmount.Name = "textBoxAmount";
            this.textBoxAmount.Size = new System.Drawing.Size(545, 44);
            this.textBoxAmount.TabIndex = 27;
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblAmount.Location = new System.Drawing.Point(2039, 932);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(488, 37);
            this.lblAmount.TabIndex = 28;
            this.lblAmount.Text = "Количество продукта в граммах:";
            // 
            // btnUpdAmount
            // 
            this.btnUpdAmount.Location = new System.Drawing.Point(2134, 1114);
            this.btnUpdAmount.Name = "btnUpdAmount";
            this.btnUpdAmount.Size = new System.Drawing.Size(281, 71);
            this.btnUpdAmount.TabIndex = 29;
            this.btnUpdAmount.Text = "Изменить количество продукта";
            this.btnUpdAmount.UseVisualStyleBackColor = true;
            this.btnUpdAmount.Click += new System.EventHandler(this.btnUpdAmount_Click);
            // 
            // comboBoxProductsOnly
            // 
            this.comboBoxProductsOnly.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxProductsOnly.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxProductsOnly.FormattingEnabled = true;
            this.comboBoxProductsOnly.Items.AddRange(new object[] {
            "id",
            "name",
            "caloriesForHundred",
            "costForHundred"});
            this.comboBoxProductsOnly.Location = new System.Drawing.Point(1091, 936);
            this.comboBoxProductsOnly.Name = "comboBoxProductsOnly";
            this.comboBoxProductsOnly.Size = new System.Drawing.Size(121, 41);
            this.comboBoxProductsOnly.TabIndex = 31;
            // 
            // textBoxProductsOnly
            // 
            this.textBoxProductsOnly.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxProductsOnly.Location = new System.Drawing.Point(1218, 936);
            this.textBoxProductsOnly.Name = "textBoxProductsOnly";
            this.textBoxProductsOnly.Size = new System.Drawing.Size(783, 41);
            this.textBoxProductsOnly.TabIndex = 30;
            this.textBoxProductsOnly.TextChanged += new System.EventHandler(this.textBoxProductsOnly_TextChanged);
            // 
            // AddRecipe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2564, 1421);
            this.Controls.Add(this.comboBoxProductsOnly);
            this.Controls.Add(this.textBoxProductsOnly);
            this.Controls.Add(this.btnUpdAmount);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.textBoxAmount);
            this.Controls.Add(this.dataGridProductsOnly);
            this.Controls.Add(this.btnDelProduct);
            this.Controls.Add(this.btnAddProduct);
            this.Controls.Add(this.comboBoxConv);
            this.Controls.Add(this.comboBoxGroup);
            this.Controls.Add(this.comboBoxSeason);
            this.Controls.Add(this.comboBoxCountry);
            this.Controls.Add(this.comboBoxUser);
            this.Controls.Add(this.textBoxDescr);
            this.Controls.Add(this.textBoxConv);
            this.Controls.Add(this.textBoxGroup);
            this.Controls.Add(this.textBoxSeason);
            this.Controls.Add(this.textBoxCountry);
            this.Controls.Add(this.textBoxUser);
            this.Controls.Add(this.dataGridProducts);
            this.Controls.Add(this.dataGridSeason);
            this.Controls.Add(this.dataGridConv);
            this.Controls.Add(this.dataGridCountry);
            this.Controls.Add(this.dataGridGroup);
            this.Controls.Add(this.dataGridUser);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSave);
            this.Name = "AddRecipe";
            this.Text = "AddRecipe";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AddRecipe_FormClosed);
            this.Load += new System.EventHandler(this.AddRecipe_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCountry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridConv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridSeason)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridProductsOnly)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.DataGridView dataGridUser;
        private System.Windows.Forms.DataGridView dataGridGroup;
        private System.Windows.Forms.DataGridView dataGridCountry;
        private System.Windows.Forms.DataGridView dataGridConv;
        private System.Windows.Forms.DataGridView dataGridSeason;
        private System.Windows.Forms.DataGridView dataGridProducts;
        private System.Windows.Forms.TextBox textBoxUser;
        private System.Windows.Forms.TextBox textBoxCountry;
        private System.Windows.Forms.TextBox textBoxSeason;
        private System.Windows.Forms.TextBox textBoxConv;
        private System.Windows.Forms.TextBox textBoxGroup;
        private System.Windows.Forms.TextBox textBoxDescr;
        private System.Windows.Forms.ComboBox comboBoxUser;
        private System.Windows.Forms.ComboBox comboBoxCountry;
        private System.Windows.Forms.ComboBox comboBoxSeason;
        private System.Windows.Forms.ComboBox comboBoxGroup;
        private System.Windows.Forms.ComboBox comboBoxConv;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Button btnAddProduct;
        private System.Windows.Forms.Button btnDelProduct;
        private System.Windows.Forms.DataGridView dataGridProductsOnly;
        private System.Windows.Forms.TextBox textBoxAmount;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.Button btnUpdAmount;
        private System.Windows.Forms.ComboBox comboBoxProductsOnly;
        private System.Windows.Forms.TextBox textBoxProductsOnly;
    }
}