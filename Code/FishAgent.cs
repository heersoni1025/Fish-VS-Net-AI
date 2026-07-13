using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;

public class FishAgent : Agent
{
    [Header("Objects")]
    public FallingNet fallingNet;
    public Transform net;

    [Header("Movement")]
    public float moveSpeed = 0.1f;
    public float turnSpeed = 20f;
    public float verticalSpeed = 0.1f;

    [Header("Tank Bounds")]
    public Vector3 tankMin = new Vector3(-3f, 0.4f, -1.2f);
    public Vector3 tankMax = new Vector3(3f, 1.5f, 1.2f);

    [Header("Curriculum")]
    public int stage = 1;
    public int episodesToNextStage = 20;

    private int episodeCount = 0;
    private int stageProgress = 0;
    private float previousFoodDistance;

    private bool trapped = false;
    private float trappedTimer = 0f;

    public float rewardDisplay;

    public override void Initialize()
    {
        ApplyCurriculum();
    }

    public override void OnEpisodeBegin()
    {
        trapped = false;
        trappedTimer = 0f;

        episodeCount++;
        stageProgress++;

        if (stageProgress >= episodesToNextStage && stage < 3)
        {
            stage++;
            stageProgress = 0;
            ApplyCurriculum();
        }

        transform.SetParent(null);
        transform.position = RandomPointInTank();
        transform.rotation = Quaternion.Euler(0f, Random.Range(0f, 360f), 0f);

        if (fallingNet != null)
            fallingNet.ResetNet();

        previousFoodDistance = DistanceToNearestFood();

        ApplyCurriculum();
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(transform.position);
        sensor.AddObservation(transform.forward);

        Transform nearestFood = GetNearestFood();
        sensor.AddObservation(nearestFood != null ? nearestFood.position - transform.position : Vector3.zero);

        sensor.AddObservation(net != null ? net.position - transform.position : Vector3.zero);

        sensor.AddObservation(stage);
        sensor.AddObservation(trapped ? 1f : 0f);
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        if (trapped)
        {
            AddReward(-0.005f);
            trappedTimer += Time.deltaTime;

            if (net != null)
                transform.position = net.position + new Vector3(0f, -0.35f, 0f);

            if (trappedTimer >= 8.0f)
            {
                AddReward(-2.0f);
                EndEpisode();
            }

            rewardDisplay = GetCumulativeReward();
            return;
        }

        float turn = Mathf.Clamp(actions.ContinuousActions[0], -1f, 1f);
        float vertical = Mathf.Clamp(actions.ContinuousActions[1], -1f, 1f);

        transform.Rotate(Vector3.up, turn * turnSpeed * Time.deltaTime);

        Vector3 movement = transform.forward * moveSpeed;
        movement += Vector3.up * vertical * verticalSpeed;

        transform.position += movement * Time.deltaTime;

        KeepInsideTank();

        AddReward(-0.001f);

        float currentFoodDistance = DistanceToNearestFood();

        if (currentFoodDistance < previousFoodDistance)
            AddReward(0.01f);
        else
            AddReward(-0.003f);

        previousFoodDistance = currentFoodDistance;

        if (net != null && stage > 1)
        {
            float netDistance = Vector3.Distance(transform.position, net.position);

            if (netDistance < 1.0f)
                AddReward(-0.01f);
        }

        rewardDisplay = GetCumulativeReward();
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        ActionSegment<float> actions = actionsOut.ContinuousActions;

        actions[0] = Input.GetAxis("Horizontal");

        if (Input.GetKey(KeyCode.E))
            actions[1] = 1f;
        else if (Input.GetKey(KeyCode.Q))
            actions[1] = -1f;
        else
            actions[1] = 0f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Food"))
        {
            AddReward(1.0f);

            FoodPellet pellet = other.GetComponent<FoodPellet>();
            if (pellet != null)
                pellet.RandomizePosition();

            previousFoodDistance = DistanceToNearestFood();
        }

        if (other.CompareTag("Net") && stage > 1)
        {
            TrapFish();
        }
    }

    private Transform GetNearestFood()
    {
        GameObject[] foods = GameObject.FindGameObjectsWithTag("Food");

        Transform nearest = null;
        float closestDistance = Mathf.Infinity;

        foreach (GameObject foodObject in foods)
        {
            float distance = Vector3.Distance(transform.position, foodObject.transform.position);

            if (distance < closestDistance)
            {
                closestDistance = distance;
                nearest = foodObject.transform;
            }
        }

        return nearest;
    }

    private float DistanceToNearestFood()
    {
        Transform nearestFood = GetNearestFood();

        if (nearestFood == null)
            return 999f;

        return Vector3.Distance(transform.position, nearestFood.position);
    }

    private void TrapFish()
    {
        if (trapped)
            return;

        trapped = true;
        trappedTimer = 0f;

        AddReward(-1.5f);

        if (net != null)
        {
            transform.SetParent(net, true);
            transform.position = net.position + new Vector3(0f, -0.35f, 0f);
            transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y, 90f);
        }
    }

    private void KeepInsideTank()
    {
        Vector3 p = transform.position;
        bool hitWall = false;

        if (p.x < tankMin.x || p.x > tankMax.x ||
            p.y < tankMin.y || p.y > tankMax.y ||
            p.z < tankMin.z || p.z > tankMax.z)
        {
            hitWall = true;
        }

        transform.position = new Vector3(
            Mathf.Clamp(p.x, tankMin.x, tankMax.x),
            Mathf.Clamp(p.y, tankMin.y, tankMax.y),
            Mathf.Clamp(p.z, tankMin.z, tankMax.z)
        );

        if (hitWall)
        {
            AddReward(-0.1f);
            transform.Rotate(Vector3.up, Random.Range(90f, 180f));
        }
    }

    private Vector3 RandomPointInTank()
    {
        return new Vector3(
            Random.Range(tankMin.x, tankMax.x),
            Random.Range(tankMin.y, tankMax.y),
            Random.Range(tankMin.z, tankMax.z)
        );
    }

    private void ApplyCurriculum()
    {
        if (fallingNet == null)
            return;

        if (stage == 1)
        {
            fallingNet.gameObject.SetActive(false);
        }
        else if (stage == 2)
        {
            fallingNet.gameObject.SetActive(true);
            fallingNet.SetSpeed(0.04f);
        }
        else
        {
            fallingNet.gameObject.SetActive(true);
            fallingNet.SetSpeed(0.06f);
        }
    }

    void OnGUI()
    {
        GUIStyle labelStyle = new GUIStyle(GUI.skin.label);
        labelStyle.fontSize = 22;
        labelStyle.normal.textColor = Color.white;

        GUIStyle boxStyle = new GUIStyle(GUI.skin.box);
        boxStyle.fontSize = 24;
        boxStyle.normal.textColor = Color.white;

        GUI.Box(new Rect(10, 10, 420, 220), "Agent Info", boxStyle);

        GUI.Label(new Rect(25, 50, 390, 30), "Episode: " + episodeCount, labelStyle);
        GUI.Label(new Rect(25, 85, 390, 30), "Step: " + StepCount + " / " + MaxStep, labelStyle);
        GUI.Label(new Rect(25, 120, 390, 30), "Reward: " + GetCumulativeReward().ToString("F2"), labelStyle);
        GUI.Label(new Rect(25, 155, 390, 30), "Stage: " + stage + " | Progress: " + stageProgress + " / " + episodesToNextStage, labelStyle);
        GUI.Label(new Rect(25, 190, 390, 30), "Trapped: " + trapped, labelStyle);
    }
}
