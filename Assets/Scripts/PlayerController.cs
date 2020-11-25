using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Animator playerAnim;
    public Rigidbody playerRb;
    public GameObject textTimerCounterGO;
    public GameObject PlaneB;

    bool iStartCount = false;
    public GameObject isHitBox;

    float speed = 8;
    float jumpForce = 15.0f;
    float iCounter = 10;
    float fTimer = 0;

    // Start is called before the first frame update
    void Start()
    {
         textTimerCounterGO.GetComponent<Text>().text = "Timer countdown: " + Mathf.RoundToInt(iCounter);
    }

    // Update is called once per frame
    void Update()
    {
        if (iCounter > 0 && !iStartCount)
        {
            iStartCount = true;
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            startRun();
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            startRun();
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.rotation = Quaternion.Euler(0, 270, 0);
            startRun();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.rotation = Quaternion.Euler(0, 90, 0);
            startRun();
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            playerAnim.SetBool("isRun", false);
            playerAnim.SetFloat("startRun", 0f);
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            playerAnim.SetBool("isRun", false);
            playerAnim.SetFloat("startRun", 0f);
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            playerAnim.SetBool("isRun", false);
            playerAnim.SetFloat("startRun", 0f);
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            playerAnim.SetBool("isRun", false);
            playerAnim.SetFloat("startRun", 0f);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            iStartCount = true;

            iCounter -= Time.deltaTime;
            textTimerCounterGO.GetComponent<Text>().text = "Timer countdown: " + Mathf.Round(iCounter);


        }

        if (transform.position.y < -5)
        {
            SceneManager.LoadScene("LoseScene");
        }
    }
    void startRun()
    {
        playerAnim.SetBool("isRun", true);
        playerAnim.SetFloat("startRun", 0.26f);
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("TagCone"))
        {
            Debug.Log("Activated PlaneB 90deg rotation");

        }
    }
}
