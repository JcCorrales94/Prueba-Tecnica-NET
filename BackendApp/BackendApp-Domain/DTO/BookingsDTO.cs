using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendApp_Domain.DTO
{
    public class BookingsDTO
    {
        public int Id { get; set; }

        public string DNI { get; set; }

        public int FloatId { get; set; }

        public DateTime reservationDate { get; set; }

        public DateTime dateCollected { get; set; }

        public DateTime? deliveryDate { get; set; }

        public bool Active { get; set; }
    }
}
