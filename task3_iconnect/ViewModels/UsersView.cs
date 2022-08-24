using task3_iconnect.user.model;

namespace task3_iconnect.ViewModels
{
    public class UsersView : BaseModel
    {
       // public int Id { get; set; }
        public string ? first_name { get; set; }
        public string? last_name { get; set; }

       public string? Email { get; set; }
        public ICollection<PostView>? Posts { get; set; }
    }
}
