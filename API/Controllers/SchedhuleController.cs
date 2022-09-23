using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using API.Data;
using API.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchedhuleController : ControllerBase
    {
        private readonly ILogger<Controller> _logger;
        private readonly DataContext _context;

        public SchedhuleController(ILogger<Controller> logger, DataContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<Schedhule>> GetSchedhules()
        {
            return _context.Schedhules.ToList<Schedhule>();
        }

          [HttpGet("{id}")]
        public ActionResult<Schedhule> GetSchedhule(long id)
        {
            var result = _context.Schedhules.FirstOrDefault(x => x.ID == id);

            if(result== null){
                return NotFound();
            }
            return result;
        }
    }

}