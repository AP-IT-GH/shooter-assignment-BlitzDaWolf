using PathCreation;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public PathCreator path;
    public GameObject prefab;

    [Min(3)]
    public int totalEnemys;

    void Start()
    {
        for (int i = 0; i < totalEnemys; i++)
        {
            float offset = Random.Range(0, path.path.length);
            var Obj = GameObject.Instantiate(prefab);
            var follower = Obj.GetComponent<Follower>();
            follower.Offset = Random.Range(-2, 2);
            follower.StartPosition = offset;
            follower.path = path;
            Obj.transform.SetParent(transform);
        }
    }
}
