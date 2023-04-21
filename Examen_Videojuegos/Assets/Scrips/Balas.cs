using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balas : MonoBehaviour
{
    public GameObject bullet;
    Rigidbody2D rb;
    public float velocity = 4;
    float velocity1 = 4;
    // Start is called before the first frame update
    public void SetRightDirection(){
        velocity1 = velocity;
    }
    
    public void SetLeftDirection(){
        velocity1 = -velocity;
    }

    void Start()
    {
        //  gameManager = FindObjectOfType<GameMangerController>();
        rb = GetComponent<Rigidbody2D>();
        //Destroy(this.gameObject, 5);
        //gameManager.GanarPuntos(0);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(velocity1, 0);
        
        
    }
}
