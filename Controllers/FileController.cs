using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIService.Data;
using APIService.Models;
using APIService.Repository;

namespace APIService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IFileService _fileService;

        public FileController(ApplicationDbContext context, IFileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }

        // GET: api/File
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Userfile>>> GetUserfiles()
        {
            return await _context.Userfiles.ToListAsync();
        }

        // GET: api/File/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Userfile>> GetUserfile(int id)
        {
            var userfile = await _context.Userfiles.FindAsync(id);

            if (userfile == null)
            {
                return NotFound();
            }

            return userfile;
        }

        // PUT: api/File/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserfile(int id, Userfile userfile)
        {
            if (id != userfile.FileId)
            {
                return BadRequest();
            }

            _context.Entry(userfile).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserfileExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/File
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult PostUserfile([FromForm] Userfile userfile)
        {
            _fileService.uploadFile(userfile);
            return CreatedAtAction("GetUserfile", new { id = userfile.FileId }, userfile);
        }

        // DELETE: api/File/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserfile(int id)
        {
            var userfile = await _context.Userfiles.FindAsync(id);
            if (userfile == null)
            {
                return NotFound();
            }

            _context.Userfiles.Remove(userfile);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserfileExists(int id)
        {
            return _context.Userfiles.Any(e => e.FileId == id);
        }
    }
}
