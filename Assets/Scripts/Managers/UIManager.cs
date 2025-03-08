using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // HUD
    [SerializeField] private TMP_Text _livesAmountText;
    [SerializeField] private TMP_Text _survivalAmountText;
    [SerializeField] private TMP_Text _quitText;
    [SerializeField] private TMP_Text _finalText;
    [SerializeField] private Canvas _hud;
    private float _survivalAmount;


    // MENU
    [SerializeField] private Canvas _menu;

    // JOURNAL
    [SerializeField] private Canvas _journal;
    [SerializeField] private RawImage _image;
    [SerializeField] private Button _leftButton;
    [SerializeField] private Button _rightButton;
    public UnityEvent onShowImage;
    
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

    public void ShowImage(string filePath) {
        byte [] rawData = System.IO.File.ReadAllBytes(filePath);
        Texture2D texture = new Texture2D(1280, 720);
        ImageConversion.LoadImage(texture, rawData);
        _image.texture = texture;        
    }

    public void ShowLeftButton(bool option) {
        _leftButton.gameObject.SetActive(option);
    }    
    
    public void ShowRightButton(bool option) {
        _rightButton.gameObject.SetActive(option);
    }

    public void ShowFinalScore() {
        _finalText.text = "Final Score: " +  GameTimeManager.Instance.GetGameTime().ToString("0.00");
        _finalText.gameObject.SetActive(true);
    }
 
    

    
}
