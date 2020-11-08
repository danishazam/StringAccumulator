using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringAccumulator
{
    public class StringAccumulator
    {
        public int Add(string numberString)
        {
            try
            {
                bool isNumberStringEmpty = string.IsNullOrEmpty(numberString);
                
                /* Check whether any new delimiters are present. 
                 * If the string is empty then no delimiters are present, return false.
                 * If the string length is less than 2, then no delimiters could be present as the start of delimiter list starts with //
                 * If the first two characters of the string are // then return true, oterwise return false
                 */
                bool newDelimitersPresent = isNumberStringEmpty 
                    ? false 
                    : numberString.Length <= 2 
                        ? false 
                        : numberString.Substring(0, 2) == "//";
                
                /* Extract the delimiter list.
                 * If new delimiters are present, then extract the delimiter list by starting from the characters
                 * that are just after the // characters until a new line character is found.
                 * If there are no new delimiters in the input string then return the default delimiters of comma and newline
                 */
                var delimiterList = newDelimitersPresent 
                    ? numberString.Substring(2, numberString.IndexOf('\n') - 2).ToLower().ToCharArray() 
                    : new Char[] { ',', '\n' };
                
                /* If the string is empty then return 0.
                 * If new delimiters are present then ignore the delimiter list in input, extract the list of integers and add them
                 * If now new delimiters are present then use the default delimiter list to extract input values to add
                 */
                var numbers = isNumberStringEmpty 
                    ? new int[] { 0 } 
                    : newDelimitersPresent 
                        ? numberString.Substring(numberString.IndexOf('\n') + 1).ToLower().Split(delimiterList).Select(int.Parse).ToArray() 
                        : numberString.ToLower().Split(delimiterList).Select(int.Parse).ToArray();
                
                /* Check if there are any negative numbers.
                 * If yes, then throw an exception that Negatives are not allowed
                 */
                var negativeNumbers = numbers.Where(x => x < 0).ToArray();
                if (negativeNumbers.Length > 0)
                {
                    throw new System.ArgumentException("Negatives not allowed",string.Join(",", negativeNumbers));
                }

                /* Ignore any numbers greater than 1000 and accumulate all the numbers in the integer array 
                 */
                var result = numbers.Where(n => n <= 1000).Aggregate((x, y) => x + y);
                return result;
            }
            catch(Exception e)
            {
                throw e;
            }
            
        }
    }
}
