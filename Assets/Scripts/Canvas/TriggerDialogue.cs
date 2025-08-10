using TMPro;
using UnityEngine;

public class DialogByTrigger : MonoBehaviour
{
    public TutorialDialog tutorialDialog;
    public DialogueLine dialogLine;
    [SerializeField] GameObject text;
    [SerializeField] bool enablesPlayerMovementOnHide;
    [SerializeField] PlayerController playerController;
    [SerializeField] float timeBeforeHide = 4f;

    private bool wasAlreadyShown = false;

    private void OnTriggerEnter(Collider other)
    {

        text.SetActive(true);

        if (wasAlreadyShown)
            return;
        wasAlreadyShown = true;
        tutorialDialog.CustomLine(dialogLine);
        Invoke("HideText", timeBeforeHide);

    }

    private void HideText()
    {
        if (wasAlreadyShown)
        {
            text.SetActive(false);
        }
        if (enablesPlayerMovementOnHide)
            playerController.isMovementEnabled = true;
    }
}