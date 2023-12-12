using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using webapi.DTOs;
using webapi.Interfaces;
using webapi.Models;
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
            Console.WriteLine("------ Get next matchable");
            var items = await _matchesRepository.GetMatchableItems(userId, itemId);
            if(items == null || items.Count() <= 0) 
            {
                return null;
            }

            var item = _matchingAlgorithmService.GetNextItem(items);
            return _mapper.Map<ItemDTO>(item);
        }

        [HttpGet("{itemId}/{targetItemId}")]
        public async Task<ActionResult<bool>> SendLike(int itemId, int targetItemId)
        {
            Console.WriteLine("------ Send like");

            var match = await _matchesRepository.AreMatched(itemId, targetItemId);
            if (match != null)
                return BadRequest("Items are already matched");

            if(await _matchesRepository.IsLiked(targetItemId, itemId))
            {
                //successfuly matched
                await _matchesRepository.CreateMatch(itemId, targetItemId, true);
                await _matchesRepository.DeleteLikes(itemId, targetItemId);
                return true;
            }

            if(await _matchesRepository.IsDisliked(targetItemId, itemId))
            {
                await _matchesRepository.CreateMatch(itemId, targetItemId, false);
                await _matchesRepository.DeleteLikes(itemId, targetItemId);
                return false;
            }

            await _matchesRepository.CreateLike(itemId, targetItemId);
            return false;
        }

        [HttpGet("{itemId}/{targetItemId}")]
        public async Task<ActionResult> SendDislike(int itemId, int targetItemId)
        {
            var match = await _matchesRepository.AreMatched(itemId, targetItemId);
            if (match != null)
                return BadRequest("Items are already matched");

            bool liked = await _matchesRepository.IsLiked(targetItemId, itemId);
            bool disliked = await _matchesRepository.IsDisliked(targetItemId, itemId);

            if(liked || disliked)
            {
                await _matchesRepository.CreateMatch(itemId, targetItemId, false);
                await _matchesRepository.DeleteLikes(itemId, targetItemId);
                return Ok();
            }

            await _matchesRepository.CreateDislike(itemId, targetItemId);
            return Ok();
        }

        public async Task<ActionResult<IEnumerable<MatchDTO>>> GetUserMatches(int userId)
        {
            var matches = await _matchesRepository.GetUserMatches(userId);
            return Ok(_mapper.Map<IEnumerable<MatchDTO>>(matches));
        }
    }
}
