using autosalon.Models;
using autosalon.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace autosalon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ICarService _carService;
        private readonly IOrderService _orderService;

        public AdminController(
            IUserService userService,
            ICarService carService,
            IOrderService orderService
            )
        {
            _userService = userService;
            _carService = carService;
            _orderService = orderService;
        }

        [HttpGet("index")]
        public async Task<IActionResult> Index()
        {
            if (Request.Cookies.ContainsKey("EMAIL"))
            {
                string email = Request.Cookies["EMAIL"];
                var currentUser = await _userService.FindUserByEmail(email);

                if (currentUser != null && currentUser.IsAdmin)
                {
                    return Ok("Welcome Admin");
                }
                else
                {
                    return Forbid("Access Denied");
                }
            }

            return Unauthorized("User is not authenticated");
        }


        [HttpPost("addcar")]
        public async Task<IActionResult> AddCar(Car model)
        {
            if (ModelState.IsValid)
            {
                var car = new Car()
                {
                    CarName = model.CarName,
                    Model = model.Model,
                    Color = model.Color,
                    ReleaseDate = model.ReleaseDate,
                    VinNumber = model.VinNumber,
                    Price = model.Price
                };
                await _carService.AddCar(car);
                return Ok(car);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPost("addUser")]
        public async Task<IActionResult> AddUser(User user)
        {
            var userAlreadyExists = _userService.ExistUser(user.Email);
            if (userAlreadyExists)
            {
                return BadRequest("User already exists!");
            }
            var newUser = new User()
            {
                Name = user.Name,
                Surname = user.Surname,
                BirthDate = user.BirthDate,
                Phone = user.Phone,
                Email = user.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(user.Password),
                IsAdmin = user.IsAdmin
            };
            await _userService.CreateUser(newUser);
            return Ok(newUser);
        }

        [HttpGet("orders")]
        public async Task<IActionResult> OrdersList()
        {
            var orders = await _orderService.GetOrders();

            if (orders != null && orders.Any())
            {
                return Ok(orders);
            }
            else
            {
                return NotFound("No orders found");
            }
        }

        [HttpGet("cars")]
        public async Task<IActionResult> CarsList()
        {
            var cars = await this._carService.GetCars();

            if (cars != null && cars.Any())
            {
                return Ok(cars);
            }
            else
            {
                return Ok(new List<Car>());
            }
        }

        [HttpGet("users")]
        public async Task<IActionResult> UsersList()
        {
            var users = await this._userService.GetUsers();

            if (users != null && users.Any())
            {
                return Ok(users);
            }
            else
            {
                return Ok(new List<User>());
            }
        }

        [HttpDelete("DeleteCar/{id:int}")]
        public async Task<IActionResult> DeleteCar(int id)
        {
            var car = await _carService.FindCarById(id);
            if (car is not null)
            {
                await _carService.DeleteCar(id);
            }
            return Ok();
        }

        [HttpDelete("DeleteUser/{id:int}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _userService.FindUserById(id);
            if (user is not null)
            {
                await _userService.DeleteUser(id);
            }
            return Ok();
        }

        [HttpDelete("DeleteOrder/{id:int}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var order = await _orderService.FindOrderById(id);
            if (order is not null)
            {
                await _orderService.DeleteOrder(id);
            }
            return Ok();
        }
    }
}
