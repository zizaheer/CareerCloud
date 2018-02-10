using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.BusinessLogicLayer
{
    public class ApplicantJobApplicationLogic : BaseLogic<ApplicantJobApplicationPoco>
    {
        public ApplicantJobApplicationLogic(IDataRepository<ApplicantJobApplicationPoco> repository) : base(repository)
        {
        }
        public override void Add(ApplicantJobApplicationPoco[] pocos)
        {
            Verify(pocos);
            base.Add(pocos);
        }
        public override ApplicantJobApplicationPoco Get(Guid id)
        {
            return base.Get(id);
        }

        public override List<ApplicantJobApplicationPoco> GetAll()
        {
            return base.GetAll();
        }
        public override void Update(ApplicantJobApplicationPoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }

        protected override void Verify(ApplicantJobApplicationPoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();
            foreach (var poco in pocos)
            {
                if (string.IsNullOrEmpty(poco.ApplicationDate.ToString()))
                {
                    exceptions.Add(new ValidationException(110, $"Application date cannot be null or empty."));
                }
                else if (poco.ApplicationDate > DateTime.Today)
                {
                    exceptions.Add(new ValidationException(110, $"Application date cannot be greater than today."));
                }
            }

            if (exceptions.Count > 0)
            {
                throw new AggregateException(exceptions);
            }
        }

        public void Delete(ApplicantJobApplicationPoco[] pocos)
        {
            base.Delete(pocos);
        }
    }
}
