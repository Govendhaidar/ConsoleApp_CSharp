using Business.Dtos;
using Business.factories;
using Business.Models;

namespace Business.Services;
 public class UserService
{
    private List<User> _users = [];
    private readonly FileService _fileService = new(@"c:\Projects");

    public void Add (RegistrationForm form)
    {
        User user = UserFactory.Create(form);
        _users.Add(user);
        _fileService.SaveListToFile(_users);

    }

    public IEnumerable<User> GetAll()
    {
        _users = _fileService.LoadListFromFile();
        return _users;
    }
    
}

