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

        // GET: api/UploadItems
        [HttpGet]
        public async Task<IActionResult> GetUploadItems()
        {
            await Db.Connection.OpenAsync();
            var query = new UploadItemQuery(Db);
            var result = await query.LatestItemsAsync();
            return new OkObjectResult(result);
        }

        // GET: api/UploadItems/5
        [HttpGet("{id}")]
        public async Task<IActionResult>GetUploadItem(int id)
        {
            await Db.Connection.OpenAsync();
            var query = new UploadItemQuery(Db);
            var result = await query.FindOneAsync(id);
            if (result is null)
                return new NotFoundResult();
            return new OkObjectResult(result);
        }

        // PUT: api/UploadItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUploadItem(int id, [FromBody]UploadItem body)
        {
            await Db.Connection.OpenAsync();
            var query = new UploadItemQuery(Db);
            var result = await query.FindOneAsync(id);
            if (result is null)
                return new NotFoundResult();
            //update fields
            result.UntrustedName = body.UntrustedName;
            result.UserID = body.UserID;
            result.Size = body.Size;
            
            await result.UpdateAsync();
            return new OkObjectResult(result);
           
        }



        // DELETE: api/UploadItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUploadItem(int id)
        {
            await Db.Connection.OpenAsync();
            var query = new UploadItemQuery(Db);
            var result = await query.FindOneAsync(id);
            if (result is null)
                return new NotFoundResult();
            await result.DeleteAsync();
            return new OkResult(); 
        }


        // DELETE api/blog
        [HttpDelete]
        public async Task<IActionResult> DeleteAll()
        {
            await Db.Connection.OpenAsync();
            var query = new UploadItemQuery(Db);
            await query.DeleteAllAsync();
            return new OkResult();
        }


    }
}
