using System;

public abstract class GeographicObject
{
    public double X { get; set; }
    public double Y { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public virtual string GetInformation()
    {
        return $"Назва: {Name}\nКоординати: X={X}, Y={Y}\nОпис: {Description}";
    }
}

public interface IGeographicObject
{
    string GetInformation();
}

public class River : GeographicObject, IGeographicObject
{
    public double FlowSpeed { get; set; }
    public double TotalLength { get; set; }

    public override string GetInformation()
    {
        return base.GetInformation() + $"\nШвидкість течії: {FlowSpeed} см/с\nЗагальна довжина: {TotalLength}";
    }
}

public class Mountain : GeographicObject, IGeographicObject
{
    public double HighestPoint { get; set; }

    public override string GetInformation()
    {
        return base.GetInformation() + $"\nНайвища точка: {HighestPoint}";
    }
}

class Program
{
    static void Main()
    {
        IGeographicObject river = new River
        {
            X = 12.34,
            Y = 56.78,
            Name = "Дніпро",
            Description = "Найбільша річка України",
            FlowSpeed = 25.5,
            TotalLength = 2201
        };

        IGeographicObject mountain = new Mountain
        {
            X = 34.56,
            Y = 78.90,
            Name = "Говерла",
            Description = "Найвища гора України",
            HighestPoint = 2061
        };

        IGeographicObject[] objects = { river, mountain };

        foreach (var obj in objects)
        {
            Console.WriteLine(obj.GetInformation());
            Console.WriteLine();
        }
    }
}
