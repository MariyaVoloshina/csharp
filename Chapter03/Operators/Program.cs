using static System.Console;

int a = 3;
int b = a++;
WriteLine($"a is {a}, b is {b}");
int c = 3;
int d = ++c; // увеличение с перед присваиванием
WriteLine($"c is {c}, d is {d}");
int e = 11;
int f = 3;
WriteLine($"e is {e}, f is {f}");
WriteLine($"e + f = {e + f}");
WriteLine($"e - f = {e - f}");
WriteLine($"e * f = {e * f}");
WriteLine($"e / f = {e / f}");
WriteLine($"e % f = {e % f}");