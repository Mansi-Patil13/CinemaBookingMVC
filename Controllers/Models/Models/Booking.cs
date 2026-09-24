namespace CinemaBookingMVC.Models;

public class Booking
{
    public int BookingId { get; set; }

    [Required(ErrorMessage = "Customer Name is required")]
    public string CustomerName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid Email Address")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Phone number is required")]
    [Phone(ErrorMessage = "Invalid Phone Number")]
    public string Phone { get; set; } = string.Empty;

    [Required(ErrorMessage = "Please select a Movie ID")]
    public int MovieId { get; set; }

    [DataType(DataType.Date)]
    public DateTime BookingDate { get; set; } = DateTime.Now;

    [Required(ErrorMessage = "Show Date is required")]
    [DataType(DataType.Date)]
    public DateTime ShowDate { get; set; }

    [Required(ErrorMessage = "Number of tickets is required")]
    [Range(1, 10, ErrorMessage = "You can book between 1 and 10 tickets")]
    public int NumberOfTickets { get; set; }

    [DataType(DataType.Date)]
    public DateTime? CancellationDate { get; set; }
}
