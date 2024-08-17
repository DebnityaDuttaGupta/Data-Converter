using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager_NewScene : MonoBehaviour
{
    public GameObject SpecificationPanel;
    public GameObject HighlightSpecification;
    public GameObject DoorSettingPanel;
    public GameObject DoorSettingHighlight;
    public GameObject BackgroundPanel;
    public Camera mainCamera;

    private bool is2Dview = true;
    
    private void Start()
    {
        BackgroundPanel.SetActive(true);
        SpecificationPanel.SetActive(false);
        DoorSettingPanel.SetActive(false);
        Set2DView();
    }

    // Update is called once per frame
    public void ShowSpecificationPanel()
    {
        SpecificationPanel.SetActive(true);
        HighlightSpecification.SetActive(true);
        DoorSettingPanel.SetActive(false);
        DoorSettingHighlight.SetActive(false);
    }

    public void ShowDoorSettingPanel()
    {
        DoorSettingPanel.SetActive(true);
        DoorSettingHighlight.SetActive(true);
        SpecificationPanel.SetActive(false);
        HighlightSpecification.SetActive(false);
    }

    public void SwitchTo3DView()
    {
        Set3DView();
        BackgroundPanel.SetActive(false);
        DoorSettingPanel.SetActive(false);
        DoorSettingHighlight.SetActive(false);
        SpecificationPanel.SetActive(false);
        HighlightSpecification.SetActive(false);
    }

    private void Set2DView()
    {
        is2Dview = true;
        mainCamera.orthographic = true;
    }

    private void Set3DView()
    {
        is2Dview = false;
        mainCamera.orthographic = false;
    }
}
