using UnityEngine;
using TMPro;
using System.Collections;

public class DialogLogic : MonoBehaviour
{
    public  TextMeshProUGUI textMesh;

    public string[] introduction;
    public string[] farewell;
    public HintController hintController;

    private float delayChar = .05f;
    private float delayLine = 1.2f;

    private float lineIndex = 0;

    private bool nextButton = false;

    private bool autoPlay = false;

    private Coroutine dialogDisplay;

    // Need to have a for each loop read out each letter with delay, using the for int to keep track of the current character count compared to the strings full length.
    // once the string is finished, have a delay, then begin the next string if there is one.

    public void ReadThis(string[] textArray)
    {
        if (dialogDisplay != null)
        {
            StopCoroutine(dialogDisplay);
        }
        dialogDisplay = StartCoroutine(ReadDialog(textArray));

    }

    [ContextMenu("Intro")]
    public void IntroQue()
    {
        ReadThis(introduction);
    }

    [ContextMenu("Farewell")]
    public void FarewellQue()
    {
        ReadThis(farewell);
    }

    [ContextMenu("Next")]
    public void NextButton()
    {
        nextButton = true;
    }

    [ContextMenu("Auto")]
    public void PlayAuto()
    {
        autoPlay = !autoPlay;
    }

    private IEnumerator ReadDialog(string[] textArray)
    {  

        foreach (string line in textArray)
        {
            textMesh.text = "";

            for (int i = 0;i < line.Length; i++)
            {
                textMesh.text += line[i];
                lineIndex = i;
                yield return new WaitForSeconds(delayChar);
            }

            if (autoPlay)
            {
                yield return new WaitForSeconds(delayLine);
            }
            else
            {
                yield return new WaitUntil(() => nextButton || autoPlay);
                nextButton = false;
            }

        }
        dialogDisplay = null;
    }

    public void DialogFinished()
    {
        // Statements to read what the next inputs should be
    }

    }
