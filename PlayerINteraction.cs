using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private Canvas canvas; 

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            DeactivateAllMenus();
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    private void DeactivateAllMenus()
    {
        foreach (Transform child in canvas.transform)
        {
            if (child.gameObject.activeSelf)
            {
                child.gameObject.SetActive(false); 
            }
        }
    }
}
