using Business.Dtos;
using Business.factories;
using Business.Models;
using Business.Services;

namespace ConsoleApp_CSharp.Services;

public class MenuServices
{
    private readonly UserService _userService = new();

    public void CreateUserDialog()
    {
        Console.Clear();

        Console.WriteLine("Fyll i dina uppgifter, tack!");
        RegistrationForm user = UserFactory.Create();

        User user1 = new();

        Console.Write("Skriv ditt förnamn: ");
        user.firstName = Console.ReadLine()!;


        Console.Write("Skriv ditt efternamn: ");
        user.lastName = Console.ReadLine()!;


        Console.Write("Skriv din Email: ");
        user.Email = Console.ReadLine()!;



        Console.Write("Skriv din Adress: ");
        user.Adress = Console.ReadLine()!;


       

        _userService.Add(user);
    }

    public void ViewAllUserDialog()
    {
        Console.Clear();
        var users = _userService.GetAll();

        foreach (var user in users)
        {
            Console.WriteLine($"{"Id:",-10} {user.Id}");
            Console.WriteLine($"{"Name:",-10} {user.FirstName} {user.LastName}");

            Console.WriteLine($"{"Email:",-10} {user.Email}");
            Console.WriteLine($"{"Adress:",-10} {user.Adress}");
            Console.WriteLine($"{"Created:",-10} {user.CreatedDate}");

            Console.WriteLine("");

        }

        Console.ReadKey();
    }

}

