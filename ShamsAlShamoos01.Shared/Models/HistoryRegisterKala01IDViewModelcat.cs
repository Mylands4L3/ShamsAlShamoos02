using System.ComponentModel.DataAnnotations;

namespace ShamsAlShamoos01.Shared.Models
{
    public class HistoryRegisterKala01ViewModel_Update
    {
        public string HistoryRegisterKala01ID { get; set; }
        public bool IsHaveJob { get; set; }
        public string? PersianWeekDate01 { get; set; }
        public string? VAzife00 { get; set; }

        // Text fields
        public string? Vartext01 { get; set; }
        public string? Vartext02 { get; set; }
        public string? Vartext03 { get; set; }
        public string? Vartext04 { get; set; }
        public string? Vartext05 { get; set; }
        public string? Vartext06 { get; set; }
        public string? Vartext07 { get; set; }
        public string? Vartext08 { get; set; }
        public string? Vartext09 { get; set; }
        public string? Vartext10 { get; set; }
        public string? Vartext11 { get; set; }
        public string? Vartext12 { get; set; }
        public string? Vartext13 { get; set; }
        public string? Vartext14 { get; set; }
        public string? Vartext15 { get; set; }
        public string? Vartext16 { get; set; }
        public string? Vartext17 { get; set; }
        public string? Vartext18 { get; set; }
        public string? Vartext19 { get; set; }
        public string? Vartext20 { get; set; }

        // Time and date fields
        public string? StrTimwStart01 { get; set; }
        public string? StrTimwEnd01 { get; set; }
        public string? StrDateCategory01 { get; set; }

        // Letter related
        public int? TypeLetter01 { get; set; }
        public string? StrTypeLetter01 { get; set; }
        public string? StrTextContent01 { get; set; }

        // Unit related
        public string? StrUitID01 { get; set; }
        public int? UnitID01 { get; set; }

        // Document
        public string? DocumentNO01 { get; set; }

        // Personal information
        public string? MelliCode { get; set; }
        public string? StrDesAmar01 { get; set; }
        public string? StrSortStatAmar01 { get; set; }

        [Display(Name = "شماره کارگزینی")]
        public string? EMP_NUM { get; set; }

        [Display(Name = "نام")]
        public string? FST_NAM { get; set; }

        [Display(Name = "نام خانوادگی")]
        public string? LST_NAM { get; set; }

        public string? DRJ_NAM { get; set; }
        public string? DUS_COD { get; set; }

        // Statistics
        public int? StatAmar01 { get; set; }
        public int? DesAmar01 { get; set; }
        public string? DateDesAmar01 { get; set; }
        public string? DateDesAmar02 { get; set; }

        // Status fields
        public string? StrLastStatAmar01 { get; set; }
        public string? StrLastStatAmar00 { get; set; }

        // Confirmation statuses
        public int? StatusConfirmation01 { get; set; }
        public int? StatusConfirmation02 { get; set; }
        public int? StatusConfirmation03 { get; set; }
        public int? StatusConfirmation04 { get; set; }
        public int? StatusConfirmation05 { get; set; }
        public int? StatusConfirmation06 { get; set; }

        // Personnel information
        public string UjobPesronel02strDarajee { get; set; }
        public string UjobPesronel02strFirstName { get; set; }
        public string UjobPesronel02strLastName { get; set; }
    }

    public class HistoryRegisterKala01ViewModelcat
    {
        public string HistoryRegisterKala01ID { get; set; }
        public string VAzife00 { get; set; }

        // Text fields
        public string? Vartext01 { get; set; }
        public string? Vartext02 { get; set; }
        public string? Vartext03 { get; set; }
        public string? Vartext04 { get; set; }
        public string? Vartext05 { get; set; }
        public string? Vartext06 { get; set; }
        public string? Vartext07 { get; set; }
        public string? Vartext08 { get; set; }
        public string? Vartext09 { get; set; }
        public string? Vartext10 { get; set; }
        public string? Vartext11 { get; set; }
        public string? Vartext12 { get; set; }
        public string? Vartext13 { get; set; }
        public string? Vartext14 { get; set; }
        public string? Vartext15 { get; set; }
        public string? Vartext16 { get; set; }
        public string? Vartext17 { get; set; }
        public string? Vartext18 { get; set; }
        public string? Vartext19 { get; set; }
        public string? Vartext20 { get; set; }

        // Additional properties specific to this class
        public string? TotalCountVacatiaonWitoutHoliday { get; set; }
        public int? YearsOFWorks { get; set; }
        public int? YearsOFOld { get; set; }
        public string? VarDate01 { get; set; }
        public string? VarDate02 { get; set; }
        public string? VarDate03 { get; set; }
        public string? VarDate04 { get; set; }
        public string? VarDate05 { get; set; }
        public string? VarDate06 { get; set; }
        public int? SubjectLetter01 { get; set; }
        public int? StrVariabl01 { get; set; }
        public int? StrVariabl02 { get; set; }
        public int? StrVariabl03 { get; set; }
        public int? StrVariabl04 { get; set; }
        public int? StrVariabl05 { get; set; }
        public int? StrVariabl06 { get; set; }
        public int? DarajeeGheshrID { get; set; }
        public int? TimwStartEnd01 { get; set; }
        public string? StrTimwStart01 { get; set; }
        public string? StrTimwEnd01 { get; set; }
        public string? StrDateCategory01 { get; set; }
        public string? Darajee { get; set; }
        public int? TypeLetter01 { get; set; }
        public string? StrTypeLetter01 { get; set; }
        public string? StrTextContent01 { get; set; }
        public string? StrPayvarVazifeh01 { get; set; }
        public string? StrPayvarVazifeh02 { get; set; }
        public string? StrPayvarVazifeh03 { get; set; }
        public string? StrUitID01 { get; set; }
        public int? UnitID01 { get; set; }
        public string? DailyPlanEvidence01ID { get; set; }
        public string? DocumentNO01 { get; set; }
        public string? CountDatelHoliday01 { get; set; }
        public string? CountVacatiaonWitoutHoliday { get; set; }
        public string? DateDesAmar01HistoryRegisterKala01ID { get; set; }
        public string? DateDesAmar02HistoryRegisterKala01ID { get; set; }
        public int? DesAmar01HistoryRegisterKala01ID { get; set; }
        public string? DifDateDesAmar02DateDesAmar01Personal { get; set; }
        public string? StrDesAmar01HistoryRegisterKala01ID { get; set; }
        public string? MelliCode { get; set; }
        public string? StrDesAmar01 { get; set; }
        public string? DifDateDesAmar02DateDesAmar01 { get; set; }
        public string? StrSortStatAmar01 { get; set; }

        [Display(Name = "قشر")]
        public string? DRJ_CODSTR01 { get; set; }

        [Display(Name = "قشر")]
        public string? DRJ_NAMGheshr1 { get; set; }

        [Display(Name = "پایور/وظیفه")]
        public string? DRJ_NAMGheshr2 { get; set; }

        [Display(Name = "شماره کارگزینی")]
        public string? EMP_NUM { get; set; }

        [Display(Name = "نام")]
        public string? FST_NAM { get; set; }

        [Display(Name = "نام خانوادگی")]
        public string? LST_NAM { get; set; }

        [Display(Name = "درجه")]
        public string? DRJ_COD { get; set; }

        [Display(Name = "رسته")]
        public string? RST_COD { get; set; }

        public string? DRJ_NAM { get; set; }
        public string? RST_NAM { get; set; }
        public string? DUS_COD { get; set; }
        public string? DUS_NAM { get; set; }
        public int? DRJ_CODSort { get; set; }
        public int? StatAmar01 { get; set; }
        public int? LastStatAmar01 { get; set; }
        public int? LastStatAmar00 { get; set; }
        public int? LastStaLastStatAmar01tAmar00 { get; set; }
        public string? StrLastStatAmar01 { get; set; }
        public string? StrLastStatAmar00 { get; set; }
        public int? DesAmar01 { get; set; }
        public string? DateDesAmar01 { get; set; }
        public string? DateDesAmar02 { get; set; }
        public string? NOTAMCHECKETitle01Activitystr { get; set; }
        public string? Date01 { get; set; }

