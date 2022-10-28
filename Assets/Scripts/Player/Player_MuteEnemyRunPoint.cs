using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_MuteEnemyRunPoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyRunAwayPoint"))
        {
            Debug.Log("已进入");
            collision.GetComponent<AddRunAwayPoint>().muted = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyRunAwayPoint"))
        {
            Debug.Log("已离开");
            collision.GetComponent<AddRunAwayPoint>().muted = false;
        }
    }
}
