using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Dodge_Tracker : MonoBehaviour
{
    public Enemy_Main_BD enemy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player_Attack") == true)
        {
            if(enemy.enemyData.enemyCanDodge == true)
            {
                enemy.Event_DodgePlayerAttack();
            }
        }
    }
}
