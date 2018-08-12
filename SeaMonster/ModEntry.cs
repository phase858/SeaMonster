using System;
using Microsoft.Xna.Framework;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley.Tools;
using StardewValley;

namespace SeaMonster
{
    public class ModEntry : Mod
    {
        Random rnd = new Random();

        public override void Entry(IModHelper helper)
        {
            GameEvents.UpdateTick += this.GameEvents_UpdateTick;
        }

        private void GameEvents_UpdateTick(object sender, EventArgs e)
        {          
            if (!Context.IsWorldReady)
                return;

            if (Game1.player.CurrentTool is FishingRod rod && rod.isFishing && !rod.hit)
            {
                int option = rnd.Next(0, 100000);
                if (option == 3)
                {
                    Game1.addHUDMessage(new HUDMessage("You caught a rare sea monster.", 2));

                    rod.doneFishing(Game1.player, true);

                    Game1.player.money += 20000;
                }
            }
        }
    }
}