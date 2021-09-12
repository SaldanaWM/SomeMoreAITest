using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwarmAI :MonoBehaviour
{
    [SerializeField] private BotInterface botInterface;

    private List<Vector2> currentDetectedPositions = new List<Vector2>();

    private Vector2 closestBot;

    //some type of spacing function - i.e. maintains space from a list of nearby physical objects and from nearby bots in particular

    private void Start()
    {
   
    }

    



    private void Update()
    {
        currentDetectedPositions.Clear();
        closestBot = Vector2.zero;

       if(botInterface.proxDetection().Count > 0)
        {

            currentDetectedPositions = botInterface.proxDetection();
            foreach (Vector2 position in currentDetectedPositions)
            {
               if( Vector2.Distance(this.gameObject.transform.position, position) > Vector2.Distance(this.gameObject.transform.position, closestBot)) { closestBot = position; }
            }
        }


        botInterface.MoveTo(-1 * closestBot);
    }


}
