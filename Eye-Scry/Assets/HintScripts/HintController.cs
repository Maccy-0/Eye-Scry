using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HintController : MonoBehaviour
{
    public PuzzleScenesLogic puzzleScenesLogic;

    private UnityEngine.SceneManagement.Scene scene;

    private int puzzleOneState;
    private int puzzleTwoState;
    private int puzzleThreeState;

    private int oneFinishedValue = 3;
    private int twoFinishedValue = 3;
    private int threeFinishedValue = 2;

    public GameObject hintBox;

    public Sprite objOneImg;
    public Sprite objTwoImg;
    public Sprite objThreeImg;

    public GameObject imgHolderOne;
    public GameObject imgHolderTwo; 
    public GameObject imgHolderThree;

    public string[] hintOpen;
    public string[] stringsWand;
    public string[] stringsBook;
    public string[] stringsRing;

    public Canvas navCanvas;
    public GameObject puzzleScreen;

    public DialogLogic dialogLogic;

    public GameObject panelText;

    // Still needs a function to temporarily close the scry scene.

    private void Awake()
    {
        UpdateProgression();
        scene = SceneManager.GetActiveScene();
    }

    private void Update()
    {
        if (puzzleOneState != puzzleScenesLogic.WandProgression || puzzleTwoState != puzzleScenesLogic.RingProgression || puzzleThreeState != puzzleScenesLogic.BookProgression)
        {
            UpdateProgression();
        }

    }

    private void UpdateProgression()
    {
        if (GetComponentInParent<PuzzleScenesLogic>() != null)
        {
            // 1
            puzzleOneState = puzzleScenesLogic.WandProgression;
            // 3
            puzzleTwoState = puzzleScenesLogic.RingProgression;
            // 2
            puzzleThreeState = puzzleScenesLogic.BookProgression;
        }

        if (puzzleOneState == oneFinishedValue)
        {
            // Put logic for disabling button here
            puzzleOneState = -1;
        }
        if (puzzleTwoState == twoFinishedValue)
        {
            puzzleTwoState = -1;
        }
        if (puzzleThreeState == threeFinishedValue)
        {
            puzzleThreeState = -1;
        }
    }

    [ContextMenu("Wand")]
    public void WandHint()
    {

        if (puzzleOneState != -1) 
        {
            dialogLogic.ReadThis(stringsWand);
        }
    }

    [ContextMenu("Book")]
    public void BookHint()
    {
        if (puzzleThreeState != -1)
        {
            dialogLogic.ReadThis(stringsRing);
        }
    }

    [ContextMenu("Ring")]
    public void RingHint()
    {

        if (puzzleTwoState != -1)
        {
            dialogLogic.ReadThis(stringsBook);
        }

    }

    [ContextMenu("Open")]
    public void OpenHint()
    {
        dialogLogic.ReadThis(hintOpen);
    }

    public void ToggleHints()
    {
        if (hintBox.activeSelf)
        {
            // Sound hook close
            hintBox.SetActive(false);
            ReturnScry();
            navCanvas.gameObject.SetActive(true);
            panelText.SetActive(false);
        }
        else
        {
            // Sound hook open
            hintBox.SetActive(true);
            navCanvas.gameObject.SetActive(false);
            panelText.SetActive(true);
            ShrinkScry();
        }
        UpdateProgression();
    }

    public void ShrinkScry()
    {
        puzzleScreen.gameObject.transform.localScale = new Vector3(.2f,.2f,1f);
    }

    public void ReturnScry()
    {
        puzzleScreen.gameObject.transform.localScale = Vector3.one;
    }

}
