using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecipeDBApp
{
    public partial class userTools : Form
    {
        int userIDform;
        public userTools(int userID)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            userIDform = userID;
        }

        private void btnGoCountry_Click(object sender, EventArgs e)
        {
            countryForm country = new countryForm(userIDform);
            country.Show();
            this.Hide();
        }

        private void userTools_Load(object sender, EventArgs e)
        {

        }

        private void btnSearchRecipe_Click(object sender, EventArgs e)
        {
            searchRecipe search = new searchRecipe();
            this.Hide();
            search.Show();
           
        }

        private void btnSearchViewedRecByUser_Click(object sender, EventArgs e)
        {
            searchViewedRecByUser search = new searchViewedRecByUser();
            this.Hide();
            search.Show();
        }

        private void btnSearchCategoryViews_Click(object sender, EventArgs e)
        {
            searchCategoryViews search = new searchCategoryViews();
            this.Hide();
            search.Show();
        }

        private void userTools_FormClosed(object sender, FormClosedEventArgs e)
        {
            login login = new login();
            login.Show();
        }

        private void btnGoProduct_Click(object sender, EventArgs e)
        {
            productForm form = new productForm(userIDform);
            this.Hide();
            form.Show();
        }

        private void btnGoGroups_Click(object sender, EventArgs e)
        {
            GroupForm form = new GroupForm(userIDform);
            this.Hide();
            form.Show();
        }

        private void btnGoUsers_Click(object sender, EventArgs e)
        {
            UserForm form = new UserForm();
            this.Hide();
            form.Show();
        }

        private void btnGoConverters_Click(object sender, EventArgs e)
        {
            CostConverterForm form = new CostConverterForm();
            this.Hide();
            form.Show();
        }

        private void btnGoSeasons_Click(object sender, EventArgs e)
        {
            SeasonForm form = new SeasonForm(userIDform);
            this.Hide();
            form.Show();
        }

        private void btnGoRecipe_Click(object sender, EventArgs e)
        {
            RecipeForm form = new RecipeForm(userIDform);
            this.Hide();
            form.Show();
        }
    }
}
