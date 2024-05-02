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

public class InMemoryBrandDal : IBrandDal
{


    public void Add(Brand entity)
    {
       using (ReCampProjectDbContext context = new ReCampProjectDbContext())
       {
            var addedEntity = context.Entry(entity);
            addedEntity.State = EntityState.Added;
            context.SaveChanges();
       }
    }

    public void Delete(Brand entity)
    {
        using (ReCampProjectDbContext context = new ReCampProjectDbContext())
        {
            var deletedEntity = context.Entry(entity);
            deletedEntity.State = EntityState.Deleted;
            context.SaveChanges();
        }
    }

    public Brand Get(Expression<Func<Brand, bool>> filter)
    {
        using (ReCampProjectDbContext context = new ReCampProjectDbContext())
        {
            return context.Set<Brand>().SingleOrDefault(filter);
        }
    }

    public List<Brand> GetAll(Expression<Func<Brand, bool>> filter = null)
    {
        using (ReCampProjectDbContext context = new ReCampProjectDbContext())
        {
            return filter == null ? context.Set<Brand>().ToList() : context.Set<Brand>().Where(filter).ToList();
        }
    }

    public void Update(Brand entity)
    {
        using (ReCampProjectDbContext context = new ReCampProjectDbContext())
        {
            var updatedEntity = context.Entry(entity);
            updatedEntity.State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
