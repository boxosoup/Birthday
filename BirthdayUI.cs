using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using StardewModdingAPI;
using StardewValley;
using StardewValley.Menus;
using StardewValley.Minigames;

namespace Birthday;

public class BirthdayUi : IClickableMenu
{
    // 2. Some of the constants you'll use to relatively lay out all the UI elements
    private static int UIWidth = 632;
    private static int UIHeight = 600;
    private int XPos = (Game1.viewport.Width / 2) - (UIWidth / 2);
    private int YPos = (Game1.viewport.Height / 2) - (UIHeight / 2);
    private int Yoffset = -150;
    private int Xoffset = -32;
    private readonly List<ClickableTextureComponent> SeasonButtons = new();
    private readonly List<ClickableTextureComponent> DayButtons = new();
    private ClickableTextureComponent okButton;


    private ClickableComponent TitleLabel;
    public BirthdayUi() : base((int)getAppropriateMenuPosition().X, (int)getAppropriateMenuPosition().Y, UIWidth , UIHeight)
    {
        base.initialize(XPos, YPos, UIWidth, UIHeight);

        okButton = new ClickableTextureComponent("OK",
            new Rectangle(xPositionOnScreen + width - borderWidth - spaceToClearSideBorder - Game1.tileSize,
                yPositionOnScreen + height - borderWidth - spaceToClearTopBorder + Game1.tileSize / 4, Game1.tileSize,
                Game1.tileSize), "", null, Game1.mouseCursors,
            Game1.getSourceRectForStandardTileSheet(Game1.mouseCursors, 46), 1f)
        {
            myID = 200,
            leftNeighborID = -7777,
            upNeighborID = -7777
        };
            DayButtons.Clear();
            SeasonButtons.Clear();

            SeasonButtons.Add(new ClickableTextureComponent("Spring",
                new Rectangle(
                    xPositionOnScreen + spaceToClearSideBorder + borderWidth + Game1.tileSize * 1 - Game1.tileSize / 4 + Xoffset,
                    yPositionOnScreen + borderWidth + spaceToClearTopBorder + (int)(Game1.tileSize * 3.10) -
                    Game1.tileSize / 4 + Yoffset, Game1.tileSize * 2, Game1.tileSize), "", "", Game1.mouseCursors,
                new Rectangle(188, 438, 32, 9), Game1.pixelZoom));
            SeasonButtons.Add(new ClickableTextureComponent("Summer",
                new Rectangle(
                    xPositionOnScreen + spaceToClearSideBorder + borderWidth + Game1.tileSize * 3 - Game1.tileSize / 4 + Xoffset,
                    yPositionOnScreen + borderWidth + spaceToClearTopBorder + (int)(Game1.tileSize * 3.10) -
                    Game1.tileSize / 4 + Yoffset, Game1.tileSize * 2, Game1.tileSize), "", "", Game1.mouseCursors,
                new Rectangle(220, 438, 32, 8), Game1.pixelZoom));
            SeasonButtons.Add(new ClickableTextureComponent("Fall",
                new Rectangle(
                    xPositionOnScreen + spaceToClearSideBorder + borderWidth + Game1.tileSize * 5 - Game1.tileSize / 4 + Xoffset,
                    yPositionOnScreen + borderWidth + spaceToClearTopBorder + (int)(Game1.tileSize * 3.1) -
                    Game1.tileSize / 4 + Yoffset, Game1.tileSize * 2, Game1.tileSize), "", "", Game1.mouseCursors,
                new Rectangle(188, 447, 32, 10), Game1.pixelZoom));
            SeasonButtons.Add(new ClickableTextureComponent("Winter",
                new Rectangle(
                    xPositionOnScreen + spaceToClearSideBorder + borderWidth + Game1.tileSize * 7 - Game1.tileSize / 4,
                    yPositionOnScreen + borderWidth + spaceToClearTopBorder + (int)(Game1.tileSize * 3.1) -
                    Game1.tileSize / 4 + Yoffset, Game1.tileSize * 2, Game1.tileSize), "", "", Game1.mouseCursors,
                new Rectangle(220, 448, 32, 8), Game1.pixelZoom));

            DayButtons.Add(new ClickableTextureComponent("1",
                new Rectangle(
                    xPositionOnScreen + spaceToClearSideBorder + borderWidth + Game1.tileSize * 1 - Game1.tileSize / 4 + Xoffset,
                    yPositionOnScreen + borderWidth + spaceToClearTopBorder + Game1.tileSize * 4 - Game1.tileSize / 4 +
                    Yoffset, Game1.tileSize * 1, Game1.tileSize), "", "",
                Game1.content.Load<Texture2D>("LooseSprites\\font_bold"), new Rectangle(8, 16, 8, 12), Game1.pixelZoom)
            {
                myID = 1,
                downNeighborID = 8,
                rightNeighborID = 2,
                upNeighborID = -7777
            });
            DayButtons.Add(new ClickableTextureComponent("2",
                new Rectangle(
                    xPositionOnScreen + spaceToClearSideBorder + borderWidth + Game1.tileSize * 2 - Game1.tileSize / 4,
                    yPositionOnScreen + borderWidth + spaceToClearTopBorder + Game1.tileSize * 4 - Game1.tileSize / 4 +
                    Yoffset, Game1.tileSize * 1, Game1.tileSize), "", "",
                Game1.content.Load<Texture2D>("LooseSprites\\font_bold"), new Rectangle(16, 16, 8, 12), Game1.pixelZoom)
            {
                myID = 2,
                downNeighborID = 9,
                leftNeighborID = 1,
                rightNeighborID = 3,
                upNeighborID = -7777
            });
            DayButtons.Add(new ClickableTextureComponent("3",
                new Rectangle(
                    xPositionOnScreen + spaceToClearSideBorder + borderWidth + Game1.tileSize * 3 - Game1.tileSize / 4,
                    yPositionOnScreen + borderWidth + spaceToClearTopBorder + Game1.tileSize * 4 - Game1.tileSize / 4 +
                    Yoffset, Game1.tileSize * 1, Game1.tileSize), "", "",
                Game1.content.Load<Texture2D>("LooseSprites\\font_bold"), new Rectangle(24, 16, 8, 12), Game1.pixelZoom)
            {
                myID = 3,
                downNeighborID = 10,
                leftNeighborID = 2,
                rightNeighborID = 4,
                upNeighborID = -7777
            });
            DayButtons.Add(new ClickableTextureComponent("4",
                new Rectangle(
                    xPositionOnScreen + spaceToClearSideBorder + borderWidth + Game1.tileSize * 4 - Game1.tileSize / 4,
                    yPositionOnScreen + borderWidth + spaceToClearTopBorder + Game1.tileSize * 4 - Game1.tileSize / 4 +
                    Yoffset, Game1.tileSize * 1, Game1.tileSize), "", "",
                Game1.content.Load<Texture2D>("LooseSprites\\font_bold"), new Rectangle(32, 16, 8, 12), Game1.pixelZoom)
            {
                myID = 4,
                downNeighborID = 11,
                leftNeighborID = 3,
                rightNeighborID = 5,
                upNeighborID = -7777
            });
            DayButtons.Add(new ClickableTextureComponent("5",
                new Rectangle(
                    xPositionOnScreen + spaceToClearSideBorder + borderWidth + Game1.tileSize * 5 - Game1.tileSize / 4,
                    yPositionOnScreen + borderWidth + spaceToClearTopBorder + Game1.tileSize * 4 - Game1.tileSize / 4 +
                    Yoffset, Game1.tileSize * 1, Game1.tileSize), "", "",
                Game1.content.Load<Texture2D>("LooseSprites\\font_bold"), new Rectangle(40, 16, 8, 12), Game1.pixelZoom)
            {
                myID = 5,
                downNeighborID = 12,
                leftNeighborID = 4,
                rightNeighborID = 6,
                upNeighborID = -7777
            });
            DayButtons.Add(new ClickableTextureComponent("6",
                new Rectangle(
                    xPositionOnScreen + spaceToClearSideBorder + borderWidth + Game1.tileSize * 6 - Game1.tileSize / 4,
                    yPositionOnScreen + borderWidth + spaceToClearTopBorder + Game1.tileSize * 4 - Game1.tileSize / 4 +
                    Yoffset, Game1.tileSize * 1, Game1.tileSize), "", "",
                Game1.content.Load<Texture2D>("LooseSprites\\font_bold"), new Rectangle(48, 16, 8, 12), Game1.pixelZoom)
            {
                myID = 6,
                downNeighborID = 13,
                leftNeighborID = 5,
                rightNeighborID = 7,
                upNeighborID = -7777
            });
            DayButtons.Add(new ClickableTextureComponent("7",
                new Rectangle(
                    xPositionOnScreen + spaceToClearSideBorder + borderWidth + Game1.tileSize * 7 - Game1.tileSize / 4,
                    yPositionOnScreen + borderWidth + spaceToClearTopBorder + Game1.tileSize * 4 - Game1.tileSize / 4 +
                    Yoffset, Game1.tileSize * 1, Game1.tileSize), "", "",
                Game1.content.Load<Texture2D>("LooseSprites\\font_bold"), new Rectangle(56, 16, 8, 12), Game1.pixelZoom)
            {
                myID = 7,
                downNeighborID = 14,
                leftNeighborID = 6,
                rightNeighborID = 8,
                upNeighborID = -7777
            });
            DayButtons.Add(new ClickableTextureComponent("8",
                new Rectangle(
                    xPositionOnScreen + spaceToClearSideBorder + borderWidth + Game1.tileSize * 1 - Game1.tileSize / 4,
                    yPositionOnScreen + borderWidth + spaceToClearTopBorder + Game1.tileSize * 5 - Game1.tileSize / 4 +
                    Yoffset, Game1.tileSize * 1, Game1.tileSize), "", "",
                Game1.content.Load<Texture2D>("LooseSprites\\font_bold"), new Rectangle(64, 16, 8, 12), Game1.pixelZoom)
            {
                myID = 8,
                downNeighborID = 15,
                leftNeighborID = 7,
                rightNeighborID = 9,
                upNeighborID = 1
            });
            DayButtons.Add(new ClickableTextureComponent("9",
                new Rectangle(
                    xPositionOnScreen + spaceToClearSideBorder + borderWidth + Game1.tileSize * 2 - Game1.tileSize / 4,
                    yPositionOnScreen + borderWidth + spaceToClearTopBorder + Game1.tileSize * 5 - Game1.tileSize / 4 +
                    Yoffset, Game1.tileSize * 1, Game1.tileSize), "", "",
                Game1.content.Load<Texture2D>("LooseSprites\\font_bold"), new Rectangle(72, 16, 8, 12), Game1.pixelZoom)
            {
                myID = 9,
                downNeighborID = 16,
                leftNeighborID = 8,
                rightNeighborID = 10,
                upNeighborID = 2
            });
            DayButtons.Add(new ClickableTextureComponent("10",
                new Rectangle(
                    xPositionOnScreen + spaceToClearSideBorder + borderWidth + (int)(Game1.tileSize * 2.75) -
                    Game1.tileSize / 4,
                    yPositionOnScreen + borderWidth + spaceToClearTopBorder + Game1.tileSize * 5 - Game1.tileSize / 4 +
                    Yoffset, Game1.tileSize / 2, Game1.tileSize), "", "",
                Game1.content.Load<Texture2D>("LooseSprites\\font_bold"), new Rectangle(8, 16, 8, 12), Game1.pixelZoom)
            {
                myID = 10,
                downNeighborID = 17,
                leftNeighborID = 9,
                rightNeighborID = 11,
                upNeighborID = 3
            });
            DayButtons.Add(new ClickableTextureComponent("10",
                new Rectangle(
                    xPositionOnScreen + spaceToClearSideBorder + borderWidth + (int)(Game1.tileSize * 3.25) -
                    Game1.tileSize / 3,
                    yPositionOnScreen + borderWidth + spaceToClearTopBorder + Game1.tileSize * 5 - Game1.tileSize / 4 +
                    Yoffset, Game1.tileSize / 2, Game1.tileSize), "", "",
                Game1.content.Load<Texture2D>("LooseSprites\\font_bold"), new Rectangle(0, 16, 8, 12), Game1.pixelZoom)
            {
                myID = 10,
                downNeighborID = 17,
                leftNeighborID = 9,
                rightNeighborID = 11,
                upNeighborID = 3
            });
            DayButtons.Add(new ClickableTextureComponent("11",
                new Rectangle(
                    xPositionOnScreen + spaceToClearSideBorder + borderWidth + (int)(Game1.tileSize * 3.75) -
                    Game1.tileSize / 4,
                    yPositionOnScreen + borderWidth + spaceToClearTopBorder + Game1.tileSize * 5 - Game1.tileSize / 4 +
                    Yoffset, Game1.tileSize / 2, Game1.tileSize), "", "",
                Game1.content.Load<Texture2D>("LooseSprites\\font_bold"), new Rectangle(8, 16, 8, 12), Game1.pixelZoom)
            {
                myID = 11,
                downNeighborID = 18,
                leftNeighborID = 10,
                rightNeighborID = 12,
                upNeighborID = 4
            });
            DayButtons.Add(new ClickableTextureComponent("11",
                new Rectangle(
                    xPositionOnScreen + spaceToClearSideBorder + borderWidth + (int)(Game1.tileSize * 4.25) -
                    Game1.tileSize / 3,
                    yPositionOnScreen + borderWidth + spaceToClearTopBorder + Game1.tileSize * 5 - Game1.tileSize / 4 +
                    Yoffset, Game1.tileSize / 2, Game1.tileSize), "", "",
                Game1.content.Load<Texture2D>("LooseSprites\\font_bold"), new Rectangle(8, 16, 8, 12), Game1.pixelZoom)
            {
                myID = 11,
                downNeighborID = 18,
                leftNeighborID = 10,
                rightNeighborID = 12,
                upNeighborID = 4
            });
            DayButtons.Add(new ClickableTextureComponent("12",
                new Rectangle(
                    xPositionOnScreen + spaceToClearSideBorder + borderWidth + (int)(Game1.tileSize * 4.75) -
                    Game1.tileSize / 4,
                    yPositionOnScreen + borderWidth + spaceToClearTopBorder + Game1.tileSize * 5 - Game1.tileSize / 4 +
                    Yoffset, Game1.tileSize / 2, Game1.tileSize), "", "",
                Game1.content.Load<Texture2D>("LooseSprites\\font_bold"), new Rectangle(8, 16, 8, 12), Game1.pixelZoom)
            {
                myID = 12,
                downNeighborID = 19,
                leftNeighborID = 11,
                rightNeighborID = 13,
                upNeighborID = 5
            });
            DayButtons.Add(new ClickableTextureComponent("12",
                new Rectangle(
                    xPositionOnScreen + spaceToClearSideBorder + borderWidth + (int)(Game1.tileSize * 5.25) -
                    Game1.tileSize / 3,
                    yPositionOnScreen + borderWidth + spaceToClearTopBorder + Game1.tileSize * 5 - Game1.tileSize / 4 +
                    Yoffset, Game1.tileSize / 2, Game1.tileSize), "", "",
                Game1.content.Load<Texture2D>("LooseSprites\\font_bold"), new Rectangle(16, 16, 8, 12), Game1.pixelZoom)
            {
                myID = 12,
                downNeighborID = 19,
                leftNeighborID = 11,
                rightNeighborID = 13,
                upNeighborID = 5
            });
            DayButtons.Add(new ClickableTextureComponent("13",
                new Rectangle(
                    xPositionOnScreen + spaceToClearSideBorder + borderWidth + (int)(Game1.tileSize * 5.75) -
                    Game1.tileSize / 4,
                    yPositionOnScreen + borderWidth + spaceToClearTopBorder + Game1.tileSize * 5 - Game1.tileSize / 4 + Yoffset,
                    Game1.tileSize / 2, Game1.tileSize), "", "",
                Game1.content.Load<Texture2D>("LooseSprites\\font_bold"), new Rectangle(8, 16, 8, 12), Game1.pixelZoom)
            {
                myID = 13,
                downNeighborID = 20,
                leftNeighborID = 12,
                rightNeighborID = 14,
                upNeighborID = 6
            });
            DayButtons.Add(new ClickableTextureComponent("13",
                new Rectangle(
                    xPositionOnScreen + spaceToClearSideBorder + borderWidth + (int)(Game1.tileSize * 6.25) -
                    Game1.tileSize / 3,
                    yPositionOnScreen + borderWidth + spaceToClearTopBorder + Game1.tileSize * 5 - Game1.tileSize / 4 +
                    Yoffset, Game1.tileSize / 2, Game1.tileSize), "", "",
                Game1.content.Load<Texture2D>("LooseSprites\\font_bold"), new Rectangle(24, 16, 8, 12), Game1.pixelZoom)
            {
                myID = 13,
                downNeighborID = 20,
                leftNeighborID = 12,
                rightNeighborID = 14,
                upNeighborID = 6
            });
            DayButtons.Add(new ClickableTextureComponent("14",
                new Rectangle(
                    xPositionOnScreen + spaceToClearSideBorder + borderWidth + (int)(Game1.tileSize * 6.75) -
                    Game1.tileSize / 4,
                    yPositionOnScreen + borderWidth + spaceToClearTopBorder + Game1.tileSize * 5 - Game1.tileSize / 4 +
                    Yoffset, Game1.tileSize / 2, Game1.tileSize), "", "",
                Game1.content.Load<Texture2D>("LooseSprites\\font_bold"), new Rectangle(8, 16, 8, 12), Game1.pixelZoom)
            {
                myID = 14,
                downNeighborID = 21,
                leftNeighborID = 13,
                rightNeighborID = 15,
                upNeighborID = 7
            });
            DayButtons.Add(new ClickableTextureComponent("14",
                new Rectangle(
                    xPositionOnScreen + spaceToClearSideBorder + borderWidth + (int)(Game1.tileSize * 7.25) -
                    Game1.tileSize / 3,
                    yPositionOnScreen + borderWidth + spaceToClearTopBorder + Game1.tileSize * 5 - Game1.tileSize / 4 +
                    Yoffset, Game1.tileSize / 2, Game1.tileSize), "", "",
                Game1.content.Load<Texture2D>("LooseSprites\\font_bold"), new Rectangle(32, 16, 8, 12), Game1.pixelZoom)
            {
                myID = 14,
                downNeighborID = 21,
                leftNeighborID = 13,
                rightNeighborID = 15,
                upNeighborID = 7
            });
            DayButtons.Add(new ClickableTextureComponent("15",
                new Rectangle(
                    xPositionOnScreen + spaceToClearSideBorder + borderWidth + (int)(Game1.tileSize * 0.75) -
                    Game1.tileSize / 4,
                    yPositionOnScreen + borderWidth + spaceToClearTopBorder + Game1.tileSize * 6 - Game1.tileSize / 4 +
                    Yoffset, Game1.tileSize / 2, Game1.tileSize), "", "",
                Game1.content.Load<Texture2D>("LooseSprites\\font_bold"), new Rectangle(8, 16, 8, 12), Game1.pixelZoom)
            {
                myID = 15,
                downNeighborID = 22,
                leftNeighborID = 14,
                rightNeighborID = 16,
                upNeighborID = 8
            });
            DayButtons.Add(new ClickableTextureComponent("15",
                new Rectangle(
                    xPositionOnScreen + spaceToClearSideBorder + borderWidth + (int)(Game1.tileSize * 1.25) -
                    Game1.tileSize / 3,
                    yPositionOnScreen + borderWidth + spaceToClearTopBorder + Game1.tileSize * 6 - Game1.tileSize / 4 +
                    Yoffset, Game1.tileSize / 2, Game1.tileSize), "", "",
                Game1.content.Load<Texture2D>("LooseSprites\\font_bold"), new Rectangle(40, 16, 8, 12), Game1.pixelZoom)
            {
                myID = 15,
                downNeighborID = 22,
                leftNeighborID = 14,
                rightNeighborID = 16,
                upNeighborID = 8
            });
            DayButtons.Add(new ClickableTextureComponent("16",
                new Rectangle(
                    xPositionOnScreen + spaceToClearSideBorder + borderWidth + (int)(Game1.tileSize * 1.75) -
                    Game1.tileSize / 4,
                    yPositionOnScreen + borderWidth + spaceToClearTopBorder + Game1.tileSize * 6 - Game1.tileSize / 4 +
                    Yoffset, Game1.tileSize / 2, Game1.tileSize), "", "",
                Game1.content.Load<Texture2D>("LooseSprites\\font_bold"), new Rectangle(8, 16, 8, 12), Game1.pixelZoom)
            {
                myID = 16,
                downNeighborID = 23,
                leftNeighborID = 15,
                rightNeighborID = 17,
                upNeighborID = 9
            });
            DayButtons.Add(new ClickableTextureComponent("16",
                new Rectangle(
                    xPositionOnScreen + spaceToClearSideBorder + borderWidth + (int)(Game1.tileSize * 2.25) -
                    Game1.tileSize / 3,
                    yPositionOnScreen + borderWidth + spaceToClearTopBorder + Game1.tileSize * 6 - Game1.tileSize / 4 +
                    Yoffset, Game1.tileSize / 2, Game1.tileSize), "", "",
                Game1.content.Load<Texture2D>("LooseSprites\\font_bold"), new Rectangle(48, 16, 8, 12), Game1.pixelZoom)
            {
                myID = 16,
                downNeighborID = 23,
                leftNeighborID = 15,
                rightNeighborID = 17,
                upNeighborID = 9
            });
            DayButtons.Add(new ClickableTextureComponent("17",
                new Rectangle(
                    xPositionOnScreen + spaceToClearSideBorder + borderWidth + (int)(Game1.tileSize * 2.75) -
                    Game1.tileSize / 4,
                    yPositionOnScreen + borderWidth + spaceToClearTopBorder + Game1.tileSize * 6 - Game1.tileSize / 4 +
                    Yoffset, Game1.tileSize / 2, Game1.tileSize), "", "",
                Game1.content.Load<Texture2D>("LooseSprites\\font_bold"), new Rectangle(8, 16, 8, 12), Game1.pixelZoom)
            {
                myID = 17,
                downNeighborID = 24,
                leftNeighborID = 16,
                rightNeighborID = 18,
                upNeighborID = 10
            });
            DayButtons.Add(new ClickableTextureComponent("17",
                new Rectangle(
                    xPositionOnScreen + spaceToClearSideBorder + borderWidth + (int)(Game1.tileSize * 3.25) -
                    Game1.tileSize / 3,
                    yPositionOnScreen + borderWidth + spaceToClearTopBorder + Game1.tileSize * 6 - Game1.tileSize / 4 +
                    Yoffset, Game1.tileSize / 2, Game1.tileSize), "", "",
                Game1.content.Load<Texture2D>("LooseSprites\\font_bold"), new Rectangle(56, 16, 8, 12), Game1.pixelZoom)
            {
                myID = 17,
                downNeighborID = 24,
                leftNeighborID = 16,
                rightNeighborID = 18,
                upNeighborID = 10
            });
            DayButtons.Add(new ClickableTextureComponent("18",
                new Rectangle(
                    xPositionOnScreen + spaceToClearSideBorder + borderWidth + (int)(Game1.tileSize * 3.75) -
                    Game1.tileSize / 4,
                    yPositionOnScreen + borderWidth + spaceToClearTopBorder + Game1.tileSize * 6 - Game1.tileSize / 4 +
                    Yoffset, Game1.tileSize / 2, Game1.tileSize), "", "",
                Game1.content.Load<Texture2D>("LooseSprites\\font_bold"), new Rectangle(8, 16, 8, 12), Game1.pixelZoom)
            {
                myID = 18,
                downNeighborID = 25,
                leftNeighborID = 17,
                rightNeighborID = 19,
                upNeighborID = 11
            });
            DayButtons.Add(new ClickableTextureComponent("18",
                new Rectangle(
                    xPositionOnScreen + spaceToClearSideBorder + borderWidth + (int)(Game1.tileSize * 4.25) -
                    Game1.tileSize / 3,
                    yPositionOnScreen + borderWidth + spaceToClearTopBorder + Game1.tileSize * 6 - Game1.tileSize / 4 +
                    Yoffset, Game1.tileSize / 2, Game1.tileSize), "", "",
                Game1.content.Load<Texture2D>("LooseSprites\\font_bold"), new Rectangle(64, 16, 8, 12), Game1.pixelZoom)
            {
                myID = 18,
                downNeighborID = 25,
                leftNeighborID = 17,
                rightNeighborID = 19,
                upNeighborID = 11
            });
            DayButtons.Add(new ClickableTextureComponent("19",
                new Rectangle(
                    xPositionOnScreen + spaceToClearSideBorder + borderWidth + (int)(Game1.tileSize * 4.75) -
                    Game1.tileSize / 4,
                    yPositionOnScreen + borderWidth + spaceToClearTopBorder + Game1.tileSize * 6 - Game1.tileSize / 4 +
                    Yoffset, Game1.tileSize / 2, Game1.tileSize), "", "",
                Game1.content.Load<Texture2D>("LooseSprites\\font_bold"), new Rectangle(8, 16, 8, 12), Game1.pixelZoom)
            {
                myID = 19,
                downNeighborID = 26,
                leftNeighborID = 18,
                rightNeighborID = 20,
                upNeighborID = 12
            });
            DayButtons.Add(new ClickableTextureComponent("19",
                new Rectangle(
                    xPositionOnScreen + spaceToClearSideBorder + borderWidth + (int)(Game1.tileSize * 5.25) -
                    Game1.tileSize / 3,
                    yPositionOnScreen + borderWidth + spaceToClearTopBorder + Game1.tileSize * 6 - Game1.tileSize / 4 +
                    Yoffset, Game1.tileSize / 2, Game1.tileSize), "", "",
                Game1.content.Load<Texture2D>("LooseSprites\\font_bold"), new Rectangle(72, 16, 8, 12), Game1.pixelZoom)
            {
                myID = 19,
                downNeighborID = 26,
                leftNeighborID = 18,
                rightNeighborID = 20,
                upNeighborID = 12
            });
            DayButtons.Add(new ClickableTextureComponent("20",
                new Rectangle(
                    xPositionOnScreen + spaceToClearSideBorder + borderWidth + (int)(Game1.tileSize * 5.75) -
                    Game1.tileSize / 4,
                    yPositionOnScreen + borderWidth + spaceToClearTopBorder + Game1.tileSize * 6 - Game1.tileSize / 4 +
                    Yoffset, Game1.tileSize / 2, Game1.tileSize), "", "",
                Game1.content.Load<Texture2D>("LooseSprites\\font_bold"), new Rectangle(16, 16, 8, 12), Game1.pixelZoom)
            {
                myID = 20,
                downNeighborID = 27,
                leftNeighborID = 19,
                rightNeighborID = 21,
                upNeighborID = 13
            });
            DayButtons.Add(new ClickableTextureComponent("20",
                new Rectangle(
                    xPositionOnScreen + spaceToClearSideBorder + borderWidth + (int)(Game1.tileSize * 6.25) -
                    Game1.tileSize / 3,
                    yPositionOnScreen + borderWidth + spaceToClearTopBorder + Game1.tileSize * 6 - Game1.tileSize / 4 +
                    Yoffset, Game1.tileSize / 2, Game1.tileSize), "", "",
                Game1.content.Load<Texture2D>("LooseSprites\\font_bold"), new Rectangle(0, 16, 8, 12), Game1.pixelZoom)
            {
                myID = 20,
                downNeighborID = 27,
                leftNeighborID = 19,
                rightNeighborID = 21,
                upNeighborID = 13
            });
            DayButtons.Add(new ClickableTextureComponent("21",
                new Rectangle(
                    xPositionOnScreen + spaceToClearSideBorder + borderWidth + (int)(Game1.tileSize * 6.75) -
                    Game1.tileSize / 4,
                    yPositionOnScreen + borderWidth + spaceToClearTopBorder + Game1.tileSize * 6 - Game1.tileSize / 4 +
                    Yoffset, Game1.tileSize / 2, Game1.tileSize), "", "",
                Game1.content.Load<Texture2D>("LooseSprites\\font_bold"), new Rectangle(16, 16, 8, 12), Game1.pixelZoom)
            {
                myID = 21,
                downNeighborID = 28,
                leftNeighborID = 20,
                rightNeighborID = 22,
                upNeighborID = 14
            });
            DayButtons.Add(new ClickableTextureComponent("21",
                new Rectangle(
                    xPositionOnScreen + spaceToClearSideBorder + borderWidth + (int)(Game1.tileSize * 7.25) -
                    Game1.tileSize / 3,
                    yPositionOnScreen + borderWidth + spaceToClearTopBorder + Game1.tileSize * 6 - Game1.tileSize / 4 +
                    Yoffset, Game1.tileSize / 2, Game1.tileSize), "", "",
                Game1.content.Load<Texture2D>("LooseSprites\\font_bold"), new Rectangle(8, 16, 8, 12), Game1.pixelZoom)
            {
                myID = 21,
                downNeighborID = 28,
                leftNeighborID = 20,
                rightNeighborID = 22,
                upNeighborID = 14
            });
            DayButtons.Add(new ClickableTextureComponent("22",
                new Rectangle(
                    xPositionOnScreen + spaceToClearSideBorder + borderWidth + (int)(Game1.tileSize * 0.75) -
                    Game1.tileSize / 4,
                    yPositionOnScreen + borderWidth + spaceToClearTopBorder + Game1.tileSize * 7 - Game1.tileSize / 4 +
                    Yoffset, Game1.tileSize / 2, Game1.tileSize), "", "",
                Game1.content.Load<Texture2D>("LooseSprites\\font_bold"), new Rectangle(16, 16, 8, 12), Game1.pixelZoom)
            {
                myID = 22,
                downNeighborID = -7777,
                leftNeighborID = 21,
                rightNeighborID = 23,
                upNeighborID = 15
            });
            DayButtons.Add(new ClickableTextureComponent("22",
                new Rectangle(
                    xPositionOnScreen + spaceToClearSideBorder + borderWidth + (int)(Game1.tileSize * 1.25) -
                    Game1.tileSize / 3,
                    yPositionOnScreen + borderWidth + spaceToClearTopBorder + Game1.tileSize * 7 - Game1.tileSize / 4 +
                    Yoffset, Game1.tileSize / 2, Game1.tileSize), "", "",
                Game1.content.Load<Texture2D>("LooseSprites\\font_bold"), new Rectangle(16, 16, 8, 12), Game1.pixelZoom)
            {
                myID = 22,
                downNeighborID = -7777,
                leftNeighborID = 21,
                rightNeighborID = 23,
                upNeighborID = 15
            });
            DayButtons.Add(new ClickableTextureComponent("23",
                new Rectangle(
                    xPositionOnScreen + spaceToClearSideBorder + borderWidth + (int)(Game1.tileSize * 1.75) -
                    Game1.tileSize / 4,
                    yPositionOnScreen + borderWidth + spaceToClearTopBorder + Game1.tileSize * 7 - Game1.tileSize / 4 +
                    Yoffset, Game1.tileSize / 2, Game1.tileSize), "", "",
                Game1.content.Load<Texture2D>("LooseSprites\\font_bold"), new Rectangle(16, 16, 8, 12), Game1.pixelZoom)
            {
                myID = 23,
                downNeighborID = -7777,
                leftNeighborID = 22,
                rightNeighborID = 24,
                upNeighborID = 16
            });
            DayButtons.Add(new ClickableTextureComponent("23",
                new Rectangle(
                    xPositionOnScreen + spaceToClearSideBorder + borderWidth + (int)(Game1.tileSize * 2.25) -
                    Game1.tileSize / 3,
                    yPositionOnScreen + borderWidth + spaceToClearTopBorder + Game1.tileSize * 7 - Game1.tileSize / 4 +
                    Yoffset, Game1.tileSize / 2, Game1.tileSize), "", "",
                Game1.content.Load<Texture2D>("LooseSprites\\font_bold"), new Rectangle(24, 16, 8, 12), Game1.pixelZoom)
            {
                myID = 23,
                downNeighborID = -7777,
                leftNeighborID = 22,
                rightNeighborID = 24,
                upNeighborID = 16
            });
            DayButtons.Add(new ClickableTextureComponent("24",
                new Rectangle(
                    xPositionOnScreen + spaceToClearSideBorder + borderWidth + (int)(Game1.tileSize * 2.75) -
                    Game1.tileSize / 4,
                    yPositionOnScreen + borderWidth + spaceToClearTopBorder + Game1.tileSize * 7 - Game1.tileSize / 4 +
                    Yoffset, Game1.tileSize / 2, Game1.tileSize), "", "",
                Game1.content.Load<Texture2D>("LooseSprites\\font_bold"), new Rectangle(16, 16, 8, 12), Game1.pixelZoom)
            {
                myID = 24,
                downNeighborID = -7777,
                leftNeighborID = 23,
                rightNeighborID = 25,
                upNeighborID = 17
            });
            DayButtons.Add(new ClickableTextureComponent("24",
                new Rectangle(
                    xPositionOnScreen + spaceToClearSideBorder + borderWidth + (int)(Game1.tileSize * 3.25) -
                    Game1.tileSize / 3,
                    yPositionOnScreen + borderWidth + spaceToClearTopBorder + Game1.tileSize * 7 - Game1.tileSize / 4 +
                    Yoffset, Game1.tileSize / 2, Game1.tileSize), "", "",
                Game1.content.Load<Texture2D>("LooseSprites\\font_bold"), new Rectangle(32, 16, 8, 12), Game1.pixelZoom)
            {
                myID = 24,
                downNeighborID = -7777,
                leftNeighborID = 23,
                rightNeighborID = 25,
                upNeighborID = 17
            });
            DayButtons.Add(new ClickableTextureComponent("25",
                new Rectangle(
                    xPositionOnScreen + spaceToClearSideBorder + borderWidth + (int)(Game1.tileSize * 3.75) -
                    Game1.tileSize / 4,
                    yPositionOnScreen + borderWidth + spaceToClearTopBorder + Game1.tileSize * 7 - Game1.tileSize / 4 +
                    Yoffset, Game1.tileSize / 2, Game1.tileSize), "", "",
                Game1.content.Load<Texture2D>("LooseSprites\\font_bold"), new Rectangle(16, 16, 8, 12), Game1.pixelZoom)
            {
                myID = 25,
                downNeighborID = -7777,
                leftNeighborID = 24,
                rightNeighborID = 26,
                upNeighborID = 18
            });
            DayButtons.Add(new ClickableTextureComponent("25",
                new Rectangle(
                    xPositionOnScreen + spaceToClearSideBorder + borderWidth + (int)(Game1.tileSize * 4.25) -
                    Game1.tileSize / 3,
                    yPositionOnScreen + borderWidth + spaceToClearTopBorder + Game1.tileSize * 7 - Game1.tileSize / 4 +
                    Yoffset, Game1.tileSize / 2, Game1.tileSize), "", "",
                Game1.content.Load<Texture2D>("LooseSprites\\font_bold"), new Rectangle(40, 16, 8, 12), Game1.pixelZoom)
            {
                myID = 25,
                downNeighborID = -7777,
                leftNeighborID = 24,
                rightNeighborID = 26,
                upNeighborID = 18
            });
            DayButtons.Add(new ClickableTextureComponent("26",
                new Rectangle(
                    xPositionOnScreen + spaceToClearSideBorder + borderWidth + (int)(Game1.tileSize * 4.75) -
                    Game1.tileSize / 4,
                    yPositionOnScreen + borderWidth + spaceToClearTopBorder + Game1.tileSize * 7 - Game1.tileSize / 4 +
                    Yoffset, Game1.tileSize / 2, Game1.tileSize), "", "",
                Game1.content.Load<Texture2D>("LooseSprites\\font_bold"), new Rectangle(16, 16, 8, 12), Game1.pixelZoom)
            {
                myID = 26,
                downNeighborID = -7777,
                leftNeighborID = 25,
                rightNeighborID = 27,
                upNeighborID = 19
            });
            DayButtons.Add(new ClickableTextureComponent("26",
                new Rectangle(
                    xPositionOnScreen + spaceToClearSideBorder + borderWidth + (int)(Game1.tileSize * 5.25) -
                    Game1.tileSize / 3,
                    yPositionOnScreen + borderWidth + spaceToClearTopBorder + Game1.tileSize * 7 - Game1.tileSize / 4 +
                    Yoffset, Game1.tileSize / 2, Game1.tileSize), "", "",
                Game1.content.Load<Texture2D>("LooseSprites\\font_bold"), new Rectangle(48, 16, 8, 12), Game1.pixelZoom)
            {
                myID = 26,
                downNeighborID = -7777,
                leftNeighborID = 25,
                rightNeighborID = 27,
                upNeighborID = 19
            });
            DayButtons.Add(new ClickableTextureComponent("27",
                new Rectangle(
                    xPositionOnScreen + spaceToClearSideBorder + borderWidth + (int)(Game1.tileSize * 5.75) -
                    Game1.tileSize / 4,
                    yPositionOnScreen + borderWidth + spaceToClearTopBorder + Game1.tileSize * 7 - Game1.tileSize / 4 +
                    Yoffset, Game1.tileSize / 2, Game1.tileSize), "", "",
                Game1.content.Load<Texture2D>("LooseSprites\\font_bold"), new Rectangle(16, 16, 8, 12), Game1.pixelZoom)
            {
                myID = 27,
                downNeighborID = -7777,
                leftNeighborID = 26,
                rightNeighborID = 28,
                upNeighborID = 20
            });
            DayButtons.Add(new ClickableTextureComponent("27",
                new Rectangle(
                    xPositionOnScreen + spaceToClearSideBorder + borderWidth + (int)(Game1.tileSize * 6.25) -
                    Game1.tileSize / 3,
                    yPositionOnScreen + borderWidth + spaceToClearTopBorder + Game1.tileSize * 7 - Game1.tileSize / 4 +
                    Yoffset, Game1.tileSize / 2, Game1.tileSize), "", "",
                Game1.content.Load<Texture2D>("LooseSprites\\font_bold"), new Rectangle(56, 16, 8, 12), Game1.pixelZoom)
            {
                myID = 27,
                downNeighborID = -7777,
                leftNeighborID = 26,
                rightNeighborID = 28,
                upNeighborID = 20
            });
            DayButtons.Add(new ClickableTextureComponent("28",
                new Rectangle(
                    xPositionOnScreen + spaceToClearSideBorder + borderWidth + (int)(Game1.tileSize * 6.75) -
                    Game1.tileSize / 4,
                    yPositionOnScreen + borderWidth + spaceToClearTopBorder + Game1.tileSize * 7 - Game1.tileSize / 4 +
                    Yoffset, Game1.tileSize / 2, Game1.tileSize), "", "",
                Game1.content.Load<Texture2D>("LooseSprites\\font_bold"), new Rectangle(16, 16, 8, 12), Game1.pixelZoom)
            {
                myID = 28,
                downNeighborID = -7777,
                leftNeighborID = 27,
                rightNeighborID = -7777,
                upNeighborID = 21
            });
            DayButtons.Add(new ClickableTextureComponent("28",
                new Rectangle(
                    xPositionOnScreen + spaceToClearSideBorder + borderWidth + (int)(Game1.tileSize * 7.25) -
                    Game1.tileSize / 3,
                    yPositionOnScreen + borderWidth + spaceToClearTopBorder + Game1.tileSize * 7 - Game1.tileSize / 4 +
                    Yoffset, Game1.tileSize / 2, Game1.tileSize), "", "",
                Game1.content.Load<Texture2D>("LooseSprites\\font_bold"), new Rectangle(64, 16, 8, 12), Game1.pixelZoom)
            {
                myID = 28,
                downNeighborID = -7777,
                leftNeighborID = 27,
                rightNeighborID = -7777,
                upNeighborID = 21
            });
        

        TitleLabel = new ClickableComponent(new Rectangle(XPos + 200, YPos + 96, UIWidth - 400, 64),
                $"{I18n.Title()}");

        
    }
    
    public static Vector2 getAppropriateMenuPosition()
    {
        Vector2 defaultPosition = new Vector2(Game1.uiViewport.Width / 2 - UIWidth / 2, (Game1.uiViewport.Height / 2 - UIHeight / 2));

        //Force the viewport into a position that it should fit into on the screen???
        if (defaultPosition.X + UIWidth > Game1.uiViewport.Width)
        {
            defaultPosition.X = 0;
        }

        if (defaultPosition.Y + UIHeight > Game1.uiViewport.Height)
        {
            defaultPosition.Y = 0;
        }
        return defaultPosition;

    }
    
    public override void draw(SpriteBatch b)
    {
        
        b.Draw(Game1.fadeToBlackRect, Game1.graphics.GraphicsDevice.Viewport.Bounds, Color.Black * 0.75f);
        Game1.drawDialogueBox(XPos, YPos, UIWidth, UIHeight, false, true);

        Utility.drawTextWithShadow(b, TitleLabel.name, Game1.dialogueFont,
            new Vector2(TitleLabel.bounds.X, TitleLabel.bounds.Y), Color.Black);

        foreach (ClickableTextureComponent button in DayButtons)
        {
            button.draw(b);
        }

        foreach (ClickableTextureComponent button in SeasonButtons)
        {
            button.draw(b);
        }
        if (birthdayday != 0 && string.IsNullOrEmpty(birthdayseason) == false)
            okButton.draw(b);
        else
        {
            okButton.draw(b);
            okButton.draw(b, Color.Black * 0.5f, 0.97f);
        }
    

    drawMouse(b);
        }
    
    


