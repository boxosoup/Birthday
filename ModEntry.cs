using StardewModdingAPI;
using StardewModdingAPI.Events;
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
            config.Register(ModManifest, gmcm);
    }

    private void OnButtonPressed(object? sender, ButtonPressedEventArgs ev)
    {
        if (!Context.IsWorldReady) return;
        if (activeClickableMenu != null || !Context.IsPlayerFree) return;
        if (ModConfig.BirthdayMenuKey.JustPressed()) activeClickableMenu = new BirthdayUi();
    }

    private void OnDayStarted(object? sender, DayStartedEventArgs e)
    {
        if (activeClickableMenu != null || !Context.IsPlayerFree)
            return;

        if (!player.modData.TryGetValue($"{UniqueID}/birthdaydate", out var birthdaydata))
        {
            activeClickableMenu = new BirthdayUi();
        }
        else
        {
            var dayPart = new string(birthdaydata.SkipWhile(char.IsLetter).ToArray());
            var dayofbirthday = int.Parse(dayPart);
            if (dayofbirthday == dayOfMonth && birthdaydata.Contains(currentSeason))
                player.activeDialogueEvents.TryAdd($"{UniqueID}_birthday", 1);
        }
    }
}