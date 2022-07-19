using task3_iconnect.user.model;
namespace task3_iconnect.repo
{
    public class users_
    {
        static List<users> userlist;
        static users_ ()
        {
            userlist = new List<users>()
            {
                new users(){id =1 , first_name="maryam" , last_name ="altawil" , email="maryamaltawil@gmail.com"},
                new users(){id =2 , first_name="aya" , last_name ="omar" , email="ayaomar@gmail.com"},
                new users(){id =3 , first_name="ali" , last_name ="yazen" , email="aliyazen@gmail.com"},
                new users(){id =4 , first_name="yara" , last_name ="altawil" , email="yaraaltawil@gmail.com"},
                new users(){id =5 , first_name="lara" , last_name ="fadi" , email="larafadi@gmail.com"}
            };
            }
        public static List<users> Getall()
        {
            return userlist;
        }
        public static users Get(int id )
            {
            return userlist.FirstOrDefault(users => users.id == id);
            }
        public static void delete(int id)
        {
            var users = Get(id);
            if (users != null)
                userlist.Remove(users);
        }
        public static void add (users users)
        { 
            userlist.Add(users);
        }
        public static void update (users users)
        {
            var index = userlist.FindIndex(user1 => user1.id == users.id);
            if (index == -1)
                return;
            userlist[index] = users;
        }



    }
}
