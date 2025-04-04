using System.IO.MemoryMappedFiles;
using System.Text;

public class NotificationService
{
    private const string MemoryMapName = "scheduleNotifications";

    public static void SendNotification(string message)
    {
        using (var mmf = MemoryMappedFile.CreateOrOpen(MemoryMapName, 1024))
        using (var stream = mmf.CreateViewStream())
        {
            var buffer = Encoding.UTF8.GetBytes(message);
            stream.Write(buffer, 0, buffer.Length);
        }
    }

    public static string ReadNotification()
    {
        using (var mmf = MemoryMappedFile.OpenExisting(MemoryMapName))
        using (var stream = mmf.CreateViewStream())
        {
            var buffer = new byte[1024];
            stream.Read(buffer, 0, buffer.Length);
            return Encoding.UTF8.GetString(buffer).TrimEnd('\0');
        }
    }
}
