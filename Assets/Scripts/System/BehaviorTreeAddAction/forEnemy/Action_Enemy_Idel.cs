using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class Action_Enemy_Idel : Action
{
    public SharedGameObject theEnemyObject;
    private Enemy_Main_BD enemy;

    public override void OnStart()
    {
        enemy = theEnemyObject.Value.GetComponent<Enemy_Main_BD>();
        if(enemy.isLowHp == false && enemy.isPlayerGetClose == false)
        {
           enemy.targetSeter.target = Player_Main.instance.transform;
        }
        
        enemy.tracker.enabled = true;
        enemy.attacker.enabled = true;
    }
    public override TaskStatus OnUpdate()
    {
        enemy.theAn.Play("Idel" + enemy.enemyData.enemySelfID);
        enemy.targetFinder.maxSpeed = 0;
        if (enemy.tracking == true)
        {
            return TaskStatus.Failure;
        }
        if(enemy.enemyHurting == true)
        {
            return TaskStatus.Failure;
        }
        return TaskStatus.Running;
    }
}
