using Dapper.Contrib.Extensions;
using System.Data.SqlClient;

namespace VoyageCare.Shared
{
    [Table("CareHome")]
    public class CareHome
    {
        [Key]
        public int CareHomeID { get; set; } = -1;

        public string Name { get; set; } = String.Empty;
    }
}