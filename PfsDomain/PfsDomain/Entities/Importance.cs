using PfsShared.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace PfsDomain.Entities
{
    [Table("Importance", Schema = "Core")]
    public class Importance : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get;set; }
        public EStatus Status { get; set; }
    }
}
