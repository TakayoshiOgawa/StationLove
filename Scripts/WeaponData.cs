using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Weapon;

namespace Weapon
{
    public enum WeaponType
    {
        Gun = 0,
        Daison,
        Bow
    }
}

[CreateAssetMenu]
public class WeaponData : ScriptableObject
{
    public BaseWeapon[] WeaponPrefab;
}