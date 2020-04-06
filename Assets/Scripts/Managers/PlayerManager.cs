using Assets.Scripts.Projectiles;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance { get; protected set; }

    public GameObject PlayerPrefab;
    public GameObject WeaponPrefab;

    public GameObject Player { get; protected set; }

    GameObject Weapon;

    public PlayerManager()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Awake()
    {
        Player = GameObject.Instantiate(PlayerPrefab);
        Weapon = GameObject.Instantiate(WeaponPrefab);
        Weapon.transform.SetParent(Player.transform, false);
    }

    public void Fire()
    {
        Weapon.GetComponent<BasicWeapon>().Fire();
    }
}
