using BussinesLayer;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JankoZivaljevic
{
    public partial class ShopApp : Form
    {
        readonly ProductBussines productBussines = new ProductBussines();
        public ShopApp()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RefreshList();

        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            Product product = new Product()
            {
                Name = textBoxName.Text,
                Description = textBoxDescription.Text,
                ExpiryDate = dateTimePicker1.Value
            };

            productBussines.InsertProduct(product);

            RefreshList();

            textBoxName.Text = string.Empty;
            textBoxDescription.Text = string.Empty;
            dateTimePicker1.Value = DateTime.Now;
        }
        private void RefreshList()
        {
            listBoxProducts.Items.Clear();
            foreach(Product product in productBussines.GetProducts())
            {
                listBoxProducts.Items.Add($"{product.Id}.{product.Name}");
            }
        }
    }
}
