using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class botellaController : MonoBehaviour
{
    public static botellaController Instance { get; private set; }

        void Awake(){
        Instance = this;
    }


        public void ChangeSize(GameObject obj)
    {
        // Aquí puedes cambiar el tamaño del objeto, por ejemplo, duplicarlo
        obj.transform.localScale = obj.transform.localScale * 0;
    }
}