using OpenAI_API.Completions;
using OpenAI_API;
using ChatGPT_CSharp.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ChatGPT_CSharp.Services
{
    public class GPTService : IGPTService
    {
        public async Task<string> GetGPTAnswer(string apiKey, string query)
        {
            try
            {
                if (string.IsNullOrEmpty(apiKey.Trim()))
                    throw new Exception("Error to execute ChatGPT");

                string result = "";
                OpenAIAPI openAI = new OpenAIAPI(apiKey.Trim());
                CompletionRequest request = new CompletionRequest();
                request.Prompt = query;
                request.Model = OpenAI_API.Models.Model.DavinciText;

                var completions = openAI.Completions.CreateCompletionAsync(request);

                foreach (var completion in completions.Result.Completions)
                {
                    result += completion.Text;
                }

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public Task<IActionResult> UseChatGPT(string query)
        {
            throw new NotImplementedException();
        }
    }
}
