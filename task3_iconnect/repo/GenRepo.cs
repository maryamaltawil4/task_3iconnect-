using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using task3_iconnect.Models;
using task3_iconnect.user.model;
namespace task3_iconnect.repo
{
    public interface IGenRepo <T> where T : class 
    {
        public Task<List<T>> GetAll();
        public Task<T> Get(int id);
        public void delete(int id);
        public Task<T> Add(T obj);
        public Task<T> Update(T obj);
    }

    public class GenRepo<T> : IGenRepo<T> where T : class ,IBaseModel
    {
        public UserContext _context;

        public GenRepo(UserContext context)
        {

            _context = context;
        }


        public async Task <List<T> >? GetAll()
        {
          
                var m =await _context.Set<T>().ToListAsync();
            return m;
        }
        public async Task< T> Get(int id)
        {
            // return  _context.Set<T>().Find(id);
            return _context.Find<T>(id);

        }
        public async void delete(int id)
        {
            _context.Remove<Task<T>>(Get(id));
            await _context.SaveChangesAsync();
        }
        public async Task<T>Add(T Object)
        {
            await _context.Set<T>().AddAsync(Object);
            await _context.SaveChangesAsync();
            return Object;
        }


        public async Task <T> Update(T Object)
        {

             _context.Set<T>().Update(Object);
            await _context.SaveChangesAsync();
           
            return Object;


        }

    }
}
