using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField]
    float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveBullet();
    }
    void moveBullet()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
        if (transform.position.x > 9.5)
        {
            Destroy(gameObject);
        }
    }
}
