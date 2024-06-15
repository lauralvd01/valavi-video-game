using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerNivel2 : MonoBehaviour
{  
    public float m_speed = 7f;
    public float m_jump_speed = 10f;

    private Animator m_animator;
    private Rigidbody m_rigidbody;
    private Vector3 m_restart_position = new Vector3(-42, 3, 0);

    void Start()
    {
        m_animator = GetComponent<Animator>();
        m_rigidbody = GetComponent<Rigidbody>();
        transform.position = new Vector3(0, 3, 0);
    }

    void Update()
    {
        Vector3 velocity_vector = Vector3.forward * m_speed * Time.deltaTime;
        if(Input.GetKey("a") || Input.GetKey("left")){
            m_animator.SetFloat("Speed", velocity_vector.magnitude);
            transform.rotation = Quaternion.Euler(0, 270, 0);
            transform.Translate(velocity_vector);
        }
        else if(Input.GetKey("d") || Input.GetKey("right")){
            m_animator.SetFloat("Speed", velocity_vector.magnitude);
            transform.rotation = Quaternion.Euler(0, 90, 0);
            transform.Translate(velocity_vector);
        }
        else if(Input.GetKey("s") || Input.GetKey("down")){
            m_animator.SetFloat("Speed", velocity_vector.magnitude);
            transform.rotation = Quaternion.Euler(0, 180, 0);
            transform.Translate(velocity_vector);
        }
        else if(Input.GetKey("w") || Input.GetKey("up")){
            m_animator.SetFloat("Speed", velocity_vector.magnitude);
            transform.rotation = Quaternion.Euler(0, 0, 0);
            transform.Translate(velocity_vector);
        }
        else{
            m_animator.SetFloat("Speed", m_rigidbody.velocity.magnitude);
        }

        if(Input.GetKey("space") && transform.position.y < 6){
            m_animator.SetBool("Jump", true);
            transform.Translate(Vector3.up * m_jump_speed * Time.deltaTime);
        }
        else{
            m_animator.SetBool("Jump", false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "RightBorder"){
            transform.position = m_restart_position;
        }
    }
}