using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class MenuBirdController : MonoBehaviour
{
    public AnimatorController[] listAnimatorControllers;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Animator>().runtimeAnimatorController = listAnimatorControllers[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void setAnimatorController(int id)
    { 
        GetComponent<Animator>().runtimeAnimatorController = listAnimatorControllers[id];
    }
}
