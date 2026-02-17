using Newtonsoft.Json.Linq;

namespace QuickCode.DemoTest.Common.Models;

public class ResponseInfo
{
    public int StatusCode { get; set; }
    public Dictionary<string, string> Headers { get; set; } = [];
    public JObject Body { get; set; } = default!;
}