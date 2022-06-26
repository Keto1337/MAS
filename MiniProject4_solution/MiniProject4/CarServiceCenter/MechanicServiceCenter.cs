using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject4
{
    class MechanicServiceCenter
    {

        private static List<MechanicServiceCenter> _extent = new();

        private Worker working_mechanic;
        private ServiceCenter service_center;

        public Worker WorkingMechanic
        { 
            get => working_mechanic;
            private set
            {
                if (value is null) throw new ArgumentNullException("WorkingMechanic can't be null.");

                working_mechanic = value;
                value.AddServiceCenter(this);
            }
        }

        public ServiceCenter ServiceCenter
        {
            get => service_center;
            private set
            {
                if (value is null) throw new ArgumentNullException("ServiceCenter can't be null.");

                service_center = value;
                value.AddMechanic(this);
            }
        }

        // constructor
        public MechanicServiceCenter(Worker workingMechanic, ServiceCenter serviceCenter)
        {
            if (workingMechanic.WorkerType != WorkerType.Mechanic) throw new ArgumentException("OwnerWorker can't work on particular service center.");
            if (!IsPairUnique(workingMechanic, serviceCenter)) throw new ArgumentException("Pair has to be unique!");

            WorkingMechanic = workingMechanic;
            ServiceCenter = serviceCenter;

            _extent.Add(this);
        }

        public void RemovePair()
        {
            if (working_mechanic is not null)
            {
                if (working_mechanic.ManagedServiceCenters.Contains(service_center))
                    working_mechanic.StopManagingServiceCenter(service_center);

                var tmp = working_mechanic;
                working_mechanic = null;
                tmp.RemoveServiceCenter(this);
            }

            if (service_center is not null)
            {
                var tmp = service_center;
                service_center = null;
                tmp.RemoveMechanic(this);
            }

            _extent.Remove(this);
        }

        private static bool IsPairUnique(Worker workingMechanic, ServiceCenter serviceCenter)
        {
            bool alreadyExists = _extent.Any(msc => msc.working_mechanic == workingMechanic && msc.service_center == serviceCenter);
            return !alreadyExists;
        }
    }
}
