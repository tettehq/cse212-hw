public class Person
{
    public readonly string Name;
    public int Turns { get; set; }

    public readonly bool IsInfinite;

    internal Person(string name, int turns)
    {
        Name = name;
        Turns = turns;
        IsInfinite = Turns <= 0; // Gives a person infinite turns if their assigned turns is 0 or negative.
    }

    public override string ToString()
    {
        return Turns <= 0 ? $"({Name}:Forever)" : $"({Name}:{Turns})";
    }
}