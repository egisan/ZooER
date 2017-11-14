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
using System.Xml;
using System.Data.Entity.Infrastructure;

namespace ZooER
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Derive the model from the context!
        //
        public void CreateDesignModel()
        {
            using (var context = new ZooContext())
            {
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;

                using (XmlWriter writer = XmlWriter.Create(@"Model.edmx", settings))
                {
                    EdmxWriter.WriteEdmx(context, writer);
                }
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            CreateDesignModel();

            using (var db = new ZooContext())
            {


                // Create and save a new Blog 


                Animal dog = new Animal { Name = "Dog", Weight = 12.5 , IsParentOf = new List<Animal>(), IsChildOf = new List<Animal>()};
                Animal cat = new Animal { Name = "Cat", Weight = 1.0, IsParentOf = new List<Animal>(), IsChildOf = new List<Animal>() };
                Animal horse = new Animal { Name = "Horse", Weight = 122.5, IsParentOf = new List<Animal>(), IsChildOf = new List<Animal>() };
                Animal eagle = new Animal { Name = "Eagle", Weight = 2.5, IsParentOf = new List<Animal>(), IsChildOf = new List<Animal>() };
                Animal wale = new Animal { Name = "Wale", Weight = 440.9, IsParentOf = new List<Animal>(), IsChildOf = new List<Animal>() };

                eagle.IsChildOf.Add(horse);
                horse.IsChildOf.Add(dog);
                horse.IsParentOf.Add(wale);
                dog.IsParentOf.Add(cat);


                var visit1 = new Visit { Start = DateTime.Now, Drugs = new List<Drug>() };

                var visit2 = new Visit { Start = DateTime.Now };

                var drug1 = new Drug { Name = "drug1", Visits = new List<Visit>() };
                var drug2 = new Drug { Name = "drug2", Visits = new List<Visit>() };
                var drug3 = new Drug { Name = "drug3", Visits = new List<Visit>() };

                drug3.Visits.Add(visit2);

                visit1.Drugs.Add(drug1);
                visit1.Drugs.Add(drug2);
                visit1.Drugs.Add(drug3);

                Animal dogPappa = new Animal { Name = "DogPappa", Weight = 20.0 };



                // define the RELATIONS Parent - Child
                //var rel1 = new ChildParent();
                //rel1.Parent = db.Animals.Where(c => c.Name == "Horse").FirstOrDefault();
                //rel1.Child = db.Animals.Where(c => c.Name == "Eagle").FirstOrDefault(); ;

                //var rel2 = new ChildParent();
                //rel2.Parent = db.Animals.Where(c => c.Name == "Horse").FirstOrDefault();
                //rel2.Child = db.Animals.Where(c => c.Name == "Wale").FirstOrDefault(); 

                //var rel3 = new ChildParent();
                //rel3.Parent = db.Animals.Where(c => c.Name == "Dog").FirstOrDefault();
                //rel3.Child = db.Animals.Where(c => c.Name == "Horse").FirstOrDefault();

                //var rel4 = new ChildParent();
                //rel4.Parent = db.Animals.Where(c => c.Name == "Dog").FirstOrDefault();
                //rel4.Child = db.Animals.Where(c => c.Name == "Cat").FirstOrDefault();
                //// Add the relations to the LINK table and...
                //// Also the Animals table will be updated automatically
                //db.ChildrenParents.Add(rel1);
                //db.ChildrenParents.Add(rel2);
                //db.ChildrenParents.Add(rel3);
                //db.ChildrenParents.Add(rel4);

                //// Removing Dog as parent of horse ==> removing the relation 'IsChildOf'
                //db.SaveChanges();

                //// Display all Blogs from the database 
                var query = db.Animals.Select(c => c);


                var animalList = new BindingList<Animal>(query.ToList());
                dataGridView1.DataSource = animalList;
            }
        }




    }
}