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
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player_Main.instance.inputCenter.CheckStateChange(InputCenter.CheckState.readyEnterNextScene);
            UI_Manager.instance.infoMain.SetActive(true);
            canCheck = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player_Main.instance.inputCenter.CheckStateChange(InputCenter.CheckState.def);
            UI_Manager.instance.infoMain.SetActive(false);
            showInfo2.SetActive(false);
            canCheck = false;
        }
    }

    public void CheckLevelFinished()
    {
        isLevelFinished = true;
    }

    void Update()
    {
        if (Player_Main.instance.inputCenter.state == InputCenter.CheckState.readyEnterNextScene && Player_Main.instance.inputCenter.Check_ButtonDown() && canCheck == true)
        {
            if(isIntoBossRoom == false)
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
