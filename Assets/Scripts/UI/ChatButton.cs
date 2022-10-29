using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChatButton : MonoBehaviour
{

    [Header("对话文件")]
    public List<TextAsset> textFiles = new List<TextAsset>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player_Main.instance.inputCenter.takingTextAsset = textFiles[Global_GameManager.instance.usingLanguage];
            Player_Main.instance.inputCenter.readyStartChat = true;
            UI_Manager.instance.infoMain.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            UI_Manager.instance.infoMain.SetActive(false);
            Player_Main.instance.inputCenter.readyStartChat = false;
            Main_EventCenter.instance.E_OnStopChat();
        }
    }
}
