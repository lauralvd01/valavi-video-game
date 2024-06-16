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
        // if(this.gameObject.name == "paredInvisible"){
        //     PlayerController.Instance.SetInitialPosition();
        // }
        if(this.gameObject.name == "MAPA"){
            Debug.Log("mapaa");
            PlayerControllerNivel2.Instance.missionComplete(1);
        }

                else if(this.gameObject.name == "BOTELLA_ROJA"){
            Debug.Log("rojo");
            GameObject objetoParaCambiar = this.gameObject; 
            PlayerControllerNivel2.Instance.ChangeSize(objetoParaCambiar);
            PlayerControllerNivel2.Instance.rgbmision(1);

        }
        
                else if(this.gameObject.name == "BOTELLA_VERDE"){
            Debug.Log("verde");
            GameObject objetoParaCambiar = this.gameObject; 
            PlayerControllerNivel2.Instance.ChangeSize(objetoParaCambiar);
            PlayerControllerNivel2.Instance.rgbmision(2);

        }

                else if(this.gameObject.name == "BOTELLA_AZUL"){
            Debug.Log("azul");
            GameObject objetoParaCambiar = this.gameObject; 
            
            PlayerControllerNivel2.Instance.ChangeSize(objetoParaCambiar);
            PlayerControllerNivel2.Instance.rgbmision(3);
        }


    }
        public void ResetBotellas()
    {
        PlayerControllerNivel2.Instance.ResetBotellas();
    }

}
