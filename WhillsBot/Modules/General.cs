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
            await Context.Channel.SendMessageAsync("**Commands**\n" +
                "`!hello` : Say hello\n" +
                "`!test` : Test the Whills\n" +
                "`!echo` : Whills will echo you\n" +
                "`!joke` : Get a cheesy joke");
        }

        [Command("Hello")]
        public async Task greeting()
        {
            await Context.Channel.SendMessageAsync("Hello there!");
        }

        [Command("Test")]
        public async Task test()
        {
            await Context.Channel.SendMessageAsync("This bot is fully armed and operational.");
        }

        [Command("Echo")]
        public async Task echo(string text)
        {
            await Context.Channel.SendMessageAsync(text);
        }

        [Command("Joke")]
        public async Task joke()
        {
            Random rand = new Random();
            string[] lines = System.IO.File.ReadAllLines(@"..\..\jokes.txt");
            await Context.Channel.SendMessageAsync(lines[rand.Next(0, lines.Length)]);
        }
    }
}
