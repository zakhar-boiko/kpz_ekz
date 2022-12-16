using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamKpz.Data;
using ExamKpz.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExamKpz.Controllers
{
    [Route("Kpz/[controller]")]
    [ApiController]
    public class LawCaseController : ControllerBase
    {
        private readonly DataContext _context;

        public LawCaseController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LawCase>>> GetLawCases()
        {
            return await _context.LawCases.Include(l => l.Documents).Include(l => l.Comments).ToListAsync();

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LawCase>> GetLawCase(int id)
        {
            var lawCase = await _context.LawCases.Include(l => l.Documents).Include(l => l.Comments).FirstOrDefaultAsync(l => l.Id == id);

            if (lawCase == null)
            {
                return NotFound();
            }

            return await _context.LawCases.Include(l => l.Documents).Include(l => l.Comments).FirstOrDefaultAsync(l => l.Id == id); ;
        }
        [HttpGet("search/{searchTerm}")]
        public async Task<ActionResult<IEnumerable<LawCase>>> GetByDocumentName(string searchTerm)
        {
            //Шукаю справи, в яких назва хоч одного документа містить searchTerm
            var lawCases =  await _context.LawCases.Include(l => l.Documents).Include(l => l.Comments).Where(l => l.Documents.Any(d => d.Name.Contains(searchTerm))).ToListAsync();

            if (lawCases == null)
            {
                return NotFound();
            }

            return lawCases;
        }
        [HttpPost]
        public async Task<ActionResult<IEnumerable<LawCase>>> AddLawCase(LawCase lawCase)
        {
            if (lawCase == null)
            {
                return NotFound();
            }
            _context.LawCases.Add(lawCase);
            await _context.SaveChangesAsync();
            return await _context.LawCases.Include(l => l.Documents).Include(l => l.Comments).ToListAsync();
        }
        [HttpPut]
        public async Task<ActionResult<IEnumerable<LawCase>>> UpdateLawCase(LawCase lawCase)
        {

            var lawCaseDb = await _context.LawCases.FirstOrDefaultAsync(l => l.Id == lawCase.Id);
            if (lawCaseDb == null)
            {
                return NotFound();
            }

            lawCaseDb.Id = lawCase.Id;
            lawCaseDb.Name = lawCase.Name;
            lawCaseDb.Documents = lawCase.Documents;
            lawCaseDb.Comments = lawCase.Comments;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LawCaseExists(lawCaseDb.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return await _context.LawCases.Include(l => l.Documents).Include(l => l.Comments).ToListAsync();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<IEnumerable<LawCase>>> DeleteLawCase(int id)
        {
            var lawCase = await _context.LawCases.FindAsync(id);
            if (lawCase == null)
            {
                return NotFound();
            }

            _context.LawCases.Remove(lawCase);
            await _context.SaveChangesAsync();
            return await _context.LawCases.Include(l => l.Documents).Include(l => l.Comments).ToListAsync();
        }
        private bool LawCaseExists(int id)
        {
            return _context.LawCases.Any(l => l.Id == id);
        }
        
    }
}
