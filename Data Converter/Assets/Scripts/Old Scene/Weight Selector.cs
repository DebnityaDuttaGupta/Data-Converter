using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WeightSelector : MonoBehaviour
{
    public GameObject weightScrollView;
    public TMP_Text selectWeightButtonText;
    void Start()
    {
        weightScrollView.SetActive(false);
    }

    public void OnSelectWeightButtonClicked()
    {
        weightScrollView.SetActive(!weightScrollView.activeSelf);
    }

    public void OnWeightSelected(TMP_Text weightText)
    {
        selectWeightButtonText.text = weightText.text;
        weightScrollView.SetActive(false);
    }
}
