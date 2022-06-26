using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject4
{
    class AnimalFood
    {

        private static Dictionary<int, AnimalFood> _extent = new();

        private static int id_counter = 0;
        private int id_animal_food;
        
        private Animal animal;
        private Food food;
        private DateTime giving_date;

        public static Dictionary<int, AnimalFood> Extent { get => new(_extent); }
        public int IdAnimalFood { get => id_animal_food; }

        public Animal Animal 
        { 
            get => animal; 
            private set
            {
                if (value is null) throw new ArgumentNullException("Animal can't be null");
                animal = value;
                value.AddFood(this);
            } 
        }

        public Food Food
        {
            get => food;
            private set
            {
                if (value is null) throw new ArgumentNullException("Food can't be null");
                food = value;
                value.AddAnimal(this);
            }
        }

        public DateTime GivingDate
        {
            get => giving_date;
            private set
            {
                if (value >= food.ExpirationDate) throw new ArgumentException("This food is already expired and spoiled.");
                giving_date = value;
            }
        }

        // constructor
        public AnimalFood(Animal animal, Food food, DateTime givingDate)
        {
            id_animal_food = ++id_counter;

            Animal = animal;
            Food = food;
            GivingDate = givingDate;

            _extent.Add(id_animal_food, this);
        }

        public void RemovePair()
        {
            if (animal is not null)
            {
                var tmp = animal;
                animal = null;
                tmp.RemoveFood(this);
            }

            if (food is not null)
            {
                var tmp = food;
                food = null;
                tmp.RemoveAnimal(this);
            }

            _extent.Remove(id_animal_food);
        }

        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if (obj == null || this.GetType() != obj.GetType()) return false;

            AnimalFood animalFood = (AnimalFood)obj;

            if (!Object.Equals(Animal, animalFood.Animal)) return false;
            if (!Object.Equals(Food, animalFood.Food)) return false;

            return Object.Equals(giving_date, animalFood.giving_date);
        }

        public override string ToString()
        {
            return $"AnimalFood {{ {id_animal_food}, {animal}, {food},  {giving_date} }}";
        }
    }
}
