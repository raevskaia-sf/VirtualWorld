using UnityEngine;

public class Interactable : MonoBehaviour
{
    public string hintMessage = "Нажмите E, чтобы взаимодействовать";

    public virtual void Interact()
    {
        Debug.Log("Взаимодействие с " + gameObject.name);
        
        // Если это предмет, который можно подобрать (назовем его Pickup)
        if (gameObject.CompareTag("Pickup"))
        {
            Destroy(gameObject); // Уничтожаем объект (подбираем)
        }
        // Если это дверь, мы просто выведем сообщение
        else
        {
            Debug.Log("Дверь открыта!");
        }
    }
}