using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace STEM_Project.ViewModels;
public class FeedbackViewModel
{
    [Required(ErrorMessage = "Please enter your message")]
    public string Message { get; set; }

    [Required(ErrorMessage = "Please select a rating")]

    public int Rating { get; set; }
}