using DSharpPlus;

namespace DiscordC2;

 public class Server {
     public static async Task Main(string[] args)
     {
         var discord = new DiscordClient(new DiscordConfiguration() {
            Token = File.ReadAllText(".dc2"),
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
        Console.WriteLine("DiscordC2::Booting finished..");
        await Task.Delay(-1);
        Console.WriteLine("DiscordC2::Server task exited unexpectedly..");
     }
    //Using add-type this entry point is callable from powershell
    //[DiscordC2.Server]::Start()
     public static async Task Start() {
        var discord = new DiscordClient(new DiscordConfiguration() {
            Token =  File.ReadAllText("/.dc2"),
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
        Console.WriteLine("DiscordC2::Booting finished..");
        await Task.Delay(-1);
        Console.WriteLine("DiscordC2::Server task exited unexpectedly..");
     }
 }