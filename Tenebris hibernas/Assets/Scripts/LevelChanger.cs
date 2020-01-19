using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public Animator animator;
    private Scene cenaAtual;

    private void Start()
    {
        cenaAtual = SceneManager.GetActiveScene();
    }
    public void FadeToLevel()
    {
        animator.SetTrigger("FadeOut");
    }

    public void FadeToLevelDie()
    {
        animator.SetTrigger("FadeOutDie");
    }

    public void OnFadeComplete()
    {
        if (cenaAtual.buildIndex == 2)
            SceneManager.LoadScene("Menu");
        else
            SceneManager.LoadScene(cenaAtual.buildIndex + 1);
    }

    public void OnFadeCompleteDie()
    {
        SceneManager.LoadScene(cenaAtual.buildIndex);
    }
}
