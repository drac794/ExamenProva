using ExamenProva.Data;
using ExamenProva.Models;

namespace ExamenProva.Services;

public class CandidaturaService
{
    
    private readonly ExamenProvaContext _context;

    public CandidaturaService(ExamenProvaContext context)
    {
        _context = context;
    }

    public List<Candidatura> GetTots()
    {
        return _context.Candidatura.OrderBy(c => c.CandidaturaID).ToList();
    }
    public List<Candidatura> GetGuanyadores(int anyMinim)
    {
        return _context.Candidatura
            .Where(c => c.Any >= anyMinim && c.HaGuanyat)
            .OrderBy(c => c.CandidaturaID)
            .ToList();
    }
   
    public void MostraCandidaturesRelacionades(int idCandidatura)
    {
        Candidatura can = _context.Candidatura
            .FirstOrDefault(c => c.CandidaturaID == idCandidatura);

        Console.WriteLine($"Candidatura: {can.NomJoc} - {can.Categoria} - {can.Representant}");

        Console.WriteLine("Candidatures relacionades:");

        foreach (Candidatura c in can.CandidaturesRelacionades)
        {
            Console.WriteLine($" - {c.NomJoc} - {c.Categoria} - {c.Representant}");
        }
    }
    
    public bool RelacionarCandidatures(int idPrincipal, int idRelacionada)
    {
        Candidatura? can = _context.Candidatura .FirstOrDefault(c => c.CandidaturaID == idPrincipal);

        Candidatura? rel = _context.Candidatura.FirstOrDefault(c => c.CandidaturaID == idRelacionada);

        if (can == null || rel == null)
        {
            return false;
        }

        if (can.NomJoc == rel.NomJoc && can.Categoria == rel.Categoria && can.Any == rel.Any)
        {
            return false;
        }

        if (can.NomJoc != rel.NomJoc)
        {
            return false;
        }

        if (can.CandidaturesRelacionades.Contains(rel))
        {
            return false;
        }

        can.CandidaturesRelacionades.Add(rel);

        _context.SaveChanges();

        return true;
    }

    public List<Candidatura> CandidaturesExitoses()
    {
        return _context.Candidatura
            .Where(c => c.HaGuanyat || c.CandidaturesRelacionades.Any(r => r.HaGuanyat))
            .OrderBy(c => c.CandidaturaID)
            .ToList();
    }
    
    public void TopEstudis(int votsMinims)
    {
        
        
    }
    
}
