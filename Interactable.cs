using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] private GameObject menuCanvas;

    private bool isPlayerInRange = false;

    void Start()
    {
        if (menuCanvas != null)
        {
            menuCanvas.SetActive(false);
        }

        BoxCollider boxCollider = GetComponent<BoxCollider>();
        if (boxCollider == null)
        {
            Debug.LogWarning("No Box Collider found");
        }
        else
        {
            boxCollider.isTrigger = true; 
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
        }
    }

    void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            ToggleMenu();
        }
    }

    private void ToggleMenu()
    {
        if (menuCanvas != null)
        {
            bool isActive = menuCanvas.activeSelf;
            menuCanvas.SetActive(!isActive);
            Cursor.lockState = CursorLockMode.Confined;


        }
    }


}
