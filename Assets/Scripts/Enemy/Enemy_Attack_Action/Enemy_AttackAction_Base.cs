using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy_AttackAction_Base : MonoBehaviour
{
    public abstract void OnAction(Enemy_Main_BD enemy_);
}
