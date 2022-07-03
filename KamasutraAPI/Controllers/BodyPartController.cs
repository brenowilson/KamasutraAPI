using KamasutraAPI.Context;
using KamasutraAPI.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KamasutraAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BodyPartController : ControllerBase
    {
        private readonly KamasutraContext _context;
        public BodyPartController(KamasutraContext context)
        {
            _context = context;
        }

        // GET: api/<BodyPartController>
        [HttpGet]
        public ActionResult<List<BodyPart>> Get()
        {
            return Ok(_context.BodyPart.ToList());
        }

        // GET api/<BodyPartController>/5
        [HttpGet("{id}")]
        public ActionResult<BodyPart> Get(int id)
        {
            var bodyPart = _context.BodyPart.Where(bp => bp.Id == id)
                                                .FirstOrDefault();

            return Ok(bodyPart);
        }
    }
}
