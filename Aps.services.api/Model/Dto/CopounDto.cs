using System.ComponentModel.DataAnnotations;

namespace Aps.services.api.Model.Dto
{
    public class CopounDto
    {
        public int CopounId { get; set; }
        public required string CopounCode { get; set; }
        public float DiscountAmount { get; set; }
        public int MinAmount { get; set; }
    }
}
