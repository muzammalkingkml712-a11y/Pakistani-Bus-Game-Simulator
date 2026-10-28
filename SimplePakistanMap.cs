
using UnityEngine;

public class SimplePakistanMap : MonoBehaviour
{
    public int roadLength = 600;

    void Start()
    {
        CreateObject(
            "Green Fields",
            new Vector3(0, -1, 300),
            new Vector3(180, 1, 700)
        );

        CreateObject(
            "Pakistan Road",
            new Vector3(0, 0, 300),
            new Vector3(12, 0.25f, roadLength)
        );

        for (int z = 5; z < roadLength; z += 12)
        {
            CreateObject(
                "Road Marking",
                new Vector3(0, 0.15f, z),
                new Vector3(0.2f, 0.03f, 5)
            );
        }

        CreateHouse(-12, 50);
        CreateHouse(12, 100);
        CreateHouse(-12, 170);
        CreateHouse(12, 260);
        CreateHouse(-12, 350);

        CreateStop(
            "Kamalia Bus Stop", -5, 45, "Khanewal"
        );

        CreateStop(
            "Village Bus Stop", 5, 210, "Multan"
        );

        CreateStop(
            "Multan Terminal", -5, 430, "Multan"
        );
    }

    void CreateHouse(float x, float z)
    {
        CreateObject(
            "Village House",
            new Vector3(x, 1.5f, z),
            new Vector3(5, 3, 5)
        );
    }

    void CreateStop(
        string stopName,
        float x,
        float z,
        string destination)
    {
        GameObject stop = new GameObject(stopName);

        stop.transform.position =
            new Vector3(x, 1, z);

        BoxCollider trigger =
            stop.AddComponent<BoxCollider>();

        trigger.isTrigger = true;
        trigger.size = new Vector3(10, 3, 10);

        PassengerStop passengers =
            stop.AddComponent<PassengerStop>();

        passengers.stopName = stopName;
        passengers.destination = destination;
        passengers.waitingPassengers = 5;
    }

    void CreateObject(
        string objectName,
        Vector3 position,
        Vector3 scale)
    {
        GameObject obj =
            GameObject.CreatePrimitive(PrimitiveType.Cube);

        obj.name = objectName;
        obj.transform.position = position;
        obj.transform.localScale = scale;
    }
}

