using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CrypterAPI.Models;


namespace CrypterAPI.Controllers
{
    [Route("api/[controller]")]
    //[ApiController]
    public class UploadItemsController : ControllerBase
    {
        //private readonly UploadItemContext _context;

        public CrypterDB Db { get; }

        public UploadItemsController(CrypterDB db)
        {
            Db = db; 
        }


        // POST: api/UploadItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult>PostUploadItem([FromBody]UploadItem body)
        {
            await Db.Connection.OpenAsync();
            body.Db = Db;
            await body.InsertAsync();
            return new OkObjectResult(body);
        }

        //// GET: api/UploadItems
        //[HttpGet]
        //public async Task<IActionResult> GetUploadItems()
        //{
        //    await Db.Connection.OpenAsync();
        //    var query = new BlogPostQuery(Db);
        //    var result = await query.LatestPostsAsync();
        //    return new OkObjectResult(result);
        //}

        //// GET: api/UploadItems/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<UploadItem>> GetUploadItem(long id)
        //{
        //    var uploadItem = await _context.UploadItems.FindAsync(id);

        //    if (uploadItem == null)
        //    {
        //        return NotFound();
        //    }

        //    return uploadItem;
        //}

        //// PUT: api/UploadItems/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutUploadItem(long id, UploadItem uploadItem)
        //{
        //    if (id != uploadItem.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(uploadItem).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!UploadItemExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}



        //// DELETE: api/UploadItems/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteUploadItem(long id)
        //{
        //    var uploadItem = await _context.UploadItems.FindAsync(id);
        //    if (uploadItem == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.UploadItems.Remove(uploadItem);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

    }
}
