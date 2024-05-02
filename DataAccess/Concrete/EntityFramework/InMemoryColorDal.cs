﻿using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework;

public class InMemoryColorDal : IColorDal
{
    public void Add(Color entity)
    {
        using (ReCampProjectDbContext context = new ReCampProjectDbContext())
        {
            var addedEntity = context.Entry(entity);
            addedEntity.State = EntityState.Added;
            context.SaveChanges();


        }
    }

    public void Delete(Color entity)
    {
        using (ReCampProjectDbContext context = new ReCampProjectDbContext())
        {
            var deletedEntity = context.Entry(entity);
            deletedEntity.State = EntityState.Deleted;
            context.SaveChanges();


        }
    }

    public Color Get(Expression<Func<Color, bool>> filter)
    {
        using (ReCampProjectDbContext context = new ReCampProjectDbContext())
        {

            return context.Set<Color>().SingleOrDefault(filter);


        }
    }

    public List<Color> GetAll(Expression<Func<Color, bool>> filter = null)
    {
        using (ReCampProjectDbContext context = new ReCampProjectDbContext())
        {

            return filter == null ? context.Set<Color>().ToList() : context.Set<Color>().Where(filter).ToList();

            
        }
    }

    public void Update(Color entity)
    {
        using (ReCampProjectDbContext context = new ReCampProjectDbContext())
        {
            var updatedEntity = context.Entry(entity);
            updatedEntity.State = EntityState.Modified;
            context.SaveChanges();


        }
    }
}