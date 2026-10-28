
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BusController : MonoBehaviour
{
    public float acceleration = 12f;
    public float maxSpeed = 25f;
    public float steeringSpeed = 55f;
    public float brakeStrength = 20f;

    public float fuel = 100f;
    public float money = 0f;

    private Rigidbody rb;

    public float SpeedKmh
    {
        get { return rb.velocity.magnitude * 3.6f; }
    }

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.mass = 8500f;
        rb.centerOfMass = new Vector3(0f, -0.8f, 0f);
        rb.interpolation = RigidbodyInterpolation.Interpolate;
    }

    void FixedUpdate()
    {
        float throttle = Input.GetAxis("Vertical");
        float steer = Input.GetAxis("Horizontal");

        if (fuel > 0f && throttle > 0f &&
            SpeedKmh < maxSpeed)
        {
            rb.AddForce(
                transform.forward * throttle * acceleration,
                ForceMode.Acceleration
            );

            fuel -= Time.fixedDeltaTime * 0.02f;
        }

        if (throttle < 0f)
        {
            if (SpeedKmh > 2f)
            {
                rb.AddForce(
                    -rb.velocity.normalized * brakeStrength,
                    ForceMode.Acceleration
                );
            }
            else if (fuel > 0f)
            {
                rb.AddForce(
                    -transform.forward * throttle * acceleration * 0.5f,
                    ForceMode.Acceleration
                );
            }
        }

        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(
                -rb.velocity.normalized * brakeStrength,
                ForceMode.Acceleration
            );
        }

        if (rb.velocity.magnitude > 0.5f)
        {
            rb.MoveRotation(
                rb.rotation * Quaternion.Euler(
                    0f,
                    steer * steeringSpeed * Time.fixedDeltaTime,
                    0f
                )
            );
        }

        fuel = Mathf.Clamp(fuel, 0f, 100f);
    }

    public void AddMoney(float amount)
    {
        money += Mathf.Max(0f, amount);
    }

    public void Refuel(float amount)
    {
        fuel = Mathf.Clamp(fuel + amount, 0f, 100f);
    }
}

