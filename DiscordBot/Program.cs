using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.EventArgs;
using DiscordBot.Commands;

namespace DiscordBot
{
	internal class Program
	{
		private static DiscordClient? Client { get; set; }
		private static CommandsNextExtension? Commands { get; set; }

		public static async Task Main()
		{
			var jsonReader = new JSONReader();
			await jsonReader.ReadJSON();

			var discordConfig = new DiscordConfiguration()
			{
				Intents = DiscordIntents.All,
				Token = jsonReader.Token,
				TokenType = TokenType.Bot,
				AutoReconnect = true,
			};

			Client = new DiscordClient(discordConfig);
			Client.Ready += Client_Ready;

			var commandsConfig = new CommandsNextConfiguration()
			{
				StringPrefixes = new string[] { jsonReader?.Prefix },
				EnableMentionPrefix = true,
				EnableDms = true,
				EnableDefaultHelp = false,
			};

			Commands = Client.UseCommandsNext(commandsConfig);
			Commands.RegisterCommands<BotCommands>();

			await Client.ConnectAsync();
			await Task.Delay(-1);
		}

		private static Task Client_Ready(DiscordClient sender, ReadyEventArgs args)
		{
			return Task.CompletedTask;
		}
	}
}