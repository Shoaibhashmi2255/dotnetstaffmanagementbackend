using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StaffManagementAPI.models
{
    [Table("employee")] // 👈 Maps this class to the correct SQL table
    public class Employee
    {
        [Key]
        [Column("staffId")] // 👈 Maps to SQL primary key
        public int staffId { get; set; }

        [Column("firstname")]
        public string? firstname { get; set; }
        [Column("secondname")]
        public string? secondname { get; set; }
        [Column("email")]
        public string? Email { get; set; }
          [Column("phonenumber")]
        public string? PhoneNumber { get; set;}
        [Column("address")]
        public string? address{ get; set; }
        
        [Column("gender")]
        public string? Gender { get; set; }      

    // [Column("photo")]
    // public byte[]? ImageUrl { get; set; } // ✅ Correct type



        // [Column("nationality")]
        // public string? Nationality { get; set; }

        // [Column("idnumber")]
        // public string? IdNumber { get; set; }

        [Column("DOB")]
        public DateTime DOB { get; set; }
        [Column("hiredate")]
        public DateTime hireDate { get; set; }

        // [Column("isactive")]
        // public bool IsActive { get; set; } = true; // Default value
 
        [Column("departmentID")]
        public int DepartmentId { get; set; }  
        // [Column("designation")]
        // public string? Designation { get; set; }

        // [Column("religion")]
        // public string? Religion { get; set; }

        [Column("resume")]
        public string? resume { get; set; }

        // [Column("isactive")]
        // public string? JobStatus { get; set; }

        // [Column("confirmationdate")]
        // public DateTime? ConfirmationDate { get; set; }

        [Column("salary")]
        public decimal? salary{ get; set; }

        [Column("martialstatus")]
        public string? martialstatus { get; set; }

        [Column("notes")]
        public string? Notes { get; set; }
        
        [Column("officelocation")]
        public string? officelocation { get; set; }
        // [Column("IdExpiryDate")]
        // public DateTime IdExpiryDate { get; set; }
    }
}