using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // HUD
    [SerializeField] private TMP_Text _livesAmountText;
    [SerializeField] private TMP_Text _survivalAmountText;
    [SerializeField] private TMP_Text _quitText;
    [SerializeField] private Canvas _hud;
    private float _survivalAmount;


    // MENU
    [SerializeField] private Canvas _menu;

    // JOURNAL
    [SerializeField] private Canvas _journal;

    // END GAME SCREEN
    

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


    public void InitializePlayerDataUI(int livesAmount, int filmsAmount) {
        SetLivesText(livesAmount);
        SetFilmsText(filmsAmount);
    }

    public void SetLivesText(int amount) {
        _livesAmountText.text = amount.ToString();
    }

    public void SetFilmsText(int amount) {
        Debug.Log(amount);
    }

    public void SetSurvivalTimeText(float amount) {
        _survivalAmountText.text = amount.ToString("0.00");
    }

    public void ShowQuitText() {
        _quitText.gameObject.SetActive(true);

    }

    public void ShowMenu(bool option) {
        _menu.gameObject.SetActive(option);
    }

    public void ShowJournal(bool option) {
        _journal.gameObject.SetActive(option);
    }

    

    
}
