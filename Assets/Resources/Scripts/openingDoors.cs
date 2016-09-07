using UnityEngine;
using System.Collections;
using System;

public class openingDoors : MonoBehaviour
{
    public readonly string keyMissingMessage = "It seems it needs a Key.";
    public readonly string notOpeningMessage = "It seams to be busted.";
    public readonly float messageDuration = 5;

    CharacterInventory inventory;
    public bool opensAtAll = true;
    public bool needsAKey = false;
    public bool opensOutward = true;
    public float rotationSpeed = 90;

    private float rotationDirection = 1;
    private float currentRotation = 0;
    private float frameRotation = 0;
    private bool opened = false;

    void Start()
    {
        inventory = CharacterInventory.Instance;
        rotationDirection = giveOpeningDirection();
        this.enabled = false;
    }

    void Update()
    {
        frameRotation = rotationDirection * Time.deltaTime * rotationSpeed;
        if (Math.Abs(currentRotation) > 90)
        {
            frameRotation = 90 * rotationDirection - currentRotation;
            currentRotation = frameRotation * -1;
            deactivate();
        }
        currentRotation += frameRotation;

        if (!opened)
        {
            transform.Rotate(transform.up, frameRotation);
        }
        else
        {
            transform.Rotate(transform.up, frameRotation * -1);
        }
    }

    private void activate()
    {
        this.enabled = true;
    }

    private void deactivate()
    {
        this.enabled = false;
        opened = !opened;
    }

    public void interact()
    {
        if (opensAtAll)
        {
            if (!needsAKey)
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

    private float giveOpeningDirection()
    {
        if (opensOutward)
        {
            return 1;
        }
        return -1;
    }

}
