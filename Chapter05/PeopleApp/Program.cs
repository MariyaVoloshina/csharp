using Packt.Shared;
using static System.Console;

// Setting and outputting field values

// var bob = new Person(); // C# 1.0 or later
Person bob = new();
// WriteLine(bob.ToString());

    bob.Name = "Bob Smith";
    bob.DateOfBirth = new DateTime(1965, 12, 22); // C# 1.0 or later

    WriteLine("{0} was born on {1:dddd, d MMMM yyyy}",
                bob.Name,
                bob.DateOfBirth);

        Person alice = new()
        {
            Name = "Alice Jones",
            DateOfBirth = new(1998, 3, 7) // C# 9.0 or later
        };

            WriteLine("{0} was born on {1:dd MMM yy}",
                    alice.Name,
                    alice.DateOfBirth);

// Storing a value using an enum type

    bob.FavoriteAncientWonder = WondersOfTheAncientWorld.StatueOfZeusAtOlympia;

    WriteLine( "{0}'s favorite wonder is {1}. Its integer is {2}.",
            bob.Name,
            bob.FavoriteAncientWonder,
            (int)bob.FavoriteAncientWonder);

// Storing multiple values using an enum type

    bob.BucketList = WondersOfTheAncientWorld.HangingGardensOfBabylon | WondersOfTheAncientWorld.MausoleumAtHalicarnassus;

// bob.BucketList = (WondersOfTheAncientWorld)18; 

    WriteLine($"{bob.Name}'s bucket list is {bob.BucketList}");

// Storing multiple values using collections

    bob.Children.Add(new Person { Name = "Alfred" }); // C# 3.0 and later
    bob.Children.Add(new() { Name = "Zoe" }); // C# 9.0 and later

WriteLine($"{bob.Name} has {bob.Children.Count} children:");

        for (int childIndex = 0; childIndex < bob.Children.Count; childIndex++)
            {
                WriteLine($"  {bob.Children[childIndex].Name}");
            }

// Making a field static

        BankAccount.InterestRate = 0.012M; // store a shared value
    
        BankAccount jonesAccount = new(); // C# 9.0 and later
        jonesAccount.AccountName = "Mrs. Jones";
        jonesAccount.Balance = 2400;

        WriteLine("{0} earned {1:C} interest.",jonesAccount.AccountName,jonesAccount.Balance * BankAccount.InterestRate);

        BankAccount gerrierAccount = new();
            gerrierAccount.AccountName = "Ms. Gerrier";
            gerrierAccount.Balance = 98;

        WriteLine("{0} earned {1:C} interest.",
            gerrierAccount.AccountName,
            gerrierAccount.Balance * BankAccount.InterestRate);

// Making a field constant

        WriteLine($"{bob.Name} is a {Person.Species}");

// Making a field read-only

        WriteLine($"{bob.Name} was born on {bob.HomePlanet}");

// Initializing fields with constructors

Person blankPerson = new();

WriteLine("{0} of {1} was created at {2:hh:mm:ss} on a {2:dddd}.",
            blankPerson.Name,
            blankPerson.HomePlanet,
            blankPerson.Instantiated);

Person gunny = new(initialName: "Gunny", homePlanet: "Mars");

WriteLine("{0} of {1} was created at {2:hh:mm:ss} on a {2:dddd}.",
        gunny.Name,
        gunny.HomePlanet,
        gunny.Instantiated);

// Returning values from methods

        bob.WriteToConsole();
        WriteLine(bob.GetOrigin());
// Combining multiple returned values using tuples

(string, int) fruit = bob.GetFruit();
WriteLine($"{fruit.Item1}, {fruit.Item2} there are.");

// Naming the fields of a tuple

var fruitNamed = bob.GetNamedFruit();
WriteLine($"There are {fruitNamed.Number} {fruitNamed.Name}.");

// Inferring tuple names

var thing1 = ("Neville", 4);
WriteLine($"{thing1.Item1} has {thing1.Item2} children.");

var thing2 = (bob.Name, bob.Children.Count);
WriteLine($"{thing2.Name} has {thing2.Count} children.");

