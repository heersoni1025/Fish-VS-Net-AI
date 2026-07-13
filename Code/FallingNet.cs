using UnityEngine;

public class FallingNet : MonoBehaviour
{
    public Vector3 tankMin = new Vector3(-3f, 0.4f, -1.2f);
    public Vector3 tankMax = new Vector3(3f, 1.8f, 1.2f);

    public float topY = 1.8f;
    public float bottomY = 0.05f;
    public float fallSpeed = 0.04f;
    public float waitTime = 4f;

    private float timer;
    private bool falling = true;

    public bool IsFalling => falling;

    void Start()
    {
        ResetNet();
    }

    void Update()
    {
        if (falling)
        {
            Vector3 pos = transform.position;
            pos.y -= fallSpeed * Time.deltaTime;
            transform.position = pos;

            if (transform.position.y <= bottomY)
            {
                transform.position = new Vector3(transform.position.x, bottomY, transform.position.z);
                falling = false;
                timer = waitTime;
            }
        }
        else
        {
            timer -= Time.deltaTime;

            if (timer <= 0f)
            {
                ResetNet();
            }
        }
    }

    public void ResetNet()
    {
        float randomX = Random.Range(tankMin.x, tankMax.x);
        float randomZ = Random.Range(tankMin.z, tankMax.z);

        transform.position = new Vector3(randomX, topY, randomZ);
        falling = true;
    }

    public void SetSpeed(float speed)
    {
        fallSpeed = speed;
    }
}
