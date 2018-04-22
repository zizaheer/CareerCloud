using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.WCF
{
    [ServiceContract]
    interface ISystem
    {
        [OperationContract]
        void AddSystemCountryCode(SystemCountryCodePoco[] pocos);

        [OperationContract]
        SystemCountryCodePoco GetSingleSystemCountryCode(string code);

        [OperationContract]
        List<SystemCountryCodePoco> GetAllSystemCountryCode();

        //[OperationContract]
        //void VerifySystemCountryCode(SystemCountryCodePoco[] pocos);

        [OperationContract]
        void UpdateSystemCountryCode(SystemCountryCodePoco[] pocos);

        [OperationContract]
        void RemoveSystemCountryCode(SystemCountryCodePoco[] pocos);

        //
        [OperationContract]
        void AddSystemLanguageCode(SystemLanguageCodePoco[] pocos);

        [OperationContract]
        SystemLanguageCodePoco GetSingleSystemLanguageCode(string langId);

        [OperationContract]
        List<SystemLanguageCodePoco> GetAllSystemLanguageCode();

        [OperationContract]
        void UpdateSystemLanguageCode(SystemLanguageCodePoco[] pocos);

        [OperationContract]
        void RemoveSystemLanguageCode(SystemLanguageCodePoco[] pocos);
         
    }
}
