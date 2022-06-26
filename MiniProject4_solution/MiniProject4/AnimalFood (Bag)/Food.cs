using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject4
{
    class Food
    {

        private string name, type;
        private DateTime expiration_date;

        private List<AnimalFood> animals = new();

        public string Name
        {
            get => name;
            set
            {
                if (string.IsNullOrEmpty(value)) throw new ArgumentNullException("Name is null or empty");
                name = value;
            }
        }

        public string Type
        {
            get => type;
            set
            {
                if (string.IsNullOrEmpty(value)) throw new ArgumentNullException("Type is null or empty");
                type = value;
            }
        }

        public DateTime ExpirationDate 
        { 
            get => expiration_date;
            set
            {
                if (value <= DateTime.Now) throw new ArgumentException("This food is already expired and spoiled.");
                expiration_date = value;
            }
        }

        public List<AnimalFood> Animals { get => new(animals); }


        // constructor
        public Food(string name, string type, DateTime expirationDate)
        {
            Name = name;
            Type = type;
            ExpirationDate = expirationDate;
        }

        public void AddAnimal(AnimalFood animal)
        {
            if (animal is null) throw new ArgumentNullException("Animal is null.");
            if (animal.Food != this) throw new ArgumentException("This Animal is not for this food.");

            animals.Add(animal);
        }

        public void RemoveAnimal(AnimalFood animal)
        {
            if (animal is null) throw new ArgumentNullException("Animal is null.");
            if (!animals.Contains(animal)) return;

            animals.Remove(animal);
            animal.RemovePair();
        }
    }
}
