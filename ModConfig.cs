using Microsoft.Xna.Framework;
using StardewModdingAPI;
using StardewModdingAPI.Utilities;
using StardewValley;

namespace Birthday;

public sealed class ModConfig
{
    public static SButton BirthdayMenuKey { get; set; } = SButton.F7;

    private void Reset()
    {
        BirthdayMenuKey = SButton.F7;
    }

    private void Save()
    {
        ModEntry.help.WriteConfig(this);
    }

    public void Register(IManifest mod, IGenericModConfigMenuApi gmcm)
    {
        gmcm.Register(mod, Reset, Save);

        gmcm.AddKeybind(
            mod,
            () => BirthdayMenuKey,
            value => BirthdayMenuKey = value,
            () => I18n.ConfigTitle()
        );
    }
}