using System;
using System.Linq.Expressions;

namespace ThrowingExceptions
{
    class Program()
    {
        static void Main()
        {
            Console.Write("Username: ");
            string UserName = Console.ReadLine();
            Console.Write("Password: ");
            string Password = Console.ReadLine();
            try
            {
                CheckCredentials(UserName, Password);
            }
            catch (InvalidUserNameException)
            {
                Console.WriteLine("Username is invalid.");
            }
            catch (InvalidPasswordException)
            {
                Console.WriteLine("Password is invalid.");
            }
        }
        static void CheckCredentials(string username, string password)
        {
            string ActualUsername = "JoeMama";
            string ActualPassword = "12345AP";
            if (username != ActualUsername || username.Length < 4)
            {
                throw new InvalidUserNameException();
            }
            else if (password != ActualPassword || password.Length < 6)
            {
                throw new InvalidPasswordException();
            }
            else
            {
                Console.WriteLine("Access Granted.");
            }
        }

    }
    public class InvalidUserNameException : Exception
    {
        public InvalidUserNameException()
        {
            Console.WriteLine("Error.");
        }
    }
    public class InvalidPasswordException : Exception
    {
        public InvalidPasswordException()
        {
            Console.WriteLine("Error.");
        }
    }
}