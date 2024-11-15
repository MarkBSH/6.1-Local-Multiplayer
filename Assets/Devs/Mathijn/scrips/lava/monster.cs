using UnityEngine;

public class monster : MonoBehaviour
{
    public Vector3 targetPosition;  
    public float moveSpeed = 1.0f;  

    private Vector3 startPosition;  
    private float journeyLength;
    private float startTime;
    [SerializeField] private Animator Animator;

    void Start()
    {
        startPosition = transform.position;
        journeyLength = Vector3.Distance(startPosition, targetPosition);
        startTime = Time.time;
    }

    void Update()
    {
        float distanceCovered = (Time.time - startTime) * moveSpeed;
        float fractionOfJourney = distanceCovered / journeyLength;
        transform.position = Vector3.Lerp(startPosition, targetPosition, fractionOfJourney);
        if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
        {
            transform.position = targetPosition;
            Animator.SetTrigger("down");
        }
    }
}
