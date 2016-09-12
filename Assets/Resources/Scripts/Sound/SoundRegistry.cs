using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class SoundRegistry : MonoBehaviour {

    public static readonly int queueSize = 50;
    private static SoundRegistry instance;
    private List<Sound> sounds;

    private SoundRegistry() {
        sounds = new List<Sound>(queueSize);
    }

    public static SoundRegistry getInstance() {
        if (instance == null) {
            instance = GameObject.FindGameObjectWithTag("Player").GetComponent<SoundRegistry>();
        }
        return instance;
    }

    public void addSound(Sound sound) {
        if (sounds.Count < queueSize) {
            sounds.Add(sound);
            AudioSource.PlayClipAtPoint(sound.getAudioClip(), sound.getSourcePosition());
        }
    }

    void Update() {
        foreach (Sound sound in sounds.ToList()) {
            if (sound.update()) {
                sounds.Remove(sound);
            }
        }
        MaterialHandler.getInstance().setShaderData(sounds.ToArray());
    }

}