        // Confirmation related properties
        public string? UjobPesronel01 { get; set; }
        public string? UjobPesronel01str { get; set; }
        public int? StatusConfirmation01 { get; set; }
        public string? StatusConfirmation01str { get; set; }
        public string? UjobPesronel02 { get; set; }
        public string? UjobPesronel02str { get; set; }
        public int? StatusConfirmation02 { get; set; }
        public string? StatusConfirmation02str { get; set; }
        public string? UjobPesronel03 { get; set; }
        public string? UjobPesronel03str { get; set; }
        public int? StatusConfirmation03 { get; set; }
        public string? StatusConfirmation03str { get; set; }
        public string? UjobPesronel04 { get; set; }
        public string? UjobPesronel04str { get; set; }
        public int? StatusConfirmation04 { get; set; }
        public string? StatusConfirmation04str { get; set; }
        public string? UjobPesronel05 { get; set; }
        public string? UjobPesronel05str { get; set; }
        public int? StatusConfirmation05 { get; set; }
        public string? StatusConfirmation05str { get; set; }
        public string? UjobPesronel06 { get; set; }
        public string? UjobPesronel06str { get; set; }
        public int? StatusConfirmation06 { get; set; }
        public string? StatusConfirmation06str { get; set; }
        public string? UjobPesronel07 { get; set; }
        public string? UjobPesronel07str { get; set; }
        public int? StatusConfirmation07 { get; set; }
        public string? StatusConfirmation07str { get; set; }
        public string? UjobPesronel08 { get; set; }
        public string? UjobPesronel08str { get; set; }
        public int? StatusConfirmation08 { get; set; }
        public string? StatusConfirmation08str { get; set; }
        public string? UjobPesronel09 { get; set; }
        public string? UjobPesronel09str { get; set; }
        public int? StatusConfirmation09 { get; set; }
        public string? StatusConfirmation09str { get; set; }
        public string? UjobPesronel10 { get; set; }
        public string? UjobPesronel10str { get; set; }
        public int? StatusConfirmation10 { get; set; }
        public string? StatusConfirmation10str { get; set; }
        public string? UjobPesronel11 { get; set; }
        public string? UjobPesronel11str { get; set; }
        public int? StatusConfirmation11 { get; set; }
        public string? StatusConfirmation11str { get; set; }
        public string? UjobPesronel12 { get; set; }
        public string? UjobPesronel12str { get; set; }
        public int? StatusConfirmation12 { get; set; }
        public string? StatusConfirmation12str { get; set; }

        // Personnel string properties
        public string UjobPesronel01strMelicode { get; set; }
        public string UjobPesronel02strMelicode { get; set; }
        public string UjobPesronel03strMelicode { get; set; }
        public string UjobPesronel04strMelicode { get; set; }
        public string UjobPesronel05strMelicode { get; set; }
        public string UjobPesronel06strMelicode { get; set; }
        public string UjobPesronel07strMelicode { get; set; }
        public string UjobPesronel08strMelicode { get; set; }
        public string UjobPesronel09strMelicode { get; set; }
        public string UjobPesronel10strMelicode { get; set; }
        public string UjobPesronel11strMelicode { get; set; }
        public string UjobPesronel12strMelicode { get; set; }

        public string UjobPesronel01strDarajee { get; set; }
        public string UjobPesronel02strDarajee { get; set; }
        public string UjobPesronel03strDarajee { get; set; }
        public string UjobPesronel04strDarajee { get; set; }
        public string UjobPesronel05strDarajee { get; set; }
        public string UjobPesronel06strDarajee { get; set; }
        public string UjobPesronel07strDarajee { get; set; }
        public string UjobPesronel08strDarajee { get; set; }
        public string UjobPesronel09strDarajee { get; set; }
        public string UjobPesronel10strDarajee { get; set; }
        public string UjobPesronel11strDarajee { get; set; }
        public string UjobPesronel12strDarajee { get; set; }

        public string UjobPesronel01strFirstName { get; set; }
        public string UjobPesronel02strFirstName { get; set; }
        public string UjobPesronel03strFirstName { get; set; }
        public string UjobPesronel04strFirstName { get; set; }
        public string UjobPesronel05strFirstName { get; set; }
        public string UjobPesronel06strFirstName { get; set; }
        public string UjobPesronel07strFirstName { get; set; }
        public string UjobPesronel08strFirstName { get; set; }
        public string UjobPesronel09strFirstName { get; set; }
        public string UjobPesronel10strFirstName { get; set; }
        public string UjobPesronel11strFirstName { get; set; }
        public string UjobPesronel12strFirstName { get; set; }

