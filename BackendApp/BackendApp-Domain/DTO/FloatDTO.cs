using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendApp_Domain.DTO
{
    public class FloatDTO
    {
        public int Id { get; set; } 

        public string CarRegistration { get; set; } 

        public string Model { get; set; }

        public int places { get; set; }

        public string Color { get; set; }

        public string hp { get; set; }

        public DateTime ManufacturingDate { get; set; } 
    }
}
