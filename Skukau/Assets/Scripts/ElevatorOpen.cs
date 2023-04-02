using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorOpen : MonoBehaviour
{
    
    [SerializeField] Animator door;
    [SerializeField] Animator door2;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
          
            door.SetTrigger("Button");
            door2.SetTrigger("Button");
        }
    }
    private void OnTriggerEnter(Collider other) 
    { 
        if (other.tag == "DoorsBack") //Проверяем столкновение с определенным тэгом объекта 
        { 
            door.SetTrigger("DoorsBack");
            door2.SetTrigger("DoorsBack");
        } 
    }
}
