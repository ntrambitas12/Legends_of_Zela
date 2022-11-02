using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Graphics;

using System.Net;

public class SoundManager
 {
    private Dictionary<string, SoundEffectInstance> soundEffects;
    private List<string> loopedSounds;

    public SoundManager()
    {
        loopedSounds = new List<String>();
        Dictionary<string, SoundEffect> temp = SoundFactory.Instance.GetSounds();
        soundEffects = new Dictionary<string, SoundEffectInstance>();
        foreach(KeyValuePair<string, SoundEffect> entry in temp)
        {
            soundEffects.Add(entry.Key, entry.Value.CreateInstance());
        }
    }
    public void PlayOnce(string key)
    {
        soundEffects[key].Play();
    }

    public void PlayLooped(string key)
    {
        loopedSounds.Add(key);
        var sound = soundEffects[key];
        sound.IsLooped = true;
        sound.Play();
    }

    public void PauseSounds()
    {
        foreach (string key in loopedSounds)
        {
            var sound = soundEffects[key];
            sound.IsLooped = false;
            sound.Pause();
        }
    }

   public void UnpauseSounds()
    {
        foreach (string key in loopedSounds)
        {
            var sound = soundEffects[key];
            sound.IsLooped = true;
            sound.Play();
        }
    }

    public void KillSound(string key)
    {
        if (loopedSounds.Contains(key))
        {
            loopedSounds.Remove(key);
        }
        var sound = soundEffects[key];
        sound.IsLooped = false;
    }

    private static readonly SoundManager instance = new SoundManager();
    public static SoundManager Instance { get { return instance; } }

    /*
     * This holds the complexity for the sounds of attacking with sword,
     * taking damage, opening/closing doors
     * 
     * What is a sprite action?
     */
    public void playStateSounds(SpriteAction action, ISpriteState state)
    {
        switch (state.toString())
        {
            case "AttackState":
                SoundManager.Instance.PlayOnce("LOZ_Sword_Slash");
                break;

            case "DamagedState":
                SoundManager.Instance.PlayOnce("LOZ_Link_Hurt");
                break;
/*  Might not need these
            case "OpenState":
                SoundManager.Instance.PlayOnce("Door_Unlock");
                break;

            case "ClosedState":
                SoundManager.Instance.PlayOnce("LOZ_Sword_Slash");
                break;*/
        }
    }
}

