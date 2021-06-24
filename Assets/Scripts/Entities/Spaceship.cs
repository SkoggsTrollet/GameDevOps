using UnityEngine;

public class Spaceship : MonoBehaviour
{
    [Header("HEALTH SYSTEM")]
    [SerializeField] int maxHitPoints = 100;

    [Header("SPACESHIP Speed CONTROLLER")]
    [SerializeField] float minSpeed = 10f;
    [SerializeField] float maxSpeed = 250f;
    [SerializeField] float acceleration = 25f;


    [Header("SPACESHIP Rotation CONTROLLER")]
    [SerializeField] float pitchSpeed = 10f;
    [SerializeField] float yawSpeed = 10f;
    [SerializeField] float rollSpeed = 10f;

    [Header("Mouse box limits")]
    [SerializeField] Vector2 innerLimits = Vector2.zero;
    [SerializeField] Vector2 outerLimits = Vector2.zero;

    HealthSystem healthSystem;
    SpeedController speedController;
    RotationController rotationController;
    Rigidbody body;

    void Start()
    {
        healthSystem = new HealthSystem(maxHitPoints);
        speedController = new SpeedController(minSpeed, maxSpeed, acceleration);
        rotationController = new RotationController(pitchSpeed, yawSpeed, rollSpeed, innerLimits, outerLimits);

        body = GetComponent<Rigidbody>();
    }

    void Update()
    {
        int verticalDirection = (int) Input.GetAxisRaw("Vertical");
        speedController.UpdateSpeed(Time.deltaTime, verticalDirection);

        float horizontalDirection = Input.GetAxisRaw("Horizontal");

        rotationController.UpdateMouseDistance(Input.mousePosition, new Vector2(Screen.width, Screen.height));
        rotationController.UpdateRotation(horizontalDirection, Time.deltaTime);

        transform.Rotate(rotationController.GetDeltaRotation(),Space.Self);
    }

    void FixedUpdate()
    {
        body.velocity = transform.forward * speedController.GetSpeed();
    }
}
