using DataAccess.Abstract;
using Entities.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework;

public class EfCarDal : ICarDal
{
    public void Add(Car entity)
    {
        using( ReCampProjectDbContext context =new ReCampProjectDbContext())
        {
            var addedEntity = context.Entry(entity);
            addedEntity.State = EntityState.Added;
            context.SaveChanges();
        }
    }

    public void Delete(Car entity)
    {
        using (ReCampProjectDbContext context = new ReCampProjectDbContext())
        {
            var deletedEntity = context.Entry(entity);
            deletedEntity.State = EntityState.Deleted;
            context.SaveChanges();
        }
    }

    public Car Get(Expression<Func<Car, bool>> filter)
    {
        using (ReCampProjectDbContext context = new ReCampProjectDbContext())
        {
            return context.Set<Car>().SingleOrDefault(filter);
        }
    }

    public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
    {
        using (ReCampProjectDbContext context = new ReCampProjectDbContext())
        {
            return filter == null ? context.Set<Car>().ToList() : context.Set<Car>().Where(filter).ToList();
        }

    }

    public void Update(Car entity)
    {
        using (ReCampProjectDbContext context = new ReCampProjectDbContext())
        {
            var updatedEntity = context.Entry(entity);
            updatedEntity.State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
