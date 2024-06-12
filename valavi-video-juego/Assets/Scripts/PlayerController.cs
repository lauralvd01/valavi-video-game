using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{      
    public GameObject player;
    public float speed = 2.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("a")){
            player.transform.position += (Vector3.left * speed * Time.deltaTime);
        }
        if(Input.GetKey("s")){
            player.transform.position += (-1 * Vector3.forward * speed * Time.deltaTime);
        }
        if(Input.GetKey("d")){
            player.transform.position += (Vector3.right * speed * Time.deltaTime);
        }
        if(Input.GetKey("w")){
            player.transform.position += (Vector3.forward * speed * Time.deltaTime);
        }
    
    }
}
