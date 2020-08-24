/**
 OOP III - 4200-04 
 Try It Out: Type Conversions in Practice
 Adapted from the book Beginning Visual C# 2012 Programming, by:  Karli Watson, et al.
 Chapter 5 - More About Variables

 @author      Natan Colavite Dellagiustina
 @date        17/01/2020
 */
using System;

namespace TryItOut
{
    class Program
    {
        static void Main(string[] args)
        {
            short shortResult, shortVal = 4;
            int integerVal = 67;
            long longResult;
            float floatVal = 10.5F;
            double doubleResult, doubleVal = 99.999;
            string stringResult, stringVal = "17";
            bool boolVal = true;

            Console.WriteLine("Variable Conversion Examples\n");

            doubleResult = floatVal * shortVal;
            Console.WriteLine("Implicit, -> double: {0} * {1} -> {2}", floatVal,
               shortVal, doubleResult);

            shortResult = (short)floatVal;
            Console.WriteLine("Explicit, -> short: {0} -> {1}", floatVal,
               shortResult);

            stringResult = Convert.ToString(boolVal) +
               Convert.ToString(doubleVal);
            Console.WriteLine("Explicit, -> string: \"{0}\" + \"{1}\" -> {2}",
               boolVal, doubleVal, stringResult);

            longResult = integerVal + Convert.ToInt64(stringVal);
            Console.WriteLine("Mixed, -> long: {0} + {1} -> {2}",
               integerVal, stringVal, longResult);
            Console.ReadKey();
        }
    }
}