// Deconstructing tuples

(string fruitName, int fruitNumber) = bob.GetFruit();
WriteLine($"Deconstructed: {fruitName}, {fruitNumber}");

// Deconstructing a Person
var (name1, dob1) = bob;
WriteLine($"Deconstructed: {name1}, {dob1}");
var (name2, dob2, fav2) = bob;
WriteLine($"Deconstructed: {name2}, {dob2}, {fav2}");

WriteLine(bob.SayHello());
WriteLine(bob.SayHello("Emily"));

WriteLine(bob.OptionalParameters());
WriteLine(bob.OptionalParameters("Jump!", 98.5));
WriteLine(bob.OptionalParameters(number: 52.7, command: "Hide!"));
WriteLine(bob.OptionalParameters("Poke!", active: false));

int a = 10;
int b = 20;
int c = 30;
WriteLine($"Before: a = {a}, b = {b}, c = {c}");
bob.PassingParameters(a, ref b, out c);
WriteLine($"After: a = {a}, b = {b}, c = {c}");
int d = 10;
int e = 20;
WriteLine($"Before: d = {d}, e = {e}, f doesn't exist yet!");
// упрощенный синтаксис параметров out в C# 7.0
bob.PassingParameters(d, ref e, out int f);
WriteLine($"After: d = {d}, e = {e}, f = {f}");

var sam = new Person
{
    Name = "Sam",
    DateOfBirth = new DateTime(1972, 1, 27)
};
WriteLine(sam.Origin);
WriteLine(sam.Greeting);
WriteLine(sam.Age);

sam.FavoriteIceCream = "Chocolate Fudge";
WriteLine($"Sam's favorite ice-cream flavor is {sam.FavoriteIceCream}.");
sam.FavoritePrimaryColor = "Red";
WriteLine($"Sam's favorite primary color is {sam.FavoritePrimaryColor}.");

sam.Children.Add(new Person { Name = "Charlie" });
sam.Children.Add(new Person { Name = "Ella" });
WriteLine($"Sam's first child is {sam.Children[0].Name}");
WriteLine($"Sam's second child is {sam.Children[1].Name}");
WriteLine($"Sam's first child is {sam[0].Name}");
WriteLine($"Sam's second child is {sam[1].Name}");

object[] passengers = {
  new FirstClassPassenger { AirMiles = 1_419 },
  new FirstClassPassenger { AirMiles = 16_562 },
  new BusinessClassPassenger(),
  new CoachClassPassenger { CarryOnKG = 25.7 },
  new CoachClassPassenger { CarryOnKG = 0 },
};
foreach (object passenger in passengers)
{
    decimal flightCost = passenger switch
    {
        /* C# 8 syntax
        FirstClassPassenger p when p.AirMiles > 35000 => 1500M,
        FirstClassPassenger p when p.AirMiles > 15000 => 1750M,
        FirstClassPassenger                           => 2000M, */
        // C# 9 or later syntax
        FirstClassPassenger p => p.AirMiles switch
        {
            > 35000 => 1500M,
            > 15000 => 1750M,
            _ => 2000M
        },
        BusinessClassPassenger => 1000M,
        CoachClassPassenger p when p.CarryOnKG < 10.0 => 500M,
        CoachClassPassenger => 650M,
        _ => 800M
    };
    WriteLine($"Flight costs {flightCost:C} for {passenger}");
}

ImmutablePerson jeff = new()
{
    FirstName = "Jeff",
    LastName = "Winger"
};
//jeff.FirstName = "Geoff";

ImmutableVehicle car = new()
{
    Brand = "Mazda MX-5 RF",
    Color = "Soul Red Crystal Metallic",
    Wheels = 4
};
ImmutableVehicle repaintedCar = car
  with
{ Color = "Polymetal Grey Metallic" };
WriteLine($"Original car color was {car.Color}.");
WriteLine($"New car color is {repaintedCar.Color}.");

var oscar = new ImmutableAnimal("Oscar", "Labrador");
var (who, what) = oscar; // вызов деструктора
WriteLine($"{who} is a {what}.");

