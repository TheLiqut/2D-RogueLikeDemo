using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_AttackAction_Summon : Enemy_AttackAction_Base
{
    public override void OnAction(Enemy_Main_BD enemy_)//Summon-召唤物体
    {
        GameObject.Instantiate(enemy_.enemyData.linkObject[0], enemy_.gameObject.transform.position, Quaternion.identity);
        enemy_.AN_Event_FinishAttackAction();
    }
}
