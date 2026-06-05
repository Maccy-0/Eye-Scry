using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SlotScript : MonoBehaviour
{
    // When making a slot for a specific purpose I recomend creating a new script as parent to the slot, or group of slots. This system doesn't need to interact with the hierarchy otherwise.

    [Tooltip("Object Types")]
    // If a slot needs a specific item, you can set it here via its associated integer
    public int objectType;

    public string correctType;

    // Whether any type of object is allowed in. Set to true if any object can enter the slot.
    public bool ignoreType = false;

    public int selfIndex;

    public ObjectMovementScript heldItem = null;
    public ObjectMovementScript wantsToBeHeld = null;
    
    // If a specific slot is more than just a holder use this integer to index.
    public int keyPointType;

    public CircleCollider2D selfCollider;
    private List<GameObject> detectedObjects = new List<GameObject>();
    public PuzzleScenesLogic PuzzleScenesLogic;

    void Start()
    {
        if (this.gameObject.GetComponent<CircleCollider2D>() != null)
        {
            selfCollider = this.gameObject.GetComponent<CircleCollider2D>();
        }
        if(selfCollider != null)
        {
            detectedObjects = new List<GameObject>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(wantsToBeHeld != null && heldItem == null && wantsToBeHeld.submitToTaker == true)
        {
            Debug.Log("4 Alert");
            PuzzleScenesLogic.readCurrentMessage(this.name);
            heldItem = wantsToBeHeld;
            wantsToBeHeld.GetSlotted(this);
            wantsToBeHeld.submitToTaker = false;
        }
    }

    public void  OnTriggerStay2D(Collider2D collision)
    {
            // Gets the items in range and determines if it's ready to be slotted
            if (heldItem == null && collision.gameObject.CompareTag(correctType))
            {
                Debug.Log("1 Alert");

                if (!detectedObjects.Contains(collision.gameObject))
                {
                    Debug.Log("2 Alert");
                    detectedObjects.Add(collision.gameObject);

                    if (collision.gameObject.GetComponent<ObjectMovementScript>() && wantsToBeHeld == null)
                    {
                        if (collision.gameObject.GetComponent<ObjectMovementScript>().objectType == this.objectType || this.ignoreType)
                        {
                            Debug.Log("3 Alert");
                            wantsToBeHeld = collision.gameObject.GetComponent<ObjectMovementScript>();
                            wantsToBeHeld.beingSlotted = true;
                        }

                    }

                }
            }    
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (wantsToBeHeld != null)
        {

            if (wantsToBeHeld.GetComponent<ObjectMovementScript>() && collision.gameObject == wantsToBeHeld.gameObject)
            {
                objectLeft(wantsToBeHeld.gameObject);

            }
        }
    }

    // Logic for item leaving the slot
    public void objectLeft(GameObject lostObject)
    {
        if (wantsToBeHeld != null)
        {
            if (detectedObjects.Contains(wantsToBeHeld.gameObject))
            {
                detectedObjects.Remove(lostObject);
                Debug.Log("Object left slot: " + selfIndex);
            }

            wantsToBeHeld.beingSlotted = false;
            wantsToBeHeld.submitToTaker = false;
            heldItem = null;
            wantsToBeHeld = null;
        }
    }

    public void ResetSlot()
    {
        this.heldItem = null;
        this.wantsToBeHeld = null;
        this.detectedObjects = new List<GameObject>();
    }
}
