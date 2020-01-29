using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public GameObject LaneControllerObject;
    private LaneController laneController;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            laneController.LaneChangeUp();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            laneController.LaneChangeDown();
        }
    }

    void Start()
    {
        laneController = LaneControllerObject.GetComponent<LaneController>();
    }

}
