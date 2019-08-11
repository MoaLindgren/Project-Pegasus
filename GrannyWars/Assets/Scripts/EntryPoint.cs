using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    enum GameState
    {
        Driving
    }
    private GameState state;
    private VehicleHandler vehicleHandler;
    [SerializeField] private VehicleComponent[] vehicleComponent;
    void Start()
    {
        vehicleHandler = new VehicleHandler(vehicleComponent);
    }

    void Update()
    {
        if (state == GameState.Driving)
        {
            vehicleHandler.Tick();
        }

    }


}
