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
    
    internal static ModConfig config = null!;
    internal static IModHelper help = null!;
    public override void Entry(IModHelper helper)
    {
        
        help = helper;
        config = help.ReadConfig<ModConfig>();
        I18n.Init(helper.Translation);
        helper.Events.Input.ButtonPressed += OnButtonPressed;
        helper.Events.GameLoop.DayStarted += OnDayStarted;
        helper.Events.GameLoop.GameLaunched += OnGameLaunched;

        BirthdaySaveData.delegateRegister();
    }

    private void OnGameLaunched(object? sender, GameLaunchedEventArgs e)
    {
        if (
            Helper.ModRegistry.GetApi<IGenericModConfigMenuApi>("spacechase0.GenericModConfigMenu")
            is IGenericModConfigMenuApi gmcm
        )
        {
            config.Register(ModManifest, gmcm);
        }
    }

    void OnButtonPressed(object? sender, ButtonPressedEventArgs ev)
    {
        if (!Context.IsWorldReady) return;
        if (activeClickableMenu != null || (!Context.IsPlayerFree)) return;
        if (ev.Button == ModConfig.BirthdayMenuKey)
            activeClickableMenu = new BirthdayUi();
    }
    
    private void OnDayStarted(object? sender, DayStartedEventArgs e)
    {
        if (activeClickableMenu != null || !Context.IsPlayerFree)
            return;
        
        if (!player.modData.TryGetValue($"{ModEntry.UniqueID}/birthdaydate", out string birthdaydata))
        {
            activeClickableMenu = new BirthdayUi();
        }
        else
        {
            string dayPart = new string(birthdaydata.SkipWhile(char.IsLetter).ToArray());
            int dayofbirthday = int.Parse(dayPart);
            if (dayofbirthday == Game1.dayOfMonth && birthdaydata.Contains(Game1.currentSeason))
            {
                    Game1.player.activeDialogueEvents.TryAdd($"{UniqueID}_birthday", 1);
                }
                return;
        }
    }
}