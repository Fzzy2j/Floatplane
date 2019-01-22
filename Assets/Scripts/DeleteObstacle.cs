using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteObstacle : MonoBehaviour {

    public GameObject stayClose;
    public float distanceOfDeletion;

	void FixedUpdate () {
		if (Vector3.Distance(stayClose.transform.position, this.transform.position) > distanceOfDeletion)
        {
            Destroy(this.gameObject);
        }
	}
}
