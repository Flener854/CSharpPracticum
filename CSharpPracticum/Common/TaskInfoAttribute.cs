using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpPracticum.Common
{
    [AttributeUsage(AttributeTargets.Class)]
    public class TaskInfoAttribute : Attribute
    {
        public string LevelName { get; }
        public TaskInfoAttribute(string levelName)
        {
            LevelName = levelName;
        }
    }
}
