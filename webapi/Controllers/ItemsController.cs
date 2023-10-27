using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using webapi.DTOs;
using webapi.Interfaces;

namespace webapi.Controllers
{
    //[Authorize]
    [Route("api/[controller]/[action]")]
    public class ItemsController : Controller
    {
        private readonly ILogger<ItemsController> _logger;
        private readonly IItemsRepository _itemsRepository;
        private readonly IMapper _mapper;

        public ItemsController(ILogger<ItemsController> logger, IItemsRepository itemsRepository, IMapper mapper)
        {
            _logger = logger;
            _itemsRepository = itemsRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemDTO>>> GetItems()
        {
            var items = await _itemsRepository.GetAllItemsAsync();
            return Ok(_mapper.Map<IEnumerable<ItemDTO>>(items));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ItemDTO>> GetItemById(int id)
        {
            var item = await _itemsRepository.GetItemByIdAsync(id);
            return _mapper.Map<ItemDTO>(item);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<ItemDTO>>> GetUserItems(int id)
        {
            var items = await _itemsRepository.GetUserItemsByIdAsync(id);
            return Ok(_mapper.Map<IEnumerable<ItemDTO>>(items));
        }
        //[HttpGet] // api/users/getusers
        //public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsers()
        //{
        //    var users = await _userRepository.GetUsersAsync();
        //    return Ok(_mapper.Map<IEnumerable<UserDTO>>(users));
        //}

        //[HttpGet("{id}")] // api/users/getuser/2
        //public async Task<ActionResult<UserDTO>> GetUser(int id)
        //{
        //    var user = await _userRepository.GetUserByIdAsync(id);
        //    return _mapper.Map<UserDTO>(user);
        //}
    }
}
