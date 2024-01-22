using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Note
    {
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(200)]
        public string Value { get; set; }
        [Range(1,5)]
        public int Priority { get; set; }
        [Key]
        public Guid Id { get; set; }
    }
}
