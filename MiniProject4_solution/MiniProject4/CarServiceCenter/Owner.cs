using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject4.CarServiceCenter
{
    class Owner
    {
        private Worker worker;

        public Owner(Worker worker)
        {
            if (worker is null)
                throw new ArgumentNullException("Owner is a partial class object and can't exist without Worker.");
            if (worker.WorkerType is not WorkerType.Owner)
                throw new ArgumentException("Worker is of another type");
            this.worker = worker;
        }

        public double CalculateAllSalaries()
        {
            if (worker.WorkersMechanics.Count() == 0) throw new Exception("There are no Mechanic Workers at this moment.");

            double total_sum = 0;

            foreach (var mech in worker.WorkersMechanics)
            {
                total_sum += mech.Salary;
            }

            return total_sum;
        }
    }
}
