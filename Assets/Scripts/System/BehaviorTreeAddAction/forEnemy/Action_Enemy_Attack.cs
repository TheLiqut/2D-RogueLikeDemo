using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class Action_Enemy_Attack : Action
{
    public SharedGameObject theEnemyObject;
    private Enemy_Main_BD enemy;

    private int currentAtkID;
    private int allAtkNum;

    private float AtkAnConDelay;

    public override void OnStart()
    {
        enemy = theEnemyObject.Value.GetComponent<Enemy_Main_BD>();
        enemy.targetFinder.maxSpeed = 0;
        allAtkNum = enemy.enemyData.enemyAtkAction.Count;
        enemy.onFinishAttackAction += AtkActionFinished;
        enemy.tracker.enabled = true;
        enemy.attacker.enabled = true;
        //currentAtkID = 0;

        enemy.attacker.radius = (enemy.enemyData.attackRange * 1.5f);

    }

    public override TaskStatus OnUpdate()
    {
        enemy.enemyData.enemyAtkAction[currentAtkID].OnAction(enemy);

        if (enemy.attacking == false && enemy.attackingAnPlaying == false)
        {
            enemy.attacker.radius = enemy.enemyData.attackRange;
            enemy.onFinishAttackAction -= AtkActionFinished;
            return TaskStatus.Failure;
        }

        if(enemy.enemyHurting == true)
        {
            enemy.attacker.radius = enemy.enemyData.attackRange;
            enemy.onFinishAttackAction -= AtkActionFinished;
            return TaskStatus.Failure;
        }

        if (enemy.isLowHp == true || enemy.isPlayerGetClose == true)
        {
            enemy.onFinishAttackAction -= AtkActionFinished;
            return TaskStatus.Failure;
        }

        FaceToPlayer();

        return TaskStatus.Running;
    }

    private void AtkActionFinished()
    {

        if(currentAtkID < (allAtkNum-1))
        {
            currentAtkID += 1;
            Debug.LogError("+1");
            return;
        }
        if(currentAtkID == (allAtkNum-1))
        {
            currentAtkID = 0;
            return;
        }
    }

    public void FaceToPlayer()
    {
        if (transform.position.x < Player_Main.instance.gameObject.transform.position.x)
        {
            enemy.thisEnemySprite.flipX = false;
        }
        if (transform.position.x > Player_Main.instance.gameObject.transform.position.x)
        {
            enemy.thisEnemySprite.flipX = true;
        }
    }
}