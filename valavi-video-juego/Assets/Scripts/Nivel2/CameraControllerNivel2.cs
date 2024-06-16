using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerNivel2 : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(player.transform.position.x,player.transform.position.y+10,player.transform.position.z-20);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3((-46 < player.transform.position.x && player.transform.position.x < 39.5) ? player.transform.position.x : transform.position.x,player.transform.position.y+10,player.transform.position.z-20);
    }
}
