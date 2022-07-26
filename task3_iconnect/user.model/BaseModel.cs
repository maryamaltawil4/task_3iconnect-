using Microsoft.AspNetCore.Mvc;

namespace task3_iconnect.user.model
{
    public interface IBaseModel
    {
        public int Id { get; set; }
    }
    public class BaseModel : IBaseModel
    {
        public int Id { get; set; }
    }
}
