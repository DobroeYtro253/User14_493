using OOOSportProduct.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace OOOSportProduct.Forms
{
    public partial class ProductInfo : Form
    {
        Bitmap bmp;
        String image;
        public ProductInfo()
        {
            InitializeComponent();
            foreach (var item in Helper.DbContext.Providers.ToList())
            {
                comboBoxProvider.Items.Add(item.providerName);
            }
            foreach (var item in Helper.DbContext.Units.ToList())
            {
                comboBoxUnit.Items.Add(item.unitName);
            }
            foreach (var item in Helper.DbContext.Manufacturers.ToList())
            {
                comboBoxManuf.Items.Add(item.manufacturerName);
            }
            foreach (var item in Helper.DbContext.Categories.ToList())
            {
                comboBoxCategory.Items.Add(item.categoryName);
            }
            if (Helper.Role == 1)
            {
                tableLayoutPanelFill.Enabled = true;
            }
            if (Helper.New != 1)
            {
                Product pr = Helper.DbContext.Products.Where(x => x.ProductArticleNumber == Helper.Artikul).FirstOrDefault();
                textBoxArtikul.Text = pr.ProductArticleNumber;
                textBoxCost.Text = Convert.ToString(pr.ProductCost);
                textBoxCount.Text = Convert.ToString(pr.productCount);
                textBoxDescription.Text = pr.ProductDescription;
                textBoxMaxSale.Text = Convert.ToString(pr.ProductSaleMax);
                textBoxName.Text = pr.ProductName;
                textBoxSale.Text = Convert.ToString(pr.productSale);
                comboBoxCategory.SelectedIndex = pr.productCategoryId - 1;
                comboBoxProvider.SelectedIndex = pr.productProviderId - 1;
                comboBoxUnit.SelectedIndex = pr.productUnitId - 1;
                comboBoxManuf.SelectedIndex = pr.productManufacturerId - 1;

                try
                {
                    bmp = new Bitmap(Environment.CurrentDirectory + "/Photo/" + pr.ProductPhoto);

                }
                catch (Exception ex)
                {
                    bmp = new Bitmap(Environment.CurrentDirectory + "/Photo/picture.png");
                }
                pictureBoxImage.Image = bmp;
            }
                
            
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            pictureBoxImage.Image = new Bitmap(Environment.CurrentDirectory + "/Photo/picture.png");
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                var prod = Helper.DbContext.Products.Where(x => x.ProductArticleNumber == Helper.Artikul).FirstOrDefault();
                prod.ProductArticleNumber = textBoxArtikul.Text;
                prod.productCategoryId = comboBoxCategory.SelectedIndex + 1;
                prod.productCount = Convert.ToInt32(textBoxCount.Text);
                prod.productManufacturerId = comboBoxManuf.SelectedIndex + 1;
                prod.productProviderId = comboBoxProvider.SelectedIndex + 1;
                prod.productSale = Convert.ToInt32(textBoxSale.Text);
                prod.productUnitId = comboBoxUnit.SelectedIndex + 1;
                prod.ProductCost = Convert.ToDecimal(textBoxCost.Text);
                prod.ProductDescription = textBoxDescription.Text;
                prod.ProductName = textBoxName.Text;
                prod.ProductSaleMax = Convert.ToInt32(textBoxMaxSale.Text);
                prod.ProductPhoto = image;
                Helper.DbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Введите корректные данные");
            }
           
        }

        private void pictureBoxImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Выберите изображение товара";
            dialog.InitialDirectory = Environment.CurrentDirectory + "/Photo/";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                pictureBoxImage.Load(dialog.FileName);
                image = Path.GetFileNameWithoutExtension(dialog.FileName) + ".jpg";
            }
        }
    }
}
