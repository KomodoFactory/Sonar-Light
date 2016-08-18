using UnityEngine;
using System.Collections.Generic;

public class SoundRegistry {

    public static readonly int queueSize = 25;
    private static SoundRegistry instance;
    private Queue<Sound> sounds;

    private SoundRegistry() {
        sounds = new Queue<Sound>();
    }

    public static SoundRegistry getInstance() {
        if(instance == null) {
            instance = new SoundRegistry();
        }
        return instance;
    }

    public void addSound(Sound sound) {
        sounds.Enqueue(sound);
    }

}
