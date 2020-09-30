﻿using System;
using System.Net.Http;
using Telegram.Bot;

namespace HelpCenter.TelegramBot.Core
{
    public class TelegramBotClientFactory : ITelegramBotClientFactory
    {
        private readonly HttpClient _httpClient;

        public TelegramBotClientFactory(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public ITelegramBotClient CreateClient(string token) => 
            new TelegramBotClient(token, _httpClient);
    }
}
