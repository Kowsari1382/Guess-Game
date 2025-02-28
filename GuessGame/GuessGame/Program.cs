using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GuessGame
{
    class Program
    {
        static void Main(string[] args)
        { 
            string x;
            int check;
            Console.WriteLine("Welcome...\nThis is a guess number game");
            Console.WriteLine("input your name:");
            string name = Console.ReadLine();
            Console.WriteLine("input your sex:\nif you are man,input m else if you are woman,input w");
            char sex = Convert.ToChar(Console.ReadLine());
            Console.WriteLine("how old are you?:");
            int age = int.Parse(Console.ReadLine());
            Console.WriteLine("input dificulty of game\nif you want easy, input 0 and if you want hard,input 1:");
            int dificulty = int.Parse(Console.ReadLine());
            if(dificulty!=0 && dificulty!=1)
            {
                dificulty = 0;
            }
            GuessGame guessgame = new GuessGame(dificulty,name,sex,age);
            guessgame.LoadFile();
            string command;
            while (true)
            {
                Console.WriteLine("if you want to start game, input 0. else, input a number between 1 to 6 if you want to see guide, input 7");
                command = Console.ReadLine();
                switch (command)
                {
                    case "0":
                        {
                            guessgame.PlayAgain();
                            while (true)
                            {
                                Console.WriteLine("Enter a number for guess and if you need help for guessing, input help:");
                                x = Console.ReadLine();
                                if (x=="help")
                                {
                                    guessgame.Help();
                                }
                                else
                                {
                                    int a = Convert.ToInt32(x);
                                    check = guessgame.CheckUserInput(a);
                                    if (check == -1)
                                    {
                                        guessgame.PrintResult();
                                        Console.WriteLine("Do you want to play another game? input y for yes and n for no");
                                        if (Console.ReadLine() == "y")
                                        {
                                            guessgame.SaveFile();
                                            guessgame.PlayAgain();
                                        }
                                        else
                                        {
                                            guessgame.SaveFile();
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                        break;
                    case "1":
                        {
                            guessgame.PrintUsers();
                        }
                        break;
                    case "2":
                        {
                            Console.WriteLine("input a name for search by name:");
                            string noun = Console.ReadLine();
                            guessgame.SearchByName(noun);
                        }
                        break;
                    case "3":
                        {
                            guessgame.PrintBests();
                        }
                        break;
                    case "4":
                        {
                            guessgame.SearchByAge();
                        }
                        break;
                    case "5":
                        {
                            Console.WriteLine("input a username for find best score for it:");
                            string n = Console.ReadLine();
                            guessgame.BestRecord(n);
                        }
                        break;
                    case "6":
                        {
                            Environment.Exit(0);
                        }
                        break;
                    case "7":
                        {
                            Console.WriteLine("input 0 for start game");
                            Console.WriteLine("input 1 for print all of users");
                            Console.WriteLine("input 2 for search users by name");
                            Console.WriteLine("input 3 for print best players");
                            Console.WriteLine("input 4 for search users by age");
                            Console.WriteLine("input 5 for print best record");
                            Console.WriteLine("input 6 for exit");
                        }
                        break;
                    default:
                        {
                            Console.WriteLine("input a number between 0 to 6");
                        }
                        break;
                }
            }
        }
    }
}