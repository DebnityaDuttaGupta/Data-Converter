using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class CompanyData
{
    public string companyName;
    public float length;
    public float width;
    public float height;
    public float payload;
    public float dryWeight;
}

[System.Serializable]
public class UnitSettings
{
    public string dimensionUnit;
    public string weightUnit;
}

[System.Serializable]
public class SaveData
{
    public UnitSettings unitSettings;
    public List<CompanyData> companyDataList = new List<CompanyData>();
}

public class DataManager : MonoBehaviour
{
    private string filePath;

    private void Start()
    {
        filePath = Path.Combine(Application.persistentDataPath, "saveData.json");
    }

    public void SaveData(string companyKey, CompanyData companyData, UnitSettings unitSettings)
    {
        SaveData saveData = LoadAllData();

        saveData.unitSettings = unitSettings;

        CompanyData existingData = saveData.companyDataList.Find(c => c.companyName == companyKey);
        if (existingData != null)
        {
            existingData.length = companyData.length;
            existingData.width = companyData.width;
            existingData.height = companyData.height;
            existingData.payload = companyData.payload;
            existingData.dryWeight = companyData.dryWeight;
        }
        else
        {
            saveData.companyDataList.Add(companyData);
        }

        string json = JsonUtility.ToJson(saveData, true);
        File.WriteAllText(filePath, json);
    }

    public SaveData LoadAllData()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            return JsonUtility.FromJson<SaveData>(json);
        }
        return new SaveData();
    }

    public CompanyData LoadCompanyData(string companyKey)
    {
        SaveData saveData = LoadAllData();
        return saveData.companyDataList.Find(c => c.companyName == companyKey);
    }

    public UnitSettings LoadUnitSettings()
    {
        SaveData saveData = LoadAllData();
        return saveData.unitSettings;
    }

    public void DeleteCompantData(string companyKey)
    {
        SaveData saveData = LoadAllData();
        CompanyData dataToRemove = saveData.companyDataList.Find(c => c.companyName == companyKey);
        if (dataToRemove != null)
        {
            saveData.companyDataList.Remove(dataToRemove);
            string json = JsonUtility.ToJson(saveData, true);
            File.WriteAllText(filePath, json);
        }
    }
}
