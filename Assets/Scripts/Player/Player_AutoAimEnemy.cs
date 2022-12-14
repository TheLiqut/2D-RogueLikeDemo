using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_AutoAimEnemy : MonoBehaviour
{
    private Player_Main player;

    private void Start()
    {
        player = Player_Main.instance;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            if (collision.GetComponent<Enemy_Main_BD>().theHp > 0)
            {
                player.targetEnemy = collision.gameObject;
            }
        }
    }
}
