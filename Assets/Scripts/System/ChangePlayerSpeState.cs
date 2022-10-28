using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePlayerSpeState : MonoBehaviour
{
    public bool canCheck;
    public TextAsset thisSpeStateNameFile;
    [Header("切换的特殊状态")]
    public SpeState speState;
    public enum SpeState
    {
        none,
        killHeal,
        AutoHeal
    };


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canCheck = true;
            Player_Main.instance.inputCenter.CheckStateChange(InputCenter.CheckState.readyChangeSpeState);
            UI_Manager.instance.infoMain.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canCheck = false;
            Player_Main.instance.inputCenter.CheckStateChange(InputCenter.CheckState.def);
            UI_Manager.instance.infoMain.SetActive(false);
        }
    }

    void Update()
    {
        if (Player_Main.instance.inputCenter.state == InputCenter.CheckState.readyChangeSpeState 
            && Player_Main.instance.inputCenter.Check_ButtonDown() && canCheck == true)
        {
             //进行检查。切换状态
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
