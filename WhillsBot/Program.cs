﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;

namespace WhillsBot
{
    class Program
    {
        public static void Main(string[] args)
            => new Program().StartAsync().GetAwaiter().GetResult();

        private DiscordSocketClient client;

        private CommandHandler handler;

        public async Task StartAsync()
        {
            client = new DiscordSocketClient();

            var tokens = System.IO.File.ReadAllLines(@"..\..\token.txt");
            Console.WriteLine(tokens[0]);

            await client.LoginAsync(TokenType.Bot, tokens[0]);
            await client.StartAsync();

            handler = new CommandHandler(client);

            await client.SetGameAsync("!help");

            Console.Write("Channel ID: ");
            ulong channelId = Convert.ToUInt64(Console.ReadLine());

            string console = "";
            while (console != "/exit")
            {
                Console.Write("> ");
                console = Console.ReadLine();
                if (console == "/channel")
                {
                    Console.Write("Channel ID: ");
                    channelId = Convert.ToUInt64(Console.ReadLine());
                }
                else
                {
                    await ((ISocketMessageChannel)client.GetChannel(channelId)).SendMessageAsync(console);
                }
            }

            //await Task.Delay(-1); // Prevents from closing
        }
        
    }
}
