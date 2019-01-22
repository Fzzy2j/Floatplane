using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAnimation : MonoBehaviour {

    public int obstacleAmount;
    public GameObject obstacle;

    private System.Random random;
    private int count;

    private void Awake()
    {
        random = new System.Random();
    }

    private void FixedUpdate () {
        this.transform.position += new Vector3(0, 0, 1);

        count++;
        if (count >= obstacleAmount)
        {
            count = 0;

            int add = random.Next(-50, 50);
            if (add > 5 || add < -5)
            {
                Vector3 pos = new Vector3(add, 0, this.transform.position.z + 80);

                GameObject ob = Instantiate(obstacle);
                ob.transform.position = pos;
                DeleteObstacle delob = ob.AddComponent<DeleteObstacle>();
                delob.stayClose = this.gameObject;
                delob.distanceOfDeletion = 100;
            }
        }
	}
}
