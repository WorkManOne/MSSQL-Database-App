namespace RecipeDBApp
{
    partial class userTools
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
            this.btnGoGroups = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnGoRecipe = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
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
            this.btnGoSeasons.Location = new System.Drawing.Point(212, 80);
            this.btnGoSeasons.Name = "btnGoSeasons";
            this.btnGoSeasons.Size = new System.Drawing.Size(293, 40);
            this.btnGoSeasons.TabIndex = 3;
            this.btnGoSeasons.Text = "Сезоны";
            this.btnGoSeasons.UseVisualStyleBackColor = true;
            this.btnGoSeasons.Click += new System.EventHandler(this.btnGoSeasons_Click);
            // 
            // btnGoGroups
            // 
            this.btnGoGroups.Location = new System.Drawing.Point(212, 34);
            this.btnGoGroups.Name = "btnGoGroups";
            this.btnGoGroups.Size = new System.Drawing.Size(293, 40);
            this.btnGoGroups.TabIndex = 5;
            this.btnGoGroups.Text = "Категории рецептов";
            this.btnGoGroups.UseVisualStyleBackColor = true;
            this.btnGoGroups.Click += new System.EventHandler(this.btnGoGroups_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox1.Controls.Add(this.btnGoCountry);
            this.groupBox1.Controls.Add(this.btnGoProduct);
            this.groupBox1.Controls.Add(this.btnGoGroups);
            this.groupBox1.Controls.Add(this.btnGoSeasons);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(516, 139);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Работа со справочниками";
            // 
            // btnGoRecipe
            // 
            this.btnGoRecipe.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnGoRecipe.Location = new System.Drawing.Point(534, 11);
            this.btnGoRecipe.Name = "btnGoRecipe";
            this.btnGoRecipe.Size = new System.Drawing.Size(262, 139);
            this.btnGoRecipe.TabIndex = 12;
            this.btnGoRecipe.Text = "Работа с рецептами";
            this.btnGoRecipe.UseVisualStyleBackColor = false;
            this.btnGoRecipe.Click += new System.EventHandler(this.btnGoRecipe_Click);
            // 
            // userTools
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 162);
            this.Controls.Add(this.btnGoRecipe);
            this.Controls.Add(this.groupBox1);
            this.Name = "userTools";
            this.Text = "userTools";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.userTools_FormClosed);
            this.Load += new System.EventHandler(this.userTools_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGoCountry;
        private System.Windows.Forms.Button btnGoProduct;
        private System.Windows.Forms.Button btnGoSeasons;
        private System.Windows.Forms.Button btnGoGroups;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnGoRecipe;
    }
}