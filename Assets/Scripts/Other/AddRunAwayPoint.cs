using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRunAwayPoint : MonoBehaviour
{
    public GameObject self;
    private bool started;
    public bool muted;
    //public bool actived;

    private void Update()
    {
        if(started == false)
        {
            started = true;
            Main_EventCenter.instance.E_OnEnemyRunAwayTransUpdate(self);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyRunAwayPoint_Mute"))
        {
            //Debug.LogError("已进入");
            muted = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyRunAwayPoint_Mute"))
        {
            //Debug.LogError("已离开");
            muted = false;
        }
    }
}
