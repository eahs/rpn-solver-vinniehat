﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

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
        public string ConvertInfixToPostfix(string expression) // Example: 3+4 = +34
        {
            string[] characters = expression.Select(x => x.ToString()).ToArray();
            List<string> output = new List<string>();
            Stack<string> stack = new Stack<string>();
            

            foreach (var token in characters)
            {
                if (int.TryParse(token, out _)) output.Add(token);
                else if (token == ")") // This is done because it is prioritized
                {
                    while(stack.Count != 0 && stack.Peek() != "(") output.Add(stack.Pop());

                    stack.Pop(); // Now after the while loop is done, we can REMOVE the "("

                }
                else
                {
                    if (stack.Count == 0 || Precedence(token) < Precedence(stack.Peek()) || token == "(")
                        stack.Push(token);
                }


            }

            while(stack.Count != 0) output.Add(stack.Pop());
            
            return output.Aggregate("", (current, s) => current + s);
        }

        /// <summary>
        /// Evaluates a postfix 
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public int EvaluatePostfix(string expression)
        {
            string[] characters = expression.Select(x => x.ToString()).ToArray();
            Stack<string> stack = new Stack<string>();

            foreach (var character in characters)
            {
                if (int.TryParse(character, out _)) stack.Push(character);
                else if (OPERATORS.Contains(character))
                {
                    int n1 = int.Parse(stack.Pop());
                    int n2 = int.Parse(stack.Pop());
                    if(character == "+") stack.Push((n2 + n1).ToString());
                    if(character == "-") stack.Push((n2 - n1).ToString());
                    if(character == "/") stack.Push((n2 / n1).ToString());
                    if(character == "*") stack.Push((n2 * n1).ToString());
                }
            }

            return int.Parse(stack.Peek());
        }
        

        public int Precedence(string op)
        {
            switch (op)
            {
                case "*":
                case "/":
                    return 2;
                case "+":
                case "-":
                    return 1;
                default:
                    return 3;
            }
        }
    }
}