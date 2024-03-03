using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public SelectList? Prices { get; set; }

        [BindProperty(SupportsGet = true)]
        public decimal? ItemPriceMin { get; set; }

		[BindProperty(SupportsGet = true)]
		public decimal? ItemPriceMax { get; set; }

		// this is getting called on a different thread
		// when your interface is locked up, things are working on the same thread
		// with async, it won't lock up the interface, it will just freeze
		public async Task OnGetAsync()
        {
            
            
            // Use LINQ to get list of items that match the search filter.
            var items = from m in _context.Items
                 select m;

            if (!string.IsNullOrEmpty(SearchString))
            {
                items = _context.Items.Where(s => s.Name.Contains(SearchString));
            }

            if (ItemPriceMin.HasValue)
            {
                items = items.Where(x => x.Price >= ItemPriceMin);
            }
			if (ItemPriceMax.HasValue)
			{
				items = items.Where(x => x.Price <= ItemPriceMax);
			}
			// context we made, with items from db, and it is converting them to a list to display each record
			ItemModel = await items.ToListAsync();
        }
    }
}
