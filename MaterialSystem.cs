using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MaterialSystem : MonoBehaviour
{
    public TMP_Text coalText;
    public TMP_Text quartzText;
    public TMP_Text ironText;
    public TMP_Text copperText;
    public TMP_Text cobaltText;
    public TMP_Text titaniumText;
    public TMP_Text steelText;
    public TMP_Text ironIngotText;
    public TMP_Text titaniumIngotText;
    public TMP_Text copperIngotText;
    public TMP_Text creditText;
    public TMP_Text powerText;

    private bool isPlayerInRange = false;

    public int coalCount = 0;
    public int quartzCount = 0;
    public int ironCount = 0;
    public int copperCount = 0;
    public int cobaltCount = 0;
    public int titaniumCount = 0;
    public int steelCount = 0;
    public int ironIngotCount = 0;
    public int titaniumIngotCount = 0;
    public int copperIngotCount = 0;
    public int credits = 1500;
    public float power = 1000;

    void Start()
    {
        BoxCollider boxCollider = GetComponent<BoxCollider>();
        if (boxCollider == null)
        {
            Debug.LogWarning("No BoxCollider found!");
        }
        else
        {
            boxCollider.isTrigger = true;
        }

        UpdateText(coalText, coalCount, "Coal");
        UpdateText(quartzText, quartzCount, "Quartz");
        UpdateText(ironText, ironCount, "Iron");
        UpdateText(copperText, copperCount, "Copper");
        UpdateText(cobaltText, cobaltCount, "Cobalt");
        UpdateText(titaniumText, titaniumCount, "Titanium");
        UpdateText(steelText, steelCount, "Steel");
        UpdateText(ironIngotText, ironIngotCount, "Iron Ingot");
        UpdateText(titaniumIngotText, titaniumIngotCount, "Titanium Ingot");
        UpdateText(copperIngotText, copperIngotCount, "Copper Ingot");


        UpdateOtherText();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
            Debug.Log("Player entered the mining pit area");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            Debug.Log("Player exited the mining pit area");
        }
    }

    void Update()
    {
        if (isPlayerInRange && (Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonDown(0)))
        {
            Debug.Log("Mining attempt made");
            MineOre();
        }
    }

    private void MineOre()
    {
        float randomValue = Random.Range(0f, 100f);

        if (randomValue <= 50f) 
        {
            if (Random.Range(0f, 1f) < 0.5f)
            {
                coalCount++;
                UpdateText(coalText, coalCount, "Coal");
            }
            else
            {
                quartzCount++;
                UpdateText(quartzText, quartzCount, "Quartz");
            }
        }
        else if (randomValue <= 85f) 
        {
            if (Random.Range(0f, 1f) < 0.6f) 
            {
                ironCount++;
                UpdateText(ironText, ironCount, "Iron");
            }
            else
            {
                copperCount++;
                UpdateText(copperText, copperCount, "Copper");
            }
        }
        else if (randomValue <= 95f) 
        {
            if (Random.Range(0f, 1f) < 0.4f) 
            {
                cobaltCount++;
                UpdateText(cobaltText, cobaltCount, "Cobalt");
            }
            else
            {
                titaniumCount++;
                UpdateText(titaniumText, titaniumCount, "Titanium");
            }
        }
    }

    public void UpdateText(TMP_Text textElement, int count, string oreName)
    {
        textElement.text = oreName + ": " + count;
    }

    public void UpdateOtherText()
    {
        creditText.text = "Credits: " + credits;
        powerText.text = "Power: " + power;

    }
}
