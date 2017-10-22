using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.WebSocket;
using Discord.Commands;
using System.Reflection;

namespace WhillsBot
{
    class CommandHandler
    {
        private DiscordSocketClient client;

        private CommandService service;

        public CommandHandler(DiscordSocketClient _client)
        {
            client = _client;

            service = new CommandService();

            service.AddModulesAsync(Assembly.GetEntryAssembly());

            client.MessageReceived += HandleCommandAsync;
        }

        private async Task HandleCommandAsync(SocketMessage msgParam)
        {
            var msg = msgParam as SocketUserMessage;
            if (msg == null)
                return;

            var context = new SocketCommandContext(client, msg);

            int argPos = 0;
            if (msg.HasCharPrefix('!', ref argPos) || msg.HasMentionPrefix(client.CurrentUser, ref argPos))
            {
                var result = await service.ExecuteAsync(context, argPos);

                if (!result.IsSuccess && result.Error != CommandError.UnknownCommand)
                {
                    await context.Channel.SendMessageAsync(result.ErrorReason);
                }
            } else if (msg.Content.ToLower() == "i am your father")
            {
                await context.Channel.SendMessageAsync("No... No. That's not true! That's impossible!!");
            }
        }
    }
}
