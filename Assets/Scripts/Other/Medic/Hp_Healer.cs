using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hp_Healer : MonoBehaviour
{
    public float healNum;
    private bool canCheck;

    private void Start()
    {
        Player_Main.instance.inputCenter.onStartHeal += HealActMain;//InputCenter
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            UI_Manager.instance.infoMain.SetActive(true);
            Player_Main.instance.inputCenter.readyStartHeal = true;
            canCheck = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            UI_Manager.instance.infoMain.SetActive(false);
            Player_Main.instance.inputCenter.readyStartHeal = false;
            canCheck = false;
        }
    }

    public void HealActMain()
    {
        if(canCheck == true)
        {
            //调整player数值并停用此object
            Player_Main.instance.theHp += healNum;
            if (Player_Main.instance.theHp > Player_Main.instance.playerData.playerHp)
            {
                Player_Main.instance.theHp = Player_Main.instance.playerData.playerHp;
            }
            UI_Manager.instance.infoMain.SetActive(false);
            this.gameObject.SetActive(false);
        }
    }
}
