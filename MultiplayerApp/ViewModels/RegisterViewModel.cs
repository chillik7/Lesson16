public class RegisterViewModel
{
    public string Username { get; set; }
    public string Password { get; set; }

    public void Register()
    {
        var user = new User { Username = Username, Password = Password };
        UserService.SaveUser(user);
    }
}
