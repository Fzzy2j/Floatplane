using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowPowerUp : MonoBehaviour
{

    private Vector3 rotate;

    public float slowFactor;

    public long addTime;

    public GameObject shatter;

    private long startTime = 0;

    private void Start()
    {
        rotate = new Vector3(0, 0, 0);
    }

    private float oldTilt;

    private void FixedUpdate()
    {
        rotate += new Vector3(1, 2, 3);
        this.transform.rotation = Quaternion.Euler(rotate);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.isTrigger) return;
        if (other.gameObject.name.ToLower().Contains("ship"))
        {
            startTime = System.DateTime.Now.Ticks;
            //ShipController.Instance.addToBulletTime(slowFactor, addTime);
            Instantiate(shatter, this.transform.position, this.transform.rotation);
            this.transform.position += new Vector3(0, 100000, 0);
        }
    }
}
