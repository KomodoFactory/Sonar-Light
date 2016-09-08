using UnityEngine;
using System.Collections;

public static class SoundComponent
{
    private static Object[] Soundclips = Resources.LoadAll("SoundEffects");
    private static AudioClip defaultAudio = audioByName("DefaultAudio");

    public static AudioClip audioByName(string name)
    {
        if (name != null)
        {
            foreach (UnityEngine.Object obj in Soundclips)
            {
                if (obj.name.ToLower().Equals(name.ToLower()))
                {
                    return (AudioClip)obj;
                }
            }
        }
        return defaultAudio;
    }

    public static AudioClip getDefaultAudio()
    {
        return defaultAudio;
    }
}
