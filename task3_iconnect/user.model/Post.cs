
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace task3_iconnect.user.model
{
    public class Post : BaseModel
    {
       

        public string Title { get; set; }

        [ForeignKey("users")]
        public int IdUser { get; set; }

        public users ? user { get; set; }

    }
}

