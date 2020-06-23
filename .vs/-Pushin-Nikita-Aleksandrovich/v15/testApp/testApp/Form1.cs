using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace testApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            testDTForDemEntities1 ctx = new testDTForDemEntities1();




            

            

            Users user = new Users();
            user.name = "erty";
            user.secondName = "ertySec";

            ctx.Users.Add(user);

            ctx.SaveChanges();

            var users = from user1 in ctx.Users
                        select user1.name;

            List<string> usersList = users.ToList();

            //MessageBox.Show(usersList[0].secondName);

            listBox1.DataSource = usersList;






        }
    }
}
