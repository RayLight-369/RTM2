using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{

    public Transform player;
    public Vector3 offset = new Vector3(0, 1.4f, -5f);
    void LateUpdate()
    {
        transform.position = player.position + offset;
    }
}
