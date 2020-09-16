﻿using MvcMtlsClient.Web.Interfaces;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace MvcMtlsClient.Web.Services
{
    public class Api1UserService : IApi1UserService
    {
        private readonly HttpClient client;

        public Api1UserService(
            HttpClient client)
        {
            this.client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<string> Get()
        {
            // No more getting access_tokens code!
            var response = await client.GetAsync("/invoices/ApiSecure");

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.StatusCode);
                throw new Exception("Failed to get protected resources.");
            }
            return await response.Content.ReadAsStringAsync();
        }
    }
}