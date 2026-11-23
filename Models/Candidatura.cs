namespace ExamenProva.Models;

public class Candidatura
{
    public int CandidaturaID { get; set; }

    public string NomJoc { get; set; }

    public CategoriaGOTY Categoria { get; set; }

    public int Any { get; set; }

    public bool HaGuanyat { get; set; }

    public int RepresentantID { get; set; }

    public virtual Representant Representant { get; set; }

    public int? CandidaturaPrincipalID { get; set; }

    public virtual Candidatura? CandidaturaPrincipal { get; set; }

    public virtual List<Candidatura> CandidaturesRelacionades { get; set; } = new List<Candidatura>();

    public Candidatura()
    {
        NomJoc = "";
    }

    public Candidatura(string nomJoc, CategoriaGOTY categoria, int any,
        bool haGuanyat, int representantID, Representant representant)
    {
        NomJoc = nomJoc;
        Categoria = categoria;
        Any = any;
        HaGuanyat = haGuanyat;
        RepresentantID = representantID;
        Representant = representant;
    }

    public override string ToString()
    {
        return $"{CandidaturaID} - {NomJoc} | {Categoria} | {Any} | Guanyador: {HaGuanyat} | {Representant.Nom}";
    }
}