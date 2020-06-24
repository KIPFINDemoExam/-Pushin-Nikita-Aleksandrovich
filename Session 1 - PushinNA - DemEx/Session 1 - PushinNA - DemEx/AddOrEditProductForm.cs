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
    public partial class AddOrEditProductForm : Form
    {
        demExDBEntities ctx = new demExDBEntities();
        string productTitle;
        string state;

        public AddOrEditProductForm(string _state ,string _choosenProductTitle)
        {
            InitializeComponent();

            productTitle = _choosenProductTitle;
            state = _state;
        }        

        private void AddOrEditProductForm_Load(object sender, EventArgs e)
        {
            if (state == "add")
            {
                button1.Text = "Добавить";
            }
            else if (state == "edit")
            {
                button1.Text = "Редактировать";


                var productCollection = from product1 in ctx.Product
                                        where product1.Title == productTitle
                                        select product1;

                Product product = productCollection.First();

                textBox1.Text = product.Title;
                textBox2.Text = product.MainImagePath;
                textBox3.Text = product.Cost.ToString();
            }
            else
            {
                MessageBox.Show("Возникла ошибка, перезапустите программу!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (state == "add")
            {
                try
                {
                    if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
                    {
                        MessageBox.Show("Не все поля заполнены!");
                    }
                    else
                    {

                        Product product = new Product();

                        product.Title = textBox1.Text;
                        product.MainImagePath = " Товары автосервиса\\"+ textBox2.Text+ ".jpg";
                        product.Cost = Convert.ToDecimal(textBox3.Text);

                        ctx.Product.Add(product);
                        ctx.SaveChanges();
                        MessageBox.Show("Добавление прошло успешно");
                        this.Close();
                    }
                }
                catch
                {
                    MessageBox.Show("Возникла ошибка при добавлении!");
                }
            }
            else if (state == "edit")
            {
                try
                {
                    if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
                    {
                        MessageBox.Show("Не все поля заполнены!");
                    }
                    else
                    {

                        var productCollection = from product1 in ctx.Product
                                      where product1.Title == productTitle
                                      select product1;

                        Product product = productCollection.First();

                        product.Title = textBox1.Text;
                        product.MainImagePath = "Товары автосервиса\\" + textBox2.Text + ".jpg";
                        product.Cost = Convert.ToDecimal(textBox3.Text);
                        
                        ctx.SaveChanges();
                        MessageBox.Show("Редактирование прошло успешно");
                        this.Close();
                    }
                }
                catch
                {
                    MessageBox.Show("Возникла ошибка при редактировании!");
                }
            }
            else
            {
                MessageBox.Show("Возникла ошибка, перезапустите программу!");
            }
        }
    }
}
