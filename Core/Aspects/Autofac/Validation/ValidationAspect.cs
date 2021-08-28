using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType) //Attirubute olduğu için constructorda Type geçmememiz lazım
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception("Bu doğrulama sınıfı geçerli değil"); // şimdilik kullanıcaz denemek için
                //throw new System.Exception(AspectMessages.WrongValidationType);
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType); //reflection çalışma anında birşeyleri çalıştırmanızı sağlıyor. Mesela newleme işini çalışma anında yapmak istiyorsunuz. CreateInstance sayesinde instance oluştur.

            var entityType = _validatorType.BaseType.GetGenericArguments()[0]; //_validatorType'un çalışma tipini bul diyor

            var entities = invocation.Arguments.Where(t => t.GetType() == entityType); // şimdi de parametrelerini bul

            foreach (var entity in entities) // herbirini gez, birden fazla parametre olabilir.
            {
                ValidationTool.Validate(validator, entity); // ValidationTool'u kullanarak validate et
            }
        }
    }
}
