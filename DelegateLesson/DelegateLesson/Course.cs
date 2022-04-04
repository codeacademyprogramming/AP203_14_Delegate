using System;
using System.Collections.Generic;
using System.Text;

namespace DelegateLesson
{
    internal class Course
    {
        public List<Student> Students { get; set; }

        public List<Student> FilterByPoint(byte min,byte max)
        {
            return Students.FindAll(x => x.Point >= min && x.Point <= max);
        }

    }
}
