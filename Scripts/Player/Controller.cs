using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Weapon;

public class Controller : MonoBehaviour
{
    public WeaponData weaponData;

    SteamVR_TrackedObject trackedObject;

    [SerializeField] WeaponType haveWeaponType = 0;
    BaseWeapon _weapon;

    public BaseWeapon Weapon
    {
        get { return _weapon; }
        private set
        {
            if(_weapon != null) Destroy(_weapon.gameObject);
            _weapon = value;
            _weapon.transform.parent = transform;
            _weapon.transform.localPosition = Vector3.zero;
            _weapon.transform.localRotation = Quaternion.identity;
        }
    }

	void Start ()
    {
        trackedObject = GetComponent<SteamVR_TrackedObject>();
        ChangeWeapon(haveWeaponType);
	}
	
	void Update ()
    {
        var device = SteamVR_Controller.Input((int)trackedObject.index);

        TriggerCheck(device);
        TouchpadCheck(device);
    }

    /// <summary>
    /// トリガーが引かれた時
    /// </summary>
    /// <param name="dvc">デバイス</param>
    void TriggerCheck(SteamVR_Controller.Device dvc)
    {
        if (dvc.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            Debug.Log("トリガーを深く引いた");
            Weapon.Trigger_Down();
        }
        if (dvc.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger))
        {
            Debug.Log("トリガーを離した");
            Weapon.Trigger_Up();
        }
    }

    /// <summary>
    /// タッチパッドが押された時
    /// </summary>
    /// <param name="dvc">デバイス</param>
    void TouchpadCheck(SteamVR_Controller.Device dvc)
    {
        if (!dvc.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad)) return;

        switch(haveWeaponType)
        {
            case WeaponType.Gun:
                ChangeWeapon(WeaponType.Daison);
                break;
            case WeaponType.Daison:
                ChangeWeapon(WeaponType.Gun);
                break;
            case WeaponType.Bow:
                break;
        }

    }

    /// <summary>
    /// 武器の変更
    /// </summary>
    public void ChangeWeapon(WeaponType type)
    {
        haveWeaponType = type;
        Weapon = Instantiate(weaponData.WeaponPrefab[(int)haveWeaponType]).GetComponent<BaseWeapon>();
    }
}