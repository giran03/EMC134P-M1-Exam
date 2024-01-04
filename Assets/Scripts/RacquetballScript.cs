using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class RacquetballScript : MonoBehaviour
{
    [Header("Configs")]
    public float projectileSpeed;
    public GameObject ball_prefab;
    public GameObject gameOverOverlay;
    public TMP_Text Final_Score;

    private Vector3 respawn_position;
    private Vector3 launch_direction;
    private Rigidbody rb;
    private Quaternion respawn_rotation;
    private int Lives;
    private float random_LR;
    private float random_UD;
    private bool isLaunched = false;
    private bool isAlive;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        gameOverOverlay.SetActive(false);
        isAlive = true;
        StatsManagerScript.scoreCount = 0;
        Lives = 3;
        rb.useGravity = false;
        respawn_position = ball_prefab.transform.position;
        respawn_rotation = Quaternion.Euler(ball_prefab.transform.eulerAngles);
        launch_direction = 100f * projectileSpeed * transform.forward + random_LR * projectileSpeed * transform.right + random_UD * projectileSpeed * transform.up;
    }
    void Update()
    {
        random_LR = Random.Range(-10f, 10f);
        random_UD = Random.Range(-5f, 5f);
        if (Input.GetKeyDown(KeyCode.Space) && !isLaunched && isAlive)
        {
            rb.useGravity = true;
            rb.AddForce(launch_direction, ForceMode.Force);
            isLaunched = true;
        }

        // return to main menu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
        }

        // Game over condition
        if (Lives < 0)
        {
            Debug.Log("GAME OVER!");
            isAlive = false;
            gameOverOverlay.SetActive(true);
            Final_Score.SetText("Score: " + StatsManagerScript.scoreCount);
            Lives = 3;
            StatsManagerScript.livesCount = Lives;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DeadZone"))
        {
            Lives -= 1;
            StatsManagerScript.livesCount = Lives;
            Debug.Log("Dead Zone Entered!\n\t\tCurrent Lives: " + Lives);
            RespawnBall();
        }
        if (other.CompareTag("ScoreZone"))
        {
            StatsManagerScript.scoreCount += 1;
            Debug.Log("Score Zone!!!");
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Paddle"))
        {
            rb.AddForce(launch_direction, ForceMode.Force);
        }
    }

    public void RespawnBall()
    {
        transform.SetPositionAndRotation(respawn_position, respawn_rotation);
        rb.useGravity = false;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        isLaunched = false;
    }
}
