using UnityEngine;
using TMPro; // Используем TextMeshPro для текста

public class PlayerInteract : MonoBehaviour
{
    public float interactDistance = 3f; // Дистанция взаимодействия
    public TextMeshProUGUI hintText; // Ссылка на текст подсказки на экране

    void Update()
    {
        // Пускаем луч из камеры (или из игрока) вперед
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        // Если луч попал в объект на расстоянии interactDistance
        if (Physics.Raycast(ray, out hit, interactDistance))
        {
            // 1. ПРОВЕРКА НА ДВЕРЬ (RealDoor)
            RealDoor realDoor = hit.collider.GetComponent<RealDoor>();
            if (realDoor != null)
            {
                if (hintText != null) 
                {
                    hintText.text = "Нажмите E, чтобы открыть/закрыть дверь";
                    hintText.enabled = true;
                }
                
                if (Input.GetKeyDown(KeyCode.E)) 
                {
                    realDoor.Interact(); // Вызываем метод открытия двери
                }
                return; // Выходим из Update, чтобы не проверять дальше
            }

            // 2. ПРОВЕРКА НА ОБЫЧНЫЙ ПРЕДМЕТ (Interactable)
            Interactable interactable = hit.collider.GetComponent<Interactable>();
            if (interactable != null)
            {
                if (hintText != null) 
                {
                    hintText.text = interactable.hintMessage; // Показываем текст из скрипта предмета
                    hintText.enabled = true;
                }

                if (Input.GetKeyDown(KeyCode.E))
                {
                    interactable.Interact(); // Вызываем взаимодействие
                }
                return;
            }

            // 3. ЕСЛИ ПОПАЛИ ВО ЧТО-ТО ДРУГОЕ (стена, пол)
            if (hintText != null) hintText.enabled = false;
        }
        else
        {
            // Если луч никуда не попал, скрываем текст
            if (hintText != null) hintText.enabled = false;
        }
    }
}