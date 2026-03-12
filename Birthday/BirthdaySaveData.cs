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
using StardewValley.Delegates;
using StardewValley.Menus;
using StardewValley.Objects;
using StardewValley.Tools;

namespace Birthday;

public class BirthdaySaveData
{

    public static void delegateRegister()
    {
        //date format is <season> <day>
        GameStateQuery.Register(GSQ_IS_BIRTHDAY, IS_BIRTHDAY);
    }

    public static void Register(string date)
    {
        Game1.player.modData[$"{ModEntry.UniqueID}/birthdaydate"] = date;
    }

    private static readonly string GSQ_IS_BIRTHDAY = $"{ModEntry.UniqueID}_IS_BIRTHDAY";
    private static readonly string ModData_BirthdayDate = $"{ModEntry.UniqueID}/birthdaydate";

    private static bool IS_BIRTHDAY(string[] query, GameStateQueryContext context)
    {
        if (!context.TargetItem.modData.TryGetValue(ModData_BirthdayDate, out string date))
        {
            return false;
        }
        string birthdaydata = Game1.player.modData[$"{ModEntry.UniqueID}/birthdaydate"];
        int dayofbirthday = int.Parse(birthdaydata.Substring(birthdaydata.Length - 2));
        if (dayofbirthday == Game1.dayOfMonth) ;
        {
            if (birthdaydata.Contains(Game1.currentSeason)) ;
            {
                return true;
            }
        }
    }
}