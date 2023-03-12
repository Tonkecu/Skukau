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
    bool isMouse;

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
        if (Input.GetMouseButtonDown(0)) {
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
    
    private void OnTriggerEnter(Collider other)
    {        
        if (other.tag == "item") //Проверяем столкновение с определенным тэгом объекта
        {
            if (isMouse)
            {
                Destroy(other.gameObject);     
            }
        }
    }
}