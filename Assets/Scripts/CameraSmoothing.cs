using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class CameraSmoothing : MonoBehaviour
{

    public Transform t;
    public float cameraStiffness;
    public float rotationStiffness;
    public Vector3 offset = new Vector3(0, 5, -30);

    private void Update()
    {

        var pos = t.position + (t.up * offset.y) + (t.forward * offset.z) + (t.right * offset.x);
        gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, pos, cameraStiffness * Time.unscaledDeltaTime * 50);
        
        //var look = Quaternion.LookRotation(t.position - gameObject.transform.position);
        gameObject.transform.rotation = Quaternion.RotateTowards(gameObject.transform.rotation, t.rotation, 100f * Time.deltaTime);


        //gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, t.position.z);
        //gameObject.transform.rotation = Quaternion.Slerp(gameObject.transform.rotation, t.rotation, rotationStiffness * Time.deltaTime * 50);
        //gameObject.transform.rotation = Quaternion.Euler(0, 0, gameObject.transform.rotation.eulerAngles.z);


    }

    private Vector3 rotateAroundZ(Vector3 start, float t)
    {
        float x = start.x * Mathf.Cos(t) - start.y * Mathf.Sin(t);
        float y = start.x * Mathf.Sin(t) + start.y * Mathf.Cos(t);

        return new Vector3(x, y, start.z);
    }

    private Vector3 rotateAroundY(Vector3 start, float t)
    {
        float x = start.x * Mathf.Cos(t) - start.z * Mathf.Sin(t);
        float z = -start.x * Mathf.Sin(t) + start.z * Mathf.Cos(t);

        return new Vector3(x, start.y, z);
    }

    private Vector3 rotateAroundX(Vector3 start, float t)
    {
        float y = start.y * Mathf.Cos(t) - start.z * Mathf.Sin(t);
        float z = start.y * Mathf.Sin(t) + start.z * Mathf.Cos(t);

        return new Vector3(start.x, y, z);
    }

}
