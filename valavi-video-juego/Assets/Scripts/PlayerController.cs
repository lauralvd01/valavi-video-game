using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{      
    public GameObject player;
    public float speed = 2.5f;

    private Vector3 initialPosition;
    public bool missionComplete1 = false;

    public static PlayerController Instance { get; private set; }

    void Awake(){
        Instance = this;
    }
    void Start()
    {
        initialPosition = player.transform.position;
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

    public void completeMission(int mision){
        if(mision == 1){
            missionComplete1 = true;
        }
    }
    public void SetInitialPosition(){
        if(!missionComplete1){
            player.transform.position = initialPosition;
        }
        
    }
}
