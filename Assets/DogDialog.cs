using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DogDialog : MonoBehaviour
{
    public static DogDialog Instance;
    public GameObject dialogPanel;
    public Button fuButton;
    public Button feedButton;
    public GameObject dogFood;

    void Awake() { Instance = this; }

    void Start()
    {
        dialogPanel.SetActive(false);
        fuButton.onClick.AddListener(OnFu);
        feedButton.onClick.AddListener(OnFeed);
    }

    public void ShowDialog()
    {
        dialogPanel.SetActive(true);
    }

    void OnFu()
    {
        dialogPanel.SetActive(false);
        DogMovement dog = FindObjectOfType<DogMovement>();
        if (dog != null) dog.RunAway();
        QuestManager.Instance.CompleteQuest("dogFed");
    }

    void OnFeed()
    {
        dialogPanel.SetActive(false);
        if (dogFood != null) dogFood.SetActive(true);
        DogMovement dog = FindObjectOfType<DogMovement>();
        if (dog != null) dog.GoToBowl();
        QuestManager.Instance.CompleteQuest("dogFed");
    }
}