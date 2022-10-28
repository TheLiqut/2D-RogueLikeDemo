using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class Action_Enemy_RunAway : Action
{
    public SharedGameObject theEnemyObject;
    private Enemy_Main_BD enemy;

    private float lastStayX;
    private float currentStayX;
    private bool goingLeft;
    private bool goingRight;

    private bool newTargetGeted;
    private GameObject theNewTarget;

    public override void OnStart()
    {
        enemy = theEnemyObject.Value.GetComponent<Enemy_Main_BD>();
        currentStayX = theEnemyObject.Value.transform.position.x;
        //enemy.tracker.enabled = false;
        //enemy.attacker.enabled = false;
    }

    public override TaskStatus OnUpdate()
    {
        enemy.theAn.Play("Run" + enemy.enemyData.enemySelfID);
        enemy.targetFinder.maxSpeed = enemy.enemyData.speed;

        if (enemy.enemyHurting == true)
        {
            return TaskStatus.Failure;
        }

        if(enemy.isLowHp == false && enemy.enemyData.runAwayAtPlayerClose == false)
        {
            return TaskStatus.Failure;
        }

        if(enemy.attacking == false && enemy.enemyData.runAwayAtPlayerClose == true 
            && enemy.isPlayerGetClose == false && enemy.isLowHp == false)
        {
            newTargetGeted = false;
            return TaskStatus.Failure;
        }

        if(newTargetGeted == true)
        {
            Vector3 src = theEnemyObject.Value.transform.position;
            Vector3 dst = theNewTarget.transform.position;
            float len = Vector3.Distance(src, dst);
            if (len < 0.5f)
            {
                newTargetGeted = false;
                return TaskStatus.Failure;
            }
        }

        if(enemy.isPlayerGetClose == true && enemy.targetSeter.target == Player_Main.instance.transform)
        {
            newTargetGeted = false;
        }

        //=====

        if(newTargetGeted == false)
        {
            enemy.targetSeter.target = GetRunAwayPoint();
        }
        if(newTargetGeted == true)
        {
            if(theNewTarget.GetComponent<AddRunAwayPoint>().muted == true)
            {
                //theNewTarget.GetComponent<AddRunAwayPoint>().actived = false;
                newTargetGeted = false;
            }
        }

        FaceToGoing();
        return TaskStatus.Running;
    }

    public Transform GetRunAwayPoint()
    {
        for (int i = 0; i < GameManager.instance.enemyRunAwayPointList.Count; i++)
        {
            int temp = Random.Range(0, GameManager.instance.enemyRunAwayPointList.Count);
            if(GameManager.instance.enemyRunAwayPointList[temp].GetComponent<AddRunAwayPoint>().muted == false)
            {
                theNewTarget = GameManager.instance.enemyRunAwayPointList[temp];
                //theNewTarget.GetComponent<AddRunAwayPoint>().actived = true;
                newTargetGeted = true;
                return GameManager.instance.enemyRunAwayPointList[temp].transform;
            }
        }
        return Player_Main.instance.transform;
    }
    public void FaceToGoing()
    {
        currentStayX = theEnemyObject.Value.transform.position.x;

        if (currentStayX > lastStayX)
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
}
