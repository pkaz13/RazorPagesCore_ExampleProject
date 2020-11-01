using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesCore.EF.DataAccessLib.Models;
using System.Threading.Tasks;

namespace RazorPagesCore.Pages
{
    public class TodoItemDetailsModel : PageModel
    {
        private readonly RazorPagesCore.EF.DataAccessLib.DataAccess.TodoListDataContext _context;

        public TodoItemDetailsModel(RazorPagesCore.EF.DataAccessLib.DataAccess.TodoListDataContext context)
        {
            _context = context;
        }

        public TodoItems TodoItems { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TodoItems = await _context.TodoItems.FirstOrDefaultAsync(m => m.Id == id);

            if (TodoItems == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
