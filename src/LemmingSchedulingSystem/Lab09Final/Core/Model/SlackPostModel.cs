using Newtonsoft.Json;

namespace Core.Model
{
    public class SlackPostModel
    {
        [JsonProperty("text")]
        public string Text { get; set; }
    }
}