        public string UjobPesronel01strFirstNameEN { get; set; }
        public string UjobPesronel02strFirstNameEN { get; set; }
        public string UjobPesronel03strFirstNameEN { get; set; }
        public string UjobPesronel04strFirstNameEN { get; set; }
        public string UjobPesronel05strFirstNameEN { get; set; }
        public string UjobPesronel06strFirstNameEN { get; set; }
        public string UjobPesronel07strFirstNameEN { get; set; }
        public string UjobPesronel08strFirstNameEN { get; set; }
        public string UjobPesronel09strFirstNameEN { get; set; }
        public string UjobPesronel10strFirstNameEN { get; set; }
        public string UjobPesronel11strFirstNameEN { get; set; }
        public string UjobPesronel12strFirstNameEN { get; set; }

        public string UjobPesronel01strLastName { get; set; }
        public string UjobPesronel02strLastName { get; set; }
        public string UjobPesronel03strLastName { get; set; }
        public string UjobPesronel04strLastName { get; set; }
        public string UjobPesronel05strLastName { get; set; }
        public string UjobPesronel06strLastName { get; set; }
        public string UjobPesronel07strLastName { get; set; }
        public string UjobPesronel08strLastName { get; set; }
        public string UjobPesronel09strLastName { get; set; }
        public string UjobPesronel10strLastName { get; set; }
        public string UjobPesronel11strLastName { get; set; }
        public string UjobPesronel12strLastName { get; set; }

        public string UjobPesronel01strLastNameEN { get; set; }
        public string UjobPesronel02strLastNameEN { get; set; }
        public string UjobPesronel03strLastNameEN { get; set; }
        public string UjobPesronel04strLastNameEN { get; set; }
        public string UjobPesronel05strLastNameEN { get; set; }
        public string UjobPesronel06strLastNameEN { get; set; }
        public string UjobPesronel07strLastNameEN { get; set; }
        public string UjobPesronel08strLastNameEN { get; set; }
        public string UjobPesronel09strLastNameEN { get; set; }
        public string UjobPesronel10strLastNameEN { get; set; }
        public string UjobPesronel11strLastNameEN { get; set; }
        public string UjobPesronel12strLastNameEN { get; set; }

        public string UjobPesronel01strEMP_NUM { get; set; }
        public string UjobPesronel02strEMP_NUM { get; set; }
        public string UjobPesronel03strEMP_NUM { get; set; }
        public string UjobPesronel04strEMP_NUM { get; set; }
        public string UjobPesronel05strEMP_NUM { get; set; }
        public string UjobPesronel06strEMP_NUM { get; set; }
        public string UjobPesronel07strEMP_NUM { get; set; }
        public string UjobPesronel08strEMP_NUM { get; set; }
        public string UjobPesronel09strEMP_NUM { get; set; }
        public string UjobPesronel10strEMP_NUM { get; set; }
        public string UjobPesronel11strEMP_NUM { get; set; }
        public string UjobPesronel12strEMP_NUM { get; set; }

        public string UjobPesronel01strJobTitle { get; set; }
        public string UjobPesronel02strJobTitle { get; set; }
        public string UjobPesronel03strJobTitle { get; set; }
        public string UjobPesronel04strJobTitle { get; set; }
        public string UjobPesronel05strJobTitle { get; set; }
        public string UjobPesronel06strJobTitle { get; set; }
        public string UjobPesronel07strJobTitle { get; set; }
        public string UjobPesronel08strJobTitle { get; set; }
        public string UjobPesronel09strJobTitle { get; set; }
        public string UjobPesronel10strJobTitle { get; set; }
        public string UjobPesronel11strJobTitle { get; set; }
        public string UjobPesronel12strJobTitle { get; set; }

        public string UjobPesronel01strJobTitleN { get; set; }
        public string UjobPesronel02strJobTitleN { get; set; }
        public string UjobPesronel03strJobTitleN { get; set; }
        public string UjobPesronel04strJobTitleN { get; set; }
        public string UjobPesronel05strJobTitleN { get; set; }
        public string UjobPesronel06strJobTitleN { get; set; }
        public string UjobPesronel07strJobTitleN { get; set; }
        public string UjobPesronel08strJobTitleN { get; set; }
        public string UjobPesronel09strJobTitleN { get; set; }
        public string UjobPesronel10strJobTitleN { get; set; }
        public string UjobPesronel11strJobTitleN { get; set; }
        public string UjobPesronel12strJobTitleN { get; set; }
    }

    public class LoadDataRequest
    {
        public string? UserId { get; set; }
    }

    public class DataManagerRequestDto
    {
        public int Skip { get; set; }
        public int Take { get; set; }
        public string? SortedField { get; set; }
        public string? Filter { get; set; }
    }
}