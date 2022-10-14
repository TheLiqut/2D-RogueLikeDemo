using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TempStart : MonoBehaviour
{
    public void StartAsCN()
    {
        Global_GameManager.instance.usingLanguage = 0;
        SceneManager.LoadScene("BaseScene");
    }

    public void StartAsEN()
    {
        Global_GameManager.instance.usingLanguage = 1;
        SceneManager.LoadScene("BaseScene");
    }
}
