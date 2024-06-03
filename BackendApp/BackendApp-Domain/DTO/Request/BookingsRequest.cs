namespace BackendApp_Domain.DTO.Request
{
    public class BookingsRequest
    {
        public string DNI { get; set; }

        public int FloatId { get; set; }

        public DateTime reservationDate { get; set; }
    }
}
