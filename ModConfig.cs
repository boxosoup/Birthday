using StardewModdingAPI;
using StardewModdingAPI.Utilities;

namespace Birthday;

public sealed class ModConfig
{
    public static KeybindList BirthdayMenuKey { get; set; } = new(SButton.F7);

    private void Reset()
    {
        BirthdayMenuKey = new KeybindList(SButton.F7);
    }

    private void Save()
    {
        ModEntry.help.WriteConfig(this);
    }

    public void Register(IManifest mod, IGenericModConfigMenuApi gmcm)
    {
        gmcm.Register(mod, Reset, Save);

        gmcm.AddKeybindList(
            mod,
            () => BirthdayMenuKey,
            value => BirthdayMenuKey = value,
            () => I18n.ConfigTitle()
        );
    }
}