namespace Sample;

internal class Program
{
    static void Main(string[] args)
    {
        var calculator = new Calculator();
        using var nativeCalculator = NativeObjects.ICalculator.Wrap(calculator);
        CallNativeCalculator(nativeCalculator.Object);
    }

    static void CallNativeCalculator(IntPtr ptr)
    {
        var calculator = NativeObjects.ICalculator.Wrap(ptr);
        var result = calculator.Add(2, 3);

        Console.WriteLine($"2 + 3 = {result}");
    }
}

[NativeObject]
public interface ICalculator
{
    int Add(int value1, int value2);
}

public class Calculator : ICalculator
{
    public int Add(int value1, int value2) => value1 + value2;
}