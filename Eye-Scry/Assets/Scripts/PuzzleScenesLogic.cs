using System.Linq;
using Unity.XR.OpenVR;
using UnityEngine;

public class PuzzleScenesLogic : MonoBehaviour
{
    public GameObject TowerTopScene;
    public GameObject TowerBottomScene;

    public int WandProgression;
    public int RingProgression;
    public int BookProgression;

    public GameObject Torch;
    public GameObject Rock;
    public GameObject Painting;
    public GameObject Pedistal;
    public SpriteRenderer PedistalPicture;
    public BoxCollider2D Pedistalbox;
    public Sprite Pedistal1;
    public Sprite Pedistal2;
    public GameObject Book;
    public GameObject Deadpainting;

    public GameObject Wand1;
    public GameObject Wand2;
    public GameObject Hat;
    public GameObject Rack;
    public ObjectMovementScript HatScript;
    public Transform hatStart;
    public Transform hatRack;

    public GameObject fakeRing;
    public GameObject realRing;
    public GameObject ringContainer;
    public GameObject gem1obj;
    public GameObject gem2obj;
    public GameObject gem3obj;
    public GameObject gem4obj;
    public GameObject gem5obj;
    public ObjectMovementScript gem1;
    public ObjectMovementScript gem2;
    public ObjectMovementScript gem3;
    public ObjectMovementScript gem4;
    public ObjectMovementScript gem5;
    public Transform gemslot1;
    public Transform gemslot2;
    public Transform gemslot3;
    public Transform gemslot4;
    public Transform gemslot5;
    public int[] gems = { 0, 0, 0, 0, 0 };

    public string currentMessage;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        WandProgression = 0;
        RingProgression = 0;
        BookProgression = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Basement
        if (BookProgression == 0)
        {
            Painting.SetActive(true);
            Pedistal.SetActive(false);
            //PedistalPicture.sprite = Pedistal1;
            Book.SetActive(false);
            Deadpainting.SetActive(false);
        }
        if (BookProgression == 1)
        {
            Painting.SetActive(false);
            Pedistal.SetActive(true);
            //PedistalPicture.sprite = Pedistal1;
            Book.SetActive(false);
            Deadpainting.SetActive(true);
        }
        if (BookProgression == 2)
        {
            Painting.SetActive(false);
            Pedistal.SetActive(true);
            Pedistalbox.enabled = false;
            //PedistalPicture.sprite = Pedistal2;
            Book.SetActive(true);
            Deadpainting.SetActive(true);
        }
        if (BookProgression == 3)
        {
            Painting.SetActive(false);
            Pedistal.SetActive(true);
            //PedistalPicture.sprite = Pedistal2;
            Book.SetActive(false);
            Deadpainting.SetActive(true);
        }
        if (WandProgression == 0)
        {
            Wand1.SetActive(true);
            Wand2.SetActive(false);
            if (!HatScript.isSelected)
            {
                Hat.transform.position = hatStart.position;
            }
        }
        if (WandProgression == 1)
        {
            Wand1.SetActive(true);
            Wand2.SetActive(false);
            if (!HatScript.isSelected)
            {
                Hat.transform.position = hatRack.position;
            }
        }
        if (WandProgression == 2)
        {
            Wand1.SetActive(false);
            Wand2.SetActive(true);
            if (!HatScript.isSelected)
            {
                Hat.transform.position = hatRack.position;
            }
        }
        if (WandProgression == 3)
        {
            Wand1.SetActive(false);
            Wand2.SetActive(false);
            if (!HatScript.isSelected)
            {
                Hat.transform.position = hatRack.position;
            }
        }
        if (RingProgression == 0)
        {
            fakeRing.SetActive(true);
            realRing.SetActive(false);
            ringContainer.SetActive(true);
        }
        if (RingProgression == 1)
        {
            fakeRing.SetActive(false);
            realRing.SetActive(true);
            ringContainer.SetActive(false);
        }
        if (RingProgression == 2)
        {
            fakeRing.SetActive(false);
            realRing.SetActive(false);
            ringContainer.SetActive(false);
        }
    }

    public void LoadTowerTop()
    {
        TowerTopScene.SetActive(true);
        TowerBottomScene.SetActive(false);
    }

    public void LoadTowerBottom()
    {
        TowerTopScene.SetActive(false);
        TowerBottomScene.SetActive(true);
    }

    public void readCurrentMessage(string message)
    {
        Debug.Log("Name: " + message);
        if (message == "Painting" && BookProgression == 0)
        {
            BookProgression = 1;
        }
        if (message == "Pedistal" && BookProgression == 1)
        {
            BookProgression = 2;
        }
        if (message == "Key3" && BookProgression == 2)
        {
            BookProgression = 3;
            Debug.Log("Book got");
        }
        if (message == "Rack" && WandProgression == 0)
        {
            WandProgression = 1;
        }
        if (message == "Key0" && WandProgression == 1)
        {
            WandProgression = 2;
        }
        if (message == "Key1" && WandProgression == 2)
        {
            WandProgression = 3;
            Debug.Log("Wand got");
        }
        if (message == "1GemSlot" && RingProgression == 0)
        {
            gems[0] = 1;
            gem1.thisRB.simulated = false;
            Destroy(gem1);
            gem1obj.transform.position = gemslot1.position;
        }
        if (message == "2GemSlot" && RingProgression == 0)
        {
            gems[1] = 1;
            gem2.thisRB.simulated = false;
            Destroy(gem2);
            gem2obj.transform.position = gemslot2.position;
        }
        if (message == "3GemSlot" && RingProgression == 0)
        {
            gems[2] = 1;
            gem3.thisRB.simulated = false;
            Destroy(gem3);
            gem3obj.transform.position = gemslot3.position;
        }
        if (message == "4GemSlot" && RingProgression == 0)
        {
            gems[3] = 1;
            gem4.thisRB.simulated = false;
            Destroy(gem4);
            gem4obj.transform.position = gemslot4.position;
        }
        if (message == "5GemSlot" && RingProgression == 0)
        {
            gems[4] = 1;
            gem5.thisRB.simulated = false;
            Destroy(gem5);
            gem5obj.transform.position = gemslot5.position;
        }
        if (gems.Sum() == 5 && RingProgression == 0)
        {
            RingProgression = 1;
            Debug.Log("did it");
        }
        if (message == "Key2" && RingProgression == 1)
        {
            RingProgression = 2;
            Debug.Log("Ring got");
        }
    }
}
