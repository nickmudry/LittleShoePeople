﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelSpawner : MonoBehaviour {

    public GameObject player;

    public enum musicEventType {nail,foot};

    [System.Serializable]
    public class musicEvent
    {
        public musicEventType eventType;
        public float eventTime;
    }

    public musicEvent[] eventsList;
    AudioSource musicPlayer;
    int eventIndex = 0;

    bool gameStarted = false;
    float musicTimer;

	// Use this for initialization
	void Start () {
        musicPlayer = gameObject.GetComponent<AudioSource>();
	}

	// Update is called once per frame
	void Update () {

        if (gameStarted == true)
        {
            musicTimer += Time.deltaTime;

            if (musicTimer >= 30)
            {
                Debug.Log(musicTimer);
            }

            if (musicTimer >= eventsList[eventIndex].eventTime - 2)
            {
                spawnNail();
                eventIndex++;
            }
        }
	}

    void spawnNail()
    {
        GameObject nail = Instantiate(Resources.Load("Nail", typeof(GameObject))) as GameObject;
        nail.transform.position = new Vector3(player.transform.position.x + 12, -1.7f, -1.7f);
    }

    public void startGenerator()
    {
        musicPlayer.Play();
        gameStarted = true;
    }
}
