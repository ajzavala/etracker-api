using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using etracker_api.Models;
using Microsoft.AspNetCore.Authorization;

namespace etracker_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class GraphDataController : ControllerBase
    {
        private readonly etrackerContext _context;

        public GraphDataController(etrackerContext context)
        {
            _context = context;
        }


        // GET: api/Users/email@email.com
        [HttpGet("{user_id}")]
        [Authorize]
        public async Task<IEnumerable<SpGraphData>> GetData(int user_id)
        {
            
            var GraphData = await _context.GraphDatas.FromSqlRaw("GraphData " + user_id).ToArrayAsync();
            
            return GraphData;
        }

        
    }
}
