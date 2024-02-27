using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorCrudUI.Data;
using RazorCrudUI.Models;

namespace RazorCrudUI.Pages.Items
{
    public class IndexModel : PageModel
    {
        private readonly RazorCrudUI.Data.ItemsContext _context;

        public IndexModel(RazorCrudUI.Data.ItemsContext context)
        {
            _context = context;
        }

       // we do not bind the property here, because we are not updating anything --> it is read only
        public IList<ItemModel> ItemModel { get;set; } = default!;

        // this is getting called on a different thread
        // when your interface is locked up, things are working on the same thread
        // with async, it won't lock up the interface, it will just freeze
        public async Task OnGetAsync()
        {
            // context we made, with items from db, and it is converting them to a list to display each record
            ItemModel = await _context.Items.ToListAsync();
        }
    }
}
