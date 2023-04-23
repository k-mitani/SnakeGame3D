using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] Follower followerPrefab;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Do());
    }

    IEnumerator Do()
    {
        var i = 0;
        while (true)
        {
            yield return new WaitForSeconds(0.3f);
            var follower = Instantiate(followerPrefab, player.transform.position, player.transform.rotation);
            follower.delayCount = i * 15 + 170;
            i++;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
