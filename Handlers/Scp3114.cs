using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiscordMessenger;
using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Map;
using Exiled.Events.EventArgs.Player;
using Exiled.Events.EventArgs.Scp079;
using Exiled.Events.EventArgs.Server;
using PlayerRoles;

namespace AddScp3114.Handlers
{
    public class Scp3114
    {
        private List<Player> scpPlayersList = new List<Player>();
        public Random rnd = new Random();
        public Player PlayerToChange;
        public string WebhookUsername {  get; set; }
        public string WebhookTitle { get; set; }
        public string WebhookDescription { get; set; }
        public string WebhookScp3114 { get; set; }

        public void OnScp3114Spawn()
        {
            foreach (Player player in Player.List)
            {
                if (!player.IsScp)
                    return;

                if (Player.List.Count <= 5)
                    return;

                scpPlayersList.Add(player);

                PlayerToChange = scpPlayersList[rnd.Next(0, scpPlayersList.Count)];

                PlayerToChange.RoleManager.ServerSetRole(RoleTypeId.Scp3114, RoleChangeReason.RoundStart, RoleSpawnFlags.UseSpawnpoint);

                OnScp3114Logs();
            }
        }

        public void OnScp3114Logs()
        {
            void SendMessage()
            {
                new DiscordMessage()
                    .SetUsername(WebhookUsername)
                    .AddEmbed()
                    .SetTitle(WebhookTitle)
                    .SetColor(126532)
                    .SetDescription(WebhookDescription)
                    .SetFooter($"{DateTime.Now}")
                    .Build()
                    .SendMessage(WebhookScp3114);
            }
            SendMessage();
        }
    }
}
