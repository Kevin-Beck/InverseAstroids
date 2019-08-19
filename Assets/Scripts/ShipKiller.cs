using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipKiller : MonoBehaviour
{

    public GameEvent BigShipKilledEvent;
    public GameEvent MedShipKilledEvent;
    public GameEvent LittleShipKilledEvent;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "BigShip")
        {
            Destroy(collision.gameObject);
            BigShipKilledEvent.Raise();
        }else if(collision.gameObject.tag == "MedShip")
        {
            Destroy(collision.gameObject);
            MedShipKilledEvent.Raise();
        }else if(collision.gameObject.tag == "LittleShip")
        {
            Destroy(collision.gameObject);
            LittleShipKilledEvent.Raise();
        }
    }
}
