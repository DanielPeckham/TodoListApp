using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers 
{
  [ApiController]
  [Route ("api/[controller]")]
  public class TodoListController : ControllerBase 
  {
    private readonly DataContext context;
    public TodoListController (DataContext context) 
    {
      this.context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ListItem>>> GetTodoList() 
    {
        return await context.ListItems.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ListItem>> GetListItem(int id) 
    {
        return await context.ListItems.FindAsync(id);
    }
  }
}