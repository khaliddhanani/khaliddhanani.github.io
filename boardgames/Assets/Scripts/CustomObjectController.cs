using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.UI;
using Button = UnityEngine.UI.Button;

public class CustomObjectController : MonoBehaviour {

    [SerializeField] private Dropdown drop;
    [SerializeField] private GameObject objects;
    [SerializeField] private GameObject detail;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void CreateCustomType (InputField field) {

        Dropdown.OptionData opt = new Dropdown.OptionData(field.text);
        drop.options.Add(opt);
        drop.onValueChanged.AddListener(delegate { SwitchCustomObject(drop.value); });

        field.text = "";
    }

    private void SwitchCustomObject (int index) {
        detail.GetComponentInChildren<Text>().text = drop.options[index].text;
        foreach (Transform button in objects.GetComponentInChildren<Transform>()) {
            Destroy(button.gameObject);
        }
    }

    public void AddCustomObject (InputField field) {
        DefaultControls.Resources temp = new DefaultControls.Resources();
        GameObject button = DefaultControls.CreateButton(temp);
        button.GetComponentInChildren<Text>().text = field.text;
        button.AddComponent<LayoutElement>();
        button.transform.SetParent(objects.transform);
    }
}
