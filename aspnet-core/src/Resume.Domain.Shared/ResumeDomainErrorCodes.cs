namespace Resume;

public static class ResumeDomainErrorCodes
{
    /* You can add your business exception error codes here, as constants */
    public const string CodeAlreadyExists = "Resume:CodeAlreadyExists"; //代碼已存在
    public const string NotExists = "Resume:NotExists"; //不存在
    public const string GuidNotExists = "Resume:GuidNotExists"; //代碼不存在
    public const string DateBeginMoreThanDateEnd = "Resume:DateBeginMoreThanDateEnd";   //日期開始時間大於日期結束時間
    public const string DataPeriodOfTimeOverlap = "Resume:DataPeriodOfTimeOverlap"; //數據時間段重疊
    public const string DepartmetCodeSameParent = "Resume:DepartmetCodeSameParent"; //部門代碼相同父級
    public const string DepartmetGuidNotExists = "Resume:DepartmetGuidNotExists";  //部門ID不存在
    public const string EmployeeGuidNotExists = "Resume:EmployeeGuidNotExists"; //員工ID不存在
    public const string EmployeeFamilyAlreadyExists = "Resume:EmployeeFamilyAlreadyExists"; //員工家庭已經存在
    public const string NameAlreadyExists = "Resume:NameAlreadyExists"; //名稱已存在
    public const string RecordAlreadyExists = "Resume:RecordAlreadyExists"; //記錄已存在
    public const string IdNumberVerificationFailed = "Resume:IdNumberVerificationFailed";   //身份證號驗證失敗
    public const string DataNotFound = "Resume:DataNotFound";   //未找到數據
    public const string ActionTypeChangeViolation = "Resume:ActionTypeChangeViolation"; //操作類型更改違規
    public const string InputValueMinViolation = "Resume:InputValueMinViolation";   //輸入值最小違規
    public const string BiggerThen = "Resume:BiggerThen";   //再大一點
}
