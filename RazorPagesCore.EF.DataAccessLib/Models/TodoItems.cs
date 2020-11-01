using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPagesCore.EF.DataAccessLib.Models
{
    public partial class TodoItems
    {
        public TodoItems()
        {
            Notes = new HashSet<Notes>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        [Column(TypeName = "VARCHAR(200)")]
        public string Name { get; set; }

        [Required]
        [MaxLength(256)]
        public string UserName { get; set; }

        [Required]
        public bool Complited { get; set; }

        public virtual ICollection<Notes> Notes { get; set; }
    }
}
