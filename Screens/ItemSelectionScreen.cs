
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class ItemSelectionScreen
    {
    public IConcreteSprite Link { get; set; }
    private static IDrop[] items;
    private HUD hud;
    private static Vector2 itemOffset = new Vector2(505, 100);
    private Rectangle baseSelector = new Rectangle(450, 60, 300, 100);
    private int baseXitemSelector = 490;
    private Rectangle itemSelector = new Rectangle(490, 95, 40, 40);
    private Rectangle currentSelectedItem = new Rectangle(160, 85, 50, 55);
    private static int itemPadding = 90;
    private bool isActive;
    private GraphicsDevice graphicsDevice;
    private SpriteBatch spriteBatch;
    private SpriteFont textFont;
    private Vector2 invTextPos = new Vector2(90,20);
    private Vector2 useTextPos = new Vector2(45, 180);
    private Vector2 useTextPos2 = new Vector2(90, 220);
    private static Vector2 selectedItemCord = new Vector2(180, 100);
    private int selectedItem = 0;
    private static Dictionary<int, IDrop> selectedDrop;
    private IDrop currentItem;
    private int baseSelectorWidth = 6;
    private int currentSelectedWidth = 4;
    private int itemSelectedWidth = 2;


    public ItemSelectionScreen(GraphicsDevice graphicsDevice, SpriteBatch spriteBatch, SpriteFont textFont, HUD hud)
    {

        items = new IDrop[3];
        isActive = false;
        this.graphicsDevice = graphicsDevice;   
        this.spriteBatch = spriteBatch; 
        this.textFont = textFont;
        this.hud = hud;
        selectedDrop = new Dictionary<int, IDrop>();    
       
    }
    
    public void Update(GameTime gameTime)
    {
        if (isActive)
        {
            selectedItem = (int)Link.ProjectileIndex();
            if (items[selectedItem] != null)
            {
                currentItem = selectedDrop[selectedItem];
                currentItem.SetShouldDraw(true);
                hud.currentItem = selectedItem;
            }
                UpdateSelectedBox();
        }
    }

    private void UpdateSelectedBox()
    {
        itemSelector.Deconstruct(out int x, out int y, out int width, out int height);
        x = (itemPadding * selectedItem) + baseXitemSelector;
        itemSelector = new Rectangle(x, y, width, height);
    }

    public void Draw(GameTime gameTime)
    {
       if(isActive) {
            DrawRectangle(baseSelector, Color.Blue, baseSelectorWidth);
            DrawRectangle(currentSelectedItem, Color.Blue, currentSelectedWidth);
            if (items[selectedItem] != null)
            {
                DrawRectangle(itemSelector, Color.Red, itemSelectedWidth);
            }
            spriteBatch.DrawString(textFont, "INVENTORY", invTextPos, Color.Red);
            spriteBatch.DrawString(textFont, "PRESS SPACE BAR", useTextPos, Color.White);
            spriteBatch.DrawString(textFont, "TO USE ITEM", useTextPos2, Color.White);

            foreach (var item in items)
            {
                if (item != null)
                {
                    item.Draw(gameTime);
                }
            }
            if (currentItem != null)
            {
                currentItem.Draw(gameTime);
            }
        }
    }

    public void ActivateItemSelection()
    {
        isActive = !isActive;
    }
    private void DrawRectangle(Rectangle coords, Color color, int thickness)
    {
        Texture2D _texture;

        _texture = new Texture2D(graphicsDevice, 1, 1);
        _texture.SetData(new Color[] { color });

        spriteBatch.Draw(_texture, new Rectangle(coords.Left, coords.Top, coords.Width, thickness), color);
        spriteBatch.Draw(_texture, new Rectangle(coords.Right, coords.Top, thickness, coords.Height), color);
        spriteBatch.Draw(_texture, new Rectangle(coords.Left, coords.Bottom, coords.Width, thickness), color);
        spriteBatch.Draw(_texture, new Rectangle(coords.Left, coords.Top, thickness, coords.Height), color);
    }
    public static void AddToInventory(IDrop item, ArrayIndex idx)
    {
        item.SetPosition(itemOffset + new Vector2(itemPadding * (int)idx, 0));
        item.SetShouldDraw(true);
        items[(int)idx] = item;
        IDrop cloneDrop = (IDrop)item.Clone();
        cloneDrop.SetPosition(selectedItemCord);
        selectedDrop.Add((int)idx, cloneDrop);
    }

    public void NextItem(bool forward)
    {
        int nextItem = (forward ? 1 : -1);
        selectedItem = (selectedItem + nextItem) % items.Length;
       if (selectedItem < 0)
        {
            selectedItem+=items.Length;
        }
        NextNonNull(forward);
        Link.SetProjectileIndex((ArrayIndex)selectedItem);
    }

    private void NextNonNull(bool forward)
    {
        int count = 0;
        int nextItem = (forward ? 1 : -1);
        while (items[selectedItem] == null && count < items.Length)
        {
            selectedItem = (selectedItem + nextItem) % items.Length;
            if (selectedItem < 0)
            {
                selectedItem += items.Length;
            }
            count++;
        }
    }
    public bool isOpen()
    {
        return isActive;
    }
}

