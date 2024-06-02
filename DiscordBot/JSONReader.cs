using Newtonsoft.Json;

namespace DiscordBot
{
	public class JSONReader
	{
		public string? Token { get; set; }
		public string? Prefix { get; set; }

		public async Task ReadJSON()
		{
			using var sr = new StreamReader("Config/config.json");
			var json = await sr.ReadToEndAsync();
			var data = JsonConvert.DeserializeObject<JSONStructure?>(json);

			this.Token = data?.Token;
			this.Prefix = data?.Prefix;		
		}
	}

	internal sealed class JSONStructure
	{
		public string? Token { get; set; }
		public string? Prefix { get; set; }
	}
}
