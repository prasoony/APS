using System.ComponentModel.DataAnnotations;

namespace Aps.services.api.Model
{
    public class Copoun
    {
        [Key]
        public int CopounId { get; set; }

        [Required]
        public required string CopounCode { get; set; }
        public float DiscountAmount { get; set; }
        public int MinAmount { get; set;}
       

    }
    
}
