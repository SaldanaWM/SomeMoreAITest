using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotPrefab : BotInterface
{
    //Serialized properties
   [SerializeField] private Rigidbody2D newRigidbody;
   [SerializeField] private bool enableControll = false;
   [SerializeField] private bool enableMoveTo = true;
   [SerializeField] private float velocityMult = 1f;
   [SerializeField] private Vector2 testLocation;
    [SerializeField] private BotDetector botDetector;


    //private properties to find
  

    //private variables
    private Vector2 moveToLocation;
    
    

    //implemented public properties


    void Start()
    {
        //this is where we get any of the components we might need
        

        //Testing stuff
        //MoveTo(testLocation);

        
    }

    private void FixedUpdate()
    {
        if (enableControll)
        {
            
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            newRigidbody.MovePosition(new Vector2(newRigidbody.position.x + moveHorizontal, newRigidbody.position.y + moveVertical));
        }

        if (enableMoveTo)
        {
            //print("test location" + moveToLocation.ToString());
            Vector2 newPosition = Vector2.MoveTowards(newRigidbody.position, moveToLocation, Time.fixedDeltaTime * velocityMult);
            newRigidbody.position = newPosition;
            //once we reach the loaction we want to disable move to mode
            if(moveToLocation == newRigidbody.position)
            {
                enableMoveTo = false;
            }
        }


    }

    // Update is called once per frame
    void Update()
    {

    
    }

    private void LateUpdate()
    {
   
    }

    //Implementing BotInterfaces
    public override void MoveTo(Vector3 targetLocation)
    {
        enableMoveTo = true;
        moveToLocation = targetLocation;
    }

    public override void EnableMovement()
    {
        enableControll = true;
    }


    public override List<Vector2> proxDetection()
    {
        return botDetector.queryBotDistances();
    }
}
