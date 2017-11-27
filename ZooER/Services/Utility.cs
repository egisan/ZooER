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
            return db.Animals.FirstOrDefault(c => c.AnimalId == selectedId);
        }


        public Animal GetAnimal(ZooContext db, string name)
        {
            return db.Animals.FirstOrDefault(c => c.Name == name);
        }


        public List<ChildParent> GetParentsLinks(ZooContext db, string childName)
        {
            return GetAnimal(db, childName).IsChildOf.ToList();
        }


        public List<ChildParent> GetChildrenLinks(ZooContext db, string parentName)
        {
            return GetAnimal(db, parentName).IsParentOf.ToList();
        }


        // Updating the current child if parents in comboboxes are changed
        public bool UpdateChildParentsLinks(ZooContext db, Animal currentChildtoUpdate, string parentInCombo)
        {
            if (parentInCombo != "All")
            {
                // I need to search in the db the Entities mapped to the parent 1/2 comboboxes and from there Add this new Animal
                // as Child 
                var parentNew = GetAnimal(db, parentInCombo);

                // Child has NO EXISTING PARENTS. I need to assign New parents ==> 1 or 2 links in the ChildParent table
                currentChildtoUpdate.IsChildOf.Add(
                                new ChildParent
                                {
                                    Child = currentChildtoUpdate, // Child getting updated
                                    Parent = parentNew            // Assigning another parent
                                });
                db.SaveChanges();
                return true;
            }
            else
            {
                return false; // No update
            }
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
                    if (animal.IsChildOf.Count() != 0)
                    {
                        if (animal.IsChildOf.Count() == 1)
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
                    if (animal.IsChildOf.Count() != 0)
                    {
                        if (animal.IsChildOf.Count() == 1)
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


        // Retrieve all info for all visits 
        // return a BindingList ready for View!
        public BindingList<BookingModel> GetVisitsDetails()
        {
            var visits = new BindingList<BookingModel>();

            using (var db = new ZooContext())
            {
                BookingModel visitView;
                foreach (var visit in db.Visits)
                {
                    string drugName = "";
                    visitView = new BookingModel();

                    visitView.Id = visit.VisitId;  // PK of Visit !

                    visitView.DoctorName = visit.Veterinary.Name;
                    visitView.NamePatient = visit.Animal.Name;
                    visitView.TimeBooked = visit.Start;
                    visitView.Diagnosis = visit.Diagnosis.Description;

                    foreach (var drug in visit.Drugs) // I lookup in the link table for all drugs attached to current visit
                    {
                        // Retrieve for each drug attached to the current visit via navigation, the name and append to a string .

                        drugName = drugName + drug.Drug.Name +",";

                    }
                    visitView.Drugs = drugName;

                    visits.Add(visitView);
                }
            }
            return visits;
        }
    }
}
