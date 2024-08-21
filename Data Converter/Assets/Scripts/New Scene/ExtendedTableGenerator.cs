using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ExtendedTableGenerator : MonoBehaviour
{
    public Transform tableParent;
    public GameObject rowPrefab;

    public void GenerateTableWithSerial(List<CompanyData> companyDataList)
    {
        foreach (Transform child in tableParent)
        {
            Destroy(child.gameObject);
        }
        Debug.Log("Generating table with " + companyDataList.Count + " entries.");

        int serialNumber = 1;
        foreach (var companyData in companyDataList)
        {
            GameObject row = Instantiate(rowPrefab, tableParent);
            Debug.Log("Instantiated row prefab for company: " + companyData.companyName);
            TextMeshProUGUI[] columns = row.GetComponentsInChildren<TextMeshProUGUI>();
            if (columns.Length >= 6)
            {
                columns[0].text = serialNumber.ToString();
                columns[1].text = companyData.length.ToString();
                columns[2].text = companyData.width.ToString();
                columns[3].text = companyData.height.ToString();
                columns[4].text = companyData.payload.ToString();
                columns[5].text = companyData.dryWeight.ToString();
            }
            serialNumber++;
        }
    }
}
