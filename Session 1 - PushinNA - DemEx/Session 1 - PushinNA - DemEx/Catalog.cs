using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Session_1___PushinNA___DemEx
{
    public partial class Catalog : Form
    {
        demExDBEntities ctx = new demExDBEntities();
        string choosenProduct;

        public Catalog()
        {
            InitializeComponent();
        }

        private void Catalog_Load(object sender, EventArgs e)
        {           
            
            

            update();         



            


        }


        //Обновление списка
        void update()
        {
            FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel();
            //flowLayoutPanel.Top = 10;
            //flowLayoutPanel.Left = 10;
            flowLayoutPanel.Width = 700;
            flowLayoutPanel.Height = 380;
            flowLayoutPanel.BackColor = Color.LightGray;
            flowLayoutPanel.Parent = this;

            //flowLayoutPanel1.
            //flowLayoutPanel1.Refresh();

            var productsCollection = from product in ctx.Product
                                     select product;

            List<Product> productsList = productsCollection.ToList();

            for (int i = 0; i < productsCollection.Count(); i++)
            {
                Product product = productsList[i];

                Panel pan = new Panel();

                pan.Width = 215;
                pan.Height = 270;
                pan.BackColor = Color.White;
                pan.Parent = flowLayoutPanel;

                PictureBox pictureBox = new PictureBox();
                pictureBox.Width = 200;
                pictureBox.Height = 200;
                pictureBox.ImageLocation = product.MainImagePath;
                pictureBox.Parent = pan;

                Label labelTitle = new Label();
                labelTitle.Text = product.Title;
                //labelTitle.Text += "("+ product. +")";            
                labelTitle.Height = 30;
                labelTitle.Width = 200;
                labelTitle.Parent = pan;
                labelTitle.Top = 205;
                labelTitle.ForeColor = Color.Blue;
                labelTitle.Click += LabelTitle_Click;


                Label labelCost = new Label();
                labelCost.Text = product.Cost.ToString();
                labelCost.Height = 30;
                labelCost.Width = 200;
                labelCost.Parent = pan;
                labelCost.Top = 235;

                //MessageBox.Show(pad.ToString());               


                
            }
        }

        //выбор товара
        private void LabelTitle_Click(object sender, EventArgs e)
        {
            Label label = sender as Label;
            MessageBox.Show("Вы выбрали элемент - " + label.Text);
            choosenProduct = label.Text;
        }      


        //удаление
        private void button3_Click(object sender, EventArgs e)
        {
            var productCollection = from productNew in ctx.Product
                          where productNew.Title == choosenProduct
                          select productNew;

            Product product = productCollection.FirstOrDefault();
            ctx.Product.Remove(product);

            ctx.SaveChanges();
            update();
        }


        //Открытие формы добавления
        private void button1_Click(object sender, EventArgs e)
        {
            string state = "add";
            AddOrEditProductForm addOrEdit = new AddOrEditProductForm(state, choosenProduct);

            addOrEdit.ShowDialog();
            update();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (choosenProduct == "")
            {
                MessageBox.Show("Вы ничего не выбрали!");
            }
            else
            {
                string state = "edit";
                AddOrEditProductForm addOrEdit = new AddOrEditProductForm(state, choosenProduct);

                addOrEdit.ShowDialog();
                update();
            }

            
        }
    }
}
