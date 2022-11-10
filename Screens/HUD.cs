using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mime;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CSE3902Project;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

public class HUD
{
    public IConcreteSprite Link { get; set; }
    public SpriteFactory sf { get; set; }
    private GraphicsDevice graphicsDevice;
    private SpriteBatch spriteBatch;
    private SpriteFont textFont;
    private RoomObjectManager rom;
    private Vector2 levelPlacement = new Vector2(150, 10);
    private Vector2 mapPlacement = new Vector2(160, 40);
    private Vector2 keyPlacement = new Vector2(300, 60);
    private Vector2 rubyPlacement = new Vector2(300, 20);
    private Vector2 bombPlacement = new Vector2(300, 80);
    private Vector2 BPlacement = new Vector2(380, 20);
    private Vector2 swordPlacement = new Vector2(420, 40);
    private Vector2 secondaryPlacement = new Vector2(380, 40);
    private Vector2 APlacement = new Vector2(420, 20);
    private Vector2 LifeTextPlacement = new Vector2(500, 20);
    private Vector2 heartOrigin = new Vector2(480, 60);
    private Vector2 countOffset = new Vector2(20, 0);
    private Vector2 _00 = new Vector2(0, 0);
    private Vector2 borderA = new Vector2(409, 30);
    private Vector2 borderB = new Vector2(369, 30);
    private Vector2 triforceRoom = new Vector2(255, 49);
    private Vector2 openInvOffset = new Vector2(0, 325);
    private IDrop item;
    private bool isResetting;
    public int currentItem { get; set; }
    private static Dictionary<int, Vector2> linkMapLocation;

    public HUD(GraphicsDevice graphicsDevice, SpriteBatch spriteBatch, SpriteFont textFont, RoomObjectManager rom)
    {

        this.graphicsDevice = graphicsDevice;
        this.spriteBatch = spriteBatch;
        this.textFont = textFont;
        this.rom = rom;
        isResetting = false;
        linkMapLocation = new Dictionary<int, Vector2>();
        LoadLocationDictionary();
    }

    public void Draw(GameTime gameTime, bool isInvOpen)
    {
        
            GetSecondaryItem(isInvOpen);
            DrawStaticElements(isInvOpen);
            DrawUpdatingElements(isInvOpen, gameTime);
            DrawHealth(isInvOpen);
            MapHandler(rom.currentRoomID(), gameTime, isInvOpen);
        
    }

    public void DrawHealth(bool isInvOpen)
    {
        spriteBatch.DrawString(textFont, "-LIFE-", isInvOpen? LifeTextPlacement + openInvOffset: LifeTextPlacement, Color.DarkRed);

        Vector2 offset = new Vector2(0, 0);
        for(int i = 0; i < Link.maxHealth; i++)
        {
            spriteBatch.Draw(sf.HUDHeart(), (isInvOpen ? heartOrigin + offset + openInvOffset : heartOrigin + offset), null, Color.Maroon, 0, _00, 3, SpriteEffects.None, 0);
            if (Link.health > i)
            {
                spriteBatch.Draw(sf.HUDHeart(), (isInvOpen ? heartOrigin + offset + openInvOffset : heartOrigin + offset), null, Color.Red, 0, _00, 3, SpriteEffects.None, 0);
            }
            offset.X += 25;
        }
    }

