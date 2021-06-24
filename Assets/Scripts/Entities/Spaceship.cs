using UnityEngine;

public class Spaceship : MonoBehaviour
{
    [Header("HEALTH SYSTEM")]
    [SerializeField] int maxHitPoints = 100;

    [Header("SPACESHIP CONTROLLER")]
    [SerializeField] float minSpeed = 10f;
    [SerializeField] float maxSpeed = 250f;
    [SerializeField] float acceleration = 25f;

    HealthSystem healthSystem;
    SpeedController speedController;
    Rigidbody body;

    void Start()
    {
        healthSystem = new HealthSystem(maxHitPoints);
        speedController = new SpeedController(minSpeed, maxSpeed, acceleration);

        body = GetComponent<Rigidbody>();
    }

    void Update()
    {
        int verticalDirection = (int) Input.GetAxisRaw("Vertical");
        speedController.UpdateSpeed(Time.deltaTime, verticalDirection);
    }

    void FixedUpdate()
    {
        body.velocity = transform.forward * speedController.GetSpeed();
    }
}
