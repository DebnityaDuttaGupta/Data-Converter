using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DimensionSelector : MonoBehaviour
{
    public GameObject dimensionScrollView;
    public TMP_Text selectDimensionButtonText;

    void Start()
    {
        dimensionScrollView.SetActive(false);
    }

    public void OnSlectDimensionButtonClicked()
    {
        dimensionScrollView.SetActive(!dimensionScrollView.activeSelf);
    }

    public void OnDimensionSelected(TMP_Text dimensionText)
    {
        selectDimensionButtonText.text = dimensionText.text;
        dimensionScrollView.SetActive(false);
    }
}
