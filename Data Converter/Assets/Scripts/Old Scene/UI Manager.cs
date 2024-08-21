using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public DataManager dataManager;
    public CompaySelector companySelector;
    public DimensionSelector dimensionsSelector;
    public WeightSelector weightSelector;

    public TableGenerator tableGenerator;
    public ExtendedTableGenerator extendedTableGenerator;

    public TMP_InputField lengthInput;
    public TMP_InputField widthInput;
    public TMP_InputField heightInput;
    public TMP_InputField payloadInput;
    public TMP_InputField dryWeightInput;

    public Button saveButton;
    public Button deleteButton;

    public string currentCompanyKey = "A";
    private UnitSettings currentUnitSettings = new UnitSettings();

    private void Start()
    {
        SetDataEntryFieldsEnabled(false);
        saveButton.interactable = false;
        deleteButton.interactable = false;

        LoadUnitSetting();
        PopulateTable();
    }

    public void OnCompanySelectionChanged()
    {
        currentCompanyKey = companySelector.selectCompanyButtonText.text;
        if(!string.IsNullOrEmpty(currentCompanyKey))
        {
            SetDataEntryFieldsEnabled(true);
            saveButton.interactable = true;
            deleteButton.interactable = true;
            LoadCompanyData();
        }
    }

    public void OnUnitSettingsChanged()
    {
        currentUnitSettings.dimensionUnit = dimensionsSelector.selectDimensionButtonText.text;
        currentUnitSettings.weightUnit = weightSelector.selectWeightButtonText.text;
        UpdateDataForUnitSettings();
    }

    private void LoadCompanyData()
    {
        CompanyData data = dataManager.LoadCompanyData(currentCompanyKey);
        if (data != null)
        {
            ApplyDataToUI(data);
        }
        else
        {
            ClearDataEntryFields();
        }

    }

    private void UpdateDataForUnitSettings()
    {
        CompanyData data = dataManager.LoadCompanyData(currentCompanyKey);
        if (data != null)
        {
            ApplyDataToUI(data);
        }
    }

    public void OnSaveButtonClicked()
    {
        if (!string.IsNullOrEmpty(currentCompanyKey))
        {
            CompanyData data = new CompanyData
            {
                companyName = currentCompanyKey,
                length = float.Parse(lengthInput.text),
                width = float.Parse(widthInput.text),
                height = float.Parse(heightInput.text),
                payload = float.Parse(payloadInput.text),
                dryWeight = float.Parse(dryWeightInput.text),
            };

            dataManager.SaveData(currentCompanyKey, data, currentUnitSettings);
            PopulateTable();
        }
    }

    public void OnDeleteButtonCliced()
    {
        if(!string.IsNullOrEmpty(currentCompanyKey))
        {
            dataManager.DeleteCompantData(currentCompanyKey);
            ClearDataEntryFields();
            PopulateTable();
        }
    }

    private void LoadUnitSetting()
    {
        UnitSettings unitSettings = dataManager.LoadUnitSettings();
        if (unitSettings != null)
        {
            dimensionsSelector.selectDimensionButtonText.text = unitSettings.dimensionUnit;
            weightSelector.selectWeightButtonText.text = unitSettings.weightUnit;
        }
    }

    private void ApplyDataToUI(CompanyData data)
    {
        lengthInput.text = data.length.ToString();
        widthInput.text = data.width.ToString();
        heightInput.text = data.height.ToString();
        payloadInput.text = data.payload.ToString();
        dryWeightInput.text = data.dryWeight.ToString();
    }

    private void ClearDataEntryFields()
    {
        lengthInput.text = "";
        widthInput.text = "";
        heightInput.text = "";
        payloadInput.text = "";
        dryWeightInput.text = "";
    }

    private void SetDataEntryFieldsEnabled(bool isEnabled)
    {
        lengthInput.interactable = isEnabled;
        widthInput.interactable = isEnabled;
        heightInput.interactable = isEnabled;
        payloadInput.interactable = isEnabled;
        dryWeightInput.interactable = isEnabled;
    }

    private void PopulateTable()
    {
        if (tableGenerator != null)
        {
            SaveData saveData = dataManager.LoadAllData();
            tableGenerator.GenerateTable(saveData.companyDataList);
            
        }
        if(extendedTableGenerator != null)
        {
            SaveData saveData = dataManager.LoadAllData();
            if(saveData != null && saveData.companyDataList != null)
            {
                Debug.Log("Populating new table with " + saveData.companyDataList.Count + "entries");
                extendedTableGenerator.GenerateTableWithSerial(saveData.companyDataList);
            }
            else
            {
                Debug.LogError("No Data to populate the table");
            }
        }
        
    }
}
