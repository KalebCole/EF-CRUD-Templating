using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorCrudUI.Data;
using RazorCrudUI.Models;

namespace RazorCrudUI.Pages.Items
{
    public class CreateModel : PageModel
    {
        private readonly RazorCrudUI.Data.ItemsContext _context;

        // this is handled by the dependency injection system
        // we will not see this being called, but it will be called by the system
        public CreateModel(RazorCrudUI.Data.ItemsContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        // we use bind property when we want to update things
        [BindProperty]
        public ItemModel ItemModel { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            // updating program representation of the database 
            _context.Items.Add(ItemModel);
            // where things get written to the database
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
