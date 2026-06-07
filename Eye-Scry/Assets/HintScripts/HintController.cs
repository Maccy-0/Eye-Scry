using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HintController : MonoBehaviour
{
    private PuzzleScenesLogic puzzleScenesLogic;

    private UnityEngine.SceneManagement.Scene scene;

    private int puzzleOneState;
    private int puzzleTwoState;
    private int puzzleThreeState;

    private int oneFinishedValue = 3;
    private int twoFinishedValue;
    private int threeFinishedValue;

    public GameObject hintBox;

    public Sprite objOneImg;
    public Sprite objTwoImg;
    public Sprite objThreeImg;

    public GameObject imgHolderOne;
    public GameObject imgHolderTwo;
    public GameObject imgHolderThree;

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
            puzzleScenesLogic = GetComponent<PuzzleScenesLogic>();

            puzzleOneState = puzzleScenesLogic.WandProgression;
            puzzleTwoState = puzzleScenesLogic.RingProgression;
            puzzleThreeState = puzzleScenesLogic.BookProgression;
        }

        if(puzzleOneState == oneFinishedValue)
        {
            // Put logic for disabling button here
            puzzleOneState = -1;
        }
    }

    public void WandHint()
    {

        if (puzzleOneState != -1) {
            // Strings to invoke a public function with, used to tell the wizard what to say
            if (puzzleOneState == 0)
            {
                // Bark One

            }
            else if (puzzleOneState == 1)
            {
                // Bark Two

            }
            else if (puzzleOneState == 2)
            {
                // Bark Three

            }
            else if (puzzleOneState == 3)
            {
                // Bark Four

            }
        }
    }

    public void RingHint()
    {

    }

    public void BookHint()
    {

    }

    public void ToggleHints()
    {
        if (hintBox.activeSelf)
        {
            // Sound hook close
            hintBox.SetActive(false);
        }
        else
        {
            // Sound hook open
            hintBox.SetActive(true);
        }
        UpdateProgression();
    }

}
