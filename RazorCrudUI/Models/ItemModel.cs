using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorCrudUI.Models
{
	public class ItemModel
	{

        public int Id { get; set; }

		// we put limits on the strings because it takes up less memory (it is max by default)
		[StringLength(60, MinimumLength = 3)]
		[Display(Name = "Item Name")]
		[Required(ErrorMessage = "Item Name is required")]
		public string? Name { get; set; }
		public string? Description { get; set; }

		[Range(0, 1000)]
		[DataType(DataType.Currency)]
		[Column(TypeName = "decimal(18,2)")] // This is the default for SQL Server
		[Display(Name = "How much it'll cost ya")]
		public decimal Price { get; set; }

    }
}
