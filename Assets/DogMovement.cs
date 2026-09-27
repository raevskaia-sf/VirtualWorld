using UnityEngine;

public class DogMovement : MonoBehaviour
{
    public Transform bowlPosition;
    public Transform runAwayPosition;
    public float speed = 2f;
    private Transform target;

    public void GoToBowl() { target = bowlPosition; }
    public void RunAway() { target = runAwayPosition; }

    void Update()
    {
        if (target == null) return;

        // Двигаемся по полу (игнорируем Y)
        Vector3 targetPos = new Vector3(target.position.x, transform.position.y, target.position.z);
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        // Поворачиваемся в сторону цели
        Vector3 direction = targetPos - transform.position;
        direction.y = 0;
        if (direction != Vector3.zero)
        {
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
        }
    }
}