using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_MicroServices.Models
{
    public class Vehicle
    {
        public int VehicleNumber { get; set; }
        public string VehicleType { get; set; }
        public string ChassisNumber { get; set; }
        public string EngineNumber { get; set; }
        public string ManufacturingYear { get; set; }
        public string LoadCarryingCapacity { get; set; }
        public string MakeOfVehicle { get; set; }
        public string ModelNumber { get; set; }
        public string BodyType { get; set; }
        public string OrganisationName { get; set; }
        public int DeviceID { get; set; }
        public int UserID { get; set; }
    }

    public class searchModel
    {
        public int VehicleNumber { get; set; }
        public string VehicleType { get; set; }
        public string EngineNumber { get; set; }
    }
}
