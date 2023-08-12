using Volo.Abp.Application.Dtos;
using System;
using System.Collections.Generic;
using Resume.ResumeSnapshots;
using Resume.ResumeMains;

namespace Resume.App.Resumes
{
    public class ResumeInput
    {
        public Guid? ResumeMainId { get; set; }
        public ResumeDisplayMethod ResumeDisplay { get; set; } = ResumeDisplayMethod.Classification;

    }

    public class UpdateResumeMainNameInput
    {
        public Guid Id { get; set; }
        public string ResumeName { get; set; }
    }

    public class UpdateResumeMainAutobiographyInput
    {
        public Guid Id { get; set; }
        public string ResumeMainAutobiography1 { get; set; }
        public string ResumeMainAutobiography2 { get; set; }
    }

    public class SaveResumeSnapshotInput : ResumeSnapshotDto
    {
        //ResumeMainCode 
        //CompanyMainCode 
        //CompanyJobCode
    }

    public class DeleteResumeInput : DeleteInput
    {
        public Guid ResumeMainId { get; set; }
    }

    public class SaveResumeDrvingLicensesListInput
    {
        public Guid ResumeMainId { get; set; }
        public List<ResumeDrvingLicenses> ListResumeDrvingLicenses { get; set; }
    }

    public class ResumeDrvingLicenses
    {
        public Guid Id { get; set; }
        public string DrvingLicenseCode { get; set; }
        public bool HaveDrvingLicense { get; set; }
        public bool HaveCar { get; set; }
    }

    public class InsertResumeDrvingLicenseInitInput
    {
        public Guid ResumeMainId { get; set; }
    }

    public class InsertResumeDrvingLicenseInput
    {
        public Guid ResumeMainId { get; set; }
        public Guid? TenantId { get; set; }
    }

    public class ResumeSnapshotsListInput
    {
        public Guid ResumeMainId { get; set; }

        //public string CompanyMainCode { get; set; }
        public Guid? CompanyJobId { get; set; }
    }

    public class ResumeSnapshotsInput
    {
        public Guid Id { get; set; }
    }

    public class ResumeSnapshotsListKeyWordsInput
    {
        public string KeyWords { get; set; }
    }

    public class SaveResumeSwitchInput
    {
        public bool Switch { get; set; } = false;
        public Guid ResumeMainId { get; set; }
    }

    public class SaveResumeMainMainInput
    {
        public Guid ResumeMainId { get; set; }
        public bool Main { get; set; } = false;
    }

    public class SaveResumeMainSortInput
    {
       //public Dictionary<string, int> dcResumeMain { get; set; } = new Dictionary<string, int>();
        public List<ResumeMainSort> ListResumeMain { get; set; } = new List<ResumeMainSort>();
    }

    public class ResumeMainSort
    {
        public Guid Id { get; set; }
        public int Sort { get; set; } = 9;

    }

    public class CopyResumeInput
    {
        public Guid ResumeMainId { get; set; }
        public string ResumeMainName { get; set; } = "";
    }

    public class SaveResumeMainInput : ResumeMainDto
    {
        public Guid? Id { get; set; }
    }

}