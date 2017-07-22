using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject EnemyPrefab;
    public float Width = 10f;
    public float Height = 10f;
    public float Speed = 5f;
    public float SpawnDelay = .5f;

    private float MinX;
    private float MaxX;
    private bool HasHit = false;

	// Use this for initialization
	void Start () {

        GetScreenBounds();
        SpawnUntilFull();
        
	}

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(Width, Height));
    }

    // Update is called once per frame
    void Update ()
    {
        //Check for formation going outside of screen
        if (transform.position.x - .5f * Width <= MinX)
            HasHit = false;
        else
            if (transform.position.x + .5f * Width >= MaxX)
            HasHit = true;
        Move();

        if(AllMembersDead())
        {
            SpawnUntilFull();
        }

	}

    void Move()
    {
        if (HasHit)
            transform.position += Vector3.left*Speed * Time.deltaTime ;
        else
            transform.position +=Vector3.right*Speed * Time.deltaTime;
    }


    void SpawnUntilFull()
    {
        Transform FreePosition = NextFreePosition();
        if (FreePosition)
        {
            SpawnEnemies(FreePosition);
            Invoke("SpawnUntilFull", SpawnDelay);
        }
        
    }

    Transform NextFreePosition()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).childCount == 0)
                return transform.GetChild(i).transform;
        }
        return null;
    }

    void SpawnEnemies(Transform child)
    {

        GameObject EnemyClone = Instantiate(EnemyPrefab, child.position, Quaternion.identity);
        EnemyClone.transform.parent = child;


    }

   

    bool AllMembersDead()
    {
        EnemyBehaviour[] Children = FindObjectsOfType<EnemyBehaviour>();
        if (Children.Length == 0)
            return true;
        else
            return false;
    }

    void GetScreenBounds()
    {
        float Distance = transform.position.z - Camera.main.transform.position.z;
        MinX= Camera.main.ViewportToWorldPoint(new Vector3(0, 0, Distance)).x;
        MaxX = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, Distance)).x;
    }
}
