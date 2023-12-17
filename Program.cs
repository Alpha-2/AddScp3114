using Exiled.API.Enums;
using Exiled.API.Features;
using System;
using System.Runtime.InteropServices;
using Player = Exiled.Events.Handlers.Player;
using Server = Exiled.Events.Handlers.Server;
using Warhead = Exiled.Events.Handlers.Warhead;
using Map = Exiled.Events.Handlers.Map;
using System.Collections.Generic;
using Exiled.Events.Handlers;

namespace AddScp3114
{
    public class Program : Plugin<Config>
    {
        public static readonly Lazy<Program> LI = new Lazy<Program>(valueFactory: () => new Program());
        public Program Instance => LI.Value;

        private Handlers.Scp3114 Scp3114;


        public override void OnEnabled()
        {
            RegisterEvents();
        }
        public override void OnDisabled()
        {
            UnRegisterEvents();
        }

        private void RegisterEvents()
        {
            Scp3114 = new Handlers.Scp3114();


            Server.RoundStarted += Scp3114.OnScp3114Spawn;
            Scp3114.WebhookUsername = Config.WebhookUsername;
            Scp3114.WebhookTitle = Config.WebhookTitle;
            Scp3114.WebhookDescription = Config.WebhookDescription;
            Scp3114.WebhookScp3114 = Config.WebhookScp3114;
        }

        private void UnRegisterEvents()
        {
            Server.RoundStarted -= Scp3114.OnScp3114Spawn;

            Scp3114 = null;
        }
    }
}
