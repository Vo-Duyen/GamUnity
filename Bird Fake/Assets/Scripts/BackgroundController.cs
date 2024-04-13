using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    public float speed;
    Vector3 pos = new Vector3(18.5f, 0, 0);
    // Start is called before the first frame update
    void Start()
    {
        transform.position = pos;
    }

    // Update is called once per frame
    void Update()
    {
        moveBackground();
    }
    void moveBackground()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
        if (transform.position.x <= - 9)
        {
            transform.position = pos;
        }
    }
}
