using Business.Dtos;
using Business.Helpers;
using Business.Models;

namespace Business.factories;

public class UserFactory
{
    public static RegistrationForm Create()
    {
        return new RegistrationForm();
    }
    
    public static User Create(RegistrationForm form)
    {
        return new User
        {
            Id = UniqueIdentifierGenerator.Generate(),
            FirstName = form.firstName,
            LastName = form.lastName,
            Email = form.Email,
            Adress = form.Adress,
         
        };
    }
}

