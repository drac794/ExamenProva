
using ExamenProva.Data;
using ExamenProva.Models;
using ExamenProva.Services;

using var db = new ExamenProvaContext();

db.Database.EnsureDeleted();
db.Database.EnsureCreated();

CandidaturaService servei = new CandidaturaService(db);

Representant r1 = new Representant("Christopher Larkin", "Compositor", "Team Cherry");
Representant r2 = new Representant("Ari Gibson", "Director Artístic", "Team Cherry");
Representant r3 = new Representant("William Pellen", "Productor Executiu", "Team Cherry");
Representant r4 = new Representant("Guillaume Broche", "Director", "SandFall Interactive");
Representant r5 = new Representant("Masayuki Yamada", "Director", "Sony Interactive");
Representant r6 = new Representant("Adri", "Dissenyador", "Team Cherry");

db.Representant.AddRange(r1, r2, r3, r4, r5, r6);
db.SaveChanges();

Candidatura c1 = new Candidatura("Hollow Knight: Silksong",
    CategoriaGOTY.MillorBandaSonora, 2025, true, 15420, r1);

Candidatura c2 = new Candidatura("Hollow Knight: Silksong",
    CategoriaGOTY.MillorDireccioArt, 2025, false, 18930, r2);

Candidatura c3 = new Candidatura("Hollow Knight: Silksong",
    CategoriaGOTY.MillorJoc, 2025, false, 25600, r3);

Candidatura c4 = new Candidatura("Expedition 33",
    CategoriaGOTY.MillorJoc, 2025, true, 32100, r4);

Candidatura c5 = new Candidatura("Astrobot",
    CategoriaGOTY.MillorJoc, 2024, true, 8200, r5);

Candidatura c6 = new Candidatura("Hollow Knight: Silksong",
    CategoriaGOTY.MillorJoc, 2026, false, 5000, r6);

db.Candidatura.AddRange(c1, c2, c3, c4, c5, c6);
db.SaveChanges();

c1.CandidaturaPrincipal = c3;
c2.CandidaturaPrincipal = c3;

db.SaveChanges();



List<Candidatura> guanyadores = servei.GetGuanyadores(2025);
db.SaveChanges();

Console.WriteLine("Guanyadores des de 2025:");

foreach (Candidatura c in guanyadores)
{
    Console.WriteLine(c);
}


servei.MostraCandidaturesRelacionades(3);



bool resultat1 = servei.RelacionarCandidatures(3, 6);
Console.WriteLine($"Relacionar 3 amb 6: {resultat1}");

bool resultat2 = servei.RelacionarCandidatures(3, 1);
Console.WriteLine($"Relacionar 3 amb 1: {resultat2}");

bool resultat3 = servei.RelacionarCandidatures(3, 4);
Console.WriteLine($"Relacionar 3 amb 4: {resultat3}");

bool resultat4 = servei.RelacionarCandidatures(3, 99);
Console.WriteLine($"Relacionar 3 amb 99: {resultat4}");

bool resultat5 = servei.RelacionarCandidatures(3, 3);
Console.WriteLine($"Relacionar 3 amb 3: {resultat5}");

db.SaveChanges();

List<Candidatura> exitoses = servei.CandidaturesExitoses();
db.SaveChanges();


foreach (Candidatura c in exitoses)
{
    Console.WriteLine(c);
}

servei.TopEstudis( 5000);
db.SaveChanges();
