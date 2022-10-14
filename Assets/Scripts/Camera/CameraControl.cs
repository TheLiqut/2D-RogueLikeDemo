using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Cinemachine.CinemachineVirtualCamera CineMain;

    void Start()
    {
        CineMain.Follow = Player_Main.instance.transform;
        CineMain.LookAt = Player_Main.instance.transform;
    }
}
