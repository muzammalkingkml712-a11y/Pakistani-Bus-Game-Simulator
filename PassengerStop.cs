
using UnityEngine;

public class PassengerStop : MonoBehaviour
{
    public string stopName = "Kamalia Bus Stop";
    public string destination = "Multan";

    public int waitingPassengers = 5;
    public float farePerPassenger = 120f;

    private bool completed = false;

    void OnTriggerStay(Collider other)
    {
        if (completed)
            return;

        BusController bus =
            other.GetComponentInParent<BusController>();

        if (bus == null)
            return;

        if (bus.SpeedKmh > 5f)
            return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            int passengers = waitingPassengers;

            float totalFare =
                passengers * farePerPassenger;

            bus.AddMoney(totalFare);

            waitingPassengers = 0;
            completed = true;

            Debug.Log(
                passengers + " passengers boarded at " +
                stopName + ". Destination: " +
                destination + ". Fare: Rs " + totalFare
            );
        }
    }
}

