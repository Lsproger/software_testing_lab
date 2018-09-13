using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab1_Awerage_Marks
{
    public class Student:IAverageCalculatable
    {
        private List<int> Marks;
        
        public Student() 
        {
            this.Marks = new List<int>();
        }

        public Student(string FullName)
        {
            this.FullName = FullName;
            this.Marks = new List<int>();
        }

        public string FullName { get; set; }

        public void AddMark(int mark)
        {
            if(mark >= 0 && mark <=10)
                this.Marks.Add(mark);
        }

        public List<int> GetMarks()
        {
            return Marks.Count == 0?null:new List<int>(Marks);
        }

        public double? CalculateAverageMark()
        {   
            if(Marks.Count != 0)
                return Marks.Average();            
            return null;
        }
    }
}