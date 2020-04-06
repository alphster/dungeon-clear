using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    void LateUpdate()
    {
        var newPos = PlayerManager.Instance.Player.transform.position;
        newPos.y = this.transform.position.y;
        newPos.x = this.transform.position.x;
        newPos.z = newPos.z - 3;

        this.transform.position = newPos;
    }
}
