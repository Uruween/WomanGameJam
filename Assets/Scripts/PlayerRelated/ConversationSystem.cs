using System.Collections;
using UnityEngine;
using TMPro;
using System;

public class TutorialDialog : MonoBehaviour
{

    [Header("Tutorial Components")]
    public GameObject tutorialCanvas;
    public GameObject characterContainer;
    public GameObject additionalToDisable;

    [Header("UI Components")]
    public TextMeshProUGUI dialogText;


    [Header("Audio")]
    public AudioClip talkClip; // Sonido por letra
    public AudioSource bgMusic; // Música de fondo del juego

    [Header("Dialog Settings")]
    public DialogueLine[] dialogLines;
    public float typingSpeed = 0.05f;

    private int currentLine = 0;
    private bool isTyping = false;

    void Start()
    {
        if (bgMusic != null)
            bgMusic.Stop(); // Detiene música del juego

        //ShowLine();
    }

    public void ShowLine()
    {
        if (currentLine < dialogLines.Length)
        {
            bool isChar1 = dialogLines[currentLine].isCharacter1;


            StartCoroutine(TypeLine(dialogLines[currentLine].text, isChar1));
        }
    }

    IEnumerator TypeLine(string line, bool isCharacter1Turn)
    {
        isTyping = true;
        dialogText.text = "";

        foreach (char c in line)
        {
            dialogText.text += c;

            if (talkClip != null)
            {

            }

            yield return new WaitForSeconds(typingSpeed);
        }

        isTyping = false;

    }

    public void NextLine()
    {
        if (isTyping)
        {
            // Mostrar línea completa de inmediato
            StopAllCoroutines();
            dialogText.text = dialogLines[currentLine].text;
            isTyping = false;


        }
        else
        {
            currentLine++;
            if (currentLine < dialogLines.Length)
            {
                ShowLine();
            }
            else
            {
                EndTutorial();
            }
        }
    }

    void EndTutorial()
    {
        if (bgMusic != null)
            bgMusic.Play(); // Reanuda música

        if (tutorialCanvas != null)
            tutorialCanvas.SetActive(false);

        if (characterContainer != null)
            characterContainer.SetActive(false);

        if (additionalToDisable != null)
            additionalToDisable.SetActive(false);

        gameObject.SetActive(false);

    }

    public void CustomLine(DialogueLine dialogLine)
    {
        if (isTyping)
        {
            // Mostrar línea completa de inmediato
            StopAllCoroutines();
            dialogText.text = dialogLine.text;
            isTyping = false;
        }
        else
        {
            bool isChar1 = dialogLine.isCharacter1;
            StartCoroutine(TypeLine(dialogLine.text, isChar1));
        }
    }
}