using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.BusinessLogicLayer
{
    public class CompanyJobLogic : BaseLogic<CompanyJobPoco>
    {
        public CompanyJobLogic(IDataRepository<CompanyJobPoco> repository) : base(repository)
        {
        }
        public override void Add(CompanyJobPoco[] pocos)
        {
            Verify(pocos);
            base.Add(pocos);
        }
        public override CompanyJobPoco Get(Guid id)
        {
            return base.Get(id);
        }

        public override List<CompanyJobPoco> GetAll()
        {
            return base.GetAll();
        }
        public override void Update(CompanyJobPoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }

        protected override void Verify(CompanyJobPoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();
            //foreach (var poco in pocos)
            //{
            //    if (string.IsNullOrEmpty(poco.ProfileCreated.ToString()))
            //    {
            //        exceptions.Add(new ValidationException(107, $"Profile created date cannot be empty."));
            //    }
            //}

            if (exceptions.Count > 0)
            {
                throw new AggregateException(exceptions);
            }
        }

        public void Delete(CompanyJobPoco[] pocos)
        {
            base.Delete(pocos);
        }
    }
}
