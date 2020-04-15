using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EFCoreApp.Models;

namespace EFCoreApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonDetailsController : ControllerBase
    {
        private readonly StorageDBContext _context;

        public PersonDetailsController(StorageDBContext context)
        {
            _context = context;
        }

        // GET: api/PersonDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonDetails>>> GetPersonDetails()
        {

            return await _context.PersonDetails.FromSqlRaw("[dbo].[GetPersonDetails]").ToListAsync();
        }
        
    }
}
