using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss_UI : MonoBehaviour
{
    public Enemy_Main_BD enemy;
    public Image fillImg;
    public float theFillNum;

    public bool started;

    private void Start()
    {
        
    }
    private void Update()
    {
        if(started == false)
        {
            started = true;
            theFillNum = 1 / enemy.theHp;
        }
        fillImg.fillAmount = enemy.theHp * theFillNum;
    }
}
