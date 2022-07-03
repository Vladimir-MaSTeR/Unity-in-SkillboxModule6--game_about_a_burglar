using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainGameScript : MonoBehaviour {
    //настройки игры
    [SerializeField] private float _timerGame;
    [SerializeField] private int _firstPin;
    [SerializeField] private int _secondPin;
    [SerializeField] private int _thirdPin;

    [SerializeField] private Text _timerText;
    [SerializeField] private Text _firstPinText;
    [SerializeField] private Text _secondPinText;
    [SerializeField] private Text _thirdPinText;

    private int _firstPinPars;
    private int _secondPinPars;
    private int _thirdPinPars;


    // Start is called before the first frame update
    void Start()
    {
        _timerText.text = _timerGame.ToString();
        _firstPinText.text = _firstPin.ToString();
        _secondPinText.text = _secondPin.ToString();
        _thirdPinText.text = _thirdPin.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


   public void ClickDrillButton() {
        _firstPinPars = Convert.ToInt32(_firstPinText.text);
        _secondPinPars = Convert.ToInt32(_secondPinText.text);

        _firstPinPars += 1;
        _secondPinPars += 1;

        _firstPinText.text = _firstPinPars.ToString();
        _secondPinText.text += _secondPinPars.ToString();
    }

}
