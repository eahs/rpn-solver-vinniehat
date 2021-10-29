using System;
using System.Collections.Generic;

namespace RPNSolver.Services
{
    public class ExpressionService
    {
        private string OPERATORS = "+-*/";
        /// <summary>
        /// Converts an infix expression to postfix and returns it
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public string ConvertInfixToPostfix(string expression) // Example: +34
        {
            char[] characters = expression.ToCharArray();
            Stack<char> numbers = new Stack<char>();
            Dictionary<int, char> operators = new Dictionary<int, char>(); // index, operator

            for (int i = 0; i < characters.Length; i++)
            {
                if (OPERATORS.Contains(characters[i])) operators.Add(i, characters[i]);
                if (Char.IsNumber(characters[i])) numbers.Push(characters[i]);
            }

            while (numbers.Count != 0)
            {
                for (int i = -2; i < numbers.Count;)
                {
                    int n1 = 0;
                    int n2 = 0;
                    if (numbers.Count > i + 2)
                    {
                        i += 2;
                    }

                    n2 = numbers.Pop();
                    n1 = numbers.Pop();
                    
                    if(operators[i].ToString() == "+") numbers.Push(Convert.ToChar(n2+n1));
                    if(operators[i].ToString() == "-") numbers.Push(Convert.ToChar(n2-n1));
                    if(operators[i].ToString() == "*") numbers.Push(Convert.ToChar(n2*n1));
                    if(operators[i].ToString() == "/") numbers.Push(Convert.ToChar(n2/n1));

                }
            }

            return "idkwtfbbq";
        }

        /// <summary>
        /// Evaluates a postfix 
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public int EvaluatePostfix(string expression)
        {
            return 0;
        }
    }
}