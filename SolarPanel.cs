using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarPanel : MonoBehaviour
{
    public MaterialSystem materialSystem; 
    private bool isActive = false; 

    void Start()
    {
        if (materialSystem == null)
        {
            Debug.LogError("MaterialSystem is not assigned in SolarPanel.");
        }
    }

    void OnEnable()
    {
        ActivateSolarPanel();
    }

    void OnDisable()
    {
        DeactivateSolarPanel();
    }

    public void ActivateSolarPanel()
    {
        if (!isActive) 
        {
            isActive = true; 
            StartCoroutine(AddPowerCoroutine()); 
            Debug.Log("Solar Panel activated."); 
        }
    }

    private IEnumerator AddPowerCoroutine()
    {
        while (isActive)
        {
            yield return new WaitForSeconds(30f);

            if (materialSystem != null) 
            {
                materialSystem.power += 100; 
                materialSystem.UpdateText(materialSystem.powerText, (int)materialSystem.power, "Power"); 
                Debug.Log("Added 100 power to the count."); 
            }
        }
    }

    public void DeactivateSolarPanel()
    {
        if (isActive) 
        {
            isActive = false; 
            StopCoroutine(AddPowerCoroutine()); 
            Debug.Log("Solar Panel deactivated.");
        }
    }
}
