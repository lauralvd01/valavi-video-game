using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    // Detecta colisiones físicas
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision detected with " + collision.gameObject.name);
        if(this.gameObject.name == "paredInvisible"){
            PlayerController.Instance.SetInitialPosition();
        }
    }

    // Detecta colisiones con triggers
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger detected with " + other.gameObject.name + " and " + this.gameObject.name);
        if(this.gameObject.name == "paredInvisible"){
            PlayerController.Instance.SetInitialPosition();
        }
        if(this.gameObject.name == "Objeto"){
            PlayerController.Instance.completeMission(1);
        }
    }
}
