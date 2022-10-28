using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Pathfinding;

public class Enemy_Main_BD : Humanoid, ITakingDamage
{
    [Header("敌人数据")]
    public Enemy_Data enemyData;
    [Header("玩家进入追踪范围")]
    public bool tracking;
    [Header("玩家进入攻击范围")]
    public bool attacking;
    public bool attackingAnPlaying;
    [Header("寻找目标")]
    public AIDestinationSetter targetSeter;
    [Header("寻路")]
    public AIPath targetFinder;
    [Header("角色图像")]
    public SpriteRenderer thisEnemySprite;
    [Header("追踪器")]
    public CircleCollider2D tracker;
    public CircleCollider2D attacker;
    [Header("正在受击")]
    public bool enemyHurting;
    [Header("闪避点")]
    public List<GameObject> dodgePoints = new List<GameObject>();
    [Header("其它")]
    public bool isLowHp;
    public bool isPlayerGetClose;
    //public bool stayAttack;

    //public event Action onFinishAttackAN;
    public event Action onFinishAttackAction;
    public event Action onFinishHurtAN;
    public event Action onDodgePlayerAttack;

    void Start()
    {
        theHp = enemyData.enemyHp;
        theAn = gameObject.GetComponent<Animator>();
        targetSeter.target = Player_Main.instance.gameObject.transform;
        selfID = enemyData.enemySelfID;

        tracker.radius = enemyData.trackRange;
        attacker.radius = enemyData.attackRange;
    }
    private void Update()
    {
        thisEnemySprite.sortingOrder = -(int)transform.localPosition.y;

        if(theHp < enemyData.runAwayHpLine && enemyData.runAwayAtLowHp == true)
        {
            isLowHp = true;
        }
        if(theHp >= enemyData.runAwayHpLine)
        {
            isLowHp = false;
        }

        GetPlayerClose();
    }
    public void TakeDamage(float _f)
    { 
            enemyHurting = true;
            tracker.enabled = false;
            attacker.enabled = false;
        theHp -= _f;
    }

    /*public void AN_Event_FinishAttack()
    {
        if(onFinishAttackAN != null)
        {
            onFinishAttackAN();
        }
    }*/

    public void AN_Event_FinishAttackAction()
    {
        if (onFinishAttackAction != null)
        {
            onFinishAttackAction();
        }
    }

    public void AN_Event_FinishHurt()
    {
        if (onFinishHurtAN != null)
        {
            onFinishHurtAN();
        }
    }

    public void AN_DeathEvent()//敌人死亡
    {
        Main_EventCenter.instance.E_OnEnemyDead();
    }

    public void Event_DodgePlayerAttack()
    {
        if (onDodgePlayerAttack != null)
        {
            onDodgePlayerAttack();
        }
    }

    public void GetPlayerClose()
    {
        if(enemyData.runAwayAtPlayerClose == true)
        {
            Vector3 src = transform.position;
            Vector3 dst = Player_Main.instance.gameObject.transform.position;
            float len = Vector3.Distance(src, dst);
            if (len < enemyData.runAwayDistance)
            {
                isPlayerGetClose = true;
            }
            else
            {
                isPlayerGetClose = false;
            }
        }
    }
}
