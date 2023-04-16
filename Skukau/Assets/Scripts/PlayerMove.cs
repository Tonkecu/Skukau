using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float speed; //скорость персонажа
    Rigidbody rb; //ссылка на Rigidbody
    Vector3 direction; //Направление движения
    [SerializeField] float jumpSpeed; //высота прыжка
    bool isGrounded; //переменная, которая будет указывать на земле мы или нет
    bool isMouse = false;
    bool pred;
    bool ele;
    [SerializeField] GameObject shit;
    [SerializeField] Animator door;
    [SerializeField] Animator door2;
    [SerializeField] Animator door3;
    [SerializeField] Animator door4;
    float x = -18.735f;
    float y = 1.854f;
    float z = 45.033f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        direction = transform.TransformDirection(x, 0, z);
        if(isGrounded)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(new Vector3(0, jumpSpeed, 0), ForceMode.Impulse);
            }
        }
        if (Input.GetMouseButtonDown(1)) {
          
                isMouse = true;      
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(transform.position + direction * speed * Time.fixedDeltaTime);
    }
    private void OnCollisionStay(Collision other)
    {
        if (other != null)
        {
            isGrounded = true;
        }
    }
    private void OnCollisionExit(Collision other)
    {
        isGrounded = false;
    }
    
    private void OnTriggerStay(Collider other) 
    {
        if (isMouse) {
            if (other.tag == "pred") //Проверяем столкновение с определенным тэгом объекта 
            { 
                Destroy(other.gameObject);
                isMouse = false;
                pred = true;         
            }
            if (other.tag == "chitok") //Проверяем столкновение с определенным тэгом объекта 
            { 
                if (pred){
                    shit.SetActive(true);
                    isMouse = false;
                    pred = false;
                    ele = true;
                }         
            }
            if (other.tag == "button") {
                if(ele){
                    door.SetTrigger("Button");
                    door2.SetTrigger("Button");
                }
            }
            if (other.tag == "button2") {
                transform.position = new Vector3(x, y, z);
                door3.SetTrigger("Button");
                door4.SetTrigger("Button");
            }
            else{
                isMouse = false;
            }
        }
    }
}