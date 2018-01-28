using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GGJ.Player;
using Weapon;

namespace GGJ.Player
{
    public enum PlayerMode
    {
        VirusBuster,
        LoveCupid
    }
}

public class Player : MonoBehaviour
{
    const int LEFT = 0; const int RIGHT = 1;
    public Controller[] controller = new Controller[2];

    PlayerMode playerMode = 0;

	void Start ()
    {
		
	}

    /// <summary>
    /// モード切替
    /// </summary>
    public void ModeChange(PlayerMode mode)
    {
        playerMode = mode;

        if(playerMode == PlayerMode.VirusBuster)
        {
            controller[LEFT].ChangeWeapon(WeaponType.Gun);
            controller[RIGHT].ChangeWeapon(WeaponType.Gun);
        }
        else if(playerMode == PlayerMode.LoveCupid)
        {
            controller[LEFT].ChangeWeapon(WeaponType.Bow);
            controller[RIGHT].ChangeWeapon(WeaponType.Bow);
        }
    }
}
