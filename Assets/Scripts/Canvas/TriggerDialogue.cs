using TMPro;
using UnityEngine;

public class DialogByTrigger : MonoBehaviour
{
    public TutorialDialog tutorialDialog;
    public DialogueLine dialogLine;
    [SerializeField] GameObject text;

    private bool wasAlreadyShown = false;

    private void OnTriggerEnter(Collider other)
    {
        if (wasAlreadyShown)
            return;
        wasAlreadyShown = true;
        tutorialDialog.CustomLine(dialogLine);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && wasAlreadyShown)
        {
            text.SetActive(false);
        }

    }
}