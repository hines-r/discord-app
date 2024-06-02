using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.CommandsNext;

namespace DiscordBot.Commands
{
	public class BotCommands : BaseCommandModule
	{
		private CancellationTokenSource? _cts;

		[Command("cd")]
		public async Task CountdownCommand(CommandContext ctx)
		{
			_cts = new CancellationTokenSource();

			await Task.Run(async () =>
			{
				for (int i = 3; i > 0; i--)
				{
					await ctx.Channel.SendMessageAsync($"{i}");
					await Task.Delay(1000, _cts.Token);
				}
				await ctx.Channel.SendMessageAsync("Go!! (ﾉ´ヮ`)ﾉ*: ･ﾟ 🥥🍌🩳🍎🍑🍗");
			}, _cts.Token);
		}
	}
}
