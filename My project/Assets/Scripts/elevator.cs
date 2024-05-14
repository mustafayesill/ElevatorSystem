using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elevator : MonoBehaviour
{
   
    public GameObject character,floor2,floor1;
    private Vector3 F1_originalPosition1,F1_originalPosition2, F2_originalPosition1, F2_originalPosition2;
    public Transform F1door1, F1door2,F2door1,F2door2;
    public float gap = 0.8f;
    bool isElevated;
    
    private void Start()
    {
        OriginalPos();
        isElevated = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (isElevated ==true)
        {
            Debug.Log("girdi");
            if (other.gameObject.CompareTag("Enter"))
            {
                Debug.Log("Enterda");
                OpenDoor_F1();               
            }
            else if (other.gameObject.CompareTag("Exit"))
            {
                CloseDoor_F1(); 
                Debug.Log("door closed");
                character.transform.position = floor2.transform.position;
                isElevated = false;
            }
            else if (other.gameObject.CompareTag("Enter2"))
            {
                OpenDoor_F2();
            }
            else if (other.gameObject.CompareTag("Floor2") && Input.GetKeyDown(KeyCode.E))
            {
                
                
                    character.transform.position = floor1.transform.position;
                    CloseDoor_F2();
                    isElevated = false;

                
            }
        }
        if (other.gameObject.CompareTag("Floor2"))
        {
            OpenDoor_F2();
        }      
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Floor2"))
        {
            CloseDoor_F2();
            isElevated = true;
        }
    }
    private void OpenDoor_F1()
    {
        F1door1.transform.position = new Vector3(F1door1.position.x + gap, F1door1.position.y, F1door1.position.z);
        F1door2.transform.position = new Vector3(F1door2.position.x - gap, F1door2.position.y, F1door2.position.z);
    }
    private void OpenDoor_F2()
    {
        F2door1.transform.position = new Vector3(F2door1.position.x + gap, F2door1.position.y, F2door1.position.z);
        F2door2.transform.position = new Vector3(F2door2.position.x - gap, F2door2.position.y, F2door2.position.z);
    }
    private void CloseDoor_F1()
    {
        F1door1.transform.position = F1_originalPosition1;
        F1door2.transform.position = F1_originalPosition2;
    }
    private void CloseDoor_F2()
    {
        F2door1.transform.position = F2_originalPosition1;
        F2door2.transform.position = F2_originalPosition2;
    }
   private void OriginalPos()
    {
        F1_originalPosition1 = F1door1.transform.position;
        F1_originalPosition2 = F1door2.transform.position;
        F2_originalPosition1 = F2door1.transform.position;
        F2_originalPosition2 = F2door2.transform.position;
    }
    

   
    
        
    
}
