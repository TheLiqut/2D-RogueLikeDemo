using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hp_Healer : MonoBehaviour
{
    public float healNum;
    public bool cancheck;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player_Main.instance.inputCenter.CheckStateChange(InputCenter.CheckState.readyStartHeal);
            UI_Manager.instance.infoMain.SetActive(true);
            cancheck = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player_Main.instance.inputCenter.CheckStateChange(InputCenter.CheckState.def);
            UI_Manager.instance.infoMain.SetActive(false);
            cancheck = false;
        }
    }

    private void Update()
    {
        if(Player_Main.instance.inputCenter.state == InputCenter.CheckState.readyStartHeal && Player_Main.instance.inputCenter.Check_ButtonDown() && cancheck == true)
        {
            //进行检查，调整player数值并停用此object
            Player_Main.instance.theHp += healNum;
            if(Player_Main.instance.theHp > Player_Main.instance.playerData.playerHp)
            {
                Player_Main.instance.theHp = Player_Main.instance.playerData.playerHp;
            }
            //Main_EventCenter.instance.E_OnGetPlayerCurrentHp(Player_Main.instance.theHp);
            UI_Manager.instance.infoMain.SetActive(false);
            this.gameObject.SetActive(false);
        }
    }
}
