using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.BusinessLogicLayer
{
    public class ApplicantProfileLogic : BaseLogic<ApplicantProfilePoco>
    {
        public ApplicantProfileLogic(IDataRepository<ApplicantProfilePoco> repository) : base(repository)
        {
        }
        public override void Add(ApplicantProfilePoco[] pocos)
        {
            Verify(pocos);
            base.Add(pocos);
        }
        public override ApplicantProfilePoco Get(Guid id)
        {
            return base.Get(id);
        }

        public override List<ApplicantProfilePoco> GetAll()
        {
            return base.GetAll();
        }
        public override void Update(ApplicantProfilePoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }

        protected override void Verify(ApplicantProfilePoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();
            foreach (var poco in pocos)
            {

                if (string.IsNullOrEmpty(poco.CurrentSalary.ToString()))
                {
                    exceptions.Add(new ValidationException(111, $"Current Salary  cannot be null or empty."));
                }
                else if (poco.CurrentSalary < 0)
                {
                    exceptions.Add(new ValidationException(111, $"Current Salary {poco.CurrentSalary} cannot be negative."));
                }
                if (string.IsNullOrEmpty(poco.CurrentRate.ToString()))
                {
                    exceptions.Add(new ValidationException(112, $"Current Rate cannot be null or empty."));
                }
                else if(poco.CurrentRate < 0)
                {
                    exceptions.Add(new ValidationException(112, $"Current Rate {poco.CurrentRate} cannot be negative."));
                }
            }

            if (exceptions.Count > 0)
            {
                throw new AggregateException(exceptions);
            }
        }

        public void Delete(ApplicantProfilePoco[] pocos)
        {
            base.Delete(pocos);
        }
    }
}
