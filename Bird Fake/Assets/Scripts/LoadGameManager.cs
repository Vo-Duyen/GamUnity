using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadGameManager : MonoBehaviour
{
    [SerializeField]
    Image yellowBar;
    [SerializeField]
    TextMeshProUGUI loadingText;
    [SerializeField]
    GameObject nextScene;
    [SerializeField]
    float timeDelay;
    // Start is called before the first frame update
    void Start()
    {
        nextScene.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        float xYellowBar = yellowBar.rectTransform.sizeDelta.x;
        xYellowBar *= 100 / 699.99f;
        xYellowBar = (int) xYellowBar;
        loadingText.text = xYellowBar.ToString() + " %";
        if (xYellowBar >= 100)
        {
            nextScene.SetActive(true);
            nextScene.GetComponent<NextScene>().NextSceneAmin(1, timeDelay);
        }
    }
}
