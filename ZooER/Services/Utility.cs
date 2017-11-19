using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooER.DAL;
using ZooER.Models;
using ZooER.ViewModels;

namespace ZooER.Services
{
    public class Utility
    {


        // Retrieve all info for all animals in Zoo
        // return a BindingList ready for View!
        public List<AnimalDetails> GetAllAnimalsInSublist(List<Animal> anim, ZooContext db)
        {
            var animals = new List<AnimalDetails>();

            using (db)
            {
                AnimalDetails animalView;

                var filteredAnimalList = from first in anim
                                         from second in db.Animals
                                         where first.AnimalId == second.AnimalId
                                         select first;

                foreach (var animal in filteredAnimalList)
                {

                    animalView = new AnimalDetails();

                    animalView.Id = animal.AnimalId;  // PK of Animals !
                    animalView.Name = animal.Name;
                    animalView.Weight = animal.Weight;

                    // Search for possible parents and store in a list
                    if (animal.IsChildOf.Any(c => c.ParentID != null))
                    //  if (animal.IsChildOf != null && animal.IsChildOf.Count() != 0)
                    {
                        if (animal.IsChildOf.ToList().Count() == 1)
                        {
                            animalView.Parent1 = animal.IsChildOf.ToList()[0].Parent.Name;
                            animalView.Parent2 = "Not available";  // Missing one parent
                        }
                        else
                        {
                            animalView.Parent1 = animal.IsChildOf.ToList()[0].Parent.Name;
                            animalView.Parent2 = animal.IsChildOf.ToList()[1].Parent.Name;
                        }
                    }
                    else
                    {
                        // there are no parents for the current animal
                        animalView.Parent1 = "Not available";  // Missing one parent
                        animalView.Parent2 = "Not available";  // Missing one parent


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





        // Retrieve all info for all animals in Zoo
        // return a BindingList ready for View!
        public BindingList<AnimalDetails> GetAnimalDetails()
        {
            var animals = new BindingList<AnimalDetails>();

            using (var db = new ZooContext())
            {
                AnimalDetails animalView;

                foreach (var animal in db.Animals)
                {
                    animalView = new AnimalDetails();

                    animalView.Id = animal.AnimalId;  // PK of Animals !

                    animalView.Name = animal.Name;
                    animalView.Weight = animal.Weight;

                    // Search for possible parents and store in a list
                    if (animal.IsChildOf.Any(c => c.ParentID != null))

                    //  if (animal.IsChildOf != null && animal.IsChildOf.Count() != 0)
                    {
                        if (animal.IsChildOf.Where(c => c.ParentID != null).Count() == 1)
                        {
                            animalView.Parent1 = animal.IsChildOf.ToList()[0].Parent.Name;
                            animalView.Parent2 = "Not available";  // Missing one parent
                        }
                        else
                        {
                            animalView.Parent1 = animal.IsChildOf.ToList()[0].Parent.Name;
                            animalView.Parent2 = animal.IsChildOf.ToList()[1].Parent.Name;
                        }
                    }
                    else
                    {
                        // there are no parents for the current animal
                        animalView.Parent1 = "Not available";  // Missing one parent
                        animalView.Parent2 = "Not available";  // Missing one parent
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
