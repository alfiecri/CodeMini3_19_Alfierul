﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlaneController : MonoBehaviour
{
    public GameObject PlayerGO;

    float zUpperLimit = 57.5f;
    float zLowerLimit = 42.5f;
    float moveSpeed = 5;

    bool isMoveFwd = false;
    bool isMoveBack = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerGO.GetComponent<PlayerController>().isHitBox)
        {
            if (isMoveBack && !isMoveFwd)
            {
                if (transform.position.z >= zLowerLimit)
                {
                    transform.Translate(Vector3.back * Time.deltaTime * moveSpeed);
                }
                else
                {
                    isMoveBack = !isMoveBack;
                    isMoveFwd = !isMoveFwd;
                }
            }

            if (isMoveFwd && !isMoveBack)
            {
                if (transform.position.z <= zUpperLimit)
                {
                    transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
                }
                else
                {
                    isMoveFwd = !isMoveFwd;
                    isMoveBack = !isMoveBack;
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerGO.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                PlayerGO.transform.parent = null;
            }
        }
    }

}
