#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace STEM_Project.Models;

[Index("Email", Name = "UQ__Users__A9D10534EA26C15C", IsUnique = true)]
public partial class User
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [StringLength(255)]
    public string Email { get; set; }

    [StringLength(255)]
    public string Password { get; set; }

    [StringLength(100)]
    public string Name { get; set; }

    public int? Age { get; set; }

    [Column("Educational_level")]
    [StringLength(20)]
    public string EducationalLevel { get; set; }

    [StringLength(100)]
    public string College { get; set; }

    [StringLength(100)]
    public string Department { get; set; }

    [StringLength(100)]
    public string Major { get; set; }

    [StringLength(100)]
    public string Government { get; set; }

    [Column("Specialization_subject")]
    [StringLength(50)]
    public string SpecializationSubject { get; set; }

    [StringLength(100)]
    public string Workplace { get; set; }

    [StringLength(20)]
    public string Type { get; set; }

    [InverseProperty("User")]
    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();
}