﻿using System;
using System.Collections;
using System.Linq.Expressions;
using RPNSolver.Services;

namespace RPNSolver
{
    public class Program
    {
        private static ExpressionService ExpressionService { get; set; }
        
        static void Main()
        {
            ExpressionService = new ExpressionService();

            while (true)
            {
                DisplayMenu();

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ConvertInfix();
                        break;
                    case "2":
                        EvaluatePostfix();
                        break;
                    default: 
                        DisplayErrorMessage("Unknown menu option");
                        break;
                }
            }
        }

        /// <summary>
        /// Displays the RPN Solver menu
        /// </summary>
        private static void DisplayMenu()
        {
            Console.Clear();
            
            Console.WriteLine("RPN Solver");
            Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=--=-=-=-");
            Console.WriteLine("Welcome to the RPN Solver!\nOur motto is \"If we can't solve it, it isn't RPN!\"");
            Console.WriteLine("");
            Console.WriteLine("Menu Options");
            Console.WriteLine(" 1. Convert Infix to Postfix expression");
            Console.WriteLine(" 2. Evaluate Postfix expression\n");
            
            Console.Write("\nChoose an Option: ");
            
        }

        /// <summary>
        /// Displays a friendly formatted error message
        /// </summary>
        /// <param name="message"></param>
        private static void DisplayErrorMessage(string message)
        {
            Console.WriteLine("The following error has occurred:");
            Console.WriteLine(message);
        }

        /// <summary>
        /// Asks the user to input a prefix expression and then converts it to postfix and then evaluates it.
        /// </summary>
        private static void ConvertInfix () // English Notation -> Reverse Polish Notation
        {
            Console.Write("Enter an infix expression: ");
            string expression = Console.ReadLine();

            string postfixExpression = ExpressionService.ConvertInfixToPostfix(expression);
            int solution = ExpressionService.EvaluatePostfix(postfixExpression);
            
            Console.WriteLine($"Postfix expression: {postfixExpression}");
            Console.WriteLine($"Solution: {solution}\n");             
        }

        private static void EvaluatePostfix() // Reverse Polish Notation -> Answer
        {
            Console.Write("Enter a postfix expression: ");
            string expression = Console.ReadLine();

            int solution = ExpressionService.EvaluatePostfix(expression);
            
            Console.WriteLine($"Solution: {solution}\n");             
        }
    }
}