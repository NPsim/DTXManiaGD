using DiscordRPC;
using DiscordRPC.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTXMania
{
	class Discord
	{
		public static DiscordRpcClient client;
		public static bool Initialized { get; private set; }
		public static RichPresence rp = new RichPresence();
		public static void Initialize()
        {
			client = new DiscordRpcClient("656054208478314496");
			client.Initialize();
			SetInMenu();
			Initialized = true;
		}
		
		public static void SetInMenu()
		{
			rp = new RichPresence()
			{
				State = "In Menu",
				Assets = new Assets()
				{
					LargeImageKey = "logo",
					LargeImageText = "v3.62GD (190426) + DiscordRPC",
					SmallImageKey = "",
					SmallImageText = ""
				}
			};
			PushPresence();
		}

		public static void SetPlaying(string title, string artist, string difficulty, string level)
		{
			rp = new RichPresence()
			{
				Details = title,
				State = artist,
				Assets = new Assets()
				{
					LargeImageKey = "logo",
					LargeImageText = "v3.62GD (190426) + DiscordRPC",
					SmallImageKey = difficulty,
					SmallImageText = difficulty.ToUpper() + " " + level
				}
			};
		}

		public static void SetEndTimestamp(double ms)
		{
			rp.Timestamps = new Timestamps();
			rp.Timestamps.Start = DateTime.UtcNow;
			rp.Timestamps.End = DateTime.UtcNow.AddMilliseconds(ms);
			PushPresence();
		}

		private static void PushPresence()
		{
			client.SetPresence(rp);
		}
	}
}
