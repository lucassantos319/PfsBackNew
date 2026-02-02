using PfsShared.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace PfsDomain.Entities
{
    [Table("Categories", Schema = "Core")]
    public class Categories : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal TotalAmount { get; set; }
        public string Color { get; set; }
        public EStatus Status { get; set; }
        public virtual IEnumerable<Transaction> Transactions { get; set; }
    }
}
