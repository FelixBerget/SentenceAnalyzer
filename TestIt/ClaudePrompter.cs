using Anthropic;
using Anthropic.Models.Messages;
using Microsoft.Extensions.AI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TestIt
{
    public class ClaudePrompter
    {
        public ClaudePrompter () { }

        public async Task<string> PromptClaude(string cont)
        {

            AnthropicClient client = new AnthropicClient() { APIKey = "" };

            MessageCreateParams parameters = new()  
            {
                
                MaxTokens = 1000,
                Messages = [
                    new(){
                        Role = Role.User,
                        Content = cont
                    },
                    ],
                Model = Model.ClaudeSonnet4_5_20250929,
            };

            var message = await client.Messages.Create(parameters);
            var jsonElement = message.Content[0].Json;
            string jsonString = jsonElement.GetProperty("text").ToString();
            jsonString = jsonString.Trim();
            if (jsonString.StartsWith("```json"))
                jsonString = jsonString.Substring(7);
            else if (jsonString.StartsWith("```"))
                jsonString = jsonString.Substring(3);

            if (jsonString.EndsWith("```"))
                jsonString = jsonString.Substring(0, jsonString.Length - 3);

            jsonString = jsonString.Trim();
            return jsonString;
        }
    }
}
