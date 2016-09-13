using UnityEngine;
using System.Collections;
using System;

public class OpeningDoors : MonoBehaviour
{
    public readonly string keyMissingMessage = "It seems it needs a Key.";
    public readonly string notOpeningMessage = "It seams to be busted.";
    public readonly string eyeSwitchMessage = "It requires a switch.";
    public readonly float messageDuration = 5;

    public bool opensAtAll = true;
    public bool needsAKey = false;
    public bool usesEyeSwitch = false;
    public bool startsOpen = false;
    public float rotationSpeed = 90;


    public readonly float audioVolume = 15;
    private AudioClip audioclosing;
    private AudioClip audioopening;

    CharacterInventory inventory;

    private int rotationDirection;
    private float currentRotation = 0;
    private float frameRotation = 0;
    private bool opened = false;

    //TODO: Reworking 
    private AudioClip currentaudio;
    public bool opensOutward = true;

    Vector3 endposition;

    void Start()
    {
        inventory = CharacterInventory.Instance;
        rotationDirection = decideOpeningDirection();
        endposition = this.gameObject.transform.rotation.eulerAngles + new Vector3(0, 90, 0) * rotationDirection;

        audioclosing = SoundComponent.audioByName("doorclosing");
        audioopening = SoundComponent.audioByName("dooropening");
        if (startsOpen)
        {
            currentaudio = audioclosing;
        }else
        {
            currentaudio = audioopening;
        }
        this.enabled = false;
    }

    void Update()
    {
        frameRotation = rotationDirection * Time.deltaTime * rotationSpeed;
        currentRotation += frameRotation;
        if (Math.Abs(currentRotation) > 90)
        {
            frameRotation = 0;
            currentRotation = 0;
            deactivate();
        }

            transform.Rotate(transform.up, frameRotation);
    }

    private void activate()
    {
        if (!this.enabled)
        {
            SoundRegistry.getInstance().addSound(new Sound(this.gameObject, audioVolume, currentaudio));
            this.enabled = true;
            endposition = this.gameObject.transform.rotation.eulerAngles + new Vector3(0, 90, 0) * rotationDirection;
            Debug.Log(endposition);
        }
    }

    private void deactivate()
    {
        this.enabled = false;
        opened = !opened;
        rotationDirection = rotationDirection *-1;
        this.gameObject.transform.rotation = Quaternion.Euler(endposition);
        Debug.Log(this.gameObject.transform.rotation);
    }

    public void interact()
    {
        if (opensAtAll)
        {
            if (usesEyeSwitch && !opened)
            {
                ScreenPromptHandler.Instance.DisplayPrompt(eyeSwitchMessage, messageDuration);
            }
            else if(!needsAKey)
            {
                activate();
            }
            else
            {
                if (CheckKey())
                {
                    needsAKey = false;
                    activate();
                }
                else
                {
                    ScreenPromptHandler.Instance.DisplayPrompt(keyMissingMessage, messageDuration);
                }
            }
        }
        else
        {
            ScreenPromptHandler.Instance.DisplayPrompt(notOpeningMessage, messageDuration);
        }
    }

    private bool CheckKey()
    {
        if (inventory.checkIfDoorCanBeOpened(this.gameObject))
        {
            return true;
        }
        return false;
    }

    private int decideOpeningDirection()
    {
        if (opensOutward)
        {
            return 1;
        }
        return -1;
    }

    public void openEyeDoor()
    {
        if (usesEyeSwitch && !opened)
        {
            activate();
        }
    }
}
