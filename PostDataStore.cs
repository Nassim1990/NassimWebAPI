using NassimWebAPI.Models;

namespace NassimWebAPI
{
    public class PostDataStore
    {
        public List<PostDto> Blogs { get; set; }
        public static PostDataStore Current {  get; } = new PostDataStore();
        public PostDataStore() { 
        
            Blogs = new List<PostDto>() 
            {
                new PostDto()
                {
                    Id = 1,
                    Title = "First",
                    Description = "First Blog",
                },
                new PostDto()
                {
                    Id = 2,
                    Title = "Nassim Mansour",
                    Description = "Second Blog",
                },
                new PostDto()
                {
                    Id = 3,
                    Title = "Nassim Mansour",
                    Description = "Third Blog",
                },
                new PostDto()
                {
                    Id = 4,
                    Title = "Nassim Mansour",
                    Description = "Fourth Blog",
                },


            };
        
        }        

        
    }
}
