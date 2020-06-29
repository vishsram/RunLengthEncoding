using System;
using System.Text;
using System.Linq;

namespace RunLengthEncoding
{
    class Program
    {
        public String ConvertRLE(String str) {
            if (String.IsNullOrEmpty(str)) {
                return String.Empty;
            }

            StringBuilder encoding = new StringBuilder();
            int i = 0; int currentCounter = 0;
            while (i < str.Length) {
                char currentChar = str[i];    
                while (i < str.Length) {
                    if (str[i] == currentChar) {
                        currentCounter++;
                        i++;
                    }
                    else {
                        i--;
                        break;
                    }
                }
                encoding.Append((char)(currentCounter + '0'));
                encoding.Append(currentChar);
                i++;
                // Reset currentCounter 
                currentCounter = 0;
            }

            return encoding.ToString();
        }

        public String RevertRLE(String str) {
            if (String.IsNullOrEmpty(str)) {
                return String.Empty;
            }

            // if str length is odd, it means the format for RLE is incorrect. Throw error.
            if (str.Length % 2 != 0) {
                throw new ArgumentException("String format for RLE is incorrect. It should be in the format of <digit><char> Eg. 5P");
            }

            char[] allowedChars = {'1', '2', '3', '4', '5', '6', '7', '8', '9', '0'};
            int index = 0;
            StringBuilder result = new StringBuilder();

            while(index < str.Length) {
                // Chars at even indices should be strictly numbers, throw otherwise.
                if (index % 2 == 0 && !allowedChars.Contains(str[index])) {
                    throw new ArgumentException("Only numbers from 0 to 9 are allowed at even indices.");
                }

                if (index % 2 == 0) {
                    result.Append(str[index+1], (str[index]-'0'));
                }
                index++;
            }

            return result.ToString();
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Program converter = new Program();
            String str = "AAABBBCCCCCCDD";
            String result = converter.ConvertRLE(str);
            Console.WriteLine(result);
            if (str == converter.RevertRLE(result)) {
                Console.WriteLine("Success!");
            }
        }
    }
}
