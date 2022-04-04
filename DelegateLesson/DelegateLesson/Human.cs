using System;
using System.Collections.Generic;
using System.Text;

namespace DelegateLesson
{
    internal class Human
    {
        public Human(string fullname,byte age)
        {
            this.FullName = fullname;
            this.Age = age;
        }
        public string FullName { get; set; }
        public byte Age { get; set; }
    }
}
