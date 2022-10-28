using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class Action_Enemy_Dodge : Action
{
    public SharedGameObject theEnemyObject;
    private Enemy_Main_BD enemy;
    public override void OnStart()
    {
        enemy = theEnemyObject.Value.GetComponent<Enemy_Main_BD>();
    }

    public override TaskStatus OnUpdate()
    {
        return TaskStatus.Failure;
    }
}
