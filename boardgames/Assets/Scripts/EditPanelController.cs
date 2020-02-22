using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditPanelController : MonoBehaviour {

    [SerializeField] private Text title;
    [SerializeField] private Image texture;
    [SerializeField] private GameObject details;
    [SerializeField] private Button delete;

    public void SetPanel (GameObject obj) {
        delete.onClick.RemoveAllListeners();
        title.text = obj.name;
        delete.onClick.AddListener(() => DeleteComponent(obj));
    }

    private void DeleteComponent(GameObject obj) {
        Destroy(obj);
        gameObject.SetActive(false);
    }
}
