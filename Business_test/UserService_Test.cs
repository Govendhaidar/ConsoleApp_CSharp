using Business.Dtos;
using Business.Services;



namespace Business_test;

public class UserService_Test
{

    [Fact]
    public void Add_ShouldAddUserToList()
    {
        //Arrange
        var userService = new UserService();
        var registrationForm = new RegistrationForm()
        {
           

            firstName = "Govii",
            lastName  = "Haidar",
            Email     = "first@domain.com",
            Adress    = "knudgata",
            CreatedDate = DateTime.Now
        

        };

        var registrationForm2 = new RegistrationForm()
        {
            firstName = "Test",
            lastName  = "Testsson",
            Email     = "Test@domain.com",
            Adress    = "kungensgata",
            CreatedDate = DateTime.Now

        };

        var registrationForm3 = new RegistrationForm()
        {
            firstName = "Test2",
            lastName  = "Testsson2",
            Email     = "Test2@domain.com",
            Adress    = "kungensgata2",
            CreatedDate = DateTime.Now

        };

        


        //ACT
        userService.Add(registrationForm);
        userService.Add(registrationForm2);
        userService.Add(registrationForm3);

        //Assert
        var users = userService.GetAll();


    }





    [Fact]
    public void GetAll_ShouldReturnSavedUsersFromFile()
    {
        //Arrange
        var fileService = new FileService();
        var userService = new UserService();


        //Act
        var users = userService.GetAll().ToList();

        //Assert
        Assert.NotNull(users);
        Assert.Equal(3, users.Count);
        Assert.Equal("Govii", users[0].FirstName);
        Assert.Contains(users, u => u.FirstName == "Test");
    }


}



