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
    public partial class adminTools : Form
    {
        public adminTools()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnGoCountry_Click(object sender, EventArgs e)
        {
            countryForm country = new countryForm(0);
            country.Show();
            this.Hide();
        }

        private void adminTools_Load(object sender, EventArgs e)
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

        private void adminTools_FormClosed(object sender, FormClosedEventArgs e)
        {
            login login = new login();
            login.Show();
        }

        private void btnGoProduct_Click(object sender, EventArgs e)
        {
            productForm form = new productForm(0);
            this.Hide();
            form.Show();
        }

        private void btnGoGroups_Click(object sender, EventArgs e)
        {
            GroupForm form = new GroupForm(0);
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
            SeasonForm form = new SeasonForm(0);
            this.Hide();
            form.Show();
        }

        private void btnGoRecipe_Click(object sender, EventArgs e)
        {
            RecipeForm form = new RecipeForm(0);
            this.Hide();
            form.Show();
        }
    }
}
