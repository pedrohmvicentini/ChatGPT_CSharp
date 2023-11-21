using Microsoft.AspNetCore.Mvc;

namespace ChatGPT_CSharp.Interfaces
{
    public interface IGPTService
    {
        Task<string> GetGPTAnswer(string apiKey, string query);
    }
}
