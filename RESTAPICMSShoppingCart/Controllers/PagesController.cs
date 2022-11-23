using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RESTAPICMSShoppingCart.Models;

namespace RESTAPICMSShoppingCart.Controllers
{
    /// <summary>
    /// 1xx Informational 
    /// 2xx Success - 200 Ok, 201 Created,  202 Accepted, 204 No Content
    /// 3xx Redirection - 301 Moved Permanently, 302 Found, 303 See other, 304 Not Modified,  
    /// 4xx Client Error - 400 Bad Request, 401 Unathorized, 404 Not Found 
    /// 5xx Server Error 
    /// </summary>


    [Route("api/[controller]")]
    [ApiController]
    public class PagesController : ControllerBase
    {
        private readonly CMSShoppingCartContext context;

        public PagesController(CMSShoppingCartContext context)
        {
            this.context = context;
        }

        // GET /api/pages 
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Page>>> GetPages()
        {
            return await context.Pages.OrderBy(x => x.Sorting).ToListAsync();
        }

        // GET /api/pages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Page>> GetPage(int id)
        {
            var page = await context.Pages.FindAsync(id);
            if (page == null)
            {
                return NotFound();
            }
            return page;
        }
        
        // PUT /api/pages/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Page>> PutPage(int id, Page page)
        {
            if (id != page.Id)
            {
                return BadRequest();
            }
            context.Entry(page).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent(); // 204
        }
        
        // POST /api/pages
        [HttpPost]
        public async Task<ActionResult<Page>> PostPage(Page page)
        {
            context.Pages.Add(page);
            await context.SaveChangesAsync();
            return CreatedAtAction(nameof(PostPage), page);
        }

        // DELETE /api/pages/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Page>> DeletePage(int id)
        {
            var page = await context.Pages.FindAsync(id);
            if (page == null)
            {
                return NotFound();
            }
            context.Pages.Remove(page);
            await context.SaveChangesAsync();
            return NoContent(); // 204
        }
    }
}
