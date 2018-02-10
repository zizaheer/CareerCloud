﻿using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.BusinessLogicLayer
{
    public class CompanyJobEducationLogic : BaseLogic<CompanyJobEducationPoco>
    {
        public CompanyJobEducationLogic(IDataRepository<CompanyJobEducationPoco> repository) : base(repository)
        {
        }
        public override void Add(CompanyJobEducationPoco[] pocos)
        {
            Verify(pocos);
            base.Add(pocos);
        }
        public override CompanyJobEducationPoco Get(Guid id)
        {
            return base.Get(id);
        }

        public override List<CompanyJobEducationPoco> GetAll()
        {
            return base.GetAll();
        }
        public override void Update(CompanyJobEducationPoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }

        protected override void Verify(CompanyJobEducationPoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();
            foreach (var poco in pocos)
            {
                if (string.IsNullOrEmpty(poco.Major))
                {
                    exceptions.Add(new ValidationException(200, $"Major cannot be null or empty."));
                }
                else if (poco.Major.Length < 2)
                {
                    exceptions.Add(new ValidationException(200, $"Major {poco.Major} must be at least 2 characters."));
                }

                if (string.IsNullOrEmpty(poco.Importance.ToString()))
                {
                    exceptions.Add(new ValidationException(201, $"Importance cannot be null or empty."));
                }
                else if (poco.Importance < 0)
                {
                    exceptions.Add(new ValidationException(201, $"Importance {poco.Importance} cannot be less than 0."));
                }
            }

            if (exceptions.Count > 0)
            {
                throw new AggregateException(exceptions);
            }
        }

        public void Delete(CompanyJobEducationPoco[] pocos)
        {
            base.Delete(pocos);
        }
    }
}
