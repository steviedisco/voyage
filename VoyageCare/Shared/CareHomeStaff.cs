using Dapper.Contrib.Extensions;
using System.Data.SqlClient;

namespace VoyageCare.Shared
{
    [Table("CareHomeStaff")]
    public class CareHomeStaff
    {
        [Key]
        public int CareHomeStaffID { get; set; } = -1;
        public int CareHomeID { get; set; } = -1;
        public string Forename { get; set; } = String.Empty;
        public string Surname { get; set; } = String.Empty;
        public DateTime DOB { get; set; } = DateTime.MinValue;
        public string JobTitle { get; set; } = String.Empty;
        public int AnnualSalary { get; set; } = 0;
    }
}