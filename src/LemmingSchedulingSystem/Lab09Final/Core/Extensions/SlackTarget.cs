using System;
using System.Net.Http;
using Core.Model;
using Newtonsoft.Json;
using NLog;
using NLog.Config;
using NLog.Targets;

namespace Core.Extensions
{
    [Target("Slack")]
    public sealed class SlackTarget : TargetWithLayout
    {
        [RequiredParameter]
        public string MessagePrefix { get; set; }

        [RequiredParameter]
        public string ChannelUrl { get; set; }

        protected override void Write(LogEventInfo logEvent)
        {
            var logMessage = Layout.Render(logEvent);

            if (!string.IsNullOrWhiteSpace(MessagePrefix))
            {
                logMessage = $"{MessagePrefix} - {logMessage}";
            }

            var json = JsonConvert.SerializeObject(new SlackPostModel() { Text = logMessage });

            var httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.ExpectContinue = false;
            httpClient.DefaultRequestHeaders.ConnectionClose = true;

            var stringContent = new StringContent(json);
            var response = httpClient.PostAsync(ChannelUrl, stringContent).Result;

            try
            {
                response.EnsureSuccessStatusCode();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
