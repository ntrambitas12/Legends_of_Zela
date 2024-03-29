﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Net;

public class SoundFactory
{
    private Dictionary<string, SoundEffect> soundEffects;


    public SoundFactory() {
        soundEffects = new Dictionary<string, SoundEffect>();
    }

    /*
     * sound effect class that plays sounds, loops them, pauses them, etc
     */
    public void LoadAllContent(ContentManager Content)
    {
        if (!soundEffects.ContainsKey("Dungeon 1"))
        {
            //This can be refactored to be less lines (data driven)
            soundEffects.Add("Dungeon 1", Content.Load<SoundEffect>("Sound2/Dungeon 1"));//done, tested
            soundEffects.Add("LOZ_Arrow_Boomerang", Content.Load<SoundEffect>("Sound2/LOZ_Arrow_Boomerang"));//done, tested
            soundEffects.Add("LOZ_Bomb_Blow", Content.Load<SoundEffect>("Sound2/LOZ_Bomb_Blow"));//done tested
            soundEffects.Add("LOZ_Bomb_Drop", Content.Load<SoundEffect>("Sound2/LOZ_Bomb_Drop"));
            soundEffects.Add("LOZ_Boss_Hit", Content.Load<SoundEffect>("Sound2/LOZ_Boss_Hit"));//done tested
            soundEffects.Add("LOZ_Boss_Scream1", Content.Load<SoundEffect>("Sound2/LOZ_Boss_Scream1"));
            soundEffects.Add("LOZ_Door_Unlock", Content.Load<SoundEffect>("Sound2/LOZ_Door_Unlock"));//done, tested
            soundEffects.Add("LOZ_Enemy_Die", Content.Load<SoundEffect>("Sound2/LOZ_Enemy_Die"));//done tested
            soundEffects.Add("LOZ_Enemy_Hit", Content.Load<SoundEffect>("Sound2/LOZ_Enemy_Hit"));
            soundEffects.Add("LOZ_Fanfare", Content.Load<SoundEffect>("Sound2/LOZ_Fanfare"));//Done, tested
            soundEffects.Add("LOZ_Get_Heart", Content.Load<SoundEffect>("Sound2/LOZ_Get_Heart"));//done, tested
            soundEffects.Add("LOZ_Get_Item", Content.Load<SoundEffect>("Sound2/LOZ_Get_Item"));//done, tested
            soundEffects.Add("LOZ_Get_Rupee", Content.Load<SoundEffect>("Sound2/LOZ_Get_Rupee"));//done, tested
            soundEffects.Add("LOZ_Key_Appear", Content.Load<SoundEffect>("Sound2/LOZ_Key_Appear"));//done tested
            soundEffects.Add("LOZ_Link_Die", Content.Load<SoundEffect>("Sound2/LOZ_Link_Die"));//done, tested
            soundEffects.Add("LOZ_Link_Hurt", Content.Load<SoundEffect>("Sound2/LOZ_Link_Hurt"));//done, tested
            soundEffects.Add("LOZ_LowHealth", Content.Load<SoundEffect>("Sound2/LOZ_LowHealth"));
            soundEffects.Add("LOZ_Refill_Loop", Content.Load<SoundEffect>("Sound2/LOZ_Refill_Loop"));
            soundEffects.Add("LOZ_Secret", Content.Load<SoundEffect>("Sound2/LOZ_Secret"));
            soundEffects.Add("LOZ_Shield", Content.Load<SoundEffect>("Sound2/LOZ_Shield"));
            soundEffects.Add("LOZ_Stairs", Content.Load<SoundEffect>("Sound2/LOZ_Stairs"));//done
            soundEffects.Add("LOZ_Sword_Combined", Content.Load<SoundEffect>("Sound2/LOZ_Sword_Combined"));
            soundEffects.Add("LOZ_Sword_Shoot", Content.Load<SoundEffect>("Sound2/LOZ_Sword_Shoot"));//done and tested
            soundEffects.Add("LOZ_Sword_Slash", Content.Load<SoundEffect>("Sound2/LOZ_Sword_Slash"));//done, tested
            soundEffects.Add("LOZ_Text", Content.Load<SoundEffect>("Sound2/LOZ_Text"));
            soundEffects.Add("LOZ_Text_Slow", Content.Load<SoundEffect>("Sound2/LOZ_Text_Slow"));
        }

        // Fire and forget play
       // soundEffects["LOZ_Bomb_Blow"].Play();

        // Play that can be manipulated after the fact
      //  var instance = soundEffects["LOZ_Bomb_Blow"].CreateInstance();
      //  instance.IsLooped = true;
      //  instance.Play();
    }

    private static readonly SoundFactory instance = new SoundFactory();
    public static SoundFactory Instance { get { return instance; } }

    public Dictionary<string, SoundEffect> GetSounds()
    {
        return soundEffects;
    }
}
