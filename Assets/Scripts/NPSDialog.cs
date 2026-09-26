using UnityEngine;
using TMPro;

public class NPCDialog : MonoBehaviour
{
    public GameObject dialogUI;
    public string npcName = "Тётя Маша";
    public string[] dialogLines = {
        "Тетя Маша: Привет, ты занята?",
        "Я: Нет, а что?",
        "Тетя Маша: Покорми, пожалуйста, собаку."
    };
    public float interactDistance = 3f;
    private int currentLine = 0;
    private bool isShowing = false;

    void Start()
    {
        if (dialogUI != null)
            dialogUI.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            float distance = Vector3.Distance(transform.position, Camera.main.transform.position);
            if (distance <= interactDistance)
            {
                if (!isShowing)
                {
                    isShowing = true;
                    currentLine = 0;
                    dialogUI.SetActive(true);
                }
                else
                {
                    currentLine++;
                    if (currentLine >= dialogLines.Length)
                    {
                        isShowing = false;
                        dialogUI.SetActive(false);
                        return;
                    }
                }

                TextMeshProUGUI textComponent = dialogUI.GetComponentInChildren<TextMeshProUGUI>();
                if (textComponent != null)
                    textComponent.text = dialogLines[currentLine];
            }
        }
    }
}