using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TempRespaw : MonoBehaviour
{
    public string RespawSceneName;

    public void AN_RespawScene()
    {
        SceneManager.LoadScene("BaseScene");
    }
    public void AN_ResetPlayer()
    {
        Player_Main.instance.theHp = Player_Main.instance.playerData.playerHp;
        Player_Main.instance.transform.position = new Vector3(0, 0, 0);
        Player_Main.instance.theAn.Play("Idel" + Player_Main.instance.selfID.ToString());
        Main_EventCenter.instance.E_OnGetPlayerCurrentHp(Player_Main.instance.theHp);
    }
}
