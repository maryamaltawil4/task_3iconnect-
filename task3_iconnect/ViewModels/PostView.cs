using task3_iconnect.user.model;

namespace task3_iconnect.ViewModels
{
    public class PostView : BaseModel
    {
        //public int Id { get; set; }
        public string? Title { get; set; }
        public int IdUser { get; set; }

        public DateTime CreatDate { get; set; }

    }
}
