using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    [SerializeField]
    Animator animNextScene;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void NextSceneAmin(int idScene, float timeDelay)
    {
        StartCoroutine(LoadNextLevel(idScene, timeDelay));
    }
    IEnumerator LoadNextLevel(int idScene, float timeDelay)
    {
        animNextScene.SetTrigger("Next");
        yield return new WaitForSeconds(timeDelay);
        SceneManager.LoadScene(idScene);
    }
}
