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
            if (e.Message.Content.ToLower().StartsWith("ping")) {
                await e.Message.RespondAsync("pong!");
            }
        };

        Console.WriteLine("DiscordC2::Server booting..");
        await discord.ConnectAsync();
        Console.WriteLine("DiscordC2::Booting finished");
    }
 }