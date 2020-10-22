using System.Collections.Generic;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers {

  public class TodoListController : BaseApiController {
    private readonly IListRepository repo;

    public TodoListController (IListRepository repo) {
      this.repo = repo;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ListItem>>> GetTodoList () {
      var list =  await repo.GetAllItemsAsync();
      return Ok(list);
    }

    [HttpGet ("{id}")]
    public async Task<ActionResult<ListItem>> GetListItem (int id) {
      var item = await repo.GetItemAsync(id);
      return Ok(item);
    }

    [HttpPost ("Item")]
    public async Task<ActionResult<ListItem>> AddItem ([FromBody] ListItemDto listItem) {
      var newItem = await repo.AddItemAsync(listItem);
      return Ok(newItem);
    }

    [HttpDelete ("Item/{id}")]
    [ProducesResponseType (StatusCodes.Status204NoContent)]
    public async Task<StatusCodeResult> RemoveItem (int id) {
      var item = await repo.GetItemAsync(id);
      if (item != null) {
        await repo.DeleteItemAsync(item);
        return new StatusCodeResult (StatusCodes.Status204NoContent);
      }
      return new StatusCodeResult (StatusCodes.Status404NotFound);
    }
  }
}