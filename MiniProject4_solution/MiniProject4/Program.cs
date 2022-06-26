using System;

namespace MiniProject4
{
    class Program
    {
        static void Main(string[] args)
        {

            // --------------------
            // Unique
            // --------------------
            // same serial exception
            // Car car2 = new Car("4T4BF1FK4CR236137", "honda civic", 2010);
            // Car car3 = new Car("4T4BF1FK4CR236137", "mercedes-benz", 600);

            // --------------------
            // Subset
            // --------------------
            Worker mechanic1 = new("firstname", "lastname", 2000, MechanicType.SeniorMechanic);
            ServiceCenter serviceCenter1 = new("servicecentername", "ul. Address 23");

            MechanicServiceCenter mechanic_center1 = new(mechanic1, serviceCenter1);
            mechanic1.ManageServiceCenter(serviceCenter1);
            Console.WriteLine(mechanic1.ManagedServiceCenters.Count);

            mechanic_center1.RemovePair();
            Console.WriteLine(mechanic1.ManagedServiceCenters.Count);

            // Exception
            // mechanic1.ManageServiceCenter(serviceCenter1);


            // --------------------
            // Ordered
            // --------------------
            Car car1 = new Car("1FAFP45X83F403461", "toyota land cruiser", 1200);

            Worker mechanic2 = new("firstname2", "lastname2", 2000, MechanicType.JuniorMechanic);
            Worker mechanic3 = new("firstname3", "lastname3", 2000, MechanicType.SeniorMechanic);

            car1.AddMechanic(mechanic1);
            car1.AddMechanic(mechanic3);
            car1.AddMechanic(mechanic2);

            foreach (var mech in car1.AssignedMechanics)
            {
                Console.WriteLine(mech.FirstName + " " + mech.LastName);
            }

            // --------------------
            // Bag
            // --------------------

            Food food1 = new Food("food1", "foodtype1", DateTime.Now.AddMonths(1));
            Animal animal1 = new Animal("Tiger", "Name1", 17);

            AnimalFood animalFood1 = new(animal1, food1, new DateTime(2022, 5, 22));
            AnimalFood animalFood2 = new(animal1, food1, new DateTime(2022, 5, 22));
            AnimalFood animalFood3 = new(animal1, food1, DateTime.Now.AddDays(5));

            foreach (var af in AnimalFood.Extent)
            {
                Console.WriteLine(af.Value);
            }

            Console.WriteLine(animalFood1.Equals(animalFood2));
            Console.WriteLine(animalFood1.Equals(animalFood3));

            // --------------------
            // Xor
            // --------------------
            // Hint*
            // Mechanic mechanic2 = new("firstname2", "lastname2", 2000, MechanicType.JuniorMechanic);
            // Mechanic mechanic3 = new("firstname3", "lastname3", 2000, MechanicType.SeniorMechanic);
            // mechanic2.base_salary = mechanic3.base_salary

            Console.WriteLine(mechanic2.Salary);
            Console.WriteLine(mechanic3.Salary);

            //////////////////////////////
            
            Worker owner1 = new("firstname4", "lastname4");

            Console.WriteLine(owner1.CalculateAllSalaries());

        }
    }
}
