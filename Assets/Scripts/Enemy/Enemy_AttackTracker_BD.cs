using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_AttackTracker_BD : MonoBehaviour
{
    public Enemy_Main_BD enemyMain;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            enemyMain.attacking = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            enemyMain.attacking = false;
        }
    }
}
