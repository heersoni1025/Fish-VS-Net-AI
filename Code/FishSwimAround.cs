using UnityEngine;

public class FishSwimAround : MonoBehaviour
{
    public float swimSpeed = 1.0f;
    public float turnSpeed = 2.0f;

    public Vector3 tankMin = new Vector3(-4f, 0.2f, -1.5f);
    public Vector3 tankMax = new Vector3(4f, 2.5f, 1.5f);

    private Vector3 targetPoint;

    void Start()
    {
        PickNewTarget();
    }

    void Update()
    {
        Vector3 direction = targetPoint - transform.position;

        if (direction.magnitude < 0.3f)
        {
            PickNewTarget();
            return;
        }

        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(
            transform.rotation,
            targetRotation,
            turnSpeed * Time.deltaTime
        );

        transform.position += transform.forward * swimSpeed * Time.deltaTime;

        if (!InsideTank())
        {
            PickNewTarget();
        }
    }

    void PickNewTarget()
    {
        targetPoint = new Vector3(
            Random.Range(tankMin.x, tankMax.x),
            Random.Range(tankMin.y, tankMax.y),
            Random.Range(tankMin.z, tankMax.z)
        );
    }

    bool InsideTank()
    {
        Vector3 p = transform.position;

        return p.x > tankMin.x && p.x < tankMax.x &&
               p.y > tankMin.y && p.y < tankMax.y &&
               p.z > tankMin.z && p.z < tankMax.z;
    }
}
