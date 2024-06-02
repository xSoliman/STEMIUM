
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace STEM_Project.Models;

[Table("Feedback")]
public partial class Feedback
{
    [Key]
    public int Id { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? Timestamp { get; set; }

    [Column("User_ID")]
    public int? UserId { get; set; }

    [Column("Feedback_content")]
    public string FeedbackContent { get; set; }

    public bool Visible { get; set; }
    public int? Rate { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("Feedbacks")]
    public virtual User User { get; set; }
}