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

        [Column("fullname")]
        public string? fullname { get; set; }

        [Column("fathername")]
        public string? fathername { get; set; }

        [Column("email")]
        public string? Email { get; set; }
          [Column("phonenumber")]
        public string? PhoneNumber { get; set;}
        [Column("address")]
        public string? address{ get; set; }
        
        [Column("gender")]
        public string? Gender { get; set; }      

    [Column("photo")]
    public byte[]? photo { get; set; } // ✅ Correct type



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

        // [Column("departmentlevel")]
        // public int departmentlevel { get; set; }  

        [Column("designation")]
        public string? Designation { get; set; }

        [Column("religion")]
        public string? Religion { get; set; }

        [Column("resume")]
        public string? resume { get; set; }

        [Column("isactive")]
        public string? JobStatus { get; set; }

        [Column("confirmationdate")]
        public DateTime? ConfirmationDate { get; set; }

        [Column("JoiningDate")]
        public DateTime? JoiningDate { get; set; }

        [Column("dateofleaving")]
        public DateTime? dateofleaving { get; set; }

        [Column("salary")]
        public decimal? salary{ get; set; }

        [Column("martialstatus")]
        public string? martialstatus { get; set; }

        [Column("notes")]
        public string? Notes { get; set; }
        
        [Column("officelocation")]
        public string? officelocation { get; set; }

        [Column("IdExpiryDate")]
        public DateTime? IdExpiryDate { get; set; }

        [Column("section")]
        public string? section { get; set; }

        [Column("levelpolicy")]
        public int? levelpolicy { get; set; }

        [Column("bloodGroup")]
        public string? bloodGroup { get; set; }

        // [Column("HOD")]
        // public bool? HOD { get; set; }

        // [Column("AsstHod")]
        // public bool? AsstHod { get; set; }

        [Column("Reason")]
        public string? Reason { get; set; }

    }
}