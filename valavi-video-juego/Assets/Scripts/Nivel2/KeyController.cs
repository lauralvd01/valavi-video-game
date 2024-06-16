using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    private GameObject m_key;

    // Start is called before the first frame update
    void Start()
    {
        m_key = GameObject.Find("Key");   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            PlayerControllerNivel2.Instance.missionComplete(2);
            Destroy(gameObject);
        }
    }
}
