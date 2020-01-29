using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LaneController : MonoBehaviour
{
    public int currentLane;
    public int numOfLanes = 5;

    public void LaneChangeUp()
    {
        if (currentLane < numOfLanes - 1)
        {
            currentLane++;
        }
        else
        {
            currentLane = 0;
        }
    }
    public void LaneChangeDown()
    {
        if (currentLane == 0)
        {
            currentLane = numOfLanes - 1;
        }
        else
        {
            currentLane--;
        }
    }

}
