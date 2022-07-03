using KamasutraAPI.Context;
using KamasutraAPI.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KamasutraAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KamasutraActionController : ControllerBase
    {
        private readonly KamasutraContext _context;
        public KamasutraActionController(KamasutraContext context)
        {
            _context = context;
        }

        // GET: api/<KamasutraActionController>
        [HttpGet]
        public ActionResult<List<KamasutraAction>> Get()
        {
            return Ok(_context.KamasutraAction.ToList());
        }

        // GET api/<KamasutraActionController>/5
        [HttpGet("{id}")]
        public ActionResult<KamasutraAction> Get(int id)
        {
            var action = _context.KamasutraAction.Where(a => a.Id == id)
                                                .FirstOrDefault();
            return Ok(action);
        }
    }
}
