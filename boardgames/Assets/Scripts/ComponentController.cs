using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ComponentController : MonoBehaviour {

    [SerializeField] private GameObject[] panels;
    [SerializeField] private EditorController editor;
	
	// Update is called once per frame
	void Update () {
		
	}

    private void HidePanels() {
        foreach (GameObject panel in panels) {
            panel.SetActive(false);
        }
    }

    public void ShowPanel(GameObject showPanel) {
        foreach (GameObject panel in panels) {
            if (ReferenceEquals(panel, showPanel)) {
                panel.SetActive(true);
            }
            else {
                panel.SetActive(false);
            }
        }
    }

    public void SwitchToEditor () {
        editor.gameObject.SetActive(true);
        HidePanels();
        this.gameObject.SetActive(false);
    }

    public void SwitchToEditor (SwitchToEditorHelper parms) {
        editor.gameObject.SetActive(true);
        if (parms.prefab) {
            editor.SetCurrentComponent(CreateComponent(parms.obj));
        }
        else {
            editor.SetCurrentComponent(parms.obj);
        }
        editor.SetComponentIsPlaced(false);
        HidePanels();
        this.gameObject.SetActive(false);
    }

    private GameObject CreateComponent(GameObject prefab) {
        return (GameObject)Instantiate(prefab, Input.mousePosition, Quaternion.identity);
    }

}
