using AutoMapper;
using task3_iconnect.user.model;

namespace task3_iconnect.ViewModels
{
    public class MapConfig:Profile

    {
        public MapConfig()
        {
            CreateMap<users, UsersView>().ReverseMap();
            CreateMap<Post, PostView>().ReverseMap();

        }

    }
}