    public void DrawStaticElements(bool isInvOpen)
    {
        spriteBatch.DrawString(textFont, "LEVEL-1", isInvOpen? levelPlacement + openInvOffset : levelPlacement, Color.White);
        spriteBatch.DrawString(textFont, "B", isInvOpen? BPlacement + openInvOffset : BPlacement, Color.White);
        spriteBatch.DrawString(textFont, "A", isInvOpen? APlacement + openInvOffset : APlacement, Color.White);
        spriteBatch.Draw(sf.HUDKey(),  isInvOpen? keyPlacement + openInvOffset : keyPlacement, null, Color.White, 0, _00, 2, SpriteEffects.None, 0);
        spriteBatch.Draw(sf.HUDBomb(), isInvOpen? bombPlacement + openInvOffset : bombPlacement, null, Color.White, 0, _00, 2, SpriteEffects.None, 0);
        spriteBatch.Draw(sf.HUDRuby(), isInvOpen ? rubyPlacement + openInvOffset : rubyPlacement, null, Color.White, 0, _00, 2, SpriteEffects.None, 0);
        spriteBatch.Draw(sf.HUDSword(),isInvOpen ? swordPlacement + openInvOffset : swordPlacement, null, Color.White, 0, _00, 2, SpriteEffects.None, 0);
        spriteBatch.Draw(sf.HUDItemBorder(), isInvOpen ? borderA + openInvOffset : borderA, null, Color.White, 0, _00, 2, SpriteEffects.None, 0);
        spriteBatch.Draw(sf.HUDItemBorder(),  isInvOpen ? borderB + openInvOffset : borderB, null, Color.White, 0, _00, 2, SpriteEffects.None, 0);
    }

    public void DrawUpdatingElements(bool isInvOpen, GameTime gameTime)
    {
        spriteBatch.DrawString(textFont, "X" + Link.rubies, isInvOpen? rubyPlacement + countOffset + openInvOffset : rubyPlacement + countOffset, Color.White);
        spriteBatch.DrawString(textFont, "X" + Link.keys, isInvOpen? keyPlacement + countOffset + openInvOffset : keyPlacement + countOffset, Color.White);
        spriteBatch.DrawString(textFont, "X" + Link.bombs, isInvOpen? bombPlacement + countOffset + openInvOffset : bombPlacement + countOffset, Color.White);
        spriteBatch.DrawString(textFont, "X" + Link.bombs, isInvOpen ? bombPlacement + countOffset + openInvOffset : bombPlacement + countOffset, Color.White);
        
        item = GetSecondaryItem(isInvOpen);
        if(item != null && !isResetting)
        {
            item.Draw(gameTime);
            item.SetShouldDraw(false);
        }
    }

    public IDrop GetSecondaryItem(bool isInvOpen) 
    {

        IDrop item = ItemSelectionScreen.currentItem;
        if(item != null)
        {
            item = (IDrop)item.Clone();
            item.SetPosition(isInvOpen ? secondaryPlacement + openInvOffset : secondaryPlacement);
            item.SetShouldDraw(true);
        }

        return item;  
    }

    public void MapHandler(int currentRoom, GameTime gameTime, bool isInvOpen)
    {
        if (Link.map) { spriteBatch.Draw(sf.HUDMap(), isInvOpen ? mapPlacement + openInvOffset : mapPlacement, Color.White); }
        if (Link.compass) 
        {
                spriteBatch.Draw(sf.HUDTriforce(), isInvOpen ? triforceRoom + openInvOffset : triforceRoom, Color.White);
        }
        spriteBatch.Draw(sf.HUDLink(), isInvOpen? linkMapLocation[currentRoom] + openInvOffset : linkMapLocation[currentRoom], Color.White);
    }

    public void LoadLocationDictionary()
    {
        linkMapLocation.Add(26, new Vector2(201, 40));
        linkMapLocation.Add(25, new Vector2(183, 40));
        linkMapLocation.Add(24, new Vector2(255, 49));
        linkMapLocation.Add(23, new Vector2(237, 49));
        linkMapLocation.Add(21, new Vector2(201, 49));
        linkMapLocation.Add(18, new Vector2(237, 58));
        linkMapLocation.Add(17, new Vector2(219, 58));
        linkMapLocation.Add(16, new Vector2(201, 58));
        linkMapLocation.Add(15, new Vector2(183, 58));
        linkMapLocation.Add(14, new Vector2(165, 58));
        linkMapLocation.Add(12, new Vector2(219, 67));
        linkMapLocation.Add(11, new Vector2(201, 67));
        linkMapLocation.Add(10, new Vector2(183, 67));
        linkMapLocation.Add(6, new Vector2(201, 76));
        linkMapLocation.Add(2, new Vector2(219, 85));
        linkMapLocation.Add(1, new Vector2(201, 85));
        linkMapLocation.Add(0, new Vector2(183, 85));
    }

}