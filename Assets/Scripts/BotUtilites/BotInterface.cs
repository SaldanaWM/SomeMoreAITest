using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BotInterface : MonoBehaviour
{
    public abstract void MoveTo(Vector3 targetLocation);
    public abstract void EnableMovement();


    //potentially want to abstract this a little higher later
    public abstract List<Vector2> proxDetection();


}
