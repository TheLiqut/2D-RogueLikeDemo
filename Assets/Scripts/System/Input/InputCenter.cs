using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InputCenter : MonoBehaviour
{
    public TextAsset takingTextAsset;
    //==========

    public bool readyStartChat;
    public event Action<TextAsset> onStartChat;
    //
    public bool readyStartHeal;
    public event Action onStartHeal;
    //
    public bool readyChangePlayerSpeState;
    public event Action onChangePlayerSpeState;
    //
    public bool readyEnterNextScene;
    public event Action onEnterNextScene;
    //
    public bool readyCheckWeapen;
    public event Action onCheckWeapen;

    private void Update()
    {
        SendInputCommand();
    }

    public void SendInputCommand()
    {
        if(Check_ButtonDown() && readyStartChat == true)
        {
            E_OnStartChat(takingTextAsset);
            readyStartChat = false;
            return;
        }

        if (Check_ButtonDown() && readyStartHeal == true)
        {
            E_OnStartHeal();
            readyStartHeal = false;
            return;
        }

        if (Check_ButtonDown() && readyChangePlayerSpeState == true)
        {
            E_OnChangePlayerSpeState();
            readyChangePlayerSpeState = false;
            return;
        }

        if (Check_ButtonDown() && readyEnterNextScene == true)
        {
            E_OnEnterNextScene();
            readyEnterNextScene = false;
            return;
        }

        if (Check_ButtonDown() && readyCheckWeapen == true)
        {
            E_OnCheckWeapen();
            readyCheckWeapen = false;
            return;
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

    //============================================

    public void E_OnStartChat(TextAsset _file)//开始对话事件通知
    {
        if (onStartChat != null)
        {
            onStartChat(_file);
        }
    }

    public void E_OnStartHeal()//开始治疗事件通知
    {
        if (onStartHeal != null)
        {
            onStartHeal();
        }
    }

    public void E_OnChangePlayerSpeState()//开始切换玩家的特殊状态
    {
        if (onChangePlayerSpeState != null)
        {
            onChangePlayerSpeState();
        }
    }

    public void E_OnEnterNextScene()//开始切换场景
    {
        if (onEnterNextScene != null)
        {
            onEnterNextScene();
        }
    }

    public void E_OnCheckWeapen()//开始切换武器
    {
        if (onCheckWeapen != null)
        {
            onCheckWeapen();
        }
    }
}
