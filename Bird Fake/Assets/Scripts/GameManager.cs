using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField]
    GameObject bird;
    [SerializeField]
    GameObject bullet;
    [SerializeField]
    GameObject block;
    [SerializeField]
    Vector3 posBlock;
    public GameObject background;
    [SerializeField]
    float cooldownBullet;
    [SerializeField]
    float cooldownBlock;
    float sizeYBlock;
    [SerializeField]
    Canvas canvas;
    [SerializeField]
    Text point, score, highScore, highPoint;
    int intPoint = 0;
    [SerializeField]
    Text endPoint, endHighPoint;
    int intHighPoint;
    [SerializeField]
    Sprite[] listBullet;
    int idBullet = 0;
    [SerializeField]
    float[] dameBullet;
    AudioSource audioS;
    [SerializeField]
    AudioClip birdDie;
    [SerializeField]
    AudioClip birdJump;
    [SerializeField]
    AudioClip bulletCreate;
    [SerializeField]
    AudioClip gameOver;
    [SerializeField]
    GameObject aminNextScene;
    [SerializeField]
    float timeDelay;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        cooldownBlock = background.GetComponent<BackgroundController>().speed;
        InvokeRepeating("SpamBullet", 1f, cooldownBullet);
        InvokeRepeating("SpamBlock", 0f, cooldownBlock);
        canvas.enabled = false;
        intHighPoint = PlayerPrefs.GetInt("intHighPoint");
        highPoint.text = intHighPoint.ToString();
        audioS = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void SpamBullet()
    {
        audioS.clip = bulletCreate;
        audioS.Play();
        if (intPoint >= 160)
        {
            idBullet = 8;
        }
        else if (intPoint >= 140)
        {
            idBullet = 7;
        }
        else if (intPoint >= 120)
        {
            idBullet = 6;
        }
        else if (intPoint >= 100)
        {
            idBullet = 5;
        }
        else if (intPoint >= 80)
        {
            idBullet = 4;
        }
        else if (intPoint >= 60)
        {
            idBullet = 3;
        }
        else if (intPoint >= 40)
        {
            idBullet = 2;
        }
        else if (intPoint >= 20)
        {
            idBullet = 1;
        }
        bullet.GetComponent<SpriteRenderer>().sprite = listBullet[idBullet];
        block.GetComponent<BlockController>().cntPlus = dameBullet[idBullet];
        Instantiate(bullet, bird.transform.position, bullet.transform.rotation);
    }
    void SpamBlock()
    {
        sizeYBlock = Random.Range(1, 4);
        Vector3 scaleBlock = block.transform.localScale;
        scaleBlock.y = sizeYBlock;
        block.transform.localScale = scaleBlock;
        Instantiate(block, new Vector3(13f, sizeYBlock / 2, 0), Quaternion.identity);
        scaleBlock.y = 5 - sizeYBlock;
        block.transform.localScale = scaleBlock;
        Instantiate(block, new Vector3(13f, sizeYBlock + (5 - sizeYBlock) / 2, 0), Quaternion.identity);

        sizeYBlock = Random.Range(1, 4);
        scaleBlock.y = sizeYBlock;
        block.transform.localScale = scaleBlock;
        Instantiate(block, new Vector3(13f, - sizeYBlock / 2, 0), Quaternion.identity);
        scaleBlock.y = 5 - sizeYBlock;
        block.transform.localScale = scaleBlock;
        Instantiate(block, new Vector3(13f, - sizeYBlock - (5 - sizeYBlock) / 2, 0), Quaternion.identity);
    }
    public void StopRespawm()
    { 
        CancelInvoke("SpamBullet");
        CancelInvoke("SpamBlock");
    }
    public void StopBackground()
    {
        background.GetComponent<BackgroundController>().speed = 0;
    }
    public void ActiveCanvas()
    {
        canvas.enabled = true;
    }
    public void Restart()
    {
        SceneManager.LoadScene("PlayGame");
    }
    public void Menu()
    {
        aminNextScene.GetComponent<NextScene>().NextSceneAmin(1, timeDelay);
    }
    public void PlusPoint(int x)
    {
        intPoint += x;
        point.text = intPoint.ToString();
        if (intPoint > int.Parse(highPoint.text))
        {
            highPoint.text = point.text;
        }
    }
    public void EndPlusPoint()
    {
        endPoint.text = point.text;
        endHighPoint.text = highPoint.text;  
        intHighPoint = int.Parse(highPoint.text);
        PlayerPrefs.SetInt("intHighPoint", intHighPoint);
    }
    public void StopScore()
    {
        score.enabled = false;
        point.enabled = false;
        highScore.enabled = false;
        highPoint.enabled = false;
    }
    public void AudioBirdDie()
    {
        audioS.clip = birdDie;
        audioS.Play();
    }
    public void AudioBirdJump()
    {
        audioS.clip = birdJump;
        audioS.Play();
    }
    public void AudioGameOver()
    {
        background.GetComponent<AudioSource>().clip = gameOver;
        background.GetComponent<AudioSource>().Play();
    }
}
