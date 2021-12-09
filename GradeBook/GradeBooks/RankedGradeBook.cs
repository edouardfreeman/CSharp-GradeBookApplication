using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = Enums.GradeBookType.Ranked;
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.Write("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.Write("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            base.CalculateStudentStatistics(name);
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
                throw new InvalidOperationException("Ranked-grading requires a minimum of 5 students to work");
            int count = 0;

            //int betterStudents = Students.Count(item => item.AverageGrade > averageGrade);


            foreach(Student theStudent in Students.OrderByDescending(item => item.AverageGrade))
            {
                if (theStudent.AverageGrade < averageGrade)
                    break;
                count++;

            }
            double proportion = (double)count / Students.Count;
            if (proportion <= 0.2)
                return 'A';
            else if (proportion <= 0.4)
                return 'B';
            else if (proportion <= 0.6)
                return 'C';
            else if (proportion <= 0.8)
                return 'D';
            
            return 'F';
        }
    }
}
