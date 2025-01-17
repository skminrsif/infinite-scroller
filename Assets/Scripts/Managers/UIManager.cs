using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _livesAmountText;
    [SerializeField] private TMP_Text _survivalAmountText;
    [SerializeField] private TMP_Text _quitText;
    [SerializeField] private Canvas _canvas;
    

    private int _livesAmount;
    private float _survivalAmount;

    public static UIManager Instance {
        get;
        private set;

    }

    private void Awake () {
        if (Instance != null && Instance != this) {
            Destroy(this);

        } else {
            Instance = this;
            
        }
    }

    public float GetSurvivalTime() {
        return _survivalAmount;
    }

    public void SetSurvivalTime(float survivalAmount) {
        _survivalAmount = survivalAmount;
    }

    public int GetLivesAmount() {
        return _livesAmount;
    }
    
    public void SetLivesAmount(int amount) {
        _livesAmount = amount;
    }
    
    public void ChangeLivesText(int amount) {
        _livesAmountText.text = amount.ToString();
    }

    public void ChangeSurvivalTimeText(float amount) {
        _survivalAmountText.text = amount.ToString("0.00");
    }

    public bool ShowQuitText() {
        _quitText.gameObject.SetActive(true);
        return true;
    }
}
