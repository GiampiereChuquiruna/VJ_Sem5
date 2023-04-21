using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aparecer : MonoBehaviour
{
   public GameObject objetoAEspawnear;
    
    void Start()
    {
        InvokeRepeating("SpawnObjeto", 1f, 3f);
    }

    void SpawnObjeto()
    {
        // Crea una instancia del objeto a spawnear en la posición actual del spawner
        Instantiate(objetoAEspawnear, transform.position, Quaternion.identity);
    }
}
