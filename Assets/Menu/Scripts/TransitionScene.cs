using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionScene : MonoBehaviour
{
    [SerializeField] private AnimationClip finalAnim;
    private Animator animator;
    private bool isChangingScene = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Puedes llamar a este método cuando quieras iniciar la transición
    public void StartSceneTransition()
    {
        if (!isChangingScene)
        {
            isChangingScene = true;
            StartCoroutine(ChangeScene());
        }
    }
    IEnumerator ChangeScene()
    {
        animator.SetTrigger("Triggersito");
        yield return new WaitForSeconds(finalAnim.length);
        SceneManager.LoadScene("TutorialLevel");
    }
}
