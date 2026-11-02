using System.Collections;
using UnityEngine;
using UnityEngine.UI;

/// <summary>Simple UI text helper. Assign a Unity UI Text and optional start/final panels.</summary>
public class MissionUI : MonoBehaviour
{
    [SerializeField] private Text messageText;
    [SerializeField] private GameObject messagePanel;
    [SerializeField, Min(0.5f)] private float messageDuration = 4f;
    [SerializeField] private GameObject finalPanel;

    private Coroutine messageRoutine;

    private void Awake()
    {
        if (messagePanel != null) messagePanel.SetActive(false);
        if (finalPanel != null) finalPanel.SetActive(false);
    }

    public void ShowMessage(string message)
    {
        if (messageText != null)
            messageText.text = message;

        if (messagePanel != null)
            messagePanel.SetActive(true);

        if (messageRoutine != null)
            StopCoroutine(messageRoutine);

        messageRoutine = StartCoroutine(HideMessageLater());
    }

    private IEnumerator HideMessageLater()
    {
        yield return new WaitForSeconds(messageDuration);
        if (messagePanel != null)
            messagePanel.SetActive(false);
        messageRoutine = null;
    }

    public void ShowFinal()
    {
        if (finalPanel != null)
            finalPanel.SetActive(true);
        else
            ShowMessage("Escapaste antes de medianoche.");
    }

    public void HideFinal()
    {
        if (finalPanel != null)
            finalPanel.SetActive(false);
    }
}
