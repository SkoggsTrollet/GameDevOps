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
    SpaceshipController shipController;
    Rigidbody body;

    void Start()
    {
        healthSystem = new HealthSystem(maxHitPoints);
        shipController = new SpaceshipController(minSpeed, maxSpeed, acceleration);

        body = GetComponent<Rigidbody>();
    }

    void Update()
    {
        int verticalDirection = (int) Input.GetAxisRaw("Vertical");
        shipController.UpdateSpeed(Time.deltaTime, verticalDirection);
    }

    void FixedUpdate()
    {
        body.velocity = transform.forward * shipController.GetSpeed();
    }
}
