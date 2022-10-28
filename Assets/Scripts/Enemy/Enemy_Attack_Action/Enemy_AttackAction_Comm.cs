using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_AttackAction_Comm : Enemy_AttackAction_Base
{
    public override void OnAction(Enemy_Main_BD enemy_)//Comm-普通的播放攻击动画
    {
        enemy_.theAn.Play("Attack" + enemy_.enemyData.enemySelfID);
    }
}
