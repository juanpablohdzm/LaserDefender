using UnityEngine;

public class PlayerController_CS : MonoBehaviour {

    public float Health = 300f;
    public float PlayerSpeed=5f;
    public float ShipWidth = .5f;
    public float LaserPosition_Y = .7f;
    public GameObject Laser;
    public float LaserSpeed = 5f;
    public float LaserFireRate = .2f;

    float minX;
    float maxX;

    private void Start()
    {
        float Distance = transform.position.z - Camera.main.transform.position.z;
        //Finds the vector from the relative origin of the camera to lower left corner
        Vector3 WorldLeftPos=Camera.main.ViewportToWorldPoint(new Vector3(0, 0, Distance));
        Vector3 WorldRightPos = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, Distance));
        minX = WorldLeftPos.x+ShipWidth;
        maxX = WorldRightPos.x-ShipWidth;
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKey(KeyCode.LeftArrow))
            MoveToLeft();
        if (Input.GetKey(KeyCode.RightArrow))
            MoveToRight();

        float NewX = Mathf.Clamp(transform.position.x, minX, maxX);
        transform.position = new Vector3(NewX, transform.position.y);

        if (Input.GetKeyDown(KeyCode.Space))
            InvokeRepeating("Fire", 0.0001f, LaserFireRate);
        if (Input.GetKeyUp(KeyCode.Space))
            CancelInvoke("Fire");


    }

    void MoveToLeft()
    {

        transform.position += Vector3.left * PlayerSpeed * Time.deltaTime;
    }

    void MoveToRight()
    {
        
        transform.position += Vector3.right * PlayerSpeed * Time.deltaTime;
    }

    void Fire()
    {
        Vector3 LaserPosition = transform.position + new Vector3(0, LaserPosition_Y, 0);
        GameObject LaserClone= Instantiate(Laser, LaserPosition, Quaternion.identity);
        LaserClone.GetComponent<Rigidbody2D>().velocity = new Vector2(0, LaserSpeed);
        LaserClone.GetComponent<Rigidbody2D>().gravityScale = 0;


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Projectile Laser = collision.gameObject.GetComponent<Projectile>();
        if (Laser != null)
        {
            Health -= Laser.GetDamage();
            Laser.Hit();
        }
        if (Health <= 0)
            Destroy(gameObject);
    }
}
