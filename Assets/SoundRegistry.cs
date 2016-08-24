using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class SoundRegistry: MonoBehaviour {

    public static readonly int queueSize = 25;
    private static SoundRegistry instance;
    private List<Sound> sounds;

    private SoundRegistry() {
        sounds = new List<Sound>();
    }

    public static SoundRegistry getInstance() {
        if(instance == null) {
            instance = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<SoundRegistry>();
        }
        return instance;
    }

    public void addSound(Sound sound) {
        sounds.Add(sound);
    }

    void Update() {
        foreach (Sound sound in sounds.ToList()) {
            Debug.Log(sound.getSourcePosition());
            if (sound.update()) {
                sounds.Remove(sound);
            }
        }
    }

}
