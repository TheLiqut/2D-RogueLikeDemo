using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class Action_Enemy_Hurt : Action
{
    public SharedGameObject theEnemyObject;
    private Enemy_Main_BD enemy;

    public override void OnStart()
    {
        enemy = theEnemyObject.Value.GetComponent<Enemy_Main_BD>();
        enemy.onFinishHurtAN += HurtAnFinished;
        enemy.targetFinder.canMove = false;
    }

    public override TaskStatus OnUpdate()
    {
        if(enemy.theHp <= 0)
        {
            return TaskStatus.Success;
        }

        enemy.theAn.Play("Hurt" + enemy.enemyData.enemySelfID);
        
        if(enemy.enemyHurting == false)
        {
            enemy.onFinishHurtAN -= HurtAnFinished;
            enemy.targetFinder.canMove = true;
            return TaskStatus.Failure;
        }
        return TaskStatus.Running;
    }

    public void HurtAnFinished()
    {
        enemy.tracker.enabled = true;
        enemy.attacker.enabled = true;
        enemy.enemyHurting = false;
    }
}
