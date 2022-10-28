using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Weapen_Checker : MonoBehaviour
{
    public SaveManager_WeapenList w_Saver;
    public Weapen_Data weapenData;
    public int thisWeapenID;
    public bool checking;
    public bool unLocked;

    public GameObject showInfo;
    public Text nameText;
    public Text infoText;
    public Text priceText;
    public GameObject buyedText;

    void Start()
    {
        CheckAndLoadSaveFile();
        GetWeapenName();
        GetWeapenInfo();

        priceText.text = weapenData.weapList[thisWeapenID]._weapenPrice.ToString();
        unLocked = weapenData.weapList[thisWeapenID]._unLocked;
        buyedText.SetActive(weapenData.weapList[thisWeapenID]._unLocked);
    }


    void Update()
    {
        if(checking == true && Player_Main.instance.inputCenter.Check_ButtonDown() 
            && Player_Main.instance.inputCenter.state == InputCenter.CheckState.readyGetWeapen)
        {
            if(unLocked == true)
            {
                EquipWeapons();
            }
            else
            {
                TryUnlockWeapen();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            checking = true;
            Player_Main.instance.inputCenter.CheckStateChange(InputCenter.CheckState.readyGetWeapen);
            showInfo.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            checking = false;
            Player_Main.instance.inputCenter.CheckStateChange(InputCenter.CheckState.def);
            showInfo.SetActive(false);
        }
    }

    public void TryUnlockWeapen()
    {
        if(Player_Main.instance.playerEx >= weapenData.weapList[thisWeapenID]._weapenPrice)
        {
            Player_Main.instance.playerEx -= weapenData.weapList[thisWeapenID]._weapenPrice;
            Player_Main.instance.saver.Saver();
            weapenData.weapList[thisWeapenID]._unLocked = true;
            unLocked = true;
            w_Saver.SaveWeapenList();
            buyedText.SetActive(weapenData.weapList[thisWeapenID]._unLocked);
            EquipWeapons();
        }
        else
        {
            return;
        }
    }

    public void EquipWeapons()
    {
        //Player_Main.instance.shooter.playerBullet = Resources.Load<GameObject>("PreFab/playerBullet/" + thisWeapenID);
        Player_Main.instance.shooter.playerBullet = weapenData.weapList[thisWeapenID]._bullet;
        Player_Main.instance.shooter.gunSight = weapenData.weapList[thisWeapenID]._gunSight;
        Player_Main.instance.shooter.firePower = weapenData.weapList[thisWeapenID]._firePower;
        Player_Main.instance.shooter.FireRat = weapenData.weapList[thisWeapenID]._FireRat;
        Player_Main.instance.shooter.sourceFireRat = weapenData.weapList[thisWeapenID]._FireRat;
        Player_Main.instance.shooter.shotGunBulletNum = weapenData.weapList[thisWeapenID]._shotGunBulletNum;
        Player_Main.instance.usingWeapenName = weapenData.weapList[thisWeapenID].weapenName[Global_GameManager.instance.usingLanguage];
        switch (weapenData.weapList[thisWeapenID].weapenType)
        {
            case 0:
                Player_Main.instance.GunWeapenSwitcher(1);
                break;
            case 1:
                Player_Main.instance.GunWeapenSwitcher(2);
                break;
            case 2:
                Player_Main.instance.GunWeapenSwitcher(3);
                break;
            default:
                break;
        }
        //Main_EventCenter.instance.E_OnGetPlayerCurrentWpName(Player_Main.instance.usingWeapenName);
    }

    public void GetWeapenName()
    {
        var tempDate = weapenData.weapList[thisWeapenID].weapNameFileMain.text.Split('\n');
        nameText.text = tempDate[Global_GameManager.instance.usingLanguage];
    }

    public void GetWeapenInfo()
    {
        var tempDate = weapenData.weapList[thisWeapenID].weapInfoFileMain.text.Split('\n');
        infoText.text = tempDate[Global_GameManager.instance.usingLanguage];
    }

    public void CheckAndLoadSaveFile()
    {
        if (File.Exists(Application.persistentDataPath + "/_Weapen/SaveWeapen.json") == true)
        {
            w_Saver.LoadWeapenList();
        }
        else
        {
            for (int i = 0; i < weapenData.weapList.Count; i++)
            {
                weapenData.weapList[i]._unLocked = false;
            }
        }
        
    }
}
