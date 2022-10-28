using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_UI : MonoBehaviour
{
    private Player_Main player;
    public Text showHpText;
    public Text showExText;
    public Text showWpText;
    public Text showSpeText;
    public bool fighting;

    private void Start()
    {
        Main_EventCenter.instance.onGetPlayerCurrentHp += TakePlayerHp;
        Main_EventCenter.instance.onGetPlayerCurrentEX += TakePlayerEX;
        Main_EventCenter.instance.onGetPlayerCurrentWeapenName += TakePlayerWP_Name;

        Main_EventCenter.instance.E_OnGetPlayerCurrentHp(Player_Main.instance.theHp);
        Main_EventCenter.instance.E_OnGetPlayerCurrentEX(Player_Main.instance.playerEx);
        Main_EventCenter.instance.E_OnGetPlayerCurrentWpName(Player_Main.instance.usingWeapenName);
    }
    private void FixedUpdate()
    {
        showSpeText.text = Global_GameManager.instance.speStateForPlayer_Now;
    }

    private void TakePlayerHp(float _f)
    {
        showHpText.text = _f.ToString();
    }

    private void TakePlayerEX(int _i)
    {
        showExText.text = _i.ToString();
    }

    private void TakePlayerWP_Name(string _s)
    {
        showWpText.text = _s;
    }
}
