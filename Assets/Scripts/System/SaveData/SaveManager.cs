using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveManager : MonoBehaviour
{
    public Player_Main player;

    //保存文件
    public void Saver()
    {
        PlayerPrefs.SetInt("PlayerEX", player.playerEx);
        //PlayerPrefs.SetFloat("PlayerHP_Level", player.theLevel_Hp);
    }
    //读取
    public void Loader()
    {
        player.playerEx = PlayerPrefs.GetInt("PlayerEX");
        //player.theHp = (player.theHp += PlayerPrefs.GetFloat("PlayerHP_Level"));
    }
}
