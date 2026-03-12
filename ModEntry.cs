using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using StardewModdingAPI;
using StardewValley;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley.Menus;
using StardewValley.Objects;
using static StardewValley.Game1;

namespace Birthday;


public class ModEntry : Mod
{
    public static string UniqueID = "boxosoup.birthday";
    private ModConfig Config;
    public override void Entry(IModHelper helper)
    {
        // bind the event handler
        I18n.Init(helper.Translation);
        helper.Events.Input.ButtonPressed += OnButtonPressed;
        helper.Events.GameLoop.DayStarted += OnDayStarted;
        
        this.Config = this.Helper.ReadConfig<ModConfig>();
        string exampleBool = this.Config.birthdaymonth;
    }
    
    void OnButtonPressed(object? sender, ButtonPressedEventArgs ev)
    {
        // Don't process button presses if player hasn't loaded a save,
        // is in another menu, or isn't free. I'd recommended you ignore these cases too.
        if (!Context.IsWorldReady) return;
        if (activeClickableMenu != null || (!Context.IsPlayerFree)) return;
        
        // Display our UI if user presses F10
        if (ev.Button == SButton.W)
            activeClickableMenu = new BirthdayUi();
    }
    
    private void OnDayStarted(object? sender, DayStartedEventArgs e)
    {
        if (activeClickableMenu != null || !Context.IsPlayerFree)
            return;

        if (!GameStateQuery.Exists($"{UniqueID}_IS_BIRTHDAY"))
        {
            activeClickableMenu = new BirthdayUi();
        }
        else
        {
            if (player.modData.TryGetValue($"{ModEntry.UniqueID}/birthdaydate", out string birthdaydata))
            {
                int dayofbirthday = int.Parse(birthdaydata.Substring(birthdaydata.Length - 2));

                if (birthdaydata.Contains(currentSeason) && dayOfMonth == dayofbirthday)
                {
                    Game1.player.activeDialogueEvents.TryAdd($"{UniqueID}_birthday", 1);
                }
            }
        }
    }
    
    public sealed class ModConfig
    {
        public string birthdaymonth { get; set; }
        public int birthdayday { get; set; }
    }
}