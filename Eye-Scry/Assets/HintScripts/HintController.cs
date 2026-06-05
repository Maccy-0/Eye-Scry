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

}
