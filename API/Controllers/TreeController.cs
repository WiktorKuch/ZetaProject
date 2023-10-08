using API.DataContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Entities;


namespace API.Controllers
{
    [Route("api/trees")]
    [ApiController]
   public class TreeController : ControllerBase
   {
    private readonly YourDbContext _context;
    

    public TreeController(YourDbContext context)
    {
        _context = context;
        
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTreeNode(int id)
    {
        var node = await _context.TreeNodes
            .Include(t => t.Children)
            .SingleOrDefaultAsync(t => t.Id == id);

            if (node == null)
            {
                return NotFound();
            }

        return Ok(node);
    }

    [HttpPost]
    public async Task<IActionResult> CreateTreeNode(TreeNode treeNode)
    {
        _context.TreeNodes.Add(treeNode);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetTreeNode), new { id = treeNode.Id }, treeNode);
    }

   }
 

}