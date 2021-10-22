using UnityEngine;

public class PlayerLogic : MonoBehaviour
{
    public float Distance = 50;
    public LayerMask enemyLayer;
    public GameObject hitObj;

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, enemyLayer))
            {
                hit.transform.GetComponent<Enemy>().TakeDamage(100f * Time.deltaTime);
            }
        }
    }
}
