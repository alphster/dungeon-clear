using Assets.Scripts.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IHealthy
{
    Action<float, float> OnHealthChange;

    float totHp = 100;
    float curHp;

    Rigidbody rb;

    AudioSource hitSound;

    void Awake()
    {
        curHp = totHp;
        rb = GetComponent<Rigidbody>();
        hitSound = GetComponent<AudioSource>();
    }

    public void Hit(Vector3 dir)
    {
        DecreaseHealth();
        Knockback(dir);
        hitSound.Play();
    }

    void DecreaseHealth()
    {
        curHp -= 10;
        OnHealthChange(totHp, curHp);
    }

    void Knockback(Vector3 dir)
    {
        rb.AddForce(dir);
    }

    public void RegisterOnHealthChanged(Action<float, float> callback)
    {
        OnHealthChange += callback;
    }

    public void UnregisterOnHealthChanged(Action<float, float> callback)
    {
        OnHealthChange -= callback;
    }
}
