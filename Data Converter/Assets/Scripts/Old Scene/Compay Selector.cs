using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CompaySelector : MonoBehaviour
{
    public Button selectCompanyButton;
    public GameObject companyScrollView;
    public TextMeshProUGUI selectCompanyButtonText;

    void Start()
    {
        companyScrollView.SetActive(false);

        selectCompanyButton.onClick.AddListener(ToggleCompantScrollView);
    }

    private void ToggleCompantScrollView()
    {
        companyScrollView.SetActive(!companyScrollView.activeSelf);
    }

    public void OnCompanySelected(string companyName)
    {
        selectCompanyButtonText.text = companyName;

        companyScrollView.SetActive(false);
    }
}
