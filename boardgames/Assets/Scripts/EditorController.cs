using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class EditorController : MonoBehaviour {

    [SerializeField] private ComponentController ccontroller;
    [SerializeField] private GameObject editPanel;
    private GameObject currentComponent;

    public bool componentIsPlaced;

    void OnEnable() {
        StartCoroutine(SetParentForEditor());
    }

    void Update() {
        if (currentComponent && !componentIsPlaced) {
            currentComponent.transform.position = Input.mousePosition;
        }
    }

    public void SetCurrentComponent(GameObject component) {
        currentComponent = component;
    }

    public void SetComponentIsPlaced(bool placed) {
        componentIsPlaced = placed;
    }

    IEnumerator SetParentForEditor() {
        yield return new WaitUntil(() => currentComponent);
        currentComponent.transform.SetParent(this.transform);
    }

    public void PlaceComponent() {
        GameObject obj = currentComponent;
        obj.GetComponentInChildren<Button>().onClick.AddListener(() => OpenEditPanel(obj));
        componentIsPlaced = true;
        currentComponent = null;
    }

    public void SwitchToComponent() {
        ccontroller.gameObject.SetActive(true);
        this.gameObject.SetActive(false);
    }

    private void OpenEditPanel (GameObject obj) {
        editPanel.SetActive(true);
        editPanel.GetComponentInChildren<EditPanelController>().SetPanel(obj);
    }
}
