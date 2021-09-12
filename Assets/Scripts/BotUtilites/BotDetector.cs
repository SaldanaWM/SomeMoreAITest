using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//the only thing this class does is keep track of which bots are in the radius of the detection zone and queries the postion of those bots
public class BotDetector : MonoBehaviour
{
    private List<BotInterface> botsInDetector = new List<BotInterface>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // we need to check if the trigger has a bot interface and then add to the list
        if(collision.GetComponent<BotInterface>() != null)
        {
            botsInDetector.Add(collision.GetComponent<BotInterface>());
        }
        else
        {
            print("collider that is not a bot is on the botComs collision layer");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        botsInDetector.Remove(collision.GetComponent<BotInterface>());
    }

    
    public List<Vector2> queryBotLocations()
    {
        List<Vector2> botDistances = new List<Vector2>();
        foreach (BotInterface bot in botsInDetector)
        {
            print("bot removed from list");
            botDistances.Add(bot.gameObject.transform.position);
        }

        return botDistances;
    }

    public List<Vector2> queryBotDistances()
    {
        List<Vector2> botDistances = new List<Vector2>();
        foreach (BotInterface bot in botsInDetector)
        {
            botDistances.Add(bot.gameObject.transform.position - this.gameObject.transform.position);
        }

        return botDistances;
    }

}
