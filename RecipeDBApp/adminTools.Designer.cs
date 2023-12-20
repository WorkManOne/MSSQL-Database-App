namespace RecipeDBApp
{
    partial class adminTools
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
            this.btnGoCountry = new System.Windows.Forms.Button();
            this.btnGoProduct = new System.Windows.Forms.Button();
            this.btnGoSeasons = new System.Windows.Forms.Button();
            this.btnGoUsers = new System.Windows.Forms.Button();
            this.btnGoGroups = new System.Windows.Forms.Button();
            this.btnGoConverters = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSearchRecipe = new System.Windows.Forms.Button();
            this.btnSearchViewedRecByUser = new System.Windows.Forms.Button();
            this.btnSearchCategoryViews = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnGoRecipe = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGoCountry
            // 
            this.btnGoCountry.Location = new System.Drawing.Point(6, 80);
            this.btnGoCountry.Name = "btnGoCountry";
            this.btnGoCountry.Size = new System.Drawing.Size(200, 40);
            this.btnGoCountry.TabIndex = 1;
            this.btnGoCountry.Text = "Страны";
            this.btnGoCountry.UseVisualStyleBackColor = true;
            this.btnGoCountry.Click += new System.EventHandler(this.btnGoCountry_Click);
            // 
            // btnGoProduct
            // 
            this.btnGoProduct.Location = new System.Drawing.Point(6, 34);
            this.btnGoProduct.Name = "btnGoProduct";
            this.btnGoProduct.Size = new System.Drawing.Size(200, 40);
            this.btnGoProduct.TabIndex = 2;
            this.btnGoProduct.Text = "Продукты";
            this.btnGoProduct.UseVisualStyleBackColor = true;
            this.btnGoProduct.Click += new System.EventHandler(this.btnGoProduct_Click);
            // 
            // btnGoSeasons
            // 
            this.btnGoSeasons.Location = new System.Drawing.Point(487, 80);
            this.btnGoSeasons.Name = "btnGoSeasons";
            this.btnGoSeasons.Size = new System.Drawing.Size(200, 40);
            this.btnGoSeasons.TabIndex = 3;
            this.btnGoSeasons.Text = "Сезоны";
            this.btnGoSeasons.UseVisualStyleBackColor = true;
            this.btnGoSeasons.Click += new System.EventHandler(this.btnGoSeasons_Click);
            // 
            // btnGoUsers
            // 
            this.btnGoUsers.Location = new System.Drawing.Point(487, 34);
            this.btnGoUsers.Name = "btnGoUsers";
            this.btnGoUsers.Size = new System.Drawing.Size(200, 40);
            this.btnGoUsers.TabIndex = 4;
            this.btnGoUsers.Text = "Пользователи";
            this.btnGoUsers.UseVisualStyleBackColor = true;
            this.btnGoUsers.Click += new System.EventHandler(this.btnGoUsers_Click);
            // 
            // btnGoGroups
            // 
            this.btnGoGroups.Location = new System.Drawing.Point(212, 34);
            this.btnGoGroups.Name = "btnGoGroups";
            this.btnGoGroups.Size = new System.Drawing.Size(269, 40);
            this.btnGoGroups.TabIndex = 5;
            this.btnGoGroups.Text = "Категории рецептов";
            this.btnGoGroups.UseVisualStyleBackColor = true;
            this.btnGoGroups.Click += new System.EventHandler(this.btnGoGroups_Click);
            // 
            // btnGoConverters
            // 
            this.btnGoConverters.Location = new System.Drawing.Point(212, 80);
            this.btnGoConverters.Name = "btnGoConverters";
            this.btnGoConverters.Size = new System.Drawing.Size(269, 40);
            this.btnGoConverters.TabIndex = 6;
            this.btnGoConverters.Text = "Конвертеры цен";
            this.btnGoConverters.UseVisualStyleBackColor = true;
            this.btnGoConverters.Click += new System.EventHandler(this.btnGoConverters_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox1.Controls.Add(this.btnGoCountry);
            this.groupBox1.Controls.Add(this.btnGoConverters);
            this.groupBox1.Controls.Add(this.btnGoProduct);
            this.groupBox1.Controls.Add(this.btnGoGroups);
            this.groupBox1.Controls.Add(this.btnGoSeasons);
            this.groupBox1.Controls.Add(this.btnGoUsers);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(699, 139);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Работа со справочниками";
            // 
            // btnSearchRecipe
            // 
            this.btnSearchRecipe.Location = new System.Drawing.Point(17, 30);
            this.btnSearchRecipe.Name = "btnSearchRecipe";
            this.btnSearchRecipe.Size = new System.Drawing.Size(250, 71);
            this.btnSearchRecipe.TabIndex = 8;
            this.btnSearchRecipe.Text = "Поиск рецепта";
            this.btnSearchRecipe.UseVisualStyleBackColor = true;
            this.btnSearchRecipe.Click += new System.EventHandler(this.btnSearchRecipe_Click);
            // 
            // btnSearchViewedRecByUser
            // 
            this.btnSearchViewedRecByUser.Location = new System.Drawing.Point(273, 30);
            this.btnSearchViewedRecByUser.Name = "btnSearchViewedRecByUser";
            this.btnSearchViewedRecByUser.Size = new System.Drawing.Size(425, 71);
            this.btnSearchViewedRecByUser.TabIndex = 9;
            this.btnSearchViewedRecByUser.Text = "Поиск всех рецептов просмотренных пользователем";
            this.btnSearchViewedRecByUser.UseVisualStyleBackColor = true;
            this.btnSearchViewedRecByUser.Click += new System.EventHandler(this.btnSearchViewedRecByUser_Click);
            // 
            // btnSearchCategoryViews
            // 
            this.btnSearchCategoryViews.Location = new System.Drawing.Point(704, 30);
            this.btnSearchCategoryViews.Name = "btnSearchCategoryViews";
            this.btnSearchCategoryViews.Size = new System.Drawing.Size(250, 71);
            this.btnSearchCategoryViews.TabIndex = 10;
            this.btnSearchCategoryViews.Text = "Поиск категорий по просмотрам";
            this.btnSearchCategoryViews.UseVisualStyleBackColor = true;
            this.btnSearchCategoryViews.Click += new System.EventHandler(this.btnSearchCategoryViews_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox2.Controls.Add(this.btnSearchRecipe);
            this.groupBox2.Controls.Add(this.btnSearchCategoryViews);
            this.groupBox2.Controls.Add(this.btnSearchViewedRecByUser);
            this.groupBox2.Location = new System.Drawing.Point(12, 157);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(967, 119);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Работа с соединениями, процедурами и представлениями";
            // 
            // btnGoRecipe
            // 
            this.btnGoRecipe.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnGoRecipe.Location = new System.Drawing.Point(717, 12);
            this.btnGoRecipe.Name = "btnGoRecipe";
            this.btnGoRecipe.Size = new System.Drawing.Size(262, 139);
            this.btnGoRecipe.TabIndex = 12;
            this.btnGoRecipe.Text = "Работа с рецептами";
            this.btnGoRecipe.UseVisualStyleBackColor = false;
            this.btnGoRecipe.Click += new System.EventHandler(this.btnGoRecipe_Click);
            // 
            // adminTools
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(990, 286);
            this.Controls.Add(this.btnGoRecipe);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "adminTools";
            this.Text = "adminTools";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.adminTools_FormClosed);
            this.Load += new System.EventHandler(this.adminTools_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGoCountry;
        private System.Windows.Forms.Button btnGoProduct;
        private System.Windows.Forms.Button btnGoSeasons;
        private System.Windows.Forms.Button btnGoUsers;
        private System.Windows.Forms.Button btnGoGroups;
        private System.Windows.Forms.Button btnGoConverters;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSearchRecipe;
        private System.Windows.Forms.Button btnSearchViewedRecByUser;
        private System.Windows.Forms.Button btnSearchCategoryViews;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnGoRecipe;
    }
}