using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kurs_idrisov.Model;

public partial class Patient : BaseClass
{
    [Key]

    public int PatientId { get; set; }

    [Required]

    private string? patientName;
    public string? PatientName
    {
        get { return patientName; }
        set
        {
            patientName = value; OnPropertyChanged(nameof(PatientName));
        }
    }

    private string? pol;
    public string? Pol
    {
        get { return pol; }
        set
        {
            pol = value; OnPropertyChanged(nameof(Pol));
        }
    }

    private DateTime? dataRosdeniya;
    public DateTime? DataRosdeniya
    {
        get { return dataRosdeniya; }
        set
        {
            dataRosdeniya = value; OnPropertyChanged(nameof(DataRosdeniya));
        }
    }

    private string? adres;
    public string? Adres
    {
        get { return adres; }
        set
        {
            adres = value; OnPropertyChanged(nameof(Adres));
        }
    }

    public virtual ICollection<Priem> Priems { get; set; } = new List<Priem>();
}
