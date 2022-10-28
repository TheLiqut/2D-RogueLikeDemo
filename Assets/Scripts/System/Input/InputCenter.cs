using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InputCenter : MonoBehaviour
{
    public TextAsset takingTextAsset;
    public enum CheckState
    {
        def,//0
        readyStartChat,
        readyStartHeal,
        readyChangeSpeState,
        readyEnterNextScene,
        readyGetWeapen,
        inChating,
    }
    public CheckState state;

    public void CheckStateChange(CheckState _state)//状态切换
    {
        state = _state;
    }
    private void Update()
    {
        switch (state)
        {
            case CheckState.readyStartChat:
                if (Check_ButtonDown())
                {
                    UI_Manager.instance.OpenChar(takingTextAsset);
                    UI_Manager.instance.infoMain.SetActive(false);
                }
                break;
            default:
                break;
        }
    }

    public bool Check_ButtonDown()
    {
        return Input.GetButtonDown("Check");
    }

    public bool Attack_Button()
    {
        return Input.GetButton("Attack");
    }

    public bool Attack2_ButtonDown()
    {
        return Input.GetButtonDown("Attack2");
    }
}