    private string birthdayseason;
    private int birthdayday;
    private void HandleButtonClick(string name)
    {
        if (name == null)
            return;

        switch (name)
        {
            case "Spring":
                birthdayseason = "spring";
                break;

            case "Summer":
                birthdayseason = "summer";
                break;

            case "Fall":
                birthdayseason = "fall";
                break;

            case "Winter":
                birthdayseason = "winter";
                break;
            
            case "OK":

                BirthdaySaveData.Register($"{birthdayseason}{birthdayday}");
                if (Game1.CurrentEvent != null)
                {
                    Game1.CurrentEvent.CurrentCommand++;
                }

                Game1.exitActiveMenu();
                break;

            default:
                birthdayday = int.Parse(name);
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

                foreach (ClickableTextureComponent other in SeasonButtons)
                {
                    other.scale = Game1.pixelZoom;
                }

                button.scale = Game1.pixelZoom + 0.5f;
            }
        }
        foreach (ClickableTextureComponent button in DayButtons)
        {
            if (button.containsPoint(x, y))
            {
                HandleButtonClick(button.name);
                
                foreach (ClickableTextureComponent other in DayButtons)
                {
                    other.scale = Game1.pixelZoom;
                }
                
                foreach (ClickableTextureComponent other in DayButtons)
                {
                    if (other.name == button.name)
                    {
                        other.scale = Game1.pixelZoom + 0.5f;
                    }
                }
            }
        }
        if (this.okButton.containsPoint(x, y))
        {
            if (string.IsNullOrEmpty(birthdayseason) || birthdayday == 0) return;
            HandleButtonClick(this.okButton.name);
            this.okButton.scale -= 0.25f;
            this.okButton.scale = Math.Max(0.75f, this.okButton.scale);
        }
    }
}
