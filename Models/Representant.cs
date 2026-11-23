using System.ComponentModel.DataAnnotations;

namespace ExamenProva.Models;

public class Representant
{
    public int RepresentantID { get; set; }

    [Required]
    [MaxLength(80)]
    public string Nom { get; set; }

    [Required]
    [MaxLength(60)]
    public string Carrec { get; set; }

    [Required]
    [MaxLength(80)]
    public string Estudi { get; set; }

    public virtual Candidatura? Candidatura { get; set; }

    public Representant()
    {
        Nom = "";
        Carrec = "";
        Estudi = "";
    }

    public Representant(string nom, string carrec, string estudi)
    {
        Nom = nom;
        Carrec = carrec;
        Estudi = estudi;
    }

    public override string ToString()
    {
        return $"{RepresentantID} - {Nom} | {Carrec} | {Estudi}";
    }
}