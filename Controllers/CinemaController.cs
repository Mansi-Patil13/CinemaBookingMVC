namespace CinemaBookingMVC.Controllers;

public class CinemaController : Controller
{
    // In-memory data storage for demonstration purposes
    public static List<Movie> Movies = new List<Movie>
    {
        new Movie { MovieId = 1, MovieName = "Inception", Genre = "Sci-Fi", Language = "English", TicketPrice = 250.00m, AvailableSeats = 50 },
        new Movie { MovieId = 2, MovieName = "Interstellar", Genre = "Sci-Fi", Language = "English", TicketPrice = 300.00m, AvailableSeats = 30 },
        new Movie { MovieId = 3, MovieName = "RRR", Genre = "Action", Language = "Telugu", TicketPrice = 200.00m, AvailableSeats = 100 }
    };

    public static List<Booking> Bookings = new List<Booking>
    {
        new Booking { BookingId = 1, CustomerName = "Rahul Sharma", Email = "rahul@example.com", Phone = "9876543210", MovieId = 1, BookingDate = DateTime.Now.AddDays(-2), ShowDate = DateTime.Today.AddDays(-1), NumberOfTickets = 2 },
        new Booking { BookingId = 2, CustomerName = "Priya Patel", Email = "priya@example.com", Phone = "9876543211", MovieId = 2, BookingDate = DateTime.Now, ShowDate = DateTime.Today, NumberOfTickets = 3 },
        new Booking { BookingId = 3, CustomerName = "Amit Kumar", Email = "amit@example.com", Phone = "9876543212", MovieId = 3, BookingDate = DateTime.Now, ShowDate = DateTime.Today.AddDays(2), NumberOfTickets = 4 }
    };

    // GET: /Cinema/Index
    public IActionResult Index()
    {
        ViewBag.Movies = Movies;
        return View(Bookings);
    }

    // GET: /Cinema/BookTicket
    public IActionResult BookTicket()
    {
        ViewBag.Movies = Movies;
        return View();
    }

    // POST: /Cinema/BookTicket
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult BookTicket(Booking booking)
    {
        if (ModelState.IsValid)
        {
            booking.BookingId = Bookings.Count > 0 ? Bookings.Max(b => b.BookingId) + 1 : 1;
            booking.BookingDate = DateTime.Now;
            Bookings.Add(booking);

            TempData["SuccessMessage"] = "Ticket booked successfully!";
            return RedirectToAction(nameof(Index));
        }

        ViewBag.Movies = Movies;
        return View(booking);
    }

    // GET: /Cinema/MovieDetails/1
    public IActionResult MovieDetails(int id)
    {
        var booking = Bookings.FirstOrDefault(b => b.BookingId == id);
        if (booking == null)
        {
            return NotFound();
        }

        var movie = Movies.FirstOrDefault(m => m.MovieId == booking.MovieId);
        ViewBag.Movie = movie;
        ViewBag.Movies = Movies;

        return View(booking);
    }

    // GET: /Cinema/About
    public IActionResult About()
    {
        return View();
    }
}
