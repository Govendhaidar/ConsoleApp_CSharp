using Business.Models;
using Business.Services;

namespace Business_test;
public class FileService_Test
{
    private readonly string _testDirectory = "TestData";
    private readonly string _testFileName = "Test_list.json";
    /// <summary>
    /// Den här koden har genererats av ChatGPT.
    /// Arrange delen skapar en instans av fileservice där den sparar filer i katalogen testDirectory och ger filen ett namn som i detta fall heter testFileName
    /// Act är där själva testet ska utföras och när testet har utförts så ska den sparas till filen som i detta fall heter (users)
    /// Assert kontrollerar och tittar så att filens innehåll finns på den plats där det förväntas ska vara.
    /// Om något av detta misslyckas så kommer filen inte att skapas då innehållet saknar rätt information
    /// </summary>
    [Fact]
    public void SaveListToFile_ShouldCreateFileAndSaveContent()
    {
        //Arrange

        var fileService = new FileService(_testDirectory, _testFileName);
        var users = new List<User>
        {
            new User 
            {
                FirstName = "Govii",
                LastName = "Haidar", 
                Email    = "first@domain.com", 
                Adress   = "knudgata"
             },

            new User 
            {
              FirstName = "Test",
              LastName = "Testa", 
              Email    = "Test@domain.com",
              Adress   = "kungensgata"
            }

        };

        //Act
        fileService.SaveListToFile(users);

        //Assert
        var filePath = Path.Combine(_testDirectory, _testFileName);
        Assert.True(File.Exists(filePath));
        var fileContent = File.ReadAllText(filePath);
        Assert.Contains("Test", fileContent);
    }
    /// <summary>
    /// Denna kod genererar från ChatGPT. Arrange delen är den delen som skapar resurs och förusttäningar som behövs för att köra igång testet. 
    /// Act Delen är den delen där själva testet utförs.
    /// Assert är den delen som veriefierar resultatet.
    /// </summary>
    [Fact]
    public void LoadListFromFile_ShouldReturnSavedList()
    {
        //Arrange
        var fileService = new FileService(_testFileName, _testDirectory);
        var users = new List<User>
        {
            new User
            {
                FirstName = "Govii",
                LastName = "Haidar",
                Email    = "First@domain.com",
                Adress   = "Knudgata"
            },

             new User
             {
                 FirstName = "Test",
                 LastName = "Testa",
                 Email    = "Test@domain.com",
                 Adress   = "kungensgata"
             }
        };

        fileService.SaveListToFile(users);


        //Act
        var loadedUsers = fileService.LoadListFromFile();


        //Asserrt
        Assert.NotNull(loadedUsers);
        Assert.Equal(2, loadedUsers.Count);
        Assert.Equal("Govii", loadedUsers[0].FirstName);
        Assert.Equal("Test", loadedUsers[1].FirstName);
    }

}
