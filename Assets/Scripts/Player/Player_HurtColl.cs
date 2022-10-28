using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_HurtColl : MonoBehaviour
{
    public float attackPower;
    private bool started;
    public bool isBullet;
    public GameObject hitEffect;

    private bool muteDes;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(isBullet == false)
        {
            if (collision.CompareTag("Enemy"))
            {
                collision.GetComponent<Enemy_Main_BD>().TakeDamage(attackPower);
            }
        }
        else
        {
            if (collision.CompareTag("Enemy_Dodger"))
            {
                muteDes = true;
            }

            if (collision.CompareTag("Enemy"))
            {
                collision.GetComponent<Enemy_Main_BD>().TakeDamage(attackPower);
                Instantiate(hitEffect, transform.position, Quaternion.identity);

                if(muteDes == false)
                {
                    Destroy(gameObject);
                }
            }

            if (collision.CompareTag("Grid"))
            {
                Instantiate(hitEffect, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }
}