using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using StardewModdingAPI;
using StardewValley;
using StardewValley.Menus;
namespace Birthday;

public class BirthdayUi : IClickableMenu
{
    // 2. Some of the constants you'll use to relatively lay out all the UI elements
    private static int UIWidth = 632;
    private static int UIHeight = 600;
    private int XPos = (Game1.viewport.Width / 2) - (UIWidth / 2);
    private int YPos = (Game1.viewport.Height / 2) - (UIHeight / 2);
    string ReminderSeason;
    private readonly List<ClickableTextureComponent> SeasonButtons = new();
    private readonly List<ClickableTextureComponent> DayButtons = new();
    
    private ClickableComponent TitleLabel;

    public BirthdayUi()
    {
        base.initialize(XPos, YPos, UIWidth, UIHeight);


        SeasonButtons.Add(new ClickableTextureComponent("Spring",
            new Rectangle(
                xPositionOnScreen + spaceToClearSideBorder + borderWidth + Game1.tileSize * 1 - Game1.tileSize / 4,
                yPositionOnScreen + borderWidth + spaceToClearTopBorder + (int)(Game1.tileSize * 3.10) -
                Game1.tileSize / 4, Game1.tileSize * 2, Game1.tileSize), "", "", Game1.mouseCursors,
            new Rectangle(188, 438, 32, 9), Game1.pixelZoom));
        SeasonButtons.Add(new ClickableTextureComponent("Summer",
            new Rectangle(
                xPositionOnScreen + spaceToClearSideBorder + borderWidth + Game1.tileSize * 3 - Game1.tileSize / 4,
                yPositionOnScreen + borderWidth + spaceToClearTopBorder + (int)(Game1.tileSize * 3.10) -
                Game1.tileSize / 4, Game1.tileSize * 2, Game1.tileSize), "", "", Game1.mouseCursors,
            new Rectangle(220, 438, 32, 8), Game1.pixelZoom));
        SeasonButtons.Add(new ClickableTextureComponent("Fall",
            new Rectangle(
                xPositionOnScreen + spaceToClearSideBorder + borderWidth + Game1.tileSize * 5 - Game1.tileSize / 4,
                yPositionOnScreen + borderWidth + spaceToClearTopBorder + (int)(Game1.tileSize * 3.1) -
                Game1.tileSize / 4, Game1.tileSize * 2, Game1.tileSize), "", "", Game1.mouseCursors,
            new Rectangle(188, 447, 32, 10), Game1.pixelZoom));
        SeasonButtons.Add(new ClickableTextureComponent("Winter",
            new Rectangle(
                xPositionOnScreen + spaceToClearSideBorder + borderWidth + Game1.tileSize * 7 - Game1.tileSize / 4,
                yPositionOnScreen + borderWidth + spaceToClearTopBorder + (int)(Game1.tileSize * 3.1) -
                Game1.tileSize / 4, Game1.tileSize * 2, Game1.tileSize), "", "", Game1.mouseCursors,
            new Rectangle(220, 448, 32, 8), Game1.pixelZoom));

        for (int i = 28; i >= 0; i--)
        {
            DayButtons.Add(new ClickableTextureComponent($"{i}", new Rectangle(xPositionOnScreen + spaceToClearSideBorder + borderWidth + Game1.tileSize * i - Game1.tileSize / 4, yPositionOnScreen + borderWidth + spaceToClearTopBorder + Game1.tileSize * 4 - Game1.tileSize / 4, Game1.tileSize * 1, Game1.tileSize), "", "", Game1.content.Load<Texture2D>("LooseSprites\\font_bold"), new Rectangle(8, 16, 8, 12), Game1.pixelZoom));
        }
        
        TitleLabel = new ClickableComponent(new Rectangle(XPos + 200, YPos + 96, UIWidth - 400, 64), $"{I18n.Title()}");
    }



    // 6. Render the UI that has been set up to the screen. 
    // Gets called automatically every render tick when this UI is active
    public override void draw(SpriteBatch b)
    {
        foreach (ClickableTextureComponent button in DayButtons)
        {
            button.draw(b);
        }

        foreach (ClickableTextureComponent button in SeasonButtons)
        {
            button.draw(b);
        }

        b.Draw(Game1.fadeToBlackRect, Game1.graphics.GraphicsDevice.Viewport.Bounds, Color.Black * 0.75f);

        Game1.drawDialogueBox(XPos, YPos, UIWidth, UIHeight, false, true);

        Utility.drawTextWithShadow(b, TitleLabel.name, Game1.dialogueFont, new Vector2(TitleLabel.bounds.X, TitleLabel.bounds.Y), Color.Black);
        
        drawMouse(b);
    }
    private void HandleButtonClick(string name)
    {
        if (name == null)
            return;

        switch (name)
        {
            // season button
            case "Spring":
            case "Summer":
            case "Fall":
            case "Winter":
                ReminderSeason = name;
                break;
        }
        Game1.playSound("coin");
    }
    
    public override void receiveLeftClick(int x, int y, bool playSound = true)
    {
        foreach (ClickableTextureComponent button in SeasonButtons)
        {
            if (button.containsPoint(x, y))
            {
                HandleButtonClick(button.name);
                button.scale -= 0.5f;
                button.scale = Math.Max(3.5f, button.scale);
            }
        }
    }
}
