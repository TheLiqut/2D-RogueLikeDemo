using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Manager : MonoBehaviour
{
    public static UI_Manager instance;

    [Header("跳出提示")]
    public GameObject infoMain;
    [Header("死亡UI")]
    public GameObject deadUI;
    public bool canRestart;
    [Header("对话")]
    public GameObject charPanel_Main;
    public DialogSystem dialog_Main;
    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }
    }
    public void Start()
    {
        Main_EventCenter.instance.onPlayerDead += ShowDead;
        Player_Main.instance.inputCenter.onStartChat += StartChar;//InputCenter
        Main_EventCenter.instance.onStopChat += StopChar;
    }

    public void ShowDead()//此方法订阅玩家死亡
    {
        deadUI.SetActive(true);
        canRestart = true;
    }

    public void StartChar(TextAsset _file)
    {
        dialog_Main.textFile = _file;
        charPanel_Main.SetActive(true);
        UI_Manager.instance.infoMain.SetActive(false);
        Player_Main.instance.inputCenter.readyStartChat = false;
        //Debug.LogError("Check");
    }

    public void StopChar()//此方法订阅停止对话
    {
        charPanel_Main.SetActive(false);
    }
}
