using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLevel : MonoBehaviour {

    public GameObject ship;
    public GameObject camera;
    public GameObject obstacle;

    public string nextLevel;

    public GameObject finishedLevelUI;

    private bool triggered = false;

    private void OnTriggerExit(Collider collision)
    {
        Destroy(ship);

        Destroy(camera.GetComponent<CameraSmoothing>());
        MenuAnimation ma = camera.AddComponent<MenuAnimation>();
        ma.obstacleAmount = 10;
        ma.obstacle = obstacle;
        triggered = true;

        GameObject obj = Instantiate(finishedLevelUI);
        FinishedLevelUI flu = obj.GetComponent<FinishedLevelUI>();
        flu.nextLevel = nextLevel;
    }

    private void FixedUpdate()
    {
        if (triggered)
        {
            this.transform.position += Vector3.forward * 2;
            if (Vector3.Distance(camera.transform.position, this.transform.position) > 100)
                Destroy(this.gameObject);
        }
    }
}
