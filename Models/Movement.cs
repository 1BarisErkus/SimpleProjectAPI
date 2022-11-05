namespace SimpleProjectAPI.Models
{
    public class Movement
    {
        public int Id { get; set; } = 0;
        public DateTime CheckinTime { get; set; } = DateTime.Now;
        public DateTime CheckoutTime { get; set; } = DateTime.Now;
        public int InOut { get; set; } = 0;
        public DateTime DepartureTime { get; set; } = DateTime.Now;
        public int EmployeeRef { get; set; } = 0;
    }
}
