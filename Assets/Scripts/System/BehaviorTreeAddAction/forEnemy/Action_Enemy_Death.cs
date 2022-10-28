using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class Action_Enemy_Death : Action
{
    public SharedGameObject theEnemyObject;
    private Enemy_Main_BD enemy;
    public override void OnStart()
    {
        enemy = theEnemyObject.Value.GetComponent<Enemy_Main_BD>();
        enemy.tracker.enabled = false;
        enemy.attacker.enabled = false;
        Player_Main.instance.playerEx += enemy.enemyData.DeathGivePlayerEx;
        Player_Main.instance.saver.Saver();

        int temp = Random.Range(0, enemy.enemyData.deathActiveObject_Random);
        if(temp == 0)
        {
            for (int i = 0; i < enemy.enemyData.deathActiveObject.Count; i++)
            {
                GameObject.Instantiate(enemy.enemyData.deathActiveObject[i], theEnemyObject.Value.transform.position, Quaternion.identity);
            }
        }
        //Main_EventCenter.instance.E_OnGetPlayerCurrentHp(Player_Main.instance.theHp);
        //Main_EventCenter.instance.E_OnGetPlayerCurrentEX(Player_Main.instance.playerEx);
    }
    public override TaskStatus OnUpdate()
    {
        enemy.targetFinder.canMove = false;
        enemy.theAn.Play("Dead" + enemy.enemyData.enemySelfID);
        return TaskStatus.Running;
    }
}
