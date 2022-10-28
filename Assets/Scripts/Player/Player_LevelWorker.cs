using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_LevelWorker : MonoBehaviour
{
    public Player_Main player;
    private bool started;

    void Update()
    {
        if(started == false)
        {
            //player.theHp += player.theLevel_Hp;
            //Main_EventCenter.instance.E_OnGetPlayerCurrentHp(player.theHp);
            //started = true;
        }
    }
}
