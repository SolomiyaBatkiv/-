using System;

namespace task2
{
    public class Employee
    {
        internal string name;
        private DateTime hiringDate;
        public Employee(string name, DateTime hiringDate)
        {
            this.name = name;
            this.hiringDate = hiringDate;
        }

        public int Experience()
        {
            return (DateTime.Now - hiringDate).Days / 365;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"{name} has {Experience()} years of experience.");
        }
    }

    public class Developer : Employee
    {
        private string programmingLanguage;

        public Developer(string name, DateTime hiringDate, string programmingLanguage) : base(name, hiringDate)
        {
            this.programmingLanguage = programmingLanguage;
        }

        public new void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine($"{name} is {programmingLanguage} programmer.\n");
        }
    }

    public class Tester : Employee
    {
        private bool isAutomation;

        public Tester(string name, DateTime hiringDate, bool isAutomation) : base(name, hiringDate)
        {
            this.isAutomation = isAutomation;
        }

        public new void ShowInfo()
        {
            base.ShowInfo();
            if (isAutomation)
            {
                Console.WriteLine($"{name} is automated tester and has {Experience()} years of experience.\n");
            }
            else
            {
                Console.WriteLine($"{name} is manual tester and has {Experience()} years of experience.\n");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Employee person1 = new Employee("Solomiya", new DateTime(2018, 8, 8));
            person1.ShowInfo();

            Developer person2 = new Developer("Anton", new DateTime(2014, 5, 17), "С++");
            person2.ShowInfo();

            Tester person3 = new Tester("Sofiya", new DateTime(2012, 4, 20), true);
            person3.ShowInfo();

            Tester person4 = new Tester("Ann", new DateTime(2015, 6, 29), false);
            person4.ShowInfo();
        }
    }
}