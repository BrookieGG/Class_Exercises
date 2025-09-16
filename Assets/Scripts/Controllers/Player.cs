﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public List<Transform> asteroidTransforms;

    public float bombTrailSpacing = 10;
    public int numberOfTrailBombs = 5;
    public float bombCorner = 3;

    [Space(15)]
    public float warpDist = 0.5f;
    public float radarDist = 10f;
    public float speed = 0.05f;
    public float maxSpeed = 1f;
    public float accelerationTime = 5;

    private Vector3 velocity = Vector3.zero;

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();

        if (Input.GetKeyDown(KeyCode.B))
        {
            SpawnBombAtOffset(new Vector3(0, 1));
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            SpawnBombTrail(bombTrailSpacing, numberOfTrailBombs);
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            SpawnBombOnRandomCorner(bombCorner);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            WarpPlayer(enemyTransform, warpDist);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            DetectAsteroids(radarDist, asteroidTransforms);
        }


    }
    private void SpawnBombAtOffset(Vector3 inOffset) //Spawn Bomb at Offset
    {
        Vector3 spawnPosition = transform.position + inOffset;
        Instantiate(bombPrefab, spawnPosition, Quaternion.identity);
    }

    private void SpawnBombTrail(float inBombSpacing, int inNumberOfBombs)
    {
        for (int i = 1; i <= inNumberOfBombs; i++)
        {
            Vector3 spawnPos = transform.position - transform.up * (inBombSpacing * i);
            Instantiate(bombPrefab, spawnPos, Quaternion.identity);
        }
    }

    private void SpawnBombOnRandomCorner(float inDistance)
    {
        Vector3[] corners = new Vector3[]
        {
            (Vector3.up + Vector3.left).normalized, //corners
            (Vector3.up + Vector3.right).normalized,
            (Vector3.down + Vector3.left).normalized,
            (Vector3.down + Vector3.right).normalized
        };

        int random = Random.Range(0, corners.Length); //random corner in the list
        Vector3 direction = corners[random];

        Vector3 spawnPosition = transform.position + direction * inDistance; //calculate spawn position

        Instantiate(bombPrefab, spawnPosition, Quaternion.identity);

    }
    private void WarpPlayer(Transform target, float ratio)
    {
        if (ratio > 1)
        {
            ratio = 1;
            //Debug.Log("ratio = ratio");
        }
        if (ratio < 0)
        {
            ratio = 0;
        }
        Vector3 interpolatedPosition = Vector3.Lerp(transform.position, target.position, ratio);
        transform.position = interpolatedPosition;
    }

    private void DetectAsteroids(float inMaxRange, List<Transform> inAsteroids)
    {
        foreach (Transform asteroid in inAsteroids)
        {
            float dist = Vector3.Distance(asteroid.position, transform.position);
            if (dist <= inMaxRange)
            {
                //Debug.Log("in range");
                Color bluecolor = new Color(0f, 0f, 1f, 0.5f);
                Vector3 end = (asteroid.position - transform.position).normalized * 2.5f + transform.position;
                Debug.DrawLine(transform.position, end, bluecolor, 2f, false);
            }
        }
    }

    private void PlayerMovement()
    {
        float acceleration = maxSpeed / accelerationTime;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            velocity += acceleration * Time.deltaTime * Vector3.left;
            //transform.position += Vector3.left * speed;
        }   

        if (Input.GetKey(KeyCode.RightArrow))
        {
            velocity += acceleration * Time.deltaTime * Vector3.right;
            //transform.position += Vector3.right * speed;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            velocity += acceleration * Time.deltaTime * Vector3.up;
            //transform.position += Vector3.up * speed;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            velocity += acceleration * Time.deltaTime * Vector3.down;
            //transform.position += Vector3.down * speed;
        }

        velocity = Vector3.ClampMagnitude(velocity, maxSpeed);
        transform.position += velocity * Time.deltaTime;
    }
}
