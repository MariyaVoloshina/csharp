using static System.Console;
static bool DoStuff()
{
    WriteLine("I am doing some stuff.");
    return true;
    WriteLine();
    WriteLine($"a & DoStuff() = {a & DoStuff()}");
    WriteLine($"b & DoStuff() = {b & DoStuff()}");
    //WriteLine($"a && DoStuff() = {a && DoStuff()}");
    //WriteLine($"b && DoStuff() = {b && DoStuff()}");
}