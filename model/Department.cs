using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StaffManagementAPI.models
{
    [Table("department")]
    public class Department
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("departmentID")]
        public int DepartmentID { get; set; }

        [Column("departmentname")]
        public string DepartmentName { get; set; } = string.Empty;
    }
}