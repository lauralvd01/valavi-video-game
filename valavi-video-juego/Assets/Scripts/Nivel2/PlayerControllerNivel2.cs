using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerControllerNivel2 : MonoBehaviour
{  
    public float m_speed = 7f;
    public float m_jump_speed = 10f;
    public static PlayerControllerNivel2 Instance { get; private set; }

    public GameObject m_info_circulo;
    public GameObject m_hint_button;
    public GameObject mision_comleted_message = null;
    public GameObject mision_uncomleted_message = null;

    private Animator m_animator;
    private Rigidbody m_rigidbody;

    private Vector3 m_restart_position = new Vector3(0, 3, 0);
    private AudioClip Lvlrst;
    private bool mision1 = false;
    private bool mision2 = false;
    private bool mision3 = false;
    private bool actual_mision_completed = false;
    List<int> list = new List<int>();

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

        if(Input.GetKey("space") && (transform.position.y < 6 || (m_rigidbody.velocity.y > -0.001 && m_rigidbody.velocity.y < 0.001))){
            m_animator.SetBool("Jump", true);
            transform.Translate(Vector3.up * m_jump_speed * Time.deltaTime);
        }
        else{
            m_animator.SetBool("Jump", false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "RightBorder" && !actual_mision_completed){
            AudioManager.Instance.PlaySFX(AudioManager.Instance.Lvlrst);
            transform.position = m_restart_position;
            m_info_circulo.SetActive(true);
            m_hint_button.SetActive(true);
            GameObject.FindObjectOfType<CollisionController>().ResetBotellas();
        }
        else if(other.gameObject.name == "RightBorder" && mision1){
            if(mision2) {
                if (mision3) {
                    AudioManager.Instance.PlaySFX(AudioManager.Instance.lvlcomplete);
                    UnityEngine.SceneManagement.SceneManager.LoadScene("FinalScene");
                }
                else {
                    AudioManager.Instance.PlaySFX(AudioManager.Instance.lvlcomplete);
                    UnityEngine.SceneManagement.SceneManager.LoadScene("Nivel3");
                }
            } 
            else {
                AudioManager.Instance.PlaySFX(AudioManager.Instance.lvlcomplete);
                UnityEngine.SceneManagement.SceneManager.LoadScene("Nivel2");
            }
        }
    }

    public void missionComplete(int mision){
        if(mision == 1){
            print("hola buenas tardes");
            mision1 = true;
            actual_mision_completed = true;
            mision_comleted_message.SetActive(true);
            AudioManager.Instance.PlaySFX(AudioManager.Instance.ITEM);
        }
        if(mision == 2){
            mision2 = true;
            mision1 = true;
            actual_mision_completed = true;
            mision_comleted_message.SetActive(true);
            AudioManager.Instance.PlaySFX(AudioManager.Instance.ITEM);
        }
    }

    public void rgbmision(int color){

        //print("hola");
        if (!list.Contains(color)) {
            list.Add(color);
            print("Lista actual: " + string.Join(", ", list));
            AudioManager.Instance.PlaySFX(AudioManager.Instance.ITEM);
            mision_comleted_message.SetActive(true);

            if (list.Count == 3)
            {
                if (list[0] == 1 && list[1] == 2 && list[2] == 3){
                    mision3= true;
                    mision2= true;
                    mision1= true;
                    actual_mision_completed = true;
                    mision_comleted_message.SetActive(false);
                    AudioManager.Instance.PlaySFX(AudioManager.Instance.lvlcomplete);
                }
                else {
                    list.Clear();
                    mision_comleted_message.SetActive(false);
                    mision_uncomleted_message.SetActive(true);
                    AudioManager.Instance.PlaySFX(AudioManager.Instance.error);
                    GameObject.FindObjectOfType<CollisionController>().ResetBotellas();

                }
            }
        
        }
        
    }

    public void ChangeSize(GameObject obj)
    {
        // Aquí puedes cambiar el tamaño del objeto, por ejemplo, duplicarlo
        obj.transform.localScale = obj.transform.localScale * 0;
    }
    
    public void ResetBotellas()
    {
        GameObject[] botellas = GameObject.FindGameObjectsWithTag("botella"); // Ajusta la etiqueta según tu configuración
        foreach (GameObject botella in botellas)
        {
            botella.transform.localScale = new Vector3(3f, 3f, 3f); // Establece el tamaño original de la botella
        }
    }
}