using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject4
{
    class Animal
    {

        private string animal_name, personal_name;
        private int age;

        private List<AnimalFood> animal_food = new();

        public string AnimalName
        {
            get => animal_name;
            set
            {
                if (string.IsNullOrEmpty(value)) throw new ArgumentNullException("AnimalName is null or empty");
                animal_name = value;
            }
        }

        public string PersonalName
        {
            get => personal_name;
            set
            {
                if (string.IsNullOrEmpty(value)) throw new ArgumentNullException("PersonalName is null or empty");
                personal_name = value;
            }
        }

        public int Age 
        { 
            get => age;
            set
            {
                if (value < 0) throw new ArgumentException("Age can't be less than 0");
                age = value;
            }
        }

        // constructor
        public Animal(string animalName, string personalName, int age)
        {
            AnimalName = animalName;
            PersonalName = personalName;
            Age = age;
        }

        public void AddFood(AnimalFood food)
        {
            if (food is null) throw new ArgumentNullException("Food is null.");
            if (food.Animal != this) throw new ArgumentException("This Food is not for this animal.");

            animal_food.Add(food);
        }

        public void RemoveFood(AnimalFood food)
        {
            if (food is null) throw new ArgumentNullException("Food is null.");
            if (!animal_food.Contains(food)) return;

            animal_food.Remove(food);
            food.RemovePair();
        }
    }
}
