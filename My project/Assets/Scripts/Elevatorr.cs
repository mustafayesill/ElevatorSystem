using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevatorr : MonoBehaviour
{

    //public Transform destinationPoint; // Iþýnlanacaðý hedef nokta
    public Transform startPoint; // Karakterin asansöre bindiði nokta
    public Transform secondFloorDestination; // Ýkinci kattaki hedef nokta
    public KeyCode interactKey = KeyCode.E; // E tuþu ile etkileþim

    private bool isOnElevator = false; // Asansörde mi deðil mi?
    private bool isOnSecondFloor = false; // Ýkinci katta mý deðil mi?
    public Transform F1door1, F1door2, F2door1, F2door2;
    public float gap = 0.8f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Entrance1"))
        {
            OpenDoor_F1();
        }
        if (other.CompareTag("Enter1")) // Karakter asansörün içine girdiðinde
        {
            isOnElevator = true; // Asansöre bindi
            //CloseDoor_F1();
            Debug.Log("Karakter asansörün içine girdi. isOnElevator = true");
        }
        else if (other.CompareTag("Enter2"))
        {
            isOnElevator = true;
            OpenDoor_F2();
        }
        else if (other.CompareTag("Entrance2"))
        {
            OpenDoor_F2();
            isOnElevator = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enter2")) // Karakter asansörün dýþýna çýktýðýnda
        {
            isOnElevator = false; // Asansörden çýktý
            CloseDoor_F2();
            Debug.Log("Karakter asansörün dýþýna çýktý. isOnElevator = false");
        }
        else if (other.CompareTag("Enter1")) // Karakter asansörün dýþýna çýktýðýnda
        {
            isOnElevator = false; // Asansörden çýktý
            CloseDoor_F1();
            Debug.Log("Karakter asansörün dýþýna çýktý. isOnElevator = false");
        }
        if (other.CompareTag("Entrance2"))
        {
            CloseDoor_F2();
            isOnElevator=false;
        }
    }

    private void Update()
    {
        if (isOnElevator && Input.GetKeyDown(interactKey)) // Karakter asansörün içindeyse ve E tuþuna basýldýysa
        {
            if (isOnSecondFloor)
            {
                TeleportTo(startPoint); // Ýkinci kattaysa birinci kata ýþýnla
                isOnSecondFloor = false; // Birinci kata geldi
                Debug.Log("Ýkinci kattan birinci kata ýþýnlandý. isOnSecondFloor = false");
            }
            else
            {
                TeleportTo(secondFloorDestination); // Birinci kattaysa ikinci kata ýþýnla
                isOnSecondFloor = true; // Ýkinci kata gitti
                Debug.Log("Birinci kattan ikinci kata ýþýnlandý. isOnSecondFloor = true");
            }
        }
    }

    private void TeleportTo(Transform target)
    {
        // Karakteri hedef noktaya ýþýnla
        if (target != null)
        {
            transform.position = target.position;
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
        F1door1.transform.position = new Vector3(F1door1.position.x - gap, F1door1.position.y, F1door1.position.z);
        F1door2.transform.position = new Vector3(F1door2.position.x + gap, F1door2.position.y, F1door2.position.z);
    }
    private void CloseDoor_F2()
    {
        F2door1.transform.position = new Vector3(F2door1.position.x - gap, F2door1.position.y, F2door1.position.z);
        F2door2.transform.position = new Vector3(F2door2.position.x + gap, F2door2.position.y, F2door2.position.z);
    }
   

}
