using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;

namespace WhillsBot.Modules
{
    public class Test : ModuleBase<SocketCommandContext>
    {
        [Command("Hello")]
        public async Task greeting()
        {
            await Context.Channel.SendMessageAsync("```Hello there!```");
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
    }
}
