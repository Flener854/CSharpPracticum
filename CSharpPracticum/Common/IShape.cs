using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpPracticum.Common
{
    public interface IShape
    {
        double Area();
        double Perimeter();
        string Name { get; }   
    }
}
