using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kurs_idrisov.Model;

public partial class Drug : BaseClass
{
    [Key]

    public int DrugId { get; set; }

    [Required]

    private string? drugName;
    public string? DrugName
    {
        get { return drugName; }
        set
        {
            drugName = value; OnPropertyChanged(nameof(DrugName));
        }
    }

    private string? sposobPriema;
    public string? SposobPriema
    {
        get { return sposobPriema; }
        set
        {
            sposobPriema = value; OnPropertyChanged(nameof(SposobPriema));
        }
    }

    private string? deistvie;
    public string? Deistvie
    {
        get { return deistvie; }
        set
        {
            deistvie = value; OnPropertyChanged(nameof(Deistvie));
        }
    }

    private string? pobochnieEffects;
    public string? PobochnieEffects
    {
        get { return pobochnieEffects; }
        set
        {
            pobochnieEffects = value; OnPropertyChanged(nameof(PobochnieEffects));
        }
    }

    public virtual ICollection<Priem> Priems { get; set; } = new List<Priem>();
}
