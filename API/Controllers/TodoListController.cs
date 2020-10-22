using System.Collections.Generic;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{

  public class TodoListController : BaseApiController 
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

    [HttpPost("Item")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<ListItem>> AddItem([FromBody]ListItemDto listItem) 
    {
      var newItem = new ListItem {
        ItemContent = listItem.ItemContent
      };

      context.ListItems.Add(newItem);
      await context.SaveChangesAsync();

      return newItem;
    }

    [HttpDelete("Item/{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<StatusCodeResult> RemoveItem(int id) 
    {
      var item = await context.ListItems.FindAsync(id);
      if (item != null)
      {
        context.ListItems.Remove(item);
        await context.SaveChangesAsync();
        return new StatusCodeResult(StatusCodes.Status204NoContent);
      }
      return new StatusCodeResult(StatusCodes.Status404NotFound);      
    }
  }
}