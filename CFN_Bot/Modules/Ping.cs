using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.Commands;
using Discord;

namespace CFN_Bot.Modules
{
	public class Ping : ModuleBase<SocketCommandContext>
	{
		[Command("ping")]

		public async Task PingAsync()
		{
			await ReplyAsync($"type yes or no");			
		}


		[Command("read")]
		public async Task Read(string name)
		{
			await ReplyAsync($"{name} ");
		}


		[Command("Gamedev")]
		public async Task gamedev()
		{
			var user = Context.User;
			var role = Context.Guild.Roles.FirstOrDefault(x => x.Name == "GameDev");
			await ReplyAsync("You have been Assigned the Game Developer role!");
			await (user as IGuildUser).AddRoleAsync(role);
			
		}

		[Command("VideoCreator")]
		public async Task youtuber()
		{
			var user = Context.User;
			var role = Context.Guild.Roles.FirstOrDefault(x => x.Name == "VideoCreator");
			await ReplyAsync("You have been Assigned the VideoCreator role!");
			await (user as IGuildUser).AddRoleAsync(role);
		}

		[Command("GamePress")]
		public async Task streamer()
		{
			var user = Context.User;
			var role = Context.Guild.Roles.FirstOrDefault(x => x.Name == "GamePress");
			await ReplyAsync("You have been Assigned the GamePress role!");
			await (user as IGuildUser).AddRoleAsync(role);
		}

		[Command("Artist")]
		public async Task Artist()
		{
			var user = Context.User;
			var role = Context.Guild.Roles.FirstOrDefault(x => x.Name == "Artist");
			await ReplyAsync("You have been Assigned the Artist role!");
			await (user as IGuildUser).AddRoleAsync(role);
		}

		[Command("Music")]
		public async Task Music()
		{
			var user = Context.User;
			var role = Context.Guild.Roles.FirstOrDefault(x => x.Name == "Music_And_Audio");
			await ReplyAsync("You have been Assigned the Music role!");
			await (user as IGuildUser).AddRoleAsync(role);
		}

		[Command("Streamer")]
		public async Task Streamer()
		{
			var user = Context.User;
			var role = Context.Guild.Roles.FirstOrDefault(x => x.Name == "Streamer");
			await ReplyAsync("You have been Assigned the Streamer role!");
			await (user as IGuildUser).AddRoleAsync(role);
		}


		[Command("helpAdmin")]
		public async Task helper()
		{
			var guild = Context.Guild;
			var Channel = guild.DefaultChannel as IMessageChannel;
			await Channel.SendMessageAsync($"Welcome, {Context.User.Mention}! welcome to CFN!, Please type one of the commands to set your role!");

			EmbedBuilder builder = new EmbedBuilder();
			builder.Color = new Color(1f, 1f, 0f);
			builder.AddField("!GameDev", "if you design games, or work in a studio!", false);
			builder.AddField("!VideoCreator", "if you are a content creator!", false);
			builder.AddField("!GamePress", "text");
			builder.AddField("!Artist", "text");
			builder.AddField("!Music", "text");
			builder.AddField("!Streamer", "text");
			await Channel.SendMessageAsync(null, false, builder.Build());
		}

		[Command("Roll")]
		public async Task roller()
		{
			Random rnd = new Random();
			await ReplyAsync($"You Rolled a { rnd.Next(0, 12) }!"); 
		}

	}
}
