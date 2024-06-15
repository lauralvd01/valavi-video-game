using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerNivel2 : MonoBehaviour
{  
    public float m_speed = 10f;
    public float m_jump_speed = 10f;

    private Vector3 m_restart_position = new Vector3(-42, 3, 0);

    void Start()
    {
        transform.position = new Vector3(0, 3, 0);
    }

    void Update()
    {
        if(Input.GetKey("a") || Input.GetKey("left")){
            transform.Translate(Vector3.left * m_speed * Time.deltaTime);
        }
        if(Input.GetKey("s") || Input.GetKey("down")){
            transform.Translate(-1 * Vector3.forward * m_speed * Time.deltaTime);
        }
        if(Input.GetKey("d") || Input.GetKey("right")){
            transform.Translate(Vector3.right * m_speed * Time.deltaTime);
        }
        if(Input.GetKey("w") || Input.GetKey("up")){
            transform.Translate(Vector3.forward * m_speed * Time.deltaTime);
        }

        if(Input.GetKey("space") && transform.position.y < 6){
            transform.Translate(Vector3.up * m_jump_speed * Time.deltaTime);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision detected with " + collision.gameObject.name);
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger detected with " + other.gameObject.name + " and " + this.gameObject.name);
        if(other.gameObject.name == "RightBorder"){
            Debug.Log("RightBorder");

            transform.position = m_restart_position;
        }
    }
}