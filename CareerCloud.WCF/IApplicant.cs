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

    interface IApplicant
    {
        [OperationContract]
        void AddApplicantEducation(ApplicantEducationPoco[] items);

        [OperationContract]
        ApplicantEducationPoco GetSingleApplicantEducation(string id);

        [OperationContract]
        List<ApplicantEducationPoco> GetAllApplicantEducation();

        [OperationContract]
        void UpdateApplicantEducation(ApplicantEducationPoco[] items);

        [OperationContract]
        void RemoveApplicantEducation(ApplicantEducationPoco[] items);

        // seperator
        [OperationContract]
        void AddApplicantJobApplication(ApplicantJobApplicationPoco[] pocos);

        [OperationContract]
        ApplicantJobApplicationPoco GetSingleApplicantJobApplication(string id);

        [OperationContract]
        List<ApplicantJobApplicationPoco> GetAllApplicantJobApplication();

        [OperationContract]
        void UpdateApplicantJobApplication(ApplicantJobApplicationPoco[] pocos);

        [OperationContract]
        void RemoveApplicantJobApplication(ApplicantJobApplicationPoco[] pocos);

        // seperator
        [OperationContract]
        void AddApplicantProfile(ApplicantProfilePoco[] pocos);

        [OperationContract]
        ApplicantProfilePoco GetSingleApplicantProfile(string id);

        [OperationContract]
        List<ApplicantProfilePoco> GetAllApplicantProfile();

        [OperationContract]
        void UpdateApplicantProfile(ApplicantProfilePoco[] pocos);

        [OperationContract]
        void RemoveApplicantProfile(ApplicantProfilePoco[] pocos);

        // seperator
        [OperationContract]
        void AddApplicantResume(ApplicantResumePoco[] pocos);

        [OperationContract]
        ApplicantResumePoco GetSingleApplicantResume(string id);

        [OperationContract]
        List<ApplicantResumePoco> GetAllApplicantResume();

        [OperationContract]
        void UpdateApplicantResume(ApplicantResumePoco[] pocos);

        [OperationContract]
        void RemoveApplicantResume(ApplicantResumePoco[] pocos);

        // seperator
        [OperationContract]
        void AddApplicantSkill(ApplicantSkillPoco[] pocos);

        [OperationContract]
        ApplicantSkillPoco GetSingleApplicantSkill(string id);

        [OperationContract]
        List<ApplicantSkillPoco> GetAllApplicantSkill();

        [OperationContract]
        void UpdateApplicantSkill(ApplicantSkillPoco[] pocos);

        [OperationContract]
        void RemoveApplicantSkill(ApplicantSkillPoco[] pocos);


        // seperator
        [OperationContract]
        void AddApplicantWorkHistory(ApplicantWorkHistoryPoco[] pocos);

        [OperationContract]
        ApplicantWorkHistoryPoco GetSingleApplicantWorkHistory(string id);

        [OperationContract]
        List<ApplicantWorkHistoryPoco> GetAllApplicantWorkHistory();

        [OperationContract]
        void UpdateApplicantWorkHistory(ApplicantWorkHistoryPoco[] pocos);

        [OperationContract]
        void RemoveApplicantWorkHistory(ApplicantWorkHistoryPoco[] pocos);

    }
}
