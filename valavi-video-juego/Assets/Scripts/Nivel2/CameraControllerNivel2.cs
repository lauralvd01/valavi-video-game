using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerNivel2 : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(player.transform.position.x,transform.position.y,transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if(-43 < player.transform.position.x && player.transform.position.x < 40) {
            transform.position = new Vector3(player.transform.position.x,transform.position.y,transform.position.z);
        }
    }
}
