using UnityEngine;

public class BowlInteract : InteractPrompt
{
    public GameObject dogFood;

    protected override void Interact()
    {
        if (dogFood != null)
            dogFood.SetActive(true);

        // Засчитываем задание "Покормить собаку"
        if (QuestManager.Instance != null)
            QuestManager.Instance.CompleteQuest("dogFed");
    }
}