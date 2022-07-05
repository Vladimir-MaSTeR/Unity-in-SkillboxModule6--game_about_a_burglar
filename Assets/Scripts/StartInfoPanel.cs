using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartInfoPanel : MonoBehaviour {

    [SerializeField] private GameObject _infoPanel;
    [SerializeField] private Text _infoPanelText;


    private void Start() {
        _infoPanel.SetActive(false);
    }
    public void onClickRulsButton() {
        _infoPanel.SetActive(true);
        _infoPanelText.text = "Любознательность до добра не доводит!!!\n\n" +
            " У Вас будет несколько инструментов (кнопок), сдвигающих пины вверх или вниз. \n\n\n" +
            "Задача — открыть замок за ограниченное время.";
    }
    public void onClickAutorButton() {
        _infoPanel.SetActive(true); 
        _infoPanelText.text = "\n\n\n Автор этого шедевра - MaSTeR";
    }

 
}
