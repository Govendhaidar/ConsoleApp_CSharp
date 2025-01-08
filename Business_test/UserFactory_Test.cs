using Business.Dtos;
using Business.factories;
using Business.Models;

namespace Business_test;
public class UserFactory_Test
{
    [Fact]
    public void Create_ShouldReturnRegistrationForm()
    {
        //Arrange

        //Act
        var result = UserFactory.Create();

        //Assert
        Assert.NotNull(result);
        Assert.IsType<RegistrationForm>(result);
    }

    [Fact]
    public void Create_ShouldReturnUser_WhenRegistrationFormProvided()
    {
        //Arrange
        var registrationform = new RegistrationForm()
        {
            firstName = "govii",
            lastName = "Haidar",
            Email = "first@domain.com",
            Adress = "knudgata",
            CreatedDate = DateTime.Now
        };

        //Act
        var result = UserFactory.Create(registrationform);

        //Assert
        Assert.NotNull(result);
        Assert.IsType<User>(result);
    }
}
