using UnityEngine;

public class PlayerMovemement : MonoBehaviour
{
    public float MovementSpeed = 5;
    public float DashSpeed = 10;
    public float Banking = 5;

    public float max;

    float currentBanking;
    float currentPosition = 0;

    void Update()
    {
        float offset = Input.GetAxis("Horizontal");
        currentPosition += offset * MovementSpeed * Time.deltaTime;

        {
            // Banking
            currentBanking += offset * Banking * Time.deltaTime;
            if(offset == 0)
            {
                currentBanking = Mathf.Lerp(currentBanking, 0, 10 * Time.deltaTime);
            }
            currentBanking = Mathf.Clamp(currentBanking, -45, 45);
            transform.localEulerAngles = Vector3.back * currentBanking;
        }

        currentPosition = Mathf.Clamp(currentPosition, -max, max);
        transform.localPosition = new Vector3(currentPosition, 0, 0);
    }
}
