using UnityEngine;
using System.Collections.Generic;

public class AccessibilityManager : MonoBehaviour
{
    [Header("Scene Cards Setup")]
    public List<AccessibilityQuestionCard> cards = new List<AccessibilityQuestionCard>();

    [Header("Menu Navigation")]
    [Tooltip("Drag your Main Menu panel UI object here (Leave empty if you don't have one yet).")]
    public GameObject mainMenuPanel;

    private int currentCardIndex = 0;

    private void Start()
    {
        if (cards == null || cards.Count == 0)
        {
            Debug.LogError("No cards assigned to the Manager array!");
            return;
        }

        // Hide all cards initially
        for (int i = 0; i < cards.Count; i++)
        {
            if (cards[i] != null)
            {
                cards[i].gameObject.SetActive(false);
            }
        }

        // Show only the very first card
        currentCardIndex = 0;
        cards[currentCardIndex].gameObject.SetActive(true);

        if (mainMenuPanel != null) mainMenuPanel.SetActive(false);
    }

    public void AdvanceToNextCard()
    {
        // Hide current card
        if (cards[currentCardIndex] != null)
        {
            cards[currentCardIndex].gameObject.SetActive(false);
        }

        // Move to next card
        currentCardIndex++;

        // If there are more cards left, show the next one
        if (currentCardIndex < cards.Count)
        {
            if (cards[currentCardIndex] != null)
            {
                cards[currentCardIndex].gameObject.SetActive(true);
            }
        }
        else
        {
            // All cards are finished!
            OnSequenceComplete();
        }
    }

    private void OnSequenceComplete()
    {
        Debug.Log("All accessibility questions completed!");

        if (mainMenuPanel != null)
        {
            mainMenuPanel.SetActive(true);
        }

        // Turn off the manager system
        gameObject.SetActive(false);
    }
}