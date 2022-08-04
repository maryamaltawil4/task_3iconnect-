using task3_iconnect.user.model;
using Microsoft.AspNetCore.Mvc;
using task3_iconnect.Models;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using task3_iconnect.ViewModels;

namespace task3_iconnect.repo
{
    public interface IpostsRepo : IGenRepo<Post>
    {
     

    }
    public class PostRepo : GenRepo<Post> , IpostsRepo

    {
        public IMapper _mapper;
        public PostRepo(UserContext context, IMapper iMapper) : base(context, iMapper)
        {

            _mapper = iMapper;
        }
       /* public new async Task < List<PostView>> ? getAll()
        {
            return await _context.Posts.ProjectTo<PostView>(_mapper.ConfigurationProvider).ToListAsync();
        }*/

    }
}