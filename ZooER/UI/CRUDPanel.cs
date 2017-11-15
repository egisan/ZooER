using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZooER.DAL;
using ZooER.ViewModels;

namespace ZooER
{
    public partial class EditPanel : Form
    {
        public EditPanel()
        {
            InitializeComponent();
        }


        // Retrieve all info for all animals in Zoo
        public BindingList<AnimalDetails> GetAnimalDetails()
        {
            var animals = new BindingList<AnimalDetails>();

            using (var db = new ZooContext())
            {
                var animalView = new AnimalDetails();

                foreach (var animal in db.Animals)
                {
                    animalView.Id = animal.AnimalId;
                    animalView.Name = animal.Name;

                    // Search for possible parents and store in a list
                    if (animal.IsChildOf != null)
                    {
                        if (animal.IsChildOf.ToList().Count() == 1)
                        {
                            animalView.Parent1 = animal.IsChildOf.ToList()[0].Name;
                            animalView.Parent2 = "Not available";  // Missing one parent
                        }
                        else
                        {
                            animalView.Parent1 = animal.IsChildOf.ToList()[0].Name;
                            animalView.Parent2 = animal.IsChildOf.ToList()[1].Name;
                        }
                    }

                    animalView.HabitatType = animal.Habitat.Name;
                    animalView.DietType = animal.Diet.Name;
                    animalView.OriginCountry = animal.Origin.Name;
                    animalView.SpeciesType = animal.Species.Name;

                    animals.Add(animalView);
                }
            }
            return animals;
        }
    }
}
