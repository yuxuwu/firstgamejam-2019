using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{

    [SerializeField] Animator transitionAnim;
    [SerializeField] float secondsBetweenTransition = 1.5f;

    public void LoadTeaMinigame()
    {
        StartCoroutine(_LoadTeaScene());
    }

    private IEnumerator _LoadTeaScene()
    {
        transitionAnim.SetTrigger("start");
        yield return new WaitForSeconds(secondsBetweenTransition);
        SceneManager.LoadScene("TeaMinigame", LoadSceneMode.Additive);
        transitionAnim.SetTrigger("end");
    }

    public void UnloadTeaMinigame()
    {

    }
}
