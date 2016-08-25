using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class SoundRegistry : MonoBehaviour {

    public static readonly int queueSize = 5;
    private static SoundRegistry instance;
    private List<Sound> sounds;
    public Material shaderMaterial;

    private SoundRegistry() {
        sounds = new List<Sound>(queueSize);
    }

    public static SoundRegistry getInstance() {
        if (instance == null) {
            instance = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<SoundRegistry>();
        }
        return instance;
    }

    public void addSound(Sound sound) {
        if (sounds.Count < queueSize) {
            sounds.Add(sound);
        }
    }

    void Update() {
        Sound oldestSound = new Sound(gameObject, 0);
        foreach (Sound sound in sounds.ToList()) {
            if (sound.getCurrentRadius() > oldestSound.getCurrentRadius()) {
                oldestSound = sound;
            }
            if (sound.update()) {
                sounds.Remove(sound);
            }
        }
        if (oldestSound != null) {
            shaderMaterial.SetFloat("_Distance", oldestSound.getCurrentRadius());
        }
        if (sounds.Count < 1) {
            shaderMaterial.SetFloat("_Distance", 0);
        }
    }

}
