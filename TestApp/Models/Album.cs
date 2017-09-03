using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestApp.Models
{
    public class Album
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(User))]
        public long UserId { get; set; }

        public string Title { get; set; }
    }
}
