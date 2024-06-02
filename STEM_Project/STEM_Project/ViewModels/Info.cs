using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using STEM_Project.Models;

namespace STEM_Project.ViewModels;

public class Info
{

    
    public int? level { get; set; }
    public string? subject { get; set; }
    public int? chapter { get; set; }
    public int? lesson { get; set; }
    public string? service { get; set; }
    public List<Services>? Services { get; set; }
}
