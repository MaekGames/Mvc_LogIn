using Microsoft.AspNetCore.Mvc;

namespace WebAppTask.Controllers
{
    public class LoginController : Controller
    {
       // private readonly NwabContext _context;

        //private readonly BankEngine _engine;

        /*public LoginController(NwabContext context)
        {
            _context = context;
            _engine = new BankEngine(_context);
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View("Login");
        }

        [HttpPost]
        public async Task<IActionResult> Login(string userID, string password)
        {
            //Check if a login of given number exists in the database
            var login = await _context.Logins.FirstOrDefaultAsync(x => x.UserID.Equals(userID));

            if (login == null || !PBKDF2.Verify(login.Password, password))
                ModelState.AddModelError("LoginFailed", "Unsuccessful login attempt");

            if (!ModelState.IsValid)
                return View();

            var customer = await _context.Customers.FirstOrDefaultAsync(x => x.CustomerID == login.CustomerID);

            //Set session customer
            HttpContext.Session.SetInt32(nameof(Customer.CustomerID), login.CustomerID);
            HttpContext.Session.SetString(nameof(Customer.CustomerName), customer.CustomerName);

            return RedirectToAction("Index", "Accounts");
        }

        [Route("Logout")]
        public IActionResult Logout()
        {
            // Logout customer.
            HttpContext.Session.Clear();

            return RedirectToAction("Index", "Home");
        }*/
    }
}
