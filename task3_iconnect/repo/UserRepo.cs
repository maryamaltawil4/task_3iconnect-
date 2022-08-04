using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using task3_iconnect.Models;
using task3_iconnect.user.model;
using task3_iconnect.ViewModels;

namespace task3_iconnect.repo

{
    public interface IUserInterface  : IGenRepo<users>
    {


       


    }
    
    public class UserRepo :  GenRepo<users> ,IUserInterface
    {

        public IMapper _mapper;

        public UserRepo(UserContext context, IMapper iMapper) : base(context, iMapper)
        {

            _mapper = iMapper;
        }
       /* public async new Task< List<UsersView>?> getAll()

        {
            return await _context.Users.ProjectTo<UsersView>(_mapper.ConfigurationProvider).ToListAsync();

            //  return _context.Users.Include(c=> c.Posts).ToList();//table Users
        }*/



    }
}


   
   