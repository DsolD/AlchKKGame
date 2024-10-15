using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{

    public Button StartGame;
    public Button ContinueGame;
    public Button Setting;
    public Button Quit;
    public Button NextSceneCraft;
    public Button NextSceneSold;
    public Button NextSceneTopDown;
    public Button NextSceneTutorial;

    private void Awake()
    {

        Debug.Log("Good");
        Information.LoadData();

    }


    void Start()
    {

        StartGame.onClick.AddListener(SceneStartGame);
        ContinueGame.onClick.AddListener(SceneContinueGame);
        Setting.onClick.AddListener(SceneSetting);
        Quit.onClick.AddListener(SceneQuit);
        NextSceneCraft.onClick.AddListener(SceneNextCraft);
        NextSceneSold.onClick.AddListener(SceneNextSold);
        NextSceneTopDown.onClick.AddListener(SceneNextTopDown);
        NextSceneTutorial.onClick.AddListener(SceneNextTutorial);

    }


    void Update()
    {
        
    }


    private void SceneStartGame()
    {

    }

    private void SceneContinueGame()
    {

    }

    private void SceneSetting()
    {

    }

    private void SceneQuit()
    {

    }

    private void SceneNextCraft()
    {
        SceneManager.LoadScene("Crafting");
    }

    private void SceneNextSold()
    {
        SceneManager.LoadScene("Sold");
    }

    private void SceneNextTopDown()
    {
        SceneManager.LoadScene("TopDown");
    }

    private void SceneNextTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }





}
