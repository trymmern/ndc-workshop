namespace console_slice;
class Program
{
    static void Main(string[] args)
    {
        var ints = new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        var end = ^4;
        Array.ForEach(ints[0..end], Console.WriteLine);
    }
}
