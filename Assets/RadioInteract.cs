using UnityEngine;

public class RadioInteract : InteractPrompt
{
    private AudioSource audioSource;
    private bool isPlaying = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (promptUI != null) promptUI.SetActive(false);
    }

    protected override void Interact()
    {
        isPlaying = !isPlaying;
        if (isPlaying)
        {
            audioSource.Play();
            if (QuestManager.Instance != null)
                QuestManager.Instance.CompleteQuest("radioOn");
        }
        else
        {
            audioSource.Pause();
        }
    }
}