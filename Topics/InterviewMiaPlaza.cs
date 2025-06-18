using Playground.Topics.Interfaces;

namespace Playground.Topics
{
    public class InterviewMiaPlaza : IRunner
    {
        public void Run()
        {
            var input1 = "()[]({})";
            Console.WriteLine($"{input1} is {ValidParentheses(input1)}");

            var input2 = "hheeellooo";
            Console.Write($"{input2} --> {ConciseString(input2)}");
        }

        // Imagine you are tasked with implementing a function that compresses a string by encoding consecutive repeated characters into a shorter format.The function should take a string of lowercase latin letters as input and return a new string where each sequence of repeated characters is replaced by a single instance of that character followed by the number of times it is repeated.
        // Note that if a character appears only once in the sequence, it should not be followed by a number
        // For example, given the input string "abbbcccc", the function should return "ab3c4".
        // 
        // Input:
        // "hheeellooo"
        // Output:
        // "h2e3l2o3"
        //
        // Input:
        // "aaa"
        //
        // Output:
        // "a3"
        //
        // Input:
        // "abc"
        // Output:
        // "abc"
        private string ConciseString(string input)
        {
            if (input.Length == 0) { return ""; }

            var occurance = new Dictionary<char, int>(); // store frequency
            foreach (var c in input)
            {
                if (occurance.ContainsKey(c))
                {
                    occurance[c] = occurance[c] + 1;
                }
                else
                {
                    occurance.Add(c, 1);
                }
            }

            var output = "";
            foreach (var info in occurance)
            {
                var repeated = info.Value > 1 ? info.Value.ToString() : string.Empty;
                output = output + $"{info.Key}{repeated}";
            }

            return output;
        }

        // Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.
        // 
        // An input string is valid if:
        // 
        // Open brackets must be closed by the same type of brackets.
        // Open brackets must be closed in the correct order.
        // Every close bracket has a corresponding open bracket of the same type
        // 
        // Example 1:
        // Input: s = "()"
        // Output: true
        // 
        // Example 2:
        // Input: s = "()[]({})"
        // Output: true
        // 
        // Example 3:
        // Input: s = "(]"
        // Output: false

        // Use stack
        // Plan
        // 1. Traverse all character in string
        //     - push opening braclet character into stack
        //     - if it is a case of closing bracket ']', ')', '}', pop the stack out
        private bool ValidParentheses(string input)
        {
            if (input.Length == 0) { return true; }

            var stack = new Stack<char>(); // this use to store each individual character from input

            foreach (var c in input)
            {
                if (c == '(' || c == '[' || c == '{')
                {
                    stack.Push(c);
                }
                else
                {
                    if (stack.Count > 0 && stack.Peek() == GetOpeningBracket(c))
                    {
                        stack.Pop();
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            return stack.Count == 0;
        }

        private char GetOpeningBracket(char c)
        {
            switch (c)
            {
                case ')': return '(';
                case ']': return '[';
                case '}': return '{';
            }

            return ' ';
        }
    }
}
