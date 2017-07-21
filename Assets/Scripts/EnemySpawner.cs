using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject EnemyPrefab;
    public float Width = 10f;
    public float Height = 10f;
    public float Speed = 5;

    private float MinX;
    private float MaxX;
    private bool HasHit = false;

	// Use this for initialization
	void Start () {

        GetScreenBounds();
        foreach(Transform child in transform)
        {
            GameObject EnemyClone = Instantiate(EnemyPrefab, child.position, Quaternion.identity);
            EnemyClone.transform.parent = child;
        }
        
	}

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(Width, Height));
    }

    // Update is called once per frame
    void Update ()
    {
        if (transform.position.x -.5f*Width < MinX || transform.position.x + .5f * Width > MaxX)
            HasHit = !HasHit;
        
        Move();

	}

    void Move()
    {
        if (HasHit)
        transform.position += Vector3.left*Speed * Time.deltaTime ;
        else
            transform.position +=Vector3.right*Speed * Time.deltaTime;
    }
   

    void GetScreenBounds()
    {
        float Distance = transform.position.z - Camera.main.transform.position.z;
        MinX= Camera.main.ViewportToWorldPoint(new Vector3(0, 0, Distance)).x;
        MaxX = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, Distance)).x;
    }
}
