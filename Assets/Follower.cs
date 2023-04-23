using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] public float delayCount = 30;

    // Update is called once per frame
    void FixedUpdate()
    {
        var c = player.positionList.Count;
        var index = (int)Mathf.Max(0, c - delayCount - 1);
        transform.position = player.positionList[index];
        transform.rotation = player.rotationList[index];
    }
}
