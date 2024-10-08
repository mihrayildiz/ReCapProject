﻿using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception("Bu bir doğrulama");
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType); //validatorı aldı yani newledi
            var entityType = _validatorType.BaseType.GetGenericArguments()[0]; //validatorın bse sınıfı (AbstractValidator argumanlarından 0 ıaldı yani enttytypeı aldı
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType); //methodun argumnlarını gez yaniadd methodunun argmanlatını gz
            foreach (var entity in entities) 
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}


//validationaspect : methodun neresinde aspect yapmak istersin? bu yüzden OnBefore methodu ezildi 