using UnityEngine;
using TMPro;
using UnityEngine.Audio;

public class AccessibilityQuestionCard : MonoBehaviour
{
    public enum AccessibilityType
    {
        ColorSensitivity,
        DyslexiaFonts,
        AuditoryAssistance
    }

    [Header("Settings")]
    public AccessibilityType questionType;

    [Header("Manager Reference")]
    [Tooltip("Drag your 'Manager' GameObject from the hierarchy here.")]
    public AccessibilityManager manager;

    [Header("Color Sensitivity Dependencies")]
    public GameObject colorblindVolume;

    [Header("Dyslexia Fonts Dependencies")]
    public TMP_FontAsset dyslexiaFont;
    private TMP_FontAsset defaultFont;

    [Header("Auditory Dependencies")]
    public AudioMixer audioMixer;
    public string dialogueVolumeParameter = "DialogueVolume";

    // This is the direct function your UI buttons will click!
    public void SelectOption(bool isYes)
    {
        Debug.Log($"[Card] Chosen option: {(isYes ? "Yes" : "No")} on {gameObject.name}");

        switch (questionType)
        {
            case AccessibilityType.ColorSensitivity:
                HandleColorSensitivity(isYes);
                break;
        }

        if (manager != null)
        {
            manager.AdvanceToNextCard();
        }
        else
        {
            Debug.LogError($"Manager is missing on {gameObject.name}! Can't switch cards.");
        }
    }

    private void HandleColorSensitivity(bool enabled)
    {
        if (colorblindVolume != null) colorblindVolume.SetActive(enabled);
    }

    private void HandleDyslexiaFonts(bool enabled)
    {
        TextMeshProUGUI[] allTextElements = FindObjectsOfType<TextMeshProUGUI>(true);
        foreach (TextMeshProUGUI textElement in allTextElements)
        {
            if (enabled)
            {
                if (defaultFont == null) defaultFont = textElement.font;
                if (dyslexiaFont != null) textElement.font = dyslexiaFont;
            }
            else
            {
                if (defaultFont != null) textElement.font = defaultFont;
            }
        }
    }

    private void HandleAuditoryAssistance(bool enabled)
    {
        if (audioMixer != null)
        {
            float targetVolume = enabled ? 10f : 0f;
            audioMixer.SetFloat(dialogueVolumeParameter, targetVolume);
        }
    }
}