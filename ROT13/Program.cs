using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Program
    {
        //ConcurrentDictionary for thread safety?
        static Dictionary<string,string> pastSolutions = new Dictionary<string, string>();

        static void Main(string[] args)
        {
            var result = ROT13(ROT13("apple"));
            result = ROT13("apples");


            result = ROT13("simeon");
            result = ROT13("fvzrba");
            result = ROT13("simeon ayling");
            result = ROT13("test");
        }


        static string ROT13_a(string passed)
        {
            if (String.IsNullOrEmpty(passed))
            {
                return passed;
            }


            string solution = "";

            // Main cipher code
            for (int i = 0; i < passed.Length; i++)
            {
                var testChar = passed[i];
                var testAscii = (int)testChar;

                switch (testAscii)
                {
                    case int n when (n >= 'A' && n <= 'Z'):
                        testAscii += 13;
                        if (testAscii > 'Z')
                            testAscii = 'A' + (testAscii % 'Z') - 1;
                        break;
                    case int n when (n >= 'a' && n <= 'z'):
                        testAscii += 13;
                        if (testAscii > 'z')
                            testAscii = 'a' + (testAscii % 'z') - 1;
                        break;
                    default:
                        break;
                }
                solution += (char)testAscii;
            }

            return solution;
        }


        static string ROT13_b(string passed)
        {
            if (String.IsNullOrEmpty(passed))
            {
                return passed;
            }

            // Have we ciphered the string previously?
            if (pastSolutions.ContainsKey(passed))
            {
                return (string)pastSolutions[passed];
            }

            string solution = "";

            // Main cipher code
            for (int i = solution.Length; i < passed.Length; i++)
            {
                var testChar = passed[i];
                var testAscii = (int)testChar;

                switch (testAscii)
                {
                    case int n when (n >= 'A' && n <= 'Z'):
                        testAscii += 13;
                        if (testAscii > 'Z')
                            testAscii = 'A' + (testAscii % 'Z') - 1;
                        break;
                    case int n when (n >= 'a' && n <= 'z'):
                        testAscii += 13;
                        if (testAscii > 'z')
                            testAscii = 'a' + (testAscii % 'z') - 1;
                        break;
                    default:
                        break;
                }
                solution += (char)testAscii;
            }

            pastSolutions.Add(passed, solution);
            pastSolutions.Add(solution, passed);
            return solution;
        }


        static string ROT13(string passed)
        {
            if (String.IsNullOrEmpty(passed))
            {
                return passed;
            }

            // Have we ciphered the string previously?
            if (pastSolutions.ContainsKey(passed))
            {
                return (string)pastSolutions[passed];
            }

            // Have we ciphered a portion of the string previously?
            string solution = "";
            var test = passed.Substring(0, passed.Length - 1);
            while (test.Length > 0)
            { 
                if (pastSolutions.ContainsKey(test))
                {
                    solution = (string)pastSolutions[test];
                    break;
                }
                test = test.Substring(0, test.Length - 1);
            }           

            // Main cipher code
            for (int i = solution.Length; i < passed.Length; i++)
            {
                var testChar = passed[i];
                var testAscii = (int)testChar;
                
                switch (testAscii)
                {
                    case int n when (n >= 'A' && n <= 'Z'):
                        testAscii += 13;
                        if (testAscii > 'Z')
                            testAscii = 'A' + (testAscii % 'Z') - 1;
                        break;
                    case int n when (n >= 'a' && n <= 'z'):
                        testAscii += 13;
                        if (testAscii > 'z')
                            testAscii = 'a' + (testAscii % 'z') - 1;
                        break;
                    default:
                        break;
                }
                solution += (char)testAscii;
            }

            pastSolutions.Add(passed, solution);
            pastSolutions.Add(solution, passed);
            return solution;
        }
    }
}
