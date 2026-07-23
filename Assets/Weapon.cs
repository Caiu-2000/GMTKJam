using UnityEditor.Rendering;
using UnityEngine;

[System.Serializable]
public struct Tool
{

    public float damage;
    public Sprite weaponSprite;
    public Vector3 HittboxSize;
    public string name;
    public int Tier;

    public Tool(string WeaponName , float newDamage = 1.0f , Sprite Icon = null, Vector3?  hittbox = null , int newTier = 1)
    {
        name = WeaponName;
        weaponSprite = Icon;
        damage = newDamage;
        HittboxSize = hittbox ?? Vector3.one;
        Tier = newTier;


    }

}
