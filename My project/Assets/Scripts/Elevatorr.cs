using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevatorr : MonoBehaviour
{

    //public Transform destinationPoint; // I��nlanaca�� hedef nokta
    public Transform startPoint; // Karakterin asans�re bindi�i nokta
    public Transform secondFloorDestination; // �kinci kattaki hedef nokta
    public KeyCode interactKey = KeyCode.E; // E tu�u ile etkile�im

    private bool isOnElevator = false; // Asans�rde mi de�il mi?
    private bool isOnSecondFloor = false; // �kinci katta m� de�il mi?
    public Transform F1door1, F1door2, F2door1, F2door2;
    public float gap = 0.8f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Entrance1"))
        {
            OpenDoor_F1();
        }
        if (other.CompareTag("Enter1")) // Karakter asans�r�n i�ine girdi�inde
        {
            isOnElevator = true; // Asans�re bindi
            //CloseDoor_F1();
            Debug.Log("Karakter asans�r�n i�ine girdi. isOnElevator = true");
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
        if (other.CompareTag("Enter2")) // Karakter asans�r�n d���na ��kt���nda
        {
            isOnElevator = false; // Asans�rden ��kt�
            CloseDoor_F2();
            Debug.Log("Karakter asans�r�n d���na ��kt�. isOnElevator = false");
        }
        else if (other.CompareTag("Enter1")) // Karakter asans�r�n d���na ��kt���nda
        {
            isOnElevator = false; // Asans�rden ��kt�
            CloseDoor_F1();
            Debug.Log("Karakter asans�r�n d���na ��kt�. isOnElevator = false");
        }
        if (other.CompareTag("Entrance2"))
        {
            CloseDoor_F2();
            isOnElevator=false;
        }
    }

    private void Update()
    {
        if (isOnElevator && Input.GetKeyDown(interactKey)) // Karakter asans�r�n i�indeyse ve E tu�una bas�ld�ysa
        {
            if (isOnSecondFloor)
            {
                TeleportTo(startPoint); // �kinci kattaysa birinci kata ���nla
                isOnSecondFloor = false; // Birinci kata geldi
                Debug.Log("�kinci kattan birinci kata ���nland�. isOnSecondFloor = false");
            }
            else
            {
                TeleportTo(secondFloorDestination); // Birinci kattaysa ikinci kata ���nla
                isOnSecondFloor = true; // �kinci kata gitti
                Debug.Log("Birinci kattan ikinci kata ���nland�. isOnSecondFloor = true");
            }
        }
    }

    private void TeleportTo(Transform target)
    {
        // Karakteri hedef noktaya ���nla
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
