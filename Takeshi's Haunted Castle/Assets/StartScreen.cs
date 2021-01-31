using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{

    public Button startButton;
    public Button endButton;
    // Start is called before the first frame update
    void Start()
    {
        startButton.onClick.AddListener(loadSceneOnClick);
        endButton.onClick.AddListener(quitOnClick);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void loadSceneOnClick()
    {
        SceneManager.LoadScene("onlineScene", LoadSceneMode.Additive);
    }
    void quitOnClick()
    {
        Application.Quit();
    }
}
