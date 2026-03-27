using StardewValley;
using StardewValley.Delegates;

namespace Birthday;

public class BirthdaySaveData
{
    private static readonly string GSQ_IS_BIRTHDAY = $"{ModEntry.UniqueID}_IS_BIRTHDAY";
    private static readonly string ModData_BirthdayDate = $"{ModEntry.UniqueID}/birthdaydate";

    public static void delegateRegister()
    {
        //date format is <season> <day>
        GameStateQuery.Register(GSQ_IS_BIRTHDAY, IS_BIRTHDAY);
    }

    public static void Register(string date)
    {
        Game1.player.modData[$"{ModEntry.UniqueID}/birthdaydate"] = date;
    }

    private static bool IS_BIRTHDAY(string[] query, GameStateQueryContext context)
    {
        if (!context.Player.modData.TryGetValue(ModData_BirthdayDate, out var date)) return false;
        var birthdaydata = Game1.player.modData[$"{ModEntry.UniqueID}/birthdaydate"];
        var dayPart = new string(birthdaydata.SkipWhile(char.IsLetter).ToArray());
        var dayofbirthday = int.Parse(dayPart);
        if (dayofbirthday == Game1.dayOfMonth && birthdaydata.Contains(Game1.currentSeason)) return true;

        return false;
    }
}