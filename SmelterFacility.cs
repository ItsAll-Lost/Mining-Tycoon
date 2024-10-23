using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SmelterFacility : MonoBehaviour
{
    public MaterialSystem materialSystem;

    public int steelIronRequirement = 5;
    public int steelCoalRequirement = 5;
    public int ironIngotIronRequirement = 10;
    public int titaniumIngotTitaniumRequirement = 10;
    public int copperIngotCopperRequirement = 10;

    public int powerDrainPerSecond = 5;
    public float craftingTimePerItem = 15f; 

    public Button craftSteelButton;
    public Button craftIronIngotButton;
    public Button craftCopperIngotButton;
    public Button craftTitaniumIngotButton;
    public Button stopButton;

    public GameObject facilityActiveIndicator;
    public GameObject powerActiveIndicator;
    public GameObject[] progressBarLevels; 

    private bool isCrafting = false;
    private string currentCraftingItem = "";
    private float craftingProgress = 0f;

    void Start()
    {
        craftSteelButton.onClick.AddListener(() => StartCrafting("Steel"));
        craftIronIngotButton.onClick.AddListener(() => StartCrafting("IronIngot"));
        craftTitaniumIngotButton.onClick.AddListener(() => StartCrafting("TitaniumIngot"));
        craftCopperIngotButton.onClick.AddListener(() => StartCrafting("CopperIngot"));
        stopButton.onClick.AddListener(StopCrafting);

        UpdateProgressBar(0); 
    }

    void Update()
    {
        if (isCrafting && materialSystem.power >= powerDrainPerSecond)
        {
            materialSystem.power -= powerDrainPerSecond * Time.deltaTime; 
            materialSystem.UpdateOtherText();

            craftingProgress += Time.deltaTime;
            UpdateProgressBar((int)(craftingProgress / craftingTimePerItem * 5));

            if (craftingProgress >= craftingTimePerItem)
            {
                craftingProgress = 0; 
                CompleteCraftingItem(); 
            }
        }
        else if (materialSystem.power < powerDrainPerSecond)
        {
            StopCrafting();
            powerActiveIndicator.SetActive(false); 
            Debug.Log("Not enough power to continue crafting.");
        }
        else
        {
            powerActiveIndicator.SetActive(true); 
        }
    }

    public void StartCrafting(string itemName)
    {
        if (isCrafting)
        {
            Debug.Log("Already crafting an item. Please stop current crafting before starting a new one.");
            return;
        }

        currentCraftingItem = itemName;
        isCrafting = true;
        craftingProgress = 0; 
        UpdateProgressBar(0); 
        facilityActiveIndicator.SetActive(true);
        Debug.Log($"{itemName} crafting started.");
    }

    public void StopCrafting()
    {
        isCrafting = false;
        facilityActiveIndicator.SetActive(false);
        currentCraftingItem = "";
        craftingProgress = 0; 
        UpdateProgressBar(0); 
        Debug.Log("Crafting stopped.");
    }

    void CompleteCraftingItem()
    {
        switch (currentCraftingItem)
        {
            case "Steel":
                CraftSteel();
                break;
            case "IronIngot":
                CraftIronIngot();
                break;
            case "TitaniumIngot":
                CraftTitaniumIngot();
                break;
            case "CopperIngot":
                CraftCopperIngot();
                break;
        }

        if (isCrafting) 
        {
            Debug.Log($"{currentCraftingItem} crafting completed. Starting next item.");
            craftingProgress = 0; 
        }
        else
        {
            StopCrafting(); 
        }
    }

    void CraftSteel()
    {
        if (materialSystem.ironCount >= steelIronRequirement && materialSystem.coalCount >= steelCoalRequirement)
        {
            materialSystem.ironCount -= steelIronRequirement;
            materialSystem.coalCount -= steelCoalRequirement;
            materialSystem.steelCount++;

            materialSystem.UpdateText(materialSystem.ironText, materialSystem.ironCount, "Iron");
            materialSystem.UpdateText(materialSystem.coalText, materialSystem.coalCount, "Coal");
            materialSystem.UpdateText(materialSystem.steelText, materialSystem.steelCount, "Steel");

            Debug.Log("Steel crafted successfully.");
        }
        else
        {
            Debug.Log("Not enough materials to craft Steel.");
            StopCrafting();
        }
    }

    void CraftIronIngot()
    {
        if (materialSystem.ironCount >= ironIngotIronRequirement)
        {
            materialSystem.ironCount -= ironIngotIronRequirement;
            materialSystem.ironIngotCount++;

            materialSystem.UpdateText(materialSystem.ironText, materialSystem.ironCount, "Iron");
            materialSystem.UpdateText(materialSystem.ironIngotText, materialSystem.ironIngotCount, "Iron Ingot");

            Debug.Log("Iron Ingot crafted successfully.");
        }
        else
        {
            Debug.Log("Not enough materials to craft Iron Ingot.");
            StopCrafting();
        }
    }

    void CraftTitaniumIngot()
    {
        if (materialSystem.titaniumCount >= titaniumIngotTitaniumRequirement)
        {
            materialSystem.titaniumCount -= titaniumIngotTitaniumRequirement;
            materialSystem.titaniumIngotCount++;

            materialSystem.UpdateText(materialSystem.titaniumText, materialSystem.titaniumCount, "Titanium");
            materialSystem.UpdateText(materialSystem.titaniumIngotText, materialSystem.titaniumIngotCount, "Titanium Ingot");

            Debug.Log("Titanium Ingot crafted successfully.");
        }
        else
        {
            Debug.Log("Not enough materials to craft Titanium Ingot.");
            StopCrafting();
        }
    }

    void CraftCopperIngot()
    {
        if (materialSystem.copperCount >= copperIngotCopperRequirement)
        {
            materialSystem.copperCount -= copperIngotCopperRequirement;
            materialSystem.copperIngotCount++;

            materialSystem.UpdateText(materialSystem.copperText, materialSystem.copperCount, "Copper");
            materialSystem.UpdateText(materialSystem.copperIngotText, materialSystem.copperIngotCount, "Copper Ingot");

            Debug.Log("Copper Ingot crafted successfully.");
        }
        else
        {
            Debug.Log("Not enough materials to craft Copper Ingot.");
            StopCrafting();
        }
    }

    void UpdateProgressBar(int level)
    {
        for (int i = 0; i < progressBarLevels.Length; i++)
        {
            progressBarLevels[i].SetActive(i <= level);
        }
    }
}
