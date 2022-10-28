using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "aPlayer", menuName = "Player_Data")]

public class Player_Data : ScriptableObject
{
    [Header("角色名字")]
    public List<string> playerName = new List<string>();
    [Header("角色数值")]
    public float playerHp;
    public float speed;
}
