using APINewsFeed.BLL.DTO.UserDTOs;
using APINewsFeed.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace APINewsFeed.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository) => _userRepository = userRepository;

        /// <summary>
        /// Получить пользователя по id
        /// </summary>
        /// <response code="400">Пользователь с таким id не найден</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserDTO))]
        public async Task<ActionResult> GetUserById([FromQuery] GetUserDTO getUserDTO)
        {
            var user = await _userRepository.GetUser(getUserDTO.id);
            if (user == null) return BadRequest("Пользователь с таким id не найден");
            return Ok(user);
        }
        /// <summary>
        /// Получить пользователя по имени
        /// </summary>
        /// <response code="400">Пользователь с таким именем не найден</response>
        [HttpGet("get")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserDTO))]
        public async Task<ActionResult> GetUsers([FromQuery] GetUsersDTO getUsersDTO)
        {
            var users = await _userRepository.GetUsers(getUsersDTO);
            if (users == null) return BadRequest("Пользователь с таким именем не найден");
            return Ok(users);
        }
        /// <summary>
        /// Регистрация пользователя
        /// </summary>
        /// <response code="200">Возвращает идентификатор созданного пользователя</response>
        /// <response code="400">Такой пользователь уже существует</response>
        [HttpPost("register")]
        public async Task<ActionResult> UserRegistration([FromForm] UserRegistrationDTO userRegistrationDTO)
        {
           var id = await _userRepository.UserRegistration(userRegistrationDTO);
           if (id == Guid.Empty) return BadRequest("Такой пользователь уже существует");
            return Ok(new { id = id });
        }
        /// <summary>
        /// Авторизация пользователя
        /// </summary>
        /// <response code="200">Возвращает идентификатор созданного пользователя</response>
        /// <response code="400">Имя или пароль введены неверно</response>
        [HttpPost("auth")]
        public async Task<ActionResult> UserAuthorization([FromForm] UserAuthorizationDTO userAuthorizationDTO)
        {
            var id = await _userRepository.UserAuthorization(userAuthorizationDTO);
            if (id == Guid.Empty) return BadRequest("Имя или пароль введены неверно");
            return Ok(new { id = id });
        }

        /// <summary>
        /// Удалить пользователя
        /// </summary>
        /// <response code="200">Возвращает идентификатор удалённого пользователя</response>
        /// <response code="400">Пользователь с таким id не найден</response>
        [HttpDelete("delete")]
        public async Task<ActionResult> DeleteUser([FromForm] DeleteUserDTO deleteUserDTO)
        {
            var id = await _userRepository.DeleteUser(deleteUserDTO.id);
            if (id == Guid.Empty) return BadRequest("Такого пользователя не существует");
            return Ok(new { id = id });
        }

        /// <summary>
        /// Обновление пользователя
        /// </summary>
        /// <response code="400">Такого пользователя не существует</response>
        [HttpPut("update")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UpdateUserDTO))]
        public async Task<ActionResult> UpdateUser([FromForm] UpdateUserDTO updateUserDTO)
        {
            var user = await _userRepository.UpdateUser(updateUserDTO);
            if (user == null) return BadRequest("Такого пользователя не существует");
            return Ok(user);
        }
    }
}
