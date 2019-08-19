using UnityEngine;

public class ShipAI : MonoBehaviour
{
    [Range(0, 10)] public int Shoot;
    [Range(0, 10)] public int Forward;
    [Range(0, 10)] public int Backward;
    [Range(0, 10)] public int Left;
    [Range(0, 10)] public int Right;
    [Range(0, 10)] public int Wait;

    public Actions MakeNextAction()
    {
        int total = Shoot + Forward + Backward+ Left + Right + Wait;
        int choice = Random.Range(0, total);
        if (choice < Shoot)
            return Actions.Shoot;
        else if (choice < Shoot + Forward)
            return Actions.MoveForward;
        else if (choice < Shoot + Forward + Backward)
            return Actions.MoveBackward;
        else if (choice < Shoot + Forward + Backward + Left)
            return Actions.TurnLeft;
        else if (choice < Shoot + Forward + Backward + Left + Right)
            return Actions.TurnRight;
        return Actions.Wait;
    }
}
public enum Actions
{
    TurnLeft,
    TurnRight,
    MoveForward,
    MoveBackward,
    Shoot,
    Wait
}
