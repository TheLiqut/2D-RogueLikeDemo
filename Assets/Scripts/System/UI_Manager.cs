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
        Main_EventCenter.instance.onStartChat += StartChar;
        Main_EventCenter.instance.onStopChat += StopChar;
    }

    public void ShowDead()//订阅玩家死亡
    {
        deadUI.SetActive(true);
        canRestart = true;
    }

    public void OpenChar(TextAsset _file)//通知弹出对话
    {
        Main_EventCenter.instance.E_OnStartChat(_file);
        Player_Main.instance.inputCenter.CheckStateChange(InputCenter.CheckState.inChating);
    }
    public void StartChar(TextAsset _file)//订阅弹出对话
    {
        dialog_Main.textFile = _file;
        charPanel_Main.SetActive(true);
    }

    public void StopChar()//订阅停止对话
    {
        charPanel_Main.SetActive(false);
    }
}
