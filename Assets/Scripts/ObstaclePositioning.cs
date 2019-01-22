using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePositioning : MonoBehaviour {

    public GameObject ship;
    public float repositionDistance;

    private bool repositioned = false;
	
	private void FixedUpdate () {
        if (ship != null)
        {
            if (!repositioned)
            {
                if (Mathf.Abs(ship.transform.position.z - this.transform.position.z) < repositionDistance)
                {
                    repositioned = true;
                    this.transform.position += new Vector3(ship.transform.position.x, ship.transform.position.y, 0);
                }
            }
        }
	}
}
