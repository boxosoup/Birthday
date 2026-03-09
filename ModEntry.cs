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

namespace Birthday;


public class ModEntry : Mod
{
    public static string UniqueID = "boxosoup.birthday";
    public override void Entry(IModHelper helper)
    {
        // bind the event handler
        I18n.Init(helper.Translation);
        helper.Events.Input.ButtonPressed += OnButtonPressed;
        helper.Events.GameLoop.DayStarted += OnDayStarted;
    }

    void OnButtonPressed(object? sender, ButtonPressedEventArgs ev)
    {
        // Don't process button presses if player hasn't loaded a save,
        // is in another menu, or isn't free. I'd recommended you ignore these cases too.
        if (!Context.IsWorldReady) return;
        if (Game1.activeClickableMenu != null || (!Context.IsPlayerFree)) return;
        
        // Display our UI if user presses F10
        if (ev.Button == SButton.W)
            Game1.activeClickableMenu = new BirthdayUi();
    }
    
    private void OnDayStarted(object? sender, DayStartedEventArgs e)
    {
        if (Game1.activeClickableMenu != null || (!Context.IsPlayerFree)) return;
        if (!GameStateQuery.Exists($"{UniqueID}_IS_BIRTHDAY"))
        {
            Game1.activeClickableMenu = new BirthdayUi();
        } ;
    }
}