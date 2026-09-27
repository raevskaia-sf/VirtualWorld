using UnityEngine;
using UnityEngine.UI;

public class DogDialog : MonoBehaviour
{
    public static DogDialog Instance;
    public GameObject dialogPanel;
    public Button fuButton;
    public Button feedButton;

    void Awake() { Instance = this; }

    void Start()
    {
        dialogPanel.SetActive(false);
        fuButton.onClick.AddListener(OnFu);
        feedButton.onClick.AddListener(OnFeed);
    }

    void Update()
    {
        if (!dialogPanel.activeSelf) return;

        if (Input.GetKeyDown(KeyCode.R))
        {
            OnFu();
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            OnFeed();
        }
    }

    public void ShowDialog()
    {
        dialogPanel.SetActive(true);
    }

    public void OnFu()
    {
        dialogPanel.SetActive(false);
        DogMovement dog = FindObjectOfType<DogMovement>();
        if (dog != null) dog.RunAway();
        // Задание "Покормить" НЕ засчитывается
    }

    public void OnFeed()
    {
        dialogPanel.SetActive(false);
        DogMovement dog = FindObjectOfType<DogMovement>();
        if (dog != null) dog.GoToBowl();
        // Задание "Покормить" НЕ засчитывается — ждём наполнения миски
    }
}