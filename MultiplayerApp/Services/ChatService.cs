using System.IO.Pipes;
using System.IO;
using System;

public class ChatService
{
    private const string PipeName = "chatPipe";

    public static void SendMessage(string message)
    {
        using (var pipeClient = new NamedPipeClientStream(PipeName))
        {
            pipeClient.Connect();
            using (var writer = new StreamWriter(pipeClient))
            {
                writer.WriteLine(message);
            }
        }
    }
    public static void StartListening(Action<string> messageReceivedCallback)
    {
        var pipeServer = new NamedPipeServerStream(PipeName);
        pipeServer.WaitForConnection();
        using (var reader = new StreamReader(pipeServer))
        {
            while (true)
            {
                var message = reader.ReadLine();
                messageReceivedCallback(message);
            }
        }
    }
}
