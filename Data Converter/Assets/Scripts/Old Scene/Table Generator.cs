using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TableGenerator : MonoBehaviour
{
    public GameObject rowPrefab;
    public Transform tableParent;
    /*
    public Transform lengthColumnParent;
    public Transform heightColumnParent;
    public Transform widthColumnParent;
    public Transform payloadColumnParent;
    public Transform dryWeightColumnParent;
    */


    public void GenerateTable(List<CompanyData> companyDataList)
    {
        foreach (Transform child in tableParent)
        {
            Destroy(child.gameObject);
        }

        foreach (var companyData in companyDataList)
        {
            GameObject newRow = Instantiate(rowPrefab, tableParent);

            TextMeshProUGUI[] column = newRow.GetComponentsInChildren<TextMeshProUGUI>();
            if (column.Length >= 5)
            {
                column[0].text = companyData.length.ToString();
                column[1].text = companyData.width.ToString();
                column[2].text = companyData.height.ToString();
                column[3].text = companyData.payload.ToString();
                column[4].text = companyData.dryWeight.ToString();
            }
            else
            {
                Debug.LogWarning("Row Prefab is missong TextMeshProGUI componencts");
            }
        }



        //ClearTable();

        /*
        foreach (CompanyData data in companyDataList) 
        {
            CreateRow(data);
        }
        */
    }

    /*private void CreateRow(CompanyData data)
    {
        GameObject lengthRow = Instantiate(rowPrefab, lengthColumnParent);
        GameObject widthRow = Instantiate(rowPrefab, widthColumnParent);
        GameObject heightRow = Instantiate(rowPrefab, heightColumnParent);
        GameObject payloadRow = Instantiate(rowPrefab, payloadColumnParent);
        GameObject dryWeightRow = Instantiate(rowPrefab, dryWeightColumnParent);

        lengthRow.GetComponentInChildren<TextMeshProUGUI>().text = data.length.ToString();
        widthRow.GetComponentInChildren<TextMeshProUGUI>().text = data.width.ToString();
        heightRow.GetComponentInChildren<TextMeshProUGUI>().text= data.height.ToString();
        payloadRow.GetComponentInChildren<TextMeshProUGUI>().text =(data.payload.ToString());
        dryWeightRow.GetComponentInChildren<TextMeshProUGUI>().text=(data.dryWeight.ToString());

        rowInstances.Add(lengthRow);
        rowInstances.Add(widthRow);
        rowInstances.Add(heightRow);
        rowInstances.Add(payloadRow);
        rowInstances.Add(dryWeightRow);
    }

    private void ClearTable()
    {
        foreach (var row in rowInstances)
        {
            Destroy(row);
        }
        rowInstances.Clear();
    }
    */
}
