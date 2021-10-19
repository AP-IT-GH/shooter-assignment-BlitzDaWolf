using UnityEngine;
using PathCreation;

public class Follower : MonoBehaviour
{
    public PathCreator path;
    public float speed = 5f;
    public float StartPosition = 0;
    float distanceTravelled;

    private void Start()
    {
        distanceTravelled = StartPosition;
    }

    private void Update()
    {
        distanceTravelled += speed * Time.deltaTime;
        transform.position = path.path.GetPointAtDistance(distanceTravelled);
        transform.rotation = path.path.GetRotationAtDistance(distanceTravelled);
    }
}
