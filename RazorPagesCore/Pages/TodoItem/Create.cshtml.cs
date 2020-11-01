using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesCore.EF.DataAccessLib.Models;
using System.Threading.Tasks;

namespace RazorPagesCore.Pages
{
    public class TodoItemCreateModel : PageModel
    {
        private readonly RazorPagesCore.EF.DataAccessLib.DataAccess.TodoListDataContext _context;

        public TodoItemCreateModel(RazorPagesCore.EF.DataAccessLib.DataAccess.TodoListDataContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public TodoItems TodoItems { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.TodoItems.Add(TodoItems);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
