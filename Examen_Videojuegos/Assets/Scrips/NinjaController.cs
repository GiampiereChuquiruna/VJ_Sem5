using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaController : MonoBehaviour
{
    public float vCorrer = 1, jumpForce = 1;

    public GameObject bullet;
    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator animator;
    public BalaController balaManager;

    const int IDLE = 0;
    const int JUMP = 1;
    const int RUN = 2;
    int cont = 1, disp = 1;
    bool salto = false;

    void Start()
    {
        balaManager = GetComponent<BalaController>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }


    void Update()
    {
        if(Input.GetKey(KeyCode.RightArrow)){
            sr.flipX = false;
            rb.velocity = new Vector2(vCorrer, rb.velocity.y);
            ChangeAnimation(RUN); 
            disp = 1;     
        }
        else if(Input.GetKey(KeyCode.LeftArrow)){
            sr.flipX = true;
            rb.velocity = new Vector2(-vCorrer, rb.velocity.y);
            ChangeAnimation(RUN);
            disp = -1;        
        }
        else{
            rb.velocity = new Vector2(0, rb.velocity.y);
            ChangeAnimation(IDLE);
        }
        Saltar();
        SaltarFuerte();
        Lazar();
        Atacar();
        Morir();
        Multibala();
    }
    private void Lazar(){
        if(Input.GetKey(KeyCode.T)){ 
            rb.velocity = new Vector2(0, 0);  
               // ChangeAnimation(THROW);
        }
    }
    private void Atacar(){
        if(Input.GetKey(KeyCode.A)){   
            rb.velocity = new Vector2(0, 0);
            //ChangeAnimation(ATTACK);
        } 
    }
    private void Saltar(){
        if(Input.GetKeyUp(KeyCode.Space)){
                //rb.velocity = new Vector2(rb.velocity.x, velSalto);
                rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                //cont--;
                ChangeAnimation(JUMP);
        } 
    }
    private void SaltarFuerte(){
        if(Input.GetKey(KeyCode.L) && salto == true){
                //rb.velocity = new Vector2(rb.velocity.x, velSalto);
                rb.AddForce(new Vector2(0, 10), ForceMode2D.Impulse);
                salto = false;
                ChangeAnimation(JUMP);
        } 
    }
    private void Morir(){
        if(Input.GetKey(KeyCode.D)){  
            rb.velocity = new Vector2(0, 0); 
            //estado = false;
                //ChangeAnimation(DEAD);
        }
    }
    private void Correr1(){
        if(Input.GetKey(KeyCode.RightArrow)){
            sr.flipX = false;
            rb.velocity = new Vector2(5, rb.velocity.y);
            ChangeAnimation(RUN);      
        }
        else if(Input.GetKey(KeyCode.LeftArrow)){
            sr.flipX = true;
            rb.velocity = new Vector2(-5, rb.velocity.y);
            ChangeAnimation(RUN);      
        }
    }
    private void Multibala(){
        if(Input.GetKeyUp(KeyCode.K)){
            Disparar();     
        }
        /*else if(Input.GetKeyUp(KeyCode.L)){
            balaManager.Disparar1();  
            //Disparar(); 
            balaManager.Disparar2();     
        }*/
    }
    private void Disparar(){
        //if(Input.GetKeyUp(KeyCode.K)){
            var bulletPosition = transform.position + new Vector3(disp,0,0);
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
    private void Disparar1(){
        //if(Input.GetKeyUp(KeyCode.K)){
            var bulletPosition = transform.position + new Vector3(1,1,0);
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
    private void Disparar2(){
        //if(Input.GetKeyUp(KeyCode.K)){
            var bulletPosition = transform.position + new Vector3(1,-1,0);
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
        cont = 1;
        if(other.gameObject.tag == "Enemy"){
            
           // Time.timeScale = 0;
        }
    } 
    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Fruta"){
            vCorrer=10;
        }
        if(other.gameObject.tag == "Fruta1"){
            vCorrer=15;
        }
        if(other.gameObject.tag == "Fruta2"){
            vCorrer=20;
        }
    }
    
    private void ChangeAnimation (int a){
        animator.SetInteger("Estado", a);
    }
}
