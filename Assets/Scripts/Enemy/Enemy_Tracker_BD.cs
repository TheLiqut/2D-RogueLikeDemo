using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Tracker_BD : MonoBehaviour
{
    public Enemy_Main_BD enemyMain;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            enemyMain.tracking = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            enemyMain.tracking = false;
        }
    }
}
