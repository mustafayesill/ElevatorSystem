using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elevator : MonoBehaviour
{
   // public Transform enterPoint, exitPoint;
    public GameObject character,floor2;
    private Vector3 originalPosition1,originalPosition2;
    public Transform door1, door2;
    public float gap = 0.3f;
    bool isElevated;
    
    private void Start()
    {
       // StartCoroutine(CloseDoor());
        originalPosition1 = door1.transform.position;
        originalPosition2 = door2.transform.position;
        isElevated = true;

    }
    private void OnTriggerStay(Collider other)
    {
        if (isElevated ==true)
        {
            Debug.Log("girdi");
            if (other.gameObject.CompareTag("Enter"))
            {
                Debug.Log("Enterda");
                if ( isElevated ==true && Input.GetKey(KeyCode.E))
                {
                    Debug.Log("tusa basti");
                    OpenDoor();
                }
            }
            if (other.gameObject.CompareTag("Exit"))
            {
                door1.transform.position = originalPosition1;
                door2.transform.position = originalPosition2;
                if (Input.GetKey(KeyCode.Alpha2))
                {
                    character.transform.position = floor2.transform.position;
                }
            }
            isElevated = false;

        }

        if (other.gameObject.CompareTag("Floor2"))
        {
            if (Input.GetKey(KeyCode.E))
            {
                OpenDoor();
            }

        }

    }

    private void OnTriggerExit(Collider other)
    {
        
    }

    private void OpenDoor()
    {
        door1.transform.position = new Vector3(door1.position.x + gap, door1.position.y, door1.position.z);
        door2.transform.position = new Vector3(door2.position.x - gap, door2.position.y, door2.position.z);
    }
   
    

   
    
        
    
}
