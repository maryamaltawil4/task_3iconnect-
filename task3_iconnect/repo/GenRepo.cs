using Microsoft.AspNetCore.Mvc;
using task3_iconnect.Models;
using task3_iconnect.user.model;
namespace task3_iconnect.repo
{
    public interface IGenRepo <T> where T : class 
    {
        public List<T>? GetAll();
        public T Get(int id);
        public void delete(int id);
        public T Add(T obj);
        public T Update(T obj);
    }

    public class GenRepo<T> : IGenRepo<T> where T : class ,IBaseModel
    {
        public UserContext _context;

        public GenRepo(UserContext context)
        {

            _context = context;
        }


        public List<T> ? GetAll()
        { 
            return _context.Set<T>().ToList();
        }
        public T Get(int id)
        {
            return  _context.Set<T>().Find(id);
        }
        public void delete(int id)
        {
           
            var _temp = _context.Set<T>().FirstOrDefault(c => c.Id == id);
            _context.Set<T>().Remove(_temp);
            _context.SaveChanges();
        }
        public T Add(T Object)
        {
            _context.Set<T>().Add(Object);
            _context.SaveChanges();
            return Object;
        }


        public T Update(T Object)
        {

            _context.Set<T>().Update(Object);
            _context.SaveChanges();
           
            return Object;


        }

    }
}
