using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using taller_programacion.Domain.Invoices.Models;
using taller_programacion.Domain.Products.Models;

namespace taller_programacion.Domain.InvoiceProducts.Models
{
    public class InvoiceProduct
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Invoice")]
        public int InvoiceId { get; set; }
        public Invoice? Invoice { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product? Product { get; set; }

        public double Subtotal { get; set; }
        public int Quantity { get; set; }
    }
}
