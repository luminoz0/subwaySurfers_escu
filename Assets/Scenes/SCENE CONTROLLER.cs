using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SCENECONTROLLER : MonoBehaviour
{
 
    [SerializeField]
    
    private Animator fade;
    [SerializeField]
    
    private string fadeAnimationName;

    public void GoToScenewithFade(string sceneName)
    {
        StartCoroutine(LoadSceneAfterFade(sceneName));
    }
    
    private IEnumerator LoadSceneAfterFade(string sceneName)
    {
        fade.Play(fadeAnimationName,0,0f);
        yield return new WaitForSeconds(fade.GetCurrentAnimatorStateInfo(0).length);
        SceneManager.LoadScene(sceneName);
    }       
}
