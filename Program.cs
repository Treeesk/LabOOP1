using System;

class Program
{
    static void Main()
    {
        var a = new MySet<int>(new[] { 1, 2, 3, 3, 2 });
        var b = new MySet<int>(new[] { 3, 4, 5 });

        Console.WriteLine("\tИсходные множества");
        Console.WriteLine($"A = {a}");
        Console.WriteLine($"B = {b}");
        Console.WriteLine();

        Console.WriteLine("\tТест уникальности");
        Console.WriteLine(a.ToString() == "{1, 2, 3}" || a.ToString() == "{1, 3, 2}" || a.ToString() == "{2, 1, 3}" 
            || a.ToString() == "{2, 3, 1}" || a.ToString() == "{3, 1, 2}" || a.ToString() == "{3, 2, 1}"
            ? "дубликаты удаляются"
            : "дубликаты не удаляются");
        Console.WriteLine();

        // |
        Console.WriteLine("\tТест объединения |");
        var union = a | b;
        Console.WriteLine($"A | B = {union}");
        Console.WriteLine();

        // -
        Console.WriteLine("\tТест разности -");
        var diff = a - b;
        Console.WriteLine($"A - B = {diff}");
        Console.WriteLine();

        // &
        Console.WriteLine("\tТест пересечения &");
        var inter = a & b;
        Console.WriteLine($"A & B = {inter}");
        Console.WriteLine();

        // /
        Console.WriteLine("\tТест симметрической разности /");
        var symDiff = a / b;
        Console.WriteLine($"A / B = {symDiff}");
        Console.WriteLine();

        // ==
        Console.WriteLine("\tТест сравнения ==");
        var c = new MySet<int>(new[] { 3, 2, 1 });
        Console.WriteLine($"C = {c}");
        Console.WriteLine(a == c ? "A == C" : "A != C, хотя должны быть равны");
        Console.WriteLine();

        // !+
        Console.WriteLine("\tТест сравнения !=");
        Console.WriteLine(a != b ? "A != B" : "A == B, хотя должны быть разными");
        Console.WriteLine();

        // Проверка, что исходные множества не изменились
        Console.WriteLine("=== Тест неизменяемости ===");
        Console.WriteLine($"A после операций = {a}");
        Console.WriteLine($"B после операций = {b}");
        Console.WriteLine("Если A = {1, 2, 3}, а B = {3, 4, 5}, то верно");
    }
}