using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject EnemyPrefab;

	// Use this for initialization
	void Start () {
       

        foreach(Transform child in transform)
        {
            GameObject EnemyClone = Instantiate(EnemyPrefab, child.position, Quaternion.identity);
            EnemyClone.transform.parent = child;
        }
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
