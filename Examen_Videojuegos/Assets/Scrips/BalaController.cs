using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BalaController : MonoBehaviour
{
    public GameObject bullet;
    public float velocity = 4;
    float velocity1;
    int disp =1;
    Rigidbody2D rb;
    // Start is called before the first frame update
    //private GameMangerController gameManager;

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
        Multibala();
    }
    private void Multibala(){
        if(Input.GetKeyUp(KeyCode.L)){
            Disparar1();  
            //Disparar(); 
            Disparar2();     
        }
    }
    public void Disparar1(){
        //if(Input.GetKeyUp(KeyCode.K)){
            var bulletPosition = transform.position + new Vector3(0,1,0);
            var gb = Instantiate(bullet, bulletPosition, Quaternion.identity) as GameObject;
            var controller = gb.GetComponent<BalaController>();
            //controller.SetLeftDirection();
            if(disp>0)controller.SetRightDirection();
            else if(disp<0)controller.SetLeftDirection();
            //controller.SetScoreText(scoreText);                 
        //}
        //else if(Input.GetKeyUp(KeyCode.D)){
            
        //}
    }
    public void Disparar2(){
        //if(Input.GetKeyUp(KeyCode.K)){
            var bulletPosition = transform.position + new Vector3(0,-1,0);
            var gb = Instantiate(bullet, bulletPosition, Quaternion.identity) as GameObject;
            var controller = gb.GetComponent<BalaController>();
            //controller.SetLeftDirection();
            if(disp>0)controller.SetRightDirection();
            else if(disp<0)controller.SetLeftDirection();
            //controller.SetScoreText(scoreText);                 
        //}
        //else if(Input.GetKeyUp(KeyCode.D)){
            
        //}
    }
    void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.tag == "Enemy"){
            //Destroy(other.gameObject);
            //Destroy(this.gameObject);
            //gameManager.GanarPuntos(10);
            //gameManager.PerderVida();
            //gameManager.SaveGame();
        }

    }
}
