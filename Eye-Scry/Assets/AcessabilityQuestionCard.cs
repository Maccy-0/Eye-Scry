using UnityEngine;
using UnityEngine.UI;
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

    [Header("UI References")]
    public Button yesButton;
    public Button noButton;

    [Header("Color Sensitivity Dependencies")]
    [Tooltip("Assign a GameObject in your scene that contains your Colorblind Post-Processing Volume.")]
    public GameObject colorblindVolume;

    [Header("Dyslexia Fonts Dependencies")]
    [Tooltip("Assign your highly readable TMP_FontAsset here.")]
    public TMP_FontAsset dyslexiaFont;
    private TMP_FontAsset defaultFont; // Stores the original font automatically

    [Header("Auditory Dependencies")]
    [Tooltip("Assign your main Audio Mixer here.")]
    public AudioMixer audioMixer;
    [Tooltip("The exact name of the exposed parameter in your Audio Mixer.")]
    public string dialogueVolumeParameter = "DialogueVolume";

    private void Start()
    {
        if (yesButton != null) yesButton.onClick.AddListener(() => OnOptionSelected(true));
        if (noButton != null) noButton.onClick.AddListener(() => OnOptionSelected(false));
    }

    private void OnOptionSelected(bool isYes)
    {
        switch (questionType)
        {
            case AccessibilityType.ColorSensitivity:
                HandleColorSensitivity(isYes);
                break;

            case AccessibilityType.DyslexiaFonts:
                HandleDyslexiaFonts(isYes);
                break;

            case AccessibilityType.AuditoryAssistance:
                HandleAuditoryAssistance(isYes);
                break;
        }
    }

    // --- FUNCTIONAL LOGIC ---

    private void HandleColorSensitivity(bool enabled)
    {
        if (colorblindVolume != null)
        {
            // Toggles the GameObject holding your specific colorblind post-processing overrides
            colorblindVolume.SetActive(enabled);
            Debug.Log($"[Accessibility] Color Sensitivity set to: {enabled}");
        }
        else
        {
            Debug.LogWarning("Colorblind Volume GameObject is not assigned in the inspector!");
        }
    }

    private void HandleDyslexiaFonts(bool enabled)
    {
        // Finds all TextMeshPro UI elements in the current scene
        TextMeshProUGUI[] allTextElements = FindObjectsOfType<TextMeshProUGUI>(true);

        foreach (TextMeshProUGUI textElement in allTextElements)
        {
            if (enabled)
            {
                // Save the default font the first time we swap it
                if (defaultFont == null) defaultFont = textElement.font;

                if (dyslexiaFont != null) textElement.font = dyslexiaFont;
            }
            else
            {
                // Revert to the standard font
                if (defaultFont != null) textElement.font = defaultFont;
            }
        }
        Debug.Log($"[Accessibility] Dyslexia Fonts set to: {enabled}");
    }

    private void HandleAuditoryAssistance(bool enabled)
    {
        if (audioMixer != null)
        {
            // Boost dialogue by 10 decibels if enabled, or keep at 0 (default) if disabled
            float targetVolume = enabled ? 10f : 0f;
            audioMixer.SetFloat(dialogueVolumeParameter, targetVolume);

            Debug.Log($"[Accessibility] Auditory Assistance set to: {enabled} ({targetVolume}dB)");
        }
        else
        {
            Debug.LogWarning("Audio Mixer is not assigned in the inspector!");
        }
    }
}