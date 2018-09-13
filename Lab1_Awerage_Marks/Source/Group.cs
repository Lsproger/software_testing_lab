using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab1_Awerage_Marks
{
    public class Group:IAverageCalculatable
    {
        private List<Student> Students;

        public Group()
        {
            this.Students = new List<Student>();
        }

        public Group(List<Student> Students)
        {
            this.Students = new List<Student>(Students);            
        }

        public void AddStudent(Student student)
        {
            if(!student.Equals(null))
                Students.Add(student);
        }

        public List<Student> GetStudents()
        {
            return Students.Count == 0 ? null : Students;
        }

        public double? CalculateAverageMark()
        {
            if (Students.Count == 0)
                return null;
            else
            {
                List<int> groupMarks = new List<int>();
                foreach(Student s in Students)
                {
                    groupMarks.AddRange(s.GetMarks());
                }
                if (groupMarks.Count == 0)
                    return null;
                else
                    return groupMarks.Average();
            }
        }
    }
}