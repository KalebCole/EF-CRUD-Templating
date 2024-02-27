using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorCrudUI.Models
{
	public class ItemModel
	{

        public int Id { get; set; }


		[Display(Name = "Item Name")]
		[Required(ErrorMessage = "Item Name is required")]
		public string? Name { get; set; }
		public string? Description { get; set; }

		[Range(0, 1000)]
		[DataType(DataType.Currency)]
		[Column(TypeName = "decimal(18,2)")] // This is the default for SQL Server
		public decimal Price { get; set; }

    }
}
