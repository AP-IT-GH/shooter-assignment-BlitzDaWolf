using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Health;
    public GameObject Graphics;
    public float RespawnTimer;
    public Transform HealthBar;

    public bool Dead
    {
        get => dead;
        set
        {
            dead = value;
            StartCoroutine("StartCoroutine");
        }
    }

    private IEnumerator StartCoroutine()
    {
        if (dead)
        {
            Graphics.SetActive(false);
            line.enabled = false;
            yield return new WaitForSeconds(RespawnTimer);
            Graphics.SetActive(true);
            line.enabled = true;
            dead = false;
            Health = startHealth;
        }
        else
        {
            yield return new WaitForSeconds(1);
        }
        Debug.Log("Test");
    }

    public void TakeDamage(float v)
    {
        if (!dead)
        {
            Health -= v;
            if (Health < 0)
            {
                Dead = true;
                KillSystem.ins.KillMade();
            }
        }
    }

    Follower line;
    float startHealth;
    bool dead;


    private void Start()
    {
        line = GetComponent<Follower>();
        startHealth = Health;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            Dead = true;
        }

        HealthBar.localScale = new Vector3(Health / startHealth, 1, 1);
    }
}
