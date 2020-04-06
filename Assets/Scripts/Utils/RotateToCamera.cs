using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToCamera : MonoBehaviour
{
    private void Awake()
    {
        this.transform.rotation = Camera.main.transform.rotation;
    }
}
