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
    }
}
