using PfsDomain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace PfsDomain.Entities
{
    [Table("Importance", Schema = "Core")]
    public class Importance : BaseEntity
    {
        public string Name { get;set; }
        public EStatus Status { get; set; }
    }
}
