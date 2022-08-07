using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using task3_iconnect.Models;
using task3_iconnect.user.model;
using task3_iconnect.ViewModels;

namespace task3_iconnect.repo
{
    public interface IGenRepo <T> where T : class 
    {
        public Task<List<TVM>> GetAll<TVM>();
        public TVM? Get<TVM>(int id) where TVM : class, IBaseModel;
        public void delete(int id);
        public Task<T> Add(T obj, int CreatById);
        public Task<T> Update(T obj, int CreatById);
    }

    public class GenRepo<T> : IGenRepo<T> where T : class ,IBaseModel
    {
        public UserContext _context;

        private readonly IMapper _mapper;
        public GenRepo(UserContext context, IMapper mapper)
        {

            _context = context;
             _mapper= mapper;
        }


        public async Task <List<TVM>>? GetAll<TVM>()
        {
       
            return await _context.Set<T>().ProjectTo<TVM>(_mapper.ConfigurationProvider).ToListAsync();
        }
        public TVM? Get<TVM>(int id) where TVM : class, IBaseModel
        {
            // return  _context.Set<T>().Find(id);
            return  _context.Set<T>().ProjectTo<TVM>(_mapper.ConfigurationProvider).FirstOrDefault(c => c.Id == id);

        }
        /* public async void delete(int id)
         {
             _context.Remove<Task<T>>(Get(id));
             await _context.SaveChangesAsync();
         }*/
        public async void delete(int id)
        {
            var _temp = await _context.Set<T>().FirstOrDefaultAsync(c => c.Id == id);

            _context.Set<T>().Remove(_temp);
            await _context.SaveChangesAsync();

        }

        public async Task<T>Add(T Object,int CreatById)
        {
            Type type = typeof(T);
            var prop = type.GetProperties().FirstOrDefault(X => X.Name == "CreatDate");
            var temp = DateTime.Now;
            prop.SetValue(Object, temp);
            var prop1 = type.GetProperties().FirstOrDefault(X => X.Name == "CreatBy");
            prop1.SetValue(Object, CreatById);
            await _context.Set<T>().AddAsync(Object);
            await _context.SaveChangesAsync();
            return Object;
        }


        public async Task <T> Update(T Object, int CreatById)
        {
            Type type = typeof(T);
            var prop = type.GetProperties().FirstOrDefault(X =>X.Name== "CreatDate");
            var temp= DateTime .Now;
            prop.SetValue(Object,temp);
            var prop1 = type.GetProperties().FirstOrDefault(X => X.Name == "CreatBy");
            prop1.SetValue(Object, CreatById);
            _context.Set<T>().Update(Object);
            await _context.SaveChangesAsync();
            return Object;


        }

    }
}
