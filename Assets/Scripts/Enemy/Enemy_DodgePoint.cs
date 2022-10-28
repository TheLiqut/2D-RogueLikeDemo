using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_DodgePoint : MonoBehaviour
{
    public bool canNotDodgeHere;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Grid") || collision.CompareTag("Blocker"))
        {
            canNotDodgeHere = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Grid") || collision.CompareTag("Blocker"))
        {
            canNotDodgeHere = false;
        }
    }
}
