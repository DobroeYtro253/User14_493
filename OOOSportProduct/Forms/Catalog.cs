using OOOSportProduct.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOOSportProduct.Forms
{
    public partial class Catalog : Form
    {
        List<Product> pr = new List<Product>();
        int kol1 = 0, kol2 = 0;
        Bitmap bmp;
        public Catalog()
        {
            
            InitializeComponent();
            dataGridViewData.Columns[2].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridViewData.Rows.Clear();
            foreach (Manufacturer mr in Helper.DbContext.Manufacturers.ToList())
            {
                comboBoxProis.Items.Add(mr.manufacturerName);
            }
            View(Helper.DbContext.Products);
            kol1 = kol2;
            labelCount.Text = kol2 + " из " + kol1;
        }
        public void View(IOrderedQueryable context)
        {
            try
            {
                dataGridViewData.Rows.Clear();
                int i = 0;
                kol2 = 0;
                foreach (Product product in context)
                {
                    dataGridViewData.Rows.Add();
                    dataGridViewData[0, i].Value = product.ProductArticleNumber;
                    try
                    {
                        bmp = new Bitmap(Environment.CurrentDirectory + "/Photo/" + product.ProductPhoto);

                    }
                    catch (Exception ex)
                    {
                        bmp = new Bitmap(Environment.CurrentDirectory + "/Photo/picture.png");
                    }
                    dataGridViewData[1, i].Value = bmp;
                    decimal sale = product.ProductCost - (product.ProductCost / 100 * product.productSale);
                    //decimal sale = (1 - (product.productSale / 100)) * product.ProductCost;
                    dataGridViewData[2, i].Value = $"Наименование: {product.ProductName} \rОписание товара: {product.ProductDescription} \rПроизводитель: {Helper.DbContext.Manufacturers.Where(x => x.manufacturerID == product.productManufacturerId).FirstOrDefault().manufacturerName}" +
                        $" \rЦена: {product.ProductCost} \rСкидка: {product.productSale} \rЦена со скидкой: {sale}";
                    dataGridViewData[3, i].Value = "Количество на складе: " + product.productCount;

                    if (product.productCount == 0)
                    {
                        dataGridViewData.Rows[i].DefaultCellStyle.BackColor = Color.Gray;
                    }
                    kol2++;
                    i++;
                }

            }
            catch (Exception ex)
            { }


        }
        public void View(IQueryable context)
        {
            try
            {
                dataGridViewData.Rows.Clear();
                int i = 0;
                kol2 = 0;
                foreach (Product product in context)
                {
                    dataGridViewData.Rows.Add();
                    dataGridViewData[0, i].Value = product.ProductArticleNumber;
                    try
                    {
                        bmp = new Bitmap(Environment.CurrentDirectory + "/Photo/" + product.ProductPhoto);

                    }
                    catch (Exception ex)
                    {
                        bmp = new Bitmap(Environment.CurrentDirectory + "/Photo/picture.png");
                    }
                    dataGridViewData[1, i].Value = bmp;
                    decimal sale = product.ProductCost - (product.ProductCost / 100 * product.productSale);
                    //decimal sale = (1 - (product.productSale / 100)) * product.ProductCost;
                    dataGridViewData[2, i].Value = $"Наименование: {product.ProductName} \rОписание товара: {product.ProductDescription} \rПроизводитель: {Helper.DbContext.Manufacturers.Where(x => x.manufacturerID == product.productManufacturerId).FirstOrDefault().manufacturerName}" +
                        $" \rЦена: {product.ProductCost} \rСкидка: {product.productSale} \rЦена со скидкой: {sale}";
                    dataGridViewData[3, i].Value = "Количество на складе: " + product.productCount;

                    if (product.productCount == 0)
                    {
                        dataGridViewData.Rows[i].DefaultCellStyle.BackColor = Color.Gray;
                    }
                    kol2++;
                    i++;
                }

            }
            catch (Exception ex)
            { }


        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            View(Helper.DbContext.Products.Where(x => x.productManufacturerId == comboBoxProis.SelectedIndex + 1).Where(x => x.ProductName.StartsWith(textBoxSearch.Text)));
            labelCount.Text = kol2 + " из " + kol1;
        }

        private void comboBoxFiltr_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxFiltr.SelectedItem)
            {
                case "<10%": View(Helper.DbContext.Products.Where(x => x.productSale < 10)); break;
                case "10% - 15%": View(Helper.DbContext.Products.Where(x => x.productSale > 10 && x.productSale < 15)); break;
                case ">15%": View(Helper.DbContext.Products.Where(x => x.productSale > 15)); break;
            }
            labelCount.Text = kol2 + " из " + kol1;
        }

        private void comboBoxSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxSort.SelectedItem)
            {
                case "По убыванию цены": View(Helper.DbContext.Products.OrderByDescending(x => x.ProductCost)); break;

                case "По возрастанию цены": View(Helper.DbContext.Products.OrderBy(x => x.ProductCost)); break;

                case "Без сортировки": View(Helper.DbContext.Products); break;
            }
            labelCount.Text = kol2 + " из " + kol1;
        }

        private void comboBoxProis_SelectedIndexChanged(object sender, EventArgs e)
        {
            View(Helper.DbContext.Products.Where(x => x.productManufacturerId == comboBoxProis.SelectedIndex + 1).Where(x => x.ProductName.StartsWith(textBoxSearch.Text)));
            labelCount.Text = kol2 + " из " + kol1;
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
