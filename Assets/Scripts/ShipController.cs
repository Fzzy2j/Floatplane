using Assets.scripts;
using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipController : MonoBehaviour
{

    public static ShipController Instance;

    public float forwardSpeedModifier;
    public float verticalSpeedModifier;
    public bool flipControls;

    public Transform cameraPos;

    public GameObject pauseUi;

    public Camera camera;

    public GameObject pole;
    public GameObject bulletTimePowerup;

    public Vector3 customRotate { get; set; }

    public bool collide { get; set; }

    public long score { get; set; }
    public Text scoreText;

    public float currentSpeed { get; set; }

    private void Awake()
    {
        Instance = this;
        if (Manager.paused) Manager.togglePause();
        customRotate = new Vector3(0, -90, 0);
        collide = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public float speed = 1;
    private void Update()
    {
        if (Manager.paused) return;

        bool up = Input.GetKey(KeyCode.UpArrow);
        bool down = Input.GetKey(KeyCode.DownArrow);
        bool left = Input.GetKey(KeyCode.LeftArrow);
        bool right = Input.GetKey(KeyCode.RightArrow);

        if (left && !right)
            PlaneControls.Rotate(-speed);
        else if (right && !left)
            PlaneControls.Rotate(speed);
        else
            PlaneControls.Rotate(0);

        if (up && !down)
            PlaneControls.Move(speed);
        else if (down && !up)
            PlaneControls.Move(-speed);
        else
            PlaneControls.Move(0);

        /*float disUp = 0;
        float disLeft = 0;
        if (up) disUp += speed;
        if (down) disUp -= speed;
        if (left) disLeft += speed;
        if (right) disLeft -= speed;

        this.transform.position += Vector3.left * disLeft * Time.deltaTime * 50;
        this.transform.position += Vector3.up * disUp * Time.deltaTime * 50;*/

        scoreText.text = "Score: " + score;
        if (!collide)
        {
            currentSpeed = forwardSpeedModifier;
            this.transform.position += Vector3.forward * currentSpeed * (Time.deltaTime * 50);
            cameraPos.transform.position = this.transform.position + new Vector3(0, 0, -5);
            cameraPos.rotation = this.transform.rotation;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collide) return;
        if (!collision.gameObject.name.ToLower().Contains("powerup"))
        {
            Manager.togglePause();
            collide = true;
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.mass = 2;
            rb.useGravity = true;
            rb.AddForce(Vector3.forward * 10000);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (collide) return;
        if (!other.gameObject.name.ToLower().Contains("powerup"))
        {
            score += 200;
        }
    }
}
