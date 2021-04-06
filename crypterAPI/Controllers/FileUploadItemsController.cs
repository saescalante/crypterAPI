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
//    public class FileUploadItemsController : ControllerBase
//    {
//        private readonly FileUploadItemContext _context;

//        public FileUploadItemsController(FileUploadItemContext context)
//        {
//            _context = context;
//        }

//        // GET: api/FileUploadItems
//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<FileUploadItem>>> GetFileUploadItems()
//        {
//            return await _context.FileUploadItems.ToListAsync();
//        }

//        // GET: api/FileUploadItems/5
//        [HttpGet("{id}")]
//        public async Task<ActionResult<FileUploadItem>> GetFileUploadItem(long id)
//        {
//            var fileUploadItem = await _context.FileUploadItems.FindAsync(id);

//            if (fileUploadItem == null)
//            {
//                return NotFound();
//            }

//            return fileUploadItem;
//        }

//        // PUT: api/FileUploadItems/5
//        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
//        [HttpPut("{id}")]
//        public async Task<IActionResult> PutFileUploadItem(long id, FileUploadItem fileUploadItem)
//        {
//            if (id != fileUploadItem.Id)
//            {
//                return BadRequest();
//            }

//            _context.Entry(fileUploadItem).State = EntityState.Modified;

//            try
//            {
//                await _context.SaveChangesAsync();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!FileUploadItemExists(id))
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

//        // POST: api/FileUploadItems
//        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
//        [HttpPost]
//        public async Task<ActionResult<FileUploadItem>> PostFileUploadItem(FileUploadItem fileUploadItem)
//        {
//            _context.FileUploadItems.Add(fileUploadItem);
//            await _context.SaveChangesAsync();

//            //return CreatedAtAction("GetFileUploadItem", new { id = fileUploadItem.Id }, fileUploadItem);
//            return CreatedAtAction(nameof(GetFileUploadItem), new { id = fileUploadItem.Id }, fileUploadItem);
//        }

//        // DELETE: api/FileUploadItems/5
//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeleteFileUploadItem(long id)
//        {
//            var fileUploadItem = await _context.FileUploadItems.FindAsync(id);
//            if (fileUploadItem == null)
//            {
//                return NotFound();
//            }

//            _context.FileUploadItems.Remove(fileUploadItem);
//            await _context.SaveChangesAsync();

//            return NoContent();
//        }

//        private bool FileUploadItemExists(long id)
//        {
//            return _context.FileUploadItems.Any(e => e.Id == id);
//        }
//    }
//}
