using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class Action_Enemy_Move : Action
{
    public SharedGameObject theEnemyObject;
    private Enemy_Main_BD enemy;

    private float lastStayX;
    private float currentStayX;
    private bool goingLeft;
    private bool goingRight;
    public override void OnStart()
    {
        enemy = theEnemyObject.Value.GetComponent<Enemy_Main_BD>();
        currentStayX = theEnemyObject.Value.transform.position.x;
        enemy.tracker.enabled = true;
        enemy.attacker.enabled = true;
        enemy.onDodgePlayerAttack += AvoidPlayerAttack;
    }
    public override TaskStatus OnUpdate()
    {
        enemy.theAn.Play("Run" + enemy.enemyData.enemySelfID);
        enemy.targetFinder.maxSpeed = enemy.enemyData.speed;
        FaceToGoing();
        if (enemy.attacking == true)
        {
            enemy.onDodgePlayerAttack -= AvoidPlayerAttack;
            return TaskStatus.Success;
        }

        if (enemy.tracking == false)
        {
            enemy.onDodgePlayerAttack -= AvoidPlayerAttack;
            return TaskStatus.Failure;
        }

        if(enemy.isLowHp == true || enemy.isPlayerGetClose == true)
        {
            enemy.onDodgePlayerAttack -= AvoidPlayerAttack;
            return TaskStatus.Success;
        }
        return TaskStatus.Running;
    }

    public void FaceToGoing()
    {
        currentStayX = theEnemyObject.Value.transform.position.x;

        if(currentStayX > lastStayX)
        {
            enemy.thisEnemySprite.flipX = false;
            lastStayX = currentStayX;
        }

        if (currentStayX < lastStayX)
        {
            enemy.thisEnemySprite.flipX = true;
            lastStayX = currentStayX;
        }
    }

    public void AvoidPlayerAttack()
    {
        int temp = Random.Range(0, enemy.enemyData.enemyDodgePlayerBullet_Random);

        if(temp == 0)
        {
            bool fined = false;
            int outCanDodgePointNum = 0;
            for (int i = 0; i < enemy.dodgePoints.Count; i++)
            {
                if (enemy.dodgePoints[i].GetComponent<Enemy_DodgePoint>().canNotDodgeHere == false)
                {
                    outCanDodgePointNum += 1;
                }
            }

            if (outCanDodgePointNum == 0)
            {
                fined = true;
                return;
            }

            while (fined == false)
            {
                int randPos = Random.Range(0, enemy.dodgePoints.Count);
                if (enemy.dodgePoints[randPos].GetComponent<Enemy_DodgePoint>().canNotDodgeHere == false)
                {
                    fined = true;
                    theEnemyObject.Value.transform.position = enemy.dodgePoints[randPos].transform.position;
                }
            }
        }
    }
}
