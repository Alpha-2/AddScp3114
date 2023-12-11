using Exiled.API.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddScp3114
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; }
        public bool Debug { get; set; }

        [Description("Discord Logs Webhook username")]
        public static string WebhookUsername { get; set; } = "here";
        [Description("Discord Logs Webhook title")]
        public static string WebhookTitle { get; set; } = "here";
        [Description("Discord Logs Webhook content")]
        public static string WebhookDescription { get; set; } = "here";
        [Description("Discord Logs Webhook")]
        public static string WebhookScp3114 { get; set; } = "https";
    }
}
