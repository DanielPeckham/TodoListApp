using System.Collections.Generic;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories {
  public class ListRepository : IListRepository {
    private readonly DataContext context;
    public ListRepository (DataContext context) {
      this.context = context;
    }

    public async Task<IEnumerable<ListItem>> GetAllItemsAsync()
    {
      return await context.ListItems.ToListAsync();
    }

    public async Task<ListItem> GetItemAsync(int id)
    {
      return await context.ListItems.FindAsync(id);
    }

    public async Task<ListItem> AddItemAsync (ListItemDto listItem) {
        var item = new ListItem {
            ItemContent = listItem.ItemContent
      };
        await context.ListItems.AddAsync(item);
        await context.SaveChangesAsync();
        return item;
    }

    public async Task<bool> DeleteItemAsync (ListItem item) {
        context.ListItems.Remove(item);
        return await context.SaveChangesAsync() > 0;        
    }    
  }
}