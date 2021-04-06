//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using CrypterAPI.Models;

//namespace CrypterAPI.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class TextUploadItemsController : ControllerBase
//    {
//        private readonly TextUploadItemContext _context;

//        public TextUploadItemsController(TextUploadItemContext context)
//        {
//            _context = context;
//        }

//        // GET: api/TextUploadItems
//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<TextUploadItem>>> GetTextUploadItems()
//        {
//            return await _context.TextUploadItems.ToListAsync();
//        }

//        // GET: api/TextUploadItems/5
//        [HttpGet("{id}")]
//        public async Task<ActionResult<TextUploadItem>> GetTextUploadItem(long id)
//        {
//            var textUploadItem = await _context.TextUploadItems.FindAsync(id);

//            if (textUploadItem == null)
//            {
//                return NotFound();
//            }

//            return textUploadItem;
//        }

//        // PUT: api/TextUploadItems/5
//        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
//        [HttpPut("{id}")]
//        public async Task<IActionResult> PutTextUploadItem(long id, TextUploadItem textUploadItem)
//        {
//            if (id != textUploadItem.Id)
//            {
//                return BadRequest();
//            }

//            _context.Entry(textUploadItem).State = EntityState.Modified;

//            try
//            {
//                await _context.SaveChangesAsync();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!TextUploadItemExists(id))
//                {
//                    return NotFound();
//                }
//                else
//                {
//                    throw;
//                }
//            }

//            return NoContent();
//        }

//        // POST: api/TextUploadItems
//        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
//        [HttpPost]
//        public async Task<ActionResult<TextUploadItem>> PostTextUploadItem(TextUploadItem textUploadItem)
//        {
//            _context.TextUploadItems.Add(textUploadItem);
//            await _context.SaveChangesAsync();

//            //return CreatedAtAction("GetTextUploadItem", new { id = textUploadItem.Id }, textUploadItem);
//            return CreatedAtAction(nameof(GetTextUploadItem), new { id = textUploadItem.Id }, textUploadItem);
//        }

//        // DELETE: api/TextUploadItems/5
//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeleteTextUploadItem(long id)
//        {
//            var textUploadItem = await _context.TextUploadItems.FindAsync(id);
//            if (textUploadItem == null)
//            {
//                return NotFound();
//            }

//            _context.TextUploadItems.Remove(textUploadItem);
//            await _context.SaveChangesAsync();

//            return NoContent();
//        }

//        private bool TextUploadItemExists(long id)
//        {
//            return _context.TextUploadItems.Any(e => e.Id == id);
//        }
//    }
//}
