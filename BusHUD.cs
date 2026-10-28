
using UnityEngine;

public class BusHUD : MonoBehaviour
{
    public BusController bus;

    void OnGUI()
    {
        GUI.Box(
            new Rect(10, 10, 260, 125),
            "PAKISTAN BUS SIMULATOR"
        );

        if (bus == null)
            return;

        GUI.Label(
            new Rect(20, 40, 240, 25),
            "Speed: " + bus.SpeedKmh.ToString("0") +
            " km/h"
        );

        GUI.Label(
            new Rect(20, 65, 240, 25),
            "Fuel: " + bus.fuel.ToString("0") + "%"
        );

        GUI.Label(
            new Rect(20, 90, 240, 25),
            "Earnings: Rs " + bus.money.ToString("0")
        );

        GUI.Label(
            new Rect(10, Screen.height - 30, 500, 25),
            "W/S: Drive | A/D: Steer | SPACE: Brake | E: Pick up"
        );
    }
}

