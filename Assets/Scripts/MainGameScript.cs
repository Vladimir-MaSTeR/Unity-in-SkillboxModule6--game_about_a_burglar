using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainGameScript : MonoBehaviour {
    //настройки игры
    [SerializeField] private float _timerGame;
    [SerializeField] private int _winningNumber;

    [SerializeField] private GameObject _finishPanel;
    [SerializeField] private GameObject _canvasGame;
    [SerializeField] private GameObject _finishCanvas;
    [SerializeField] private Button _finishHistoryButton;

    //настройки отображения панелей
    [SerializeField] private Text _timerText;
    [SerializeField] private Text _firstPinText;
    [SerializeField] private Text _secondPinText;
    [SerializeField] private Text _thirdPinText;

    [SerializeField] private Text _finishPanelText;

    private int _firstPinPars;
    private int _secondPinPars;
    private int _thirdPinPars;
    private float _timeLeft;


    // Start is called before the first frame update
    void Start() {
        _timerText.text = _timerGame.ToString();

        SetTexttoPin();

        _timeLeft = _timerGame; 
    }

    private void FixedUpdate() {
        if (_timeLeft > 0) {
            ParserPinTextToInt();
            TextColorInPin();
            _timeLeft -= Time.deltaTime;
            UpdateTimeText();
            
        } else {
            _finishPanel.SetActive(true);
            _finishPanelText.text = "Вы проиграли";
            _finishHistoryButton.interactable = false;
        }

        if (_firstPinPars == _winningNumber && _secondPinPars == _winningNumber && _thirdPinPars == _winningNumber) {
            _finishPanel.SetActive(true);
            _timeLeft = _timerGame;
            _finishPanelText.text = "Вы выиграли";
            _finishHistoryButton.interactable = true;

        } 
    }

    public void RestartGame() {
        _finishPanel.SetActive(false);
        _timeLeft = _timerGame;
        SetTexttoPin();
    }

    public void СontinuationHistory() {
        _canvasGame.SetActive(false);
        _finishCanvas.SetActive(true);
    }


   public void ClickDrillButton() {
        ParserPinTextToInt();

        _firstPinPars += 1;
        _secondPinPars -= 1;

        TextDisplayInPin();
    }

    public void ClickHammerButton() {
        ParserPinTextToInt();

        _firstPinPars -= 1;
        _secondPinPars += 2;
        _thirdPinPars += 2;

        TextDisplayInPin();
    }   
    
    public void ClickWrenchButton() {
        ParserPinTextToInt();

        _secondPinPars -= 1;
        _thirdPinPars -= 1;

        TextDisplayInPin();

    }

    public void ClickScrewdriveButton() {
        ParserPinTextToInt();

        _firstPinPars += 1;

        TextDisplayInPin();

    }

    public void ClickPliersButton() {
        ParserPinTextToInt();

        _secondPinPars += 1;

        TextDisplayInPin();

    }

    public void ClickIdeyaButton() {
        ParserPinTextToInt();

        _thirdPinPars += 1;

        TextDisplayInPin();

    }

    private void ParserPinTextToInt() {
        _firstPinPars = Convert.ToInt32(_firstPinText.text);
        _secondPinPars = Convert.ToInt32(_secondPinText.text);
        _thirdPinPars = Convert.ToInt32(_thirdPinText.text);
    }

    private void TextDisplayInPin() {
        if (_firstPinPars >= 0 && _firstPinPars <= 10) {
            _firstPinText.text = _firstPinPars.ToString(); 
        }
        if (_secondPinPars >= 0 && _secondPinPars <= 10) {
            _secondPinText.text = _secondPinPars.ToString();
        }
        if (_thirdPinPars >= 0 && _thirdPinPars <= 10) {
            _thirdPinText.text = _thirdPinPars.ToString();
        }
    }

    private void TextColorInPin() {
        if (_firstPinPars == _winningNumber) {
            _firstPinText.color = Color.green;
        } else{
            _firstPinText.color = Color.white;
        }

        if (_secondPinPars == _winningNumber){
            _secondPinText.color = Color.green;
        } else {
            _secondPinText.color = Color.white;
        }

        if (_thirdPinPars == _winningNumber){
            _thirdPinText.color = Color.green;
        } else {
            _thirdPinText.color = Color.white;
        }
    }

    private void UpdateTimeText() {
        if (_timeLeft < 0) {
            _timeLeft = 0;
        }

        float seconds = Mathf.FloorToInt(_timeLeft % 60);
        _timerText.text = seconds.ToString();
    }

    private int NewRandomNumber(int min, int max) {
        System.Random random = new System.Random();

        return random.Next(min, max);
    }

    private void SetTexttoPin() {
        _firstPinText.text = NewRandomNumber(0, 10).ToString();
        _secondPinText.text = NewRandomNumber(0, 10).ToString();
        _thirdPinText.text = NewRandomNumber(0, 10).ToString();
    }



}
