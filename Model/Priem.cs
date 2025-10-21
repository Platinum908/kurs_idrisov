using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kurs_idrisov.Model;

public partial class Priem : BaseClass
{
    [Key]
    public int PriemId { get; set; }

    [Required]
    private DateTime? data;
    public DateTime? Data
    {
        get { return data; }
        set
        {
            data = value; OnPropertyChanged(nameof(Data));
        }
    }

    private string? mesto;
    public string? Mesto
    {
        get { return mesto; }
        set
        {
            mesto = value; OnPropertyChanged(nameof(Mesto));
        }
    }

    private string? simptomi;
    public string? Simptomi
    {
        get { return simptomi; }
        set
        {
            simptomi = value; OnPropertyChanged(nameof(Simptomi));
        }
    }

    private string? diagnoz;
    public string? Diagnoz
    {
        get { return diagnoz; }
        set
        {
            diagnoz = value; OnPropertyChanged(nameof(Diagnoz));
        }
    }

    private string? naznachenie;
    public string? Naznachenie
    {
        get { return naznachenie; }
        set
        {
            naznachenie = value; OnPropertyChanged(nameof(Naznachenie));
        }
    }

    private int patientId;
    public int PatientId
    {
        get { return patientId; }
        set
        {
            patientId = value; OnPropertyChanged(nameof(PatientId));
        }
    }

    private int drugId;
    public int DrugId
    {
        get { return drugId; }
        set
        {
            drugId = value; OnPropertyChanged(nameof(DrugId));
        }
    }

    private int doctorId;
    public int DoctorId
    {
        get { return doctorId; }
        set
        {
            doctorId = value; OnPropertyChanged(nameof(DoctorId));
        }
    }

    public virtual Doctor? Doctor { get; set; }
    public virtual Drug? Drug { get; set; }
    public virtual Patient? Patient { get; set; }
}
