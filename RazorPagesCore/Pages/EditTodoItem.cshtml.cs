using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesCore.EF.DataAccessLib.Models;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesCore.Pages
{
    public class TodoItemEditModel : PageModel
    {
        private readonly RazorPagesCore.EF.DataAccessLib.DataAccess.TodoListDataContext _context;

        public TodoItemEditModel(RazorPagesCore.EF.DataAccessLib.DataAccess.TodoListDataContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(TodoItems).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TodoItemsExists(TodoItems.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool TodoItemsExists(int id)
        {
            return _context.TodoItems.Any(e => e.Id == id);
        }
    }
}
