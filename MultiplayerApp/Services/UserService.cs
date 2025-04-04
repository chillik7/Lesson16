using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

public class UserService
{
    private const string UserFilePath = "users.json";

    public static void SaveUser(User user)
    {
        var users = LoadUsers();
        users.Add(user);
        var json = JsonConvert.SerializeObject(users, Formatting.Indented);
        File.WriteAllText(UserFilePath, json);
    }

    public static List<User> LoadUsers()
    {
        if (File.Exists(UserFilePath))
        {
            var json = File.ReadAllText(UserFilePath);
            return JsonConvert.DeserializeObject<List<User>>(json);
        }
        return new List<User>();
    }

    public static bool Authenticate(string username, string password)
    {
        var users = LoadUsers();
        return users.Exists(u => u.Username == username && u.Password == password);
    }
}
