using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPagesCore.EF.DataAccessLib.Models
{
    public partial class Notes
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(1000)]
        [Column(TypeName = "VARCHAR(1000)")]
        public string NoteText { get; set; }
        [Required]
        [ForeignKey("TodoItem")]
        public int TodoItemId { get; set; }

        public virtual TodoItems TodoItem { get; set; }
    }
}
