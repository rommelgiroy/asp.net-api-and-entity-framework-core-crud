using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentLibrary.Models;

public class Student
{
    [Key]
    public int StudentId { get; set; }
    [Required]
    [MaxLength(20)]
    public string? StudentNumber { get; set; }
    [Required]
    [MaxLength(100)]
    public string? FirstName { get; set; }
    [Required]
    [MaxLength(100)]
    public string? LastName { get; set; }
    [Required]
    [MaxLength(20)]
    public string? PhoneNo { get; set; }
    [Required]
    [MaxLength(100)]
    public string? EmailAddress { get; set; }
}
