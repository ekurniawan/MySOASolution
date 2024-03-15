// See https://aka.ms/new-console-template for more information

using Microsoft.EntityFrameworkCore;
using MySOASolution.Data;
using MySOASolution.Domain;

SamuraiContext _context = new SamuraiContext();
_context.Database.EnsureCreated();


//AddSamurai("Tanjiro Kamado");
//AddSamurai("Kenshin Himura");
//AddSamurai("Gintoki Sakata");
//AddSamurai("Roronoa Zoro");
//AddSamurai("Musashi Miyamoto");
//Console.WriteLine($"Samurai added");

/*GetAllSamurai();
Console.WriteLine("\n GetByID");
GetSamuraiByID(1);
Console.WriteLine("\n GetByName");
GetSamuraiByName("TO");*/
//Console.WriteLine("\n Update");
//UpdateSamurai(1, "Maseno Kibutsuji");
//Console.WriteLine("\n Delete");
//DeleteSamurai(4);

//sample samurai quotes
//InsertQuote(1, "Accept everything just the way it is");
//InsertQuote(1, "Think lightly of yourself and deeply of the world");
//InsertSamuraiWithQuotes();
GetAllQuotesWithSamurai();

void GetAllQuotesWithSamurai()
{
    var quotes = _context.Quotes.Include(s => s.Samurai);
    foreach (var quote in quotes)
    {
        Console.WriteLine($"{quote.Text} - {quote.Samurai.Name}");
    }
}

void InsertSamuraiWithQuotes()
{
    var newSamurai = new Samurai
    {
        Name = "Nobunaga Oda",
        Quotes = new List<Quote>
        {
            new Quote { Text="Do not seek pleasure for its own sake" },
            new Quote {Text="Be indifferent to where you live"}
        }
    };
    try
    {
        _context.Samurais.Add(newSamurai);
        _context.SaveChanges();
        Console.WriteLine("Add Samurai With Quotes");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"{ex.Message}");
    }
}

void InsertQuote(int samuraiId, string quotes)
{
    var newQuote = new Quote
    {
        SamuraiId = samuraiId,
        Text = quotes
    };
    try
    {
        _context.Quotes.Add(newQuote);
        _context.SaveChanges();
        Console.WriteLine("Quote added successfuly");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"{ex.Message}");
    }
}


void GetAllSamurai()
{
    //var samurais = _context.Samurais.OrderBy(s => s.Name).ToList();
    var samurais = from s in _context.Samurais
                   orderby s.Name descending
                   select s;

    foreach (var samurai in samurais)
    {
        Console.WriteLine(samurai.Name);
    }
}

void GetSamuraiByID(int id)
{
    //var samurai = _context.Samurais.SingleOrDefault(s => s.SamuraiId == id);
    var samurai = (from s in _context.Samurais
                   where s.SamuraiId == id
                   select s).SingleOrDefault();

    if (samurai == null)
    {
        Console.WriteLine("Samurai not found");
        return;
    }
    Console.WriteLine(samurai.Name);
}

void GetSamuraiByName(string name)
{
    //var samurais = _context.Samurais.Where(s => s.Name.ToLower().Contains(name.ToLower()));
    var samurais = from s in _context.Samurais
                   where s.Name.ToLower().Contains(name.ToLower())
                   select s;

    foreach (var samurai in samurais)
    {
        Console.WriteLine(samurai.Name);
    }
}

void AddSamurai(string name)
{
    var samurai = new Samurai { Name = name };
    _context.Samurais.Add(samurai);
    _context.SaveChanges();
}

void UpdateSamurai(int id, string name)
{
    var samurai = _context.Samurais.SingleOrDefault(s => s.SamuraiId == id);
    if (samurai == null)
    {
        Console.WriteLine("Samurai not found");
        return;
    }
    samurai.Name = name;
    _context.SaveChanges();
    Console.WriteLine("Samurai updated");
}

void DeleteSamurai(int id)
{
    var samurai = _context.Samurais.SingleOrDefault(s => s.SamuraiId == id);
    if (samurai == null)
    {
        Console.WriteLine("Samurai not found");
        return;
    }
    _context.Samurais.Remove(samurai);
    _context.SaveChanges();
    Console.WriteLine("Samurai deleted");
}
