using UnityEngine;

public class DogInteract : InteractPrompt
{
    public GameObject barkUI;
    public float barkDuration = 2f;
    private float barkTimer = 0f;

    protected override void Interact()
    {
        // 1. Показать "Гав!"
        if (barkUI != null)
        {
            barkUI.SetActive(true);
            barkTimer = barkDuration;
        }

        // 2. Показать диалог с кнопками
        if (DogDialog.Instance != null)
        {
            DogDialog.Instance.ShowDialog();
        }

        // 3. Отметить задание "Поговорить с собакой"
        if (QuestManager.Instance != null)
        {
            QuestManager.Instance.CompleteQuest("dogTalk");
        }
    }

    protected override void Update()
    {
        base.Update();

        if (barkTimer > 0)
        {
            barkTimer -= Time.deltaTime;
            if (barkTimer <= 0 && barkUI != null)
            {
                barkUI.SetActive(false);
            }
        }
    }
}