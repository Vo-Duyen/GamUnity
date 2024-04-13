using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuGameManager : MonoBehaviour
{
    [SerializeField]
    GameObject bird;
    MenuBirdController scriptsBird;
    int id = 0;
    [SerializeField]
    AudioClip playButton;
    [SerializeField]
    AudioClip lrButton;
    AudioSource audioS;
    [SerializeField]
    GameObject nextScene;
    [SerializeField]
    float timeDelay;
    // Start is called before the first frame update
    void Start()
    {
        id = PlayerPrefs.GetInt("idAnimatorController");
        scriptsBird = bird.GetComponent<MenuBirdController>();
        scriptsBird.setAnimatorController(id);
        audioS = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void playGame()
    {
        audioS.clip = playButton;
        audioS.Play();
        PlayerPrefs.SetInt("idAnimatorController", id);
        nextScene.GetComponent<NextScene>().NextSceneAmin(2, timeDelay);
        SceneManager.LoadScene("PlayGame");
    }
    public void rightBird()
    {
        ++id;
        id %= scriptsBird.listAnimatorControllers.Length;
        scriptsBird.setAnimatorController(id);
        audioS.clip = lrButton;
        audioS.Play();
    }
    public void leftBird()
    {
        --id;
        id += scriptsBird.listAnimatorControllers.Length;
        id %= scriptsBird.listAnimatorControllers.Length;
        scriptsBird.setAnimatorController(id);
        audioS.clip = lrButton;
        audioS.Play();
    }
}
