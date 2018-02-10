﻿using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.BusinessLogicLayer
{
    public class CompanyDescriptionLogic : BaseLogic<CompanyDescriptionPoco>
    {
        public CompanyDescriptionLogic(IDataRepository<CompanyDescriptionPoco> repository) : base(repository)
        {
        }
        public override void Add(CompanyDescriptionPoco[] pocos)
        {
            Verify(pocos);
            base.Add(pocos);
        }
        public override CompanyDescriptionPoco Get(Guid id)
        {
            return base.Get(id);
        }

        public override List<CompanyDescriptionPoco> GetAll()
        {
            return base.GetAll();
        }
        public override void Update(CompanyDescriptionPoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }

        protected override void Verify(CompanyDescriptionPoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();
            foreach (var poco in pocos)
            {
                if (string.IsNullOrEmpty(poco.CompanyName))
                {
                    exceptions.Add(new ValidationException(106, $"Company name must be greater than 2 characters."));
                }
                else if (poco.CompanyName.Length < 3)
                {
                    exceptions.Add(new ValidationException(106, $"Company name {poco.CompanyName} must be greater than 2 characters."));
                }
                if (string.IsNullOrEmpty(poco.CompanyDescription))
                {
                    exceptions.Add(new ValidationException(107, $"Company description must be greater than 2 characters."));
                }
                else if (poco.CompanyDescription.Length < 3)
                {
                    exceptions.Add(new ValidationException(107, $"Company description {poco.CompanyDescription} must be greater than 2 characters."));
                }
            }

            if (exceptions.Count > 0)
            {
                throw new AggregateException(exceptions);
            }
        }

        public void Delete(CompanyDescriptionPoco[] pocos)
        {
            base.Delete(pocos);
        }
    }
}
