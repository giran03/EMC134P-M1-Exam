using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchBall : MonoBehaviour
{
    [Header("Configs")]
    public float projectileSpeed;
    public GameObject ball;

    private bool isLaunched = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isLaunched)
        {
            GameObject racquetball = Instantiate(ball, transform.position, transform.rotation);
            racquetball.GetComponent<Rigidbody>().AddForce(100f * projectileSpeed * transform.forward, ForceMode.Force);
            isLaunched = true;
        }

        if (!ball.activeInHierarchy)  {
            Debug.Log("Ball is not ACTIVE!");
            isLaunched = false;
        }
    }
}
