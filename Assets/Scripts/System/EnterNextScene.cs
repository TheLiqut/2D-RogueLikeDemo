using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterNextScene : MonoBehaviour
{
    public string nextSceneName;
    public string playerChangeSceneCode;
    public GameObject showInfo;
    public GameObject showInfo2;
    public bool canCheck;
    [Header("需要前往Boss场景？")]
    public bool isIntoBossRoom;
    public bool isLevelFinished;

    private void Start()
    {
        Main_EventCenter.instance.onLevelFinished += CheckLevelFinished;
        //
        Player_Main.instance.inputCenter.onEnterNextScene += EnterNextSceneActMain;//InputCenter
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            UI_Manager.instance.infoMain.SetActive(true);
            Player_Main.instance.inputCenter.readyEnterNextScene = true;
            canCheck = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            UI_Manager.instance.infoMain.SetActive(false);
            showInfo2.SetActive(false);
            Player_Main.instance.inputCenter.readyEnterNextScene = false;
            canCheck = false;
        }
    }

    public void CheckLevelFinished()
    {
        isLevelFinished = true;
    }

    public void EnterNextSceneActMain()
    {
        if(canCheck == true)
        {
            if (isIntoBossRoom == false)
            {
                Player_Main.instance.transSceneCode = playerChangeSceneCode;
                SceneManager.LoadScene(nextSceneName);
            }
            else
            {
                if (isLevelFinished == true)
                {
                    Player_Main.instance.transSceneCode = playerChangeSceneCode;
                    SceneManager.LoadScene(nextSceneName);
                }
                else
                {
                    showInfo2.SetActive(true);
                    UI_Manager.instance.infoMain.SetActive(false);
                }
            }
        }
    }
}
