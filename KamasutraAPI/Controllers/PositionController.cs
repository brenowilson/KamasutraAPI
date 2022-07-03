using KamasutraAPI.Context;
using KamasutraAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KamasutraAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionController : ControllerBase
    {
        private readonly KamasutraContext _context;
        public PositionController(KamasutraContext context)
        {
            _context = context;
        }

        // GET: api/<PositionController>
        [HttpGet]
        public async Task<ActionResult<List<Position>>> Get()
        {
            return Ok(await _context.Position.Include("Action").Include("BodyPart").ToListAsync());
        }

        // GET api/<PositionController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Position>> Get(int id)
        {
            var position = await _context.Position.Include("Action")
                                            .Include("BodyPart")
                                            .Where(p => p.Id == id)
                                            .FirstOrDefaultAsync();
            return Ok(position);
        }

        // POST api/<PositionController>
        [HttpPost]
        public async Task<ActionResult> Post()
        {
            var action = await PickAction();
            var bodyPart = await PickBodyPart(action);

            var position = new Position
            {
                Action = action,
                BodyPart = bodyPart,
                CreatedDate = DateTime.Now.ToUniversalTime(),
                Duration = new Random().Next(1, 6),
            };

            await _context.Position.AddAsync(position);
            await _context.SaveChangesAsync();

            return Ok(position);
        }

        private async Task<KamasutraAction> PickAction()
        {
            var random = new Random();

            var actionList = await _context.KamasutraAction.ToListAsync();

            var action = actionList[random.Next(actionList.Count)];

            return action;
        }

        private async Task<BodyPart> PickBodyPart(KamasutraAction action)
        {
            var random = new Random();

            var bodyPartList = await _context.BodyPart.ToListAsync();

            if (action.Description.ToLower().Contains("penetrar"))
            {
                foreach (var bp in bodyPartList)
                {
                    var part = bodyPartList[random.Next(bodyPartList.Count)];

                    if (part.Id == 3 || part.Id == 12 || part.Id == 13)
                    {
                        return part;
                    }
                }
            }

            var bodyPart = bodyPartList[random.Next(bodyPartList.Count)];

            return bodyPart;
        }
    }
}
