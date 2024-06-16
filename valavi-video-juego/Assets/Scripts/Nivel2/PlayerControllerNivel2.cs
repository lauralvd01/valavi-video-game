using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerNivel2 : MonoBehaviour
{  
    public float m_speed = 10f;
    public float m_jump_speed = 10f;

    private Animator m_animator;
    private Rigidbody m_rigidbody;
    private Vector3 m_restart_position = new Vector3(-42, 3, 0);
    private bool mision1 = false;
    public static PlayerControllerNivel2 Instance { get; private set; }

    void Awake(){
        Instance = this;
    }
    void Start()
    {
        m_animator = GetComponent<Animator>();
        m_rigidbody = GetComponent<Rigidbody>();
        transform.position = new Vector3(0, 3, 0);
    }

    void Update()
    {
        if(Input.GetKey("a") || Input.GetKey("left")){
            Vector3 velocity_vector = Vector3.left * m_speed * Time.deltaTime;
            m_animator.SetFloat("Speed_X", velocity_vector.x);
            transform.Translate(velocity_vector);
        }
        else if(Input.GetKey("d") || Input.GetKey("right")){
            Vector3 velocity_vector = Vector3.right * m_speed * Time.deltaTime;
            m_animator.SetFloat("Speed_X", velocity_vector.x);
            transform.Translate(velocity_vector);
        }
        else if(Input.GetKey("s") || Input.GetKey("down")){
            Vector3 velocity_vector = -1 * Vector3.forward * m_speed * Time.deltaTime;
            m_animator.SetFloat("Speed_Z", velocity_vector.z);
            transform.Translate(velocity_vector);
        }
        else if(Input.GetKey("w") || Input.GetKey("up")){
            Vector3 velocity_vector = Vector3.forward * m_speed * Time.deltaTime;
            m_animator.SetFloat("Speed_Z", velocity_vector.z);
            transform.Translate(velocity_vector);
        }
        else{
            m_animator.SetFloat("Speed_X", m_rigidbody.velocity.x);
            m_animator.SetFloat("Speed_Z", m_rigidbody.velocity.z);
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
        if(other.gameObject.name == "RightBorder" && !mision1){
            transform.position = m_restart_position;
        }
        else if(other.gameObject.name == "RightBorder" && mision1){
            print("MISION COMPLETADA UWU");
        }
    }

    public void missionComplete(int mision){
        mision1 = true;
    }
}