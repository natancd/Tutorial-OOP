/**
 OOP III - 4200-04 
 Tutorial 1 - Fundamentals of C#
 Adapted from T. MacDonald's tutorial videos.

 @author      Natan Colavite Dellagiustina
 @date        17/01/2020
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutorial_1
{
    struct GradeStats
    {
        public double averageGrade;
        public int passCount;
        public int failCount;
        public int invalidCount;
    }
    class Program
    {
        /// <summary>
        /// PercentToFeedback - This will be used as a reference to either PercentToGrade() or PercentToDescription()
        /// </summary>

        static void Main(string[] args)
        {
            const int NUMBER_OF_GRADES = 5;
            double[] grades = new double[NUMBER_OF_GRADES];
            string userInput = "";

            for (int student = 0; student < grades.Length;)
            {
                try
                {
                    Console.Write("\nEnter a grade for student {0}: ", student + 1);
                    userInput = Console.ReadLine();
                    grades[student] = Convert.ToDouble(userInput);
                    student++;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Sorry, I could not convert \"{0}\" into a numeric value. Please try again", userInput);
                }
                catch (Exception)
                {
                    Console.WriteLine("Sorry, an error occured. Please try again.");
                }
            }

            PercentToFeedback feedbackMethod = PercentToLetterGrade;

            try
            {
                if (args[0].ToLower() == "description")
                    feedbackMethod = PercentToLetterGrade;
                 // feedbackMethod = PercentToDescription;
            }
            catch (Exception)
            {
            }

            Console.WriteLine("\n");
            ShowGradeReport(grades, feedbackMethod);
            Console.WriteLine("\nPress any key to end...");
            Console.ReadKey();
        }

        /// <summary>
        /// ShowGradeReport - This will display grades and feedback as well as count, average, number of passes, number of fails
        /// </summary>
        public static void ShowGradeReport(double[] marks, PercentToFeedback feedback)
        {
            GradeStats stats;
            int count = CalculateGradeStats(marks, out stats);

            for (int student = 0; student < marks.Length; student++)
            {
                Console.WriteLine("Student {0}: {1,5:n1}% : {2}", student + 1, marks[student], feedback(marks[student]));
            }

            Console.WriteLine("\nCount:   {0, 5:n1}", count);
            Console.WriteLine("Passed:  {0, 5:n1}", stats.passCount);
            Console.WriteLine("Failed:  {0, 5:n1}", stats.failCount);
            Console.WriteLine("Invalid: {0, 5:n1}", stats.invalidCount);
            Console.WriteLine("Average: {0, 5:n1}%\n", stats.averageGrade);
        }

        /// <summary>
        /// PercentToFeedback - This will be used as a reference to either PercentToGrade() or PercentToDescription()
        /// </summary>
        public static int CalculateGradeStats(double[] marks, out GradeStats stats)
        {
            const double MINIMUM_GRADE = 0.0;
            const double MAXIMUM_GRADE = 100.0;
            const double PASSING_GRADE = 50.0;

            double totalValid = 0.0;
            int validCount;

            stats.averageGrade = 0.0;
            stats.passCount = 0;
            stats.failCount = 0;
            stats.invalidCount = 0;

            if (marks.Length > 0)
            {
                foreach (double mark in marks)
                {
                    if (mark >= MINIMUM_GRADE && mark <= MAXIMUM_GRADE)
                    {
                        totalValid += mark;
                        if (mark >= PASSING_GRADE)
                            stats.passCount++;
                        else
                            stats.failCount++;
                    }
                    else
                    {
                        stats.invalidCount++;
                    }
                }
                validCount = stats.passCount + stats.failCount;
                if (validCount > 0)
                    stats.averageGrade = (double)totalValid / validCount;
            }
            return marks.Length;
        }

        /// <summary>
        /// PercentToFeedback - This will be used as a reference to either PercentToGrade() or PercentToDescription()
        /// </summary>
        public delegate string PercentToFeedback(double percentageGrade);

        /// <summary>
        /// PercentToLetterGrade - Converts a percentage numeric grade to a letter grade
        /// </summary>
        public static string PercentToLetterGrade(double percentageGrade)
        {
            const double MINIMUM_GRADE = 0.0;
            const double MAXIMUM_GRADE = 100.0;

            string strFeedBack = "INVALID";

            if (percentageGrade >= MINIMUM_GRADE && percentageGrade <= MAXIMUM_GRADE)
            {
                if (percentageGrade >= 90.0)
                    strFeedBack = "A+";
                else if (percentageGrade >= 85.0)
                    strFeedBack = "A";
                else if (percentageGrade >= 80.0)
                    strFeedBack = "A-";
                else if (percentageGrade >= 75.0)
                    strFeedBack = "B+";
                else if (percentageGrade >= 70.0)
                    strFeedBack = "B";
                else if (percentageGrade >= 65.0)
                    strFeedBack = "C+";
                else if (percentageGrade >= 60.0)
                    strFeedBack = "C";
                else if (percentageGrade >= 55.0)
                    strFeedBack = "D+";
                else if (percentageGrade >= 50.0)
                    strFeedBack = "D";
                else
                    strFeedBack = "F";
            }
            return strFeedBack;
        }

        /// <summary>
        /// PercentToDescription - Converts a percentage numeric grade to a descriptive string
        /// </summary>
        public static string PercentToDescription(double percentageGrade)
        {
            const double MIN_GRADE = 0.0;
            const double MAX_GRADE = 100.0;

            string strFeedBack = "INVALID";

            if (percentageGrade >= MIN_GRADE && percentageGrade <= MAX_GRADE)
            {
                if (percentageGrade >= 90.0)
                    strFeedBack = "Outstanding";
                else if (percentageGrade >= 85.0)
                    strFeedBack = "Exemplary";
                else if (percentageGrade >= 80.0)
                    strFeedBack = "Excellent";
                else if (percentageGrade >= 75.0)
                    strFeedBack = "Very Good";
                else if (percentageGrade >= 70.0)
                    strFeedBack = "Good";
                else if (percentageGrade >= 65.0)
                    strFeedBack = "Satisfactory";
                else if (percentageGrade >= 60.0)
                    strFeedBack = "Acceptable";
                else if (percentageGrade >= 50.0)
                    strFeedBack = "Conditional Pass";
                else
                    strFeedBack = "Failure";
            }
            return strFeedBack;
        }
    }
}
