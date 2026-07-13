using UnityEngine;

public class FoodPellet : MonoBehaviour
{
    public Vector3 tankMin = new Vector3(-3f, 0.4f, -1.2f);
    public Vector3 tankMax = new Vector3(3f, 1.5f, 1.2f);

    void Start()
    {
        RandomizePosition();
    }

    public void RandomizePosition()
    {
        transform.position = new Vector3(
            Random.Range(tankMin.x, tankMax.x),
            Random.Range(tankMin.y, tankMax.y),
            Random.Range(tankMin.z, tankMax.z)
        );
    }
}
