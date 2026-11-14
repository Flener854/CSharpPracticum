using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpPracticum.Common
{
    public interface INotification
    {
        void Send(string message);
        string Channel { get; }  
    }
}
