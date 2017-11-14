using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;

namespace WhillsBot.Modules
{
    public class General : ModuleBase<SocketCommandContext>
    {
        [Command("Help")]
        public async Task help()
        {
            var eb = new EmbedBuilder();
            eb.WithTitle("Help");
            eb.WithDescription("Commands");
            eb.AddField("`!hello`", "Say hello");
            eb.AddField("`!test`", "Test the Whills");
            eb.AddField("`!echo <string>`", "The Whills will echo you");
            eb.AddField("`!joke`", "Get a cheesy joke");
            eb.WithColor(Color.Blue);

            await Context.Channel.SendMessageAsync("", false, eb);
        }

        [Command("Hello")]
        public async Task Hello()
        {
            await Context.Channel.SendMessageAsync("Hello there!");
        }

        [Command("Test")]
        public async Task Test()
        {
            await Context.Channel.SendMessageAsync("This bot is fully armed and operational.");
        }

        [Command("Echo")]
        public async Task Echo(string text)
        {
            await Context.Channel.SendMessageAsync(text);
        }

        [Command("Joke")]
        public async Task Joke()
        {
            Random rand = new Random();
            string[] lines = System.IO.File.ReadAllLines(@"..\..\jokes.txt");
            await Context.Channel.SendMessageAsync(lines[rand.Next(0, lines.Length)]);
        }

        [Command("About")]
        public async Task About()
        {
            await Context.Channel.SendMessageAsync("This bot was created by **Kala0330**.\nView code: https://github.com/Kala30/WhillsBot");
        }
    }
}
