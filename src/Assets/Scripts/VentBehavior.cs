using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VentBehavior : MonoBehaviour
{
    private SpriteRenderer sr;
    public Sprite defaultSprite;  // Sprite default state
    public Sprite activatedSprite;  // Sprite when vent is activated
    public Sprite selectedSprite; // Sprite when lane is active
    public KeyCode KeyToPress;  // What is the activation button?
    public int lane; // Which lane is this vent in?
    public bool isActive = false;
    public bool inHitZone = false;

    public GameObject LaneControllerObject;
    private LaneController laneController;


    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        laneController = LaneControllerObject.GetComponent<LaneController>();
    }
    void Update()
    {
        if(lane == laneController.currentLane)
        {
            if (Input.GetKeyDown(KeyToPress))
            {
                sr.sprite = activatedSprite;
                isActive = true;
            }
            if (Input.GetKeyUp(KeyToPress))
            {
                sr.sprite = defaultSprite;
                isActive = false;
            }
            if ( isActive == false)
            {
                sr.sprite = selectedSprite;
            }
        } else
        {
            sr.sprite = defaultSprite;
        }
    }

    void OnTriggerEnter2D(Collider2D collisionInfo)
    {
        inHitZone = true;
    }
    void OnTriggerExit2D(Collider2D collisionInfo)
    {
        inHitZone = false;
        Destroy(collisionInfo.gameObject);
        Debug.Log("You Missed It");
    }

    void OnTriggerStay2D(Collider2D collisionInfo)
    {
        Debug.Log("Is Colliding");
        if (isActive)
        {
            Destroy(collisionInfo.gameObject);
            Debug.Log("You Zapped It");
        }
    }
}
