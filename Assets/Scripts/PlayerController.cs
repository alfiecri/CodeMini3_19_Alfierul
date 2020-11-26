using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Animator playerAnim;
    public Rigidbody playerRb;
    public Renderer playerRdr;
    public GameObject textTimerCounterGO;
    public GameObject PlaneB;
    public Material[] playerMats;

    bool isStartCount = false;
    public bool isHitBox = false;
    bool isStartJump = false;

    float speed = 8;
    float jumpForce = 6;
    float jumpTime = 2;
    float iCounter = 10;
    float fTimer = 10;

    // Start is called before the first frame update
    void Start()
    {
         textTimerCounterGO.GetComponent<Text>().text = "Timer countdown: " + Mathf.RoundToInt(iCounter);
        playerRdr = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (fTimer > 0 && isStartCount)
        {
            fTimer -= Time.deltaTime;
            iCounter = Mathf.RoundToInt(fTimer);
            textTimerCounterGO.GetComponent<Text>().text = "Timer countdown: " + iCounter.ToString();
        }
        else if (fTimer <= 0 && isStartCount)
        {
            PlaneB.GetComponent<Transform>().Rotate(0, 90, 0);
            fTimer = 10;
            iCounter = 10;
            isStartCount = false;
            textTimerCounterGO.GetComponent<Text>().text = "Timer countdown: " + iCounter.ToString();
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
            playerAnim.SetTrigger("jumpTrigger");

            playerRdr.material.color = playerMats[2].color;

            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

        }

        if (transform.position.y < -10)
        {
            SceneManager.LoadScene("GameOverScene");
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
            isStartCount = true;
            PlaneB.GetComponent<Transform>().Rotate(0, 90, 0);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("TagBox"))
        {
            Debug.Log("Collided with Box!");
            isHitBox = true;
        }
    }
}
