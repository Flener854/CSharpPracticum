using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpPracticum.Rashirenie
{
    public class Employee
    {
        public string Name { get; }
        public int Age { get; }
        public decimal Salary { get; }
        public string Department { get; }

        public Employee(string name, int age, decimal salary, string department)
        {
            Name = name;
            Age = age;
            Salary = salary;
            Department = department;
        }

        public override string ToString() =>
            $"{Name,-12} | {Age,2} лет | {Salary,8} | {Department}";
    }
}
