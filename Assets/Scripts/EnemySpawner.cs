﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject EnemyPrefab;

	// Use this for initialization
	void Start () {
        Instantiate(EnemyPrefab, new Vector3(0, 0, 0), Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}