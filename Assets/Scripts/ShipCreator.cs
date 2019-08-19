using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipCreator : MonoBehaviour
{
    public List<GameObject> ships;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("AddLargeShipTimer", .1f);
    }

    void AddLargeShipTimer()
    {
        Instantiate(ships[0], new Vector3(Random.Range(-30f, 30f), 20f, Random.Range(-20f, 20f)), Quaternion.identity);
        Invoke("AddLargeShipTimer", 10);
    }

    public void AddMedShip()
    {
        Instantiate(ships[1], new Vector3(Random.Range(-30f, 30f), 20, Random.Range(-20f, 20f)), Quaternion.identity);
    }
    public void DelayedAddMedShip()
    {
        Invoke("AddMedShip", 1);
    }

    public void AddLittleShip()
    {
        Instantiate(ships[2], new Vector3(Random.Range(-30f, 30f), 20, Random.Range(-20f, 20f)), Quaternion.identity);
    }
    public void DelayedAddLittleShip()
    {
        Invoke("AddLittleShip", .2f);
    }
}
