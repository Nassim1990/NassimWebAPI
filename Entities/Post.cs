using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NassimWebAPI.Entities
{
    public class Post
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]        
        public string Title { get; set; }

        [Required]
        public string Contents { get; set; }

        [Required]
        public int CateGoryId { get; set; }

        public DateTime TimeStamp { get; set; }

       

        public Post(string title, string contents, int cateGoryId)
        {
            Title = title;
            Contents = contents;
            CateGoryId = cateGoryId;
        }
    }
}
