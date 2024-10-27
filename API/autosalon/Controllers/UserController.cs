using autosalon.Models;
using autosalon.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace autosalon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ICarService _carService;
        private readonly IOrderService _orderService;

        public UserController(
            IUserService userService,
            ICarService carService,
            IOrderService orderService
            )
        {
            _userService = userService;
            _carService = carService;
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<IActionResult> Register(User user)
        {
            var userAlreadyExists = _userService.ExistUser(user.Email);
            if (userAlreadyExists) {
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
                return NotFound("No users found");
            }
        }


        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _userService.FindUserById(id);
            if (user is not null)
            {
                await _userService.DeleteUser(id);
            }
            return Ok();
        }

        [HttpPut("updateUser/{id}")]
        public async Task<IActionResult> UpdateUserProfile(int id, UpdatedUser model)
        {
            var currentUser = await _userService.FindUserById(id);

            if (currentUser != null)
            {
                if (model.Name != null) { currentUser.Name = model.Name; }
                if (model.Surname != null) { currentUser.Surname = model.Surname; }
                if (model.Phone != null) { currentUser.Phone = model.Phone; }
                if (model.Email != null) { currentUser.Email = model.Email; }
                if (model.BirthDate != null) { currentUser.BirthDate = (DateTime)model.BirthDate; }
                if (!string.IsNullOrEmpty(model.Password))
                {
                    currentUser.Password = BCrypt.Net.BCrypt.HashPassword(model.Password);
                }

                _userService.UpdateUser(currentUser);
            }
            else
            {
                return NotFound();
            }


            return Ok();
    }

        private bool VerifyPassword(string enteredPassword, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(enteredPassword, hashedPassword);
        }

        [HttpPost("signIn")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            if (model == null || string.IsNullOrEmpty(model.Email) || string.IsNullOrEmpty(model.Password))
                return BadRequest("Invalid login request");

            var user = await _userService.FindUserByEmail(model.Email);

            if (user == null || !VerifyPassword(model.Password, user.Password))
                return Unauthorized("Invalid email or password");

            var response = new
            {
                isAuthenticated = true,
                user = new
                {
                    user.Id,
                    user.Name,
                    user.Surname,
                    user.Email,
                    user.Password,
                    user.Phone,
                    user.BirthDate,
                    user.IsAdmin
                }
            };

            return Ok(response);
        }

        [HttpGet("profile/{id}")]
        public async Task<IActionResult> GetUserProfile(int id)
        {
            var user = await _userService.FindUserById(id);

            if (user == null)
                return NotFound("User not found");

            var response = new
            {
                user.Id,
                user.Name,
                user.Surname,
                user.Email,
                user.Password,
                user.Phone,
                user.BirthDate,
                user.IsAdmin
            };

            return Ok(response);
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

        [HttpPost("addOrder")]
        public async Task<IActionResult> CreateUser(Order order)
        {
            var newOrder = new Order()
            {
                OrderDate = order.OrderDate,
                CarId = order.CarId,
                UserId = order.UserId
            };
            await _orderService.CreateOrder(order);
            return Ok(newOrder);
        }

    }
}
