using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;

namespace API.Interfaces
{
    public interface IListRepository
    {
        Task<IEnumerable<ListItem>> GetAllItemsAsync();
        Task<ListItem> GetItemAsync(int id);
         Task<ListItem> AddItemAsync(ListItemDto listItem);
         Task<bool> DeleteItemAsync(ListItem item);         
    }
}