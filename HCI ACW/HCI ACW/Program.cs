using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ACW_HCI
{

    public interface IPalindromeChecker
    {

        bool checkIsPalindrome(string stringTocheck);

    }

    class PalindromeChecker : IPalindromeChecker
    {

        public bool checkIsPalindrome(string inputString)
        {

            bool isPalindrome;
            int leftSideCheckIndex;
            int rightSideCheckIndex;
            int lengthOfInput;

            lengthOfInput = inputString.Length;
            rightSideCheckIndex = lengthOfInput - 1; //String is treated as an array, index starts at 0 meaning the ending index is string length - 1.
            leftSideCheckIndex = 0;
            Regex skipCharachters = new Regex("[ ,;!?.]"); //List of characters that aren't checked.

            if (lengthOfInput == 1) //If only one character, it's clearly a palindrome.
            {

                isPalindrome = true;

            }

            else //Else, check if it's a palindrome.
            {

                isPalindrome = true;

                while (isPalindrome == true && leftSideCheckIndex < rightSideCheckIndex) //While the left character index hasn't reached the right character index (locates central characters).
                {

                    while (skipCharachters.Match(inputString[leftSideCheckIndex].ToString()).Success) //While a character that needs to be ignored is found on the left side.
                    {

                        leftSideCheckIndex++; //Skip that character.

                    }

                    while (skipCharachters.Match(inputString[rightSideCheckIndex].ToString()).Success) //While a character that needs to be ignored is found on the right side.
                    {

                        rightSideCheckIndex--; //Skip that character.

                    }

                    if (inputString.ToUpper()[leftSideCheckIndex] == inputString.ToUpper()[rightSideCheckIndex]) //If the character on the left equals the character on the right.
                    {

                        leftSideCheckIndex++; //Go to the next set of characters.
                        rightSideCheckIndex--; //Go to the next set of characters.

                    }

                    else //If the left characters doesn't match the right character at their equidistant indexes from the start/end respectively, it's not a palindrome.
                    {

                        isPalindrome = false;

                    }

                }

            }

            return isPalindrome;

        }

    }

    class Program
    {

        static void Main()
        {

            IPalindromeChecker checker = new PalindromeChecker();

            Console.WriteLine(checkPalindromeCheckerMethod(checker));

            string checkString = Console.ReadLine();

            if(checker.checkIsPalindrome(checkString))
            {

                Console.WriteLine(checkString + " is a palindrome.");

            }

            else
            {

                Console.WriteLine(checkString + " is not a palindrome.");

            }

        }

        /// <summary>
        /// Tests a normal working palindrome with a central character such as "pop".
        /// Tests a normal working palindrome with no central character such as "peep".
        /// Tests a single character (such as "a") as this is a special case.
        /// Tests strings containing " ,;!?." characters placed randomly throughout a palindrome as these characters should be ignored (eg, pop becommes "? p,.!op") and should still return true.
        /// Tests a string that isn't a palindrome such as "test".
        /// </summary>
        /// <param name="palindromeCheckerInstance">Instance of the palindrome checker.</param>
        /// <returns>String containing a report of the method.</returns>
        private static string checkPalindromeCheckerMethod(IPalindromeChecker palindromeCheckerInstance)
        {

            string returnString = "Palindrome test results:\n\n";

            if(palindromeCheckerInstance.checkIsPalindrome("pop"))
            {

                returnString += "[PASS]Test for palindromes with central character (odd character length palindrome).\n";

            }

            else
            {

                returnString += "[FAIL]Test for palindromes with central character (odd character length palindrome).\n";

            }

            if(palindromeCheckerInstance.checkIsPalindrome("peep"))
            {

                returnString += "[PASS]Test for palindromes with no central character (even character length palindrome).\n";

            }

            else
            {

                returnString += "[FAIL]Test for palindromes with no central character (even character length palindrome).\n";

            }

            if (palindromeCheckerInstance.checkIsPalindrome("a"))
            {

                returnString += "[PASS]Test for palindromes with only one character.\n";

            }

            else
            {

                returnString += "[FAIL]Test for palindromes with only one character.\n";

            }

            if (palindromeCheckerInstance.checkIsPalindrome("? p,.!op"))
            {

                returnString += "[PASS]Test for palindromes with \" ,;!?.\" characters placed randomly throughout.\n";

            }

            else
            {

                returnString += "[FAIL]Test for palindromes with \" ,;!?.\" characters placed randomly throughout.\n";

            }

            if (!palindromeCheckerInstance.checkIsPalindrome("test"))
            {

                returnString += "[PASS]Test for something that is not a palindrome.\n";

            }

            else
            {

                returnString += "[FAIL]Test for something that is not a palindrome.\n";

            }

            return returnString;

        }

    }

}
