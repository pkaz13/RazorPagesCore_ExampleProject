using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesCore.EF.DataAccessLib.DataAccess;
using RazorPagesCore.EF.DataAccessLib.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesCore.Pages
{
    public class TodoItemModel : PageModel
    {
        private readonly TodoListDataContext _context;

        public TodoItemModel(TodoListDataContext context)
        {
            _context = context;
        }

        public IList<TodoItems> TodoItems { get; set; }

        public async Task OnGetAsync()
        {
            TodoItems = await _context.TodoItems.Where(x => x.UserName == User.Identity.Name).ToListAsync();
        }
    }
}
