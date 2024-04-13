using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField]
    float speed;
    [SerializeField]
    float maxY;
    [SerializeField]
    AnimatorController[] listAnimatorController;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Animator>().runtimeAnimatorController = listAnimatorController[PlayerPrefs.GetInt("idAnimatorController")];
        rb = GetComponent<Rigidbody2D>();
        transform.position = new Vector3(- 5.5f, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        moveBird();
    }
    void moveBird()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            GameManager.instance.AudioBirdJump();
            rb.velocity = new Vector2(0, speed);
        }
        Vector3 pos = transform.position;
        pos.y = Mathf.Clamp(pos.y, -maxY - 10f, maxY);
        transform.position = pos;
        if (pos.x < - 8.1 || pos.y <= - maxY)
        {
            GameManager.instance.StopRespawm();
            GameManager.instance.StopBackground();
            GameManager.instance.ActiveCanvas();
            GameManager.instance.StopScore();
            GameManager.instance.EndPlusPoint();
            GameManager.instance.AudioBirdDie();
            GameManager.instance.AudioGameOver();
            Destroy(gameObject);
        }
    }
}
