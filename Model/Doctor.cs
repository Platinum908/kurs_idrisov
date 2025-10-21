using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kurs_idrisov.Model;

public partial class Doctor : BaseClass
{
    [Key]
    public int DoctorId { get; set; }

    [Required]

    private string? doctorName;
    public string? DoctorName
    {
        get { return doctorName; }
        set
        {
            doctorName = value; OnPropertyChanged(nameof(DoctorName));
        }
    }

    private string? doctorLogin;
    public string? DoctorLogin
    {
        get { return doctorLogin; }
        set
        {
            doctorLogin = value; OnPropertyChanged(nameof(DoctorLogin));
        }
    }

    private string? doctorPassword;
    public string? DoctorPassword
    {
        get { return doctorPassword; }
        set
        {
            doctorPassword = value; OnPropertyChanged(nameof(DoctorPassword));
        }
    }

    public virtual ICollection<Priem> Priems { get; set; } = new List<Priem>();
}
