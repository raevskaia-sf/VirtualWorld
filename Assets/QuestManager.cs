using UnityEngine;
using TMPro;

public class QuestManager : MonoBehaviour
{
    public static QuestManager Instance;
    public TextMeshProUGUI questText;

    private bool dogTalked = false;
    private bool dogFed = false;
    private bool radioOn = false;

    void Awake() { Instance = this; }
    void Start() { UpdateQuestText(); }

    public void CompleteQuest(string questName)
    {
        if (questName == "dogTalk") dogTalked = true;
        if (questName == "dogFed") dogFed = true;
        if (questName == "radioOn") radioOn = true;
        UpdateQuestText();
    }

    void UpdateQuestText()
    {
        string text = "<b>ЗАДАНИЯ:</b>\n";
        text += FormatQuest("Поговорить с собакой", dogTalked);
        text += FormatQuest("Покормить собаку", dogFed);
        text += FormatQuest("Включить радио", radioOn);
        questText.text = text;
    }

    string FormatQuest(string questName, bool completed)
    {
        if (completed)
            return "<s>[X] " + questName + "</s>\n";
        else
            return "[ ] " + questName + "\n";
    }
}