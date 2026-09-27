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
        if (target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }
}