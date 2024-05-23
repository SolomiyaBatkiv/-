using System;

public class MyAccessModifiers
{
    private int birthYear;
    protected string personalInfo;
    internal string IdNumber;

    public MyAccessModifiers(int birthYear, string idNumber, string personalInfo)
    {
        this.birthYear = birthYear;
        this.IdNumber = idNumber;
        this.personalInfo = personalInfo;
    }

    public int Age
    {
        get
        {
            int currentYear = DateTime.Now.Year;
            return currentYear - birthYear;
        }
    }

    private static readonly byte averageMiddleAge = 50;

    public string Name { get; set; }

    public string NickName { get; internal set; }

    protected bool HasLivedHalfOfLife()
    {
        int currentAge = Age;
        return currentAge >= averageMiddleAge;
    }

    public string GetPersonalInfo()
    {
        return personalInfo;
    }

    public static bool operator ==(MyAccessModifiers obj1, MyAccessModifiers obj2)
    {
        if (ReferenceEquals(obj1, obj2))
            return true;

        if (obj1 is null || obj2 is null)
            return false;

        return obj1.Name == obj2.Name &&
               obj1.Age == obj2.Age &&
               obj1.personalInfo == obj2.personalInfo;
    }

    public static bool operator !=(MyAccessModifiers obj1, MyAccessModifiers obj2)
    {
        return !(obj1 == obj2);
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        MyAccessModifiers person = new MyAccessModifiers(2005, "123456789", "Solomiya Batkiv");

        person.Name = "Solomiya";
        person.NickName = "Solya";
        string personalInfo = person.GetPersonalInfo();

        Console.WriteLine($"Name: {person.Name}");
        Console.WriteLine($"Nickname: {person.NickName}");
        Console.WriteLine($"Age: {person.Age}");
        Console.WriteLine($"Personal Info: {person.IdNumber} - {personalInfo}");

        MyAccessModifiers anotherPerson = new MyAccessModifiers(1990, "987654321", "Ann Andr");
        Console.WriteLine($"Is the person the same as another person? {person == anotherPerson}");
    }
}
