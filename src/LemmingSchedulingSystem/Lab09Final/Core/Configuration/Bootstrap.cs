using System;
using Core.Extensions;
using NLog;
using NLog.Config;
using NLog.Layouts;
using NLog.Targets;

namespace Core.Configuration
{
    public static class Bootstrap
    {
        public static void Start()
        {
            BootstrapNLog();
        }

        private static void BootstrapNLog()
        {
            GlobalDiagnosticsContext.Set("ServiceInstanceId", Guid.NewGuid().ToString("N"));

            var config = new LoggingConfiguration();
            var colorConsoleTarget = new ColoredConsoleTarget()
            {
                Name = "colorConsole"
            };

            config.AddTarget("colorConsole", colorConsoleTarget);
            config.LoggingRules.Add(new LoggingRule("*", LogLevel.Trace, colorConsoleTarget));

            var databaseTarget = new DatabaseTarget()
            {
                ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString,
                CommandText = "INSERT INTO EventLog (Logger, [TimeStamp], Level, ServiceInstanceId, JobId, Message, Exception, StackTrace) " +
                              "VALUES (@logger, @timeStamp, @level, @serviceinstanceid, @jobid, " +
                              "CASE WHEN LEN(@message) > 4000 THEN LEFT(@message, 3988) + '[truncated]' ELSE @message END," +
                              "CASE WHEN LEN(@exception) > 4000 THEN LEFT(@exception, 3988) + '[truncated]' ELSE @exception END," +
                              "CASE WHEN LEN(@stacktrace) > 4000 THEN LEFT(@stacktrace, 3988) + '[truncated]' ELSE @stacktrace END" +
                              ")",
                Parameters =
                {
                    new DatabaseParameterInfo("@logger", new SimpleLayout("${logger}")),
                    new DatabaseParameterInfo("@timestamp", new SimpleLayout("${date}")),
                    new DatabaseParameterInfo("@level", new SimpleLayout("${level}")),
                    new DatabaseParameterInfo("@serviceinstanceid", new SimpleLayout("${gdc:item=ServiceInstanceId}")),
                    new DatabaseParameterInfo("@jobid", new SimpleLayout("${mdc:item=JobId}")),
                    new DatabaseParameterInfo("@message", new SimpleLayout("${message}")),
                    new DatabaseParameterInfo("@exception", new SimpleLayout("${exception}")),
                    new DatabaseParameterInfo("@stacktrace", new SimpleLayout("${exception:stacktrace}")),
                }
            };

            config.AddTarget("database", databaseTarget);
            config.LoggingRules.Add(new LoggingRule("*", LogLevel.Info, databaseTarget));

            var slackTarget = new SlackTarget() {ChannelUrl = "https://hooks.slack.com/services/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", MessagePrefix = Environment.MachineName};

            config.AddTarget("slack", slackTarget);
            config.LoggingRules.Add(new LoggingRule("*", LogLevel.Warn, slackTarget));

            LogManager.Configuration = config;
        }
    }
}
