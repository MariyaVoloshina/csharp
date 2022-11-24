using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Packt.Shared; // C# 10 file-scoped namespace
public class ImmutablePerson
{
    public string? FirstName { get; init; }
    public string? LastName { get; init; }
}
public record ImmutableVehicle
{
    public int Wheels { get; init; }
    public string Color { get; init; }
    public string Brand { get; init; }
}
public record ImmutableAnimal
{
    string Name; // то есть общедоступное только для инициализации
    string Species;

    public ImmutableAnimal(string name, string species)
    {
        Name = name;
        Species = species;
    }
    public void Deconstruct(out string name, out string species)
    {
        name = Name;
        species = Species;
    }
}
// более простой способ определить запись
//public data class ImmutableAnimal(string Name, string Species);