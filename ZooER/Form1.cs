using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity; // NEED this to use Include()
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZooER.DAL;
using ZooER.Models;

namespace ZooER
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var db = new ZooContext())
            {
                // Create and save a new Blog 


                Animal dog = new Animal { Name = "Dog", Weight = 12.5 };
                Animal cat = new Animal { Name = "Cat", Weight = 1.0 };
                Animal horse = new Animal { Name = "Horse", Weight = 122.5 };
                Animal eagle = new Animal { Name = "Eagle", Weight = 2.5 };
               


                // define the RELATIONS Parent - Child
                var rel1 = new ChildParent();
                rel1.Parent = horse;
                rel1.Child = eagle;

                var rel2 = new ChildParent();
                rel2.Parent = dog;
                rel2.Child = horse;

                var rel3 = new ChildParent();
                rel3.Parent = dog;
                rel3.Child = cat;

                // Add the relations to the LINK table and...
                // Also the Animals table will be updated automatically
                db.ChildrenParents.Add(rel1);
                db.ChildrenParents.Add(rel2);
                db.ChildrenParents.Add(rel3);

                db.SaveChanges();
               

                // Display all Blogs from the database 
                var query = db.Animals.Select(c => c);


                var animalList = new BindingList<Animal>(query.ToList());
                dataGridView1.DataSource = animalList;
            }
        }




    }
}