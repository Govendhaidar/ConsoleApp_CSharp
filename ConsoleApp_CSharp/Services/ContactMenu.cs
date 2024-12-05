using System;

namespace ConsoleApp_CSharp.Services;

public class ContactMenu
{
    private readonly MenuServices _menuServices = new();
    // denna kod genererar ChatGpt 4o. Koden skickar ett meddelande till användaren så att användaren kan fortsätta med programmet OM användaren har tryckt fel på tangenten.
    private void InvalidOption(string message)
    {
        Console.WriteLine(message);
        Console.WriteLine("Vänligen tryck på en tangent för att fortsätta");
        Console.ReadKey();
    }
    //
    public void CreateContactMenu()
    {
        bool isRunning = true;

        do
        {
            Console.Clear();
            Console.WriteLine("Vänligen fyll i dina uppgifter, tack.");
            Console.WriteLine("1. Registrera användare");
            Console.WriteLine("2. Visa registrerad användare");
            Console.WriteLine("q. Vänligen avsluta programmet");
            Console.WriteLine("");
            Console.Write("Vänligen välj ditt alternativ: ");

            string option = Console.ReadLine()!;

            switch (option.ToLower())
            {
                case "1":
                    _menuServices.CreateUserDialog();
                    break;

                    case "2":
                    _menuServices.ViewAllUserDialog();
                    break;

                    case "q":
                    Console.Clear();
                    Console.WriteLine("Tryck på en tangent för att avsluta och stänga ner programmet");
                    Console.ReadKey();

                    isRunning = false;
                    break;

                   default:
                    InvalidOption("Felaktigt, vänligen försök igen");
                    break;
            }
        } while (isRunning);
    }

}

