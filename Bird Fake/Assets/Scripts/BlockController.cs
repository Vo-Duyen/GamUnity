using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    float speedBlock;
    [SerializeField]
    Sprite[] listTypeBlock;
    [SerializeField]
    UnityEditor.Animations.AnimatorController[] listAnimatorController;
    [SerializeField]
    Animator animator;
    int id;
    float hp, cnt = 0;
    public float cntPlus = 0.75f;
    [SerializeField]
    float[] listHP;
    [SerializeField]
    AudioClip[] lisAudioBlock;
    AudioSource audioS;
    // Start is called before the first frame update
    void Start()
    {
        id = Random.Range(0, listTypeBlock.Length);
        GetComponent<SpriteRenderer>().sprite = listTypeBlock[id];
        GetComponent<Animator>().runtimeAnimatorController = listAnimatorController[id];
        hp = listHP[id];
        audioS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        moveBlock();
    }
    void moveBlock()
    {
        speedBlock = GameManager.instance.background.GetComponent<BackgroundController>().speed;
        transform.Translate(Vector3.left * speedBlock * Time.deltaTime);
        if (transform.position.x < - 9)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            audioS.clip = lisAudioBlock[id];
            audioS.Play();
            Destroy(collision.gameObject);
            cnt += cntPlus;
            animator.SetFloat("cnt", cnt / hp);
        }
        if (hp - cnt <= 0)
        {
            GameManager.instance.PlusPoint(id + 3);
            Destroy(gameObject);
        }
    }
}
