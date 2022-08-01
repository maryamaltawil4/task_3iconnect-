namespace task3_iconnect.ViewModels
{
    public class UsersView
    {
        public int Id { get; set; }
        public string ? first_name { get; set; }
        public string? last_name { get; set; }

        public string? email { get; set; }
        public ICollection<PostView>? Posts { get; set; }
    }
}
