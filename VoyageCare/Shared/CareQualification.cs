using Dapper.Contrib.Extensions;
using System.Data.SqlClient;

namespace VoyageCare.Shared
{
    [Table("CareQualification")]
    public class CareQualification
    {
        [Key]
        public int CareQualificationID { get; set; } = -1;
        public int CareHomeStaffID { get; set; } = -1;
        public string Type { get; set; } = String.Empty;
        public string Grade { get; set; } = String.Empty;
        public DateTime AttainmentDate { get; set; } = DateTime.MinValue;
    }
}