using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StringAccumulator;

namespace StringAccumulatorApp
{
    class Program
    {
        static void Main(string[] args)
        {
            AccumulatorDriver();
        }

        private static void AccumulatorDriver()
        {
            try
            {
                StringAccumulator.StringAccumulator stringAccumulator = new StringAccumulator.StringAccumulator();
                var result = stringAccumulator.Add("");
                Console.WriteLine($"The cummulative value is {result}");

                result = stringAccumulator.Add("1");
                Console.WriteLine($"The cummulative value is {result}");

                result = stringAccumulator.Add("1,2");
                Console.WriteLine($"The cummulative value is {result}");

                result = stringAccumulator.Add("1\n2,3");
                Console.WriteLine($"The cummulative value is {result}");

                result = stringAccumulator.Add("//;\n1;2");
                Console.WriteLine($"The cummulative value is {result}");

                result = stringAccumulator.Add("1\n2,3,-1002,-4302,99");
                Console.WriteLine($"The cummulative value is {result}");
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
        }
    }
}
