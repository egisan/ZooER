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

        public Animal GetSelectedAnimal(ZooContext db, int selectedId)
        {
            //using (db)
            //{
            return db.Animals.FirstOrDefault(c => c.AnimalId == selectedId);
            //  }
        }


        public Animal GetAnimal(ZooContext db, string name)
        {
            //using (db)
            //{
            return db.Animals.FirstOrDefault(c => c.Name == name);
            //}
        }

        public List<ChildParent> GetParentsLinks(ZooContext db, string childName)
        {
            //using (db)
            //{
            return GetAnimal(db, childName).IsChildOf.ToList();
            //}

        }

        public List<ChildParent> GetChildrenLinks(ZooContext db, string parentName)
        {
            //using (db)
            //{
            return GetAnimal(db, parentName).IsParentOf.ToList();
            //}

        }

        // Updating the current child if parents in comboboxes are changed
        public bool UpdateChildParentsLinks(ZooContext db, Animal currentChildtoUpdate, int numberOfParents, string parentInCombo, int nrParentsInCombos)
        {
            //using (db)
            //{
            if (parentInCombo != "All")
            {
                // I need to search in the db the Entities mapped to the parent 1/2 comboboxes and from there Add this new Animal
                // as Child 
                var parentNew = GetAnimal(db, parentInCombo);

                switch (numberOfParents)
                {
                    case 0:
                        // Child has NO EXISTING PARENTS. I need to assign New parents ==> 1 or 2 links in the ChildParent table
                        currentChildtoUpdate.IsParentOf.Add(
                                        new ChildParent
                                        {
                                            Child = currentChildtoUpdate, // Child getting updated
                                            Parent = parentNew            // Assigning another parent
                                        });
                        db.SaveChanges();
                        break;
                    case 1:
                        currentChildtoUpdate.IsChildOf.FirstOrDefault(c => c.ParentID == null).ParentID = parentNew.AnimalId;
                        if (nrParentsInCombos == 2)
                        {
                            // I need to create a new entry in link table and connect the child with the new combo parent!
                            currentChildtoUpdate.IsChildOf.Add(
                                        new ChildParent
                                        {
                                            Child = currentChildtoUpdate, // Child getting updated
                                            Parent = null //  parentNew            // Assigning another parent
                                        });
                            db.SaveChanges();
                        }
                        break;
                    case 2:
                        // Child has 1 OR 2 EXISTING PARENT. I need to re-assign the first parent element to combobox1
                        if (currentChildtoUpdate.IsChildOf.FirstOrDefault(c => c.ParentID == null).ParentID == null)
                        {
                            currentChildtoUpdate.IsChildOf.FirstOrDefault(c => c.ParentID == null).ParentID = parentNew.AnimalId;
                            db.SaveChanges();
                        }
                        break;
                }
                return true;
            }
            else
            {
                return false; // No update
            }
            //}
        }

        // Retrieve all info for all animals in Zoo
        // return a BindingList ready for View!
        public List<AnimalDetails> GetAllAnimalsInSublist(List<Animal> anim)
        {
            var animals = new List<AnimalDetails>();

            using (var db = new ZooContext())
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
