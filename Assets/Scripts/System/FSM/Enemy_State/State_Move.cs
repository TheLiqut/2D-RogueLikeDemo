using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_Move : State_Base
{
    private Animator animator;
    private Enemy_Main enemy;
    private FSM_Controller fsm;

    //追踪
    public GameObject targetPlayer;
    private Vector2 attackTarget;
    private bool SeekBlocked;

    public State_Move(Animator _animator, Enemy_Main _enemy, FSM_Controller _fsm)
    {
        this.animator = _animator;
        this.enemy = _enemy;
        this.fsm = _fsm;
    }

    public override void OnEnter()
    {
        targetPlayer = Player_Main.instance.aimPointForEnemy;
        enemy.currentStateShow = "移动";
    }

    public override void OnExit()
    {
        
    }

    public override void OnStay()
    {
            RaycastHit2D CheckRay = CreateRaycast(TrackPlayer(), 1.5f, enemy.seekPlayerBlockLayer);
            SeekBlocked = CheckRay;

            if(SeekBlocked == false)
            {
                enemy.FaceToPlayer();
                animator.Play("Run" + enemy.selfID.ToString());
                enemy.currentStateShow = "移动";
                enemy.transform.localPosition = Vector3.MoveTowards(enemy.transform.localPosition, enemy.targetTrans.position, enemy.speed * Time.deltaTime);
            }
            else
            {
                fsm.SetState(StateType.IDEL);
            }


        if(enemy.isWin == true)
        {
            fsm.SetState(StateType.IDEL);
            return;
        }
        if (enemy.theHp <= 0)
        {
            fsm.SetState(StateType.DEAD);
            return;
        }
        if(enemy.atking == true && SeekBlocked == false)
        {
            fsm.SetState(StateType.ATK);
            return;
        }
        if(enemy.traking == false)
        {
            fsm.SetState(StateType.IDEL);
            return;
        }
    }

    public Vector2 TrackPlayer()
    {
        attackTarget.x = targetPlayer.transform.position.x;
        attackTarget.y = targetPlayer.transform.position.y;
        Vector2 lookDir = attackTarget - (Vector2)enemy.gameObject.transform.position;
        lookDir = lookDir.normalized;
        return lookDir;
    }

    public RaycastHit2D CreateRaycast(Vector2 _diraction, float _length, LayerMask _layer)
    {
        Vector2 enemy_Vector2 = new Vector2(enemy.transform.position.x, enemy.transform.position.y);
        RaycastHit2D hit = Physics2D.Raycast(enemy_Vector2, _diraction, _length, _layer);
        Color rayColor = hit ? Color.red : Color.green;
        Debug.DrawRay(enemy_Vector2, _diraction * _length, rayColor);
        return hit;
    }
}
