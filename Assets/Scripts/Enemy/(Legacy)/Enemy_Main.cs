using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Main : Humanoid,ITakingDamage
{
    [Header("敌人数据")]
    public Enemy_Data enemyData;
    public Player_Main player;
    public float speed;
    public Transform targetTrans;
    public GameObject enemyShowUpEffect;
    public Rigidbody2D theRB;
    public bool traking;
    public bool atking;
    public bool canNotRotate;
    public bool antiTraking;
    public bool hurting;
    public bool isDead;
    public bool isWin;
    public int givePlayerExMin;
    public SpriteRenderer enemyImageBody;
    public bool canNotIntoHurtState;
    public LayerMask seekPlayerBlockLayer;
    [Header("FSM")]
    private FSM_Controller fsm;
    private StateType stateType;
    public string currentStateShow;
    [Header("死亡后启用")]
    public List<GameObject> deathActive = new List<GameObject>();

    private void Awake()
    {
        fsm = new FSM_Controller();
        fsm.AddState(StateType.IDEL, new State_Idel(theAn,this,this.fsm));
        fsm.AddState(StateType.MOVE, new State_Move(theAn,this, this.fsm));
        fsm.AddState(StateType.ATK, new State_Attack(theAn, this, this.fsm));
        fsm.AddState(StateType.HURT, new State_Hurt(theAn,this, this.fsm));
        fsm.AddState(StateType.DEAD, new State_Death(theAn,this, this.fsm));

        fsm.SetState(StateType.IDEL);
    }
    void Start()
    {
        Main_EventCenter.instance.onPlayerDead += EnemyWin;
        player = Player_Main.instance;
        theRB = gameObject.GetComponent<Rigidbody2D>();
        targetTrans = player.transform;
        Instantiate(enemyShowUpEffect, transform.localPosition, Quaternion.identity);
    }

    private void FixedUpdate()
    {
        fsm.OnStateStay();
    }
    void Update()
    {
        enemyImageBody.sortingOrder = -(int)transform.localPosition.y;
    }

    public void FaceToPlayer()//面向玩家
    {
        if (transform.position.x < targetTrans.gameObject.transform.position.x)
        {
            if (canNotRotate != true)
            {
                transform.localScale = new Vector3(2, 2, 2);
            }

        }
        if (transform.position.x > targetTrans.gameObject.transform.position.x)
        {
            if (canNotRotate != true)
            {
                transform.localScale = new Vector3(-2, 2, 2);
            }
        }
    }

    public void TakeDamage(float _f)//承受伤害
    {
        if(isDead == false)
        {
            theHp -= _f;
            if(canNotIntoHurtState == false)
            {
                fsm.SetState(StateType.HURT);
            }

            if(theHp <= 0)
            {
                fsm.SetState(StateType.DEAD);
            }
        }
    }

    public void AN_to_Idel_State()//动画中调用-前往静止状态
    {
        fsm.SetState(StateType.IDEL);
    }

    public void AN_to_Move_State()//动画中调用-前往移动状态
    {
        fsm.SetState(StateType.MOVE);
    }

    public void AN_DeathEvent()//敌人死亡
    {
        Main_EventCenter.instance.E_OnEnemyDead();
    }

    public void EnemyWin()//敌人胜利后
    {
        if(isDead == false)
        {
            isWin = true;
            fsm.SetState(StateType.IDEL);
        }
    }
}