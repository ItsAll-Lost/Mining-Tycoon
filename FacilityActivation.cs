using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FacilityActivation : MonoBehaviour
{
    public MaterialSystem materialSystem; 
    public int requiredCoal = 0; 
    public int requiredQuartz = 0; 
    public int requiredIron = 50; 
    public int requiredCopper = 0; 
    public int requiredCobalt = 0; 
    public int requiredTitanium = 5; 
    public int requiredSteel = 5;
    public int requiredCredits = 500; 
    public Button activateButton;
    public GameObject buildingPlat;

    public void ActivateFacility()
    {
        if (materialSystem != null) 
        {
            if (materialSystem.coalCount >= requiredCoal &&
                materialSystem.quartzCount >= requiredQuartz &&
                materialSystem.ironCount >= requiredIron &&
                materialSystem.copperCount >= requiredCopper &&
                materialSystem.cobaltCount >= requiredCobalt &&
                materialSystem.titaniumCount >= requiredTitanium &&
                materialSystem.steelCount >= requiredSteel &&
                materialSystem.credits >= requiredCredits)
            {
                materialSystem.coalCount -= requiredCoal;
                materialSystem.quartzCount -= requiredQuartz;
                materialSystem.ironCount -= requiredIron;
                materialSystem.copperCount -= requiredCopper;
                materialSystem.cobaltCount -= requiredCobalt;
                materialSystem.titaniumCount -= requiredTitanium;
                materialSystem.steelCount -= requiredSteel;
                materialSystem.credits -= requiredCredits;

                materialSystem.UpdateText(materialSystem.coalText, materialSystem.coalCount, "Coal");
                materialSystem.UpdateText(materialSystem.quartzText, materialSystem.quartzCount, "Quartz");
                materialSystem.UpdateText(materialSystem.ironText, materialSystem.ironCount, "Iron");
                materialSystem.UpdateText(materialSystem.copperText, materialSystem.copperCount, "Copper");
                materialSystem.UpdateText(materialSystem.cobaltText, materialSystem.cobaltCount, "Cobalt");
                materialSystem.UpdateText(materialSystem.titaniumText, materialSystem.titaniumCount, "Titanium");
                materialSystem.UpdateText(materialSystem.steelText, materialSystem.steelCount, "Steel");
                materialSystem.UpdateOtherText();

                gameObject.SetActive(true); 

                if (activateButton != null)
                {
                    activateButton.gameObject.SetActive(false);
                }

                if (buildingPlat != null)
                {
                    buildingPlat.SetActive(false); 
                }

                Debug.Log("Facility activated!");
            }
            else
            {
                Debug.Log("Not enough materials or credits to activate the facility.");
            }
        }
        else
        {
            Debug.LogError("MaterialSystem is not assigned in FacilityActivation.");
        }
    }
}
