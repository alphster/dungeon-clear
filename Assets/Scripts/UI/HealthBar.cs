using Assets.Scripts.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public GameObject HittableGameObject;
    public GameObject GreenBar;

    Image greenBarImage;

    void Awake()
    {
        var healthy = HittableGameObject.GetComponent<IHealthy>();
        healthy.RegisterOnHealthChanged(Change);

        greenBarImage = GreenBar.GetComponent<Image>();
    }

    private void Change(float totHp, float curHp)
    {
        greenBarImage.fillAmount = curHp / totHp;
    }
}
