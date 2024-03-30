using Microsoft.EntityFrameworkCore;


namespace WepAp1.Models
{
    public class Repository<T> : IRepository<T> where T : class
    {
        Context context;
        public Repository(Context _context)
        {
            context = _context;
        }
       public void Delete(int id)
        {
            T t = GetById(id);
            Update(t);
        }

       public List<T> GetAll()//string include=null)
        {
            return context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return context.Set<T>().Find(id);
        }

        public void Insert(T obj)
        {
            context.Add(obj);
        }

        public void Save()
        {
            context.SaveChanges();
        }

       public void Update(T obj)
        {
            context.Update(obj);
        }
    }
}
