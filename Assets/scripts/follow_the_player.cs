using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow_the_player : MonoBehaviour
{
    public GameObject player;


    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x+5.2f,transform.position.y,transform.position.z);
    }
}
