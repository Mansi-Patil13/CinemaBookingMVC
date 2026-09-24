namespace CinemaBookingMVC.Extensions;

public static class CinemaExtensions
{
    // Determines booking status based on cancellation date, current date, and show date
    public static string GetBookingStatus(this Booking booking)
    {
        if (booking.CancellationDate.HasValue)
        {
            return "Cancelled";
        }

        var today = DateTime.Today;
        var showDate = booking.ShowDate.Date;

        if (showDate < today)
        {
            return "Completed";
        }
        else if (showDate == today)
        {
            return "Today";
        }
        else
        {
            return "Upcoming";
        }
    }

    // Calculates total ticket price
    public static decimal CalculateTotalAmount(this Booking booking, List<Movie> movies)
    {
        var movie = movies.FirstOrDefault(m => m.MovieId == booking.MovieId);
        if (movie == null) return 0;

        return booking.NumberOfTickets * movie.TicketPrice;
    }
}
