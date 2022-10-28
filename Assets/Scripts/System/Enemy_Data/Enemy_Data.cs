using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "aEnemy", menuName = "Enemy_Data")]

public class Enemy_Data : ScriptableObject
{
    [Header("敌人ID")]
    public int enemyID;
    [Header("敌人名字")]
    public List<string> enemyName = new List<string>();
    [Header("敌人内部ID-用于匹配动画")]
    public int enemySelfID;
    [Header("敌人数值")]
    public float enemyHp;
    public float speed;
    [Header("敌人追踪与攻击范围")]
    public float trackRange;
    public float attackRange;

    [Header("行为-低血量时逃跑")]
    public bool runAwayAtLowHp;
    public float runAwayHpLine;
    [Header("行为-玩家靠近时逃跑")]
    public bool runAwayAtPlayerClose;
    public float runAwayDistance;
    //[Header("行为-循环播放敌人攻击动画")]
    //public List<string> enemyAtkAnNames = new List<string>();
    [Header("行为-循环执行敌人攻击行为")]
    public List<Enemy_AttackAction_Base> enemyAtkAction = new List<Enemy_AttackAction_Base>();
    [Header("行为-概率躲避玩家子弹(值越大概率越低)")]
    public bool enemyCanDodge;
    public int enemyDodgePlayerBullet_Random;
    [Header("行为-是远程敌人")]
    public bool isFireEnemy;
    [Header("行为-远程敌人-射击的子弹")]
    public GameObject enemyBullet;
    [Header("行为-远程敌人-射击精准度")]
    public float enemyGunSight;
    [Header("行为-远程敌人-子弹的速度")]
    public float firePower;
    [Header("行为-死亡后启用")]
    public List<GameObject> deathActiveObject = new List<GameObject>();
    [Header("行为-死亡后启用的概率(值越大概率越低)")]
    public int deathActiveObject_Random;
    [Header("行为-死亡后给予经验值")]
    public int DeathGivePlayerEx;

    [Header("其它-获取其它GameObject")]
    public List<GameObject> linkObject = new List<GameObject>();
}