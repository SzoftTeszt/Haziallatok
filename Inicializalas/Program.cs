//// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using Adatok.Data;

AllatokContext _context = new AllatokContext();

if (_context.Animal.Any())
    _context.Animal.RemoveRange(_context.Animal);

if (_context.Gazda.Any())
    _context.Gazda.RemoveRange(_context.Gazda);
_context.SaveChanges();

var sorok = File.ReadAllLines(@"c:\adat\gazda.csv");
foreach (var line in sorok)
    _context.Gazda.Add(new Adatok.Models.Gazda(line));
_context.SaveChanges();

var sorok2 = File.ReadAllLines(@"c:\adat\haziallatok.csv").Skip(1);
foreach (var line in sorok2)
    _context.Animal.Add(new Adatok.Models.Animal(line));
 _context.SaveChanges();


