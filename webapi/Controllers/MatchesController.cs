using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using webapi.DTOs;
using webapi.Interfaces;
using webapi.Repositories;

namespace webapi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class MatchesController : Controller
    {
        private readonly ILogger<MatchesController> _logger;
        private readonly IMatchesRepository _matchesRepository;
        private readonly IMapper _mapper;
        private readonly IMatchingAlgorithmService _matchingAlgorithmService;

        public MatchesController(
            ILogger<MatchesController> logger,
            IMatchesRepository matchesRepository,
            IMapper mapper,
            IMatchingAlgorithmService matchingAlgorithmService)
        {
            _logger = logger;
            _matchesRepository = matchesRepository;
            _mapper = mapper;
            _matchingAlgorithmService = matchingAlgorithmService;
        }

        [HttpGet("{userId}/{itemId}")]
        public async Task<ActionResult<IEnumerable<ItemDTO>>> GetMatchableItems(int userId, int itemId)
        {
            var items = await _matchesRepository.GetMatchableItems(userId, itemId);
            return Ok(_mapper.Map<IEnumerable<ItemDTO>>(items));
        }

        [HttpGet("{userId}/{itemId}")]
        public async Task<ActionResult<ItemDTO>> GetNextMatchable(int userId, int itemId)
        {
            var items = await _matchesRepository.GetMatchableItems(userId, itemId);
            var item = _matchingAlgorithmService.GetNextItem(items);
            return _mapper.Map<ItemDTO>(item);
        }
    }
}
