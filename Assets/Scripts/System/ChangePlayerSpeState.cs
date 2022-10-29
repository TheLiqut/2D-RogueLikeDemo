using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePlayerSpeState : MonoBehaviour
{
    private bool canCheck;
    public TextAsset thisSpeStateNameFile;
    [Header("切换的特殊状态")]
    public SpeState speState;
    public enum SpeState
    {
        none,
        killHeal,
        AutoHeal
    };
    private void Start()
    {
        Player_Main.instance.inputCenter.onChangePlayerSpeState += ChangePlayerSpeStateActMain;//InputCenter
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canCheck = true;
            Player_Main.instance.inputCenter.readyChangePlayerSpeState = true;
            UI_Manager.instance.infoMain.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canCheck = false;
            Player_Main.instance.inputCenter.readyChangePlayerSpeState = false;
            UI_Manager.instance.infoMain.SetActive(false);
        }
    }

    public void ChangePlayerSpeStateActMain()
    {
        if(canCheck == true)
        {
            switch (speState)
            {
                case SpeState.none:
                    Global_GameManager.instance.speStateForPlayer = 0;
                    Global_GameManager.instance.speStateForPlayer_Now = GetSpeStateName();
                    canCheck = false;
                    UI_Manager.instance.infoMain.SetActive(false);
                    break;
                case SpeState.killHeal:
                    Global_GameManager.instance.speStateForPlayer = 1;
                    Global_GameManager.instance.speStateForPlayer_Now = GetSpeStateName();
                    canCheck = false;
                    UI_Manager.instance.infoMain.SetActive(false);
                    break;
                case SpeState.AutoHeal:
                    Global_GameManager.instance.speStateForPlayer = 2;
                    Global_GameManager.instance.speStateForPlayer_Now = GetSpeStateName();
                    canCheck = false;
                    UI_Manager.instance.infoMain.SetActive(false);
                    break;
                default:
                    break;
            }
        }
    }

    public string GetSpeStateName()
    {
        var tempDate = thisSpeStateNameFile.text.Split('\n');
        string outString = tempDate[Global_GameManager.instance.usingLanguage];
        return outString;
    }
}
