using UnityEngine;
using TMPro;

public class QuestManager : MonoBehaviour
{
    public static QuestManager Instance;
    public TextMeshProUGUI questText;

    private bool dogTalked = false;
    private bool dogFed = false;
    private bool radioOn = false;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        UpdateQuestText();
    }

    public void CompleteQuest(string questName)
    {
        if (questName == "dogTalk") dogTalked = true;
        if (questName == "dogFeed") dogFed = true;
        if (questName == "radioOn") radioOn = true;
        UpdateQuestText();
    }

    void UpdateQuestText()
    {
        string text = "Задания:\n";
        text += (dogTalked ? "✅" : "⬜") + " Поговорить с собакой\n";
        text += (dogFed ? "✅" : "⬜") + " Покормить собаку\n";
        text += (radioOn ? "✅" : "⬜") + " Включить радио";
        questText.text = text;
    }
}