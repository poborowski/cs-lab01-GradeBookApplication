using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(String name, bool isWeighted) : base(name, isWeighted)
        {
            Name = name;
            Type = Enums.GradeBookType.Ranked;
        }
        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException();
            }
            int x = (int)Math.Ceiling(Students.Count * 0.20);
            int l = 0;

            for (int i = 0; i < Students.Count; i++)
            {
                double m = 0;
                for (int j = 0; j < Students[i].Grades.Count; j++)
                {
                    m = +Students[i].Grades[j];
                }
                if (averageGrade >= m / Students[i].Grades.Count)
                {
                    l++;
                }
            }
            if (l <= (int)Math.Ceiling(Students.Count * 0.20))
                return 'F';
            else if (l <= (int)Math.Ceiling(Students.Count * 0.40))
                return 'D';
            else if (l <= (int)Math.Ceiling(Students.Count * 0.60))
                return 'C';
            else if (l <= (int)Math.Ceiling(Students.Count * 0.80))
                return 'B';
            else
                return 'A';
        }
        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
            }
            else
            {
                base.CalculateStatistics();
            }
        }
        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
            }
            else
            {
                base.CalculateStudentStatistics(name);
            }
        }
    }
}