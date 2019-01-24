using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;


using Discord;
using Discord.WebSocket;
using Discord.Commands;

namespace CFN_Bot
{
	class Program
	{

		static void Main(string[] args) => new Program().RunBotAsync().GetAwaiter().GetResult();


		private DiscordSocketClient Client;
		private CommandService Commands;
		private IServiceProvider Services;

		public async Task RunBotAsync()
		{
			Client = new DiscordSocketClient();
			Commands = new CommandService();
			Services = new ServiceCollection()
				.AddSingleton(Client)
				.AddSingleton(Commands)
				.BuildServiceProvider();

			string botKey = "NTM0MzI4NzkyOTkxMTM3Nzkz.Dx4ogw.4MUKzsrxUvVqIZfBsOlos0xXtC8";

			//event subs
			Client.Log += Log;
			Client.UserJoined += AnnounceUserJoined;
			

			await RegisterCommandsAsync();

			await Client.LoginAsync(TokenType.Bot, botKey);
			await Client.SetGameAsync("With a Ball", null, ActivityType.Playing);
			await Client.StartAsync();

			await Task.Delay(-1);
		}
		
		private Task Log(LogMessage arg)
		{
			Console.WriteLine(arg);
			return Task.CompletedTask;
		}

		private async Task AnnounceUserJoined(SocketGuildUser user)
		{
			var guild = user.Guild;


			//TODO CHANGE TO ANNOUNCEMENT CHANNEL
			var Channel = guild.DefaultChannel;
			await Channel.SendMessageAsync($"Welcome, {user.Mention}! welcome to CFN!, Please type one of the commands to set your role!");

			EmbedBuilder builder = new EmbedBuilder();
			builder.Color = new Color(1f, 1f, 0f);
			builder.AddField("Commands", "!gamedev >>> Gamedev Role !youtuber >>> Youtuber Role", false);
			builder.AddField("", "Tester", false);
			await Channel.SendMessageAsync(null,false,builder.Build());
					
		}

		public async Task RegisterCommandsAsync()
		{
			Client.MessageReceived += HandleCommandAsync;
			await Commands.AddModulesAsync(Assembly.GetEntryAssembly(), Services);
		}

		private async Task HandleCommandAsync(SocketMessage arg)
		{
			var message = arg as SocketUserMessage;

			if (message == null || message.Author.IsBot) return;

			int argPos = 0; 

			if(message.HasStringPrefix("!", ref argPos) || message.HasMentionPrefix(Client.CurrentUser, ref argPos))
			{
				var context = new SocketCommandContext(Client, message);

				var result = await Commands.ExecuteAsync(context, argPos, Services);

				if (!result.IsSuccess)
					Console.WriteLine(result.ErrorReason);
			}

		}
	}
}
