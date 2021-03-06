﻿using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public float Health = 300;
    public float LaserPosition_Y = -.7f;
    public GameObject Laser;
    public float LaserSpeed = 5f;
    public float LaserFireRate = .5f;
    public float ScoreValue = 150f;
    public AudioClip DestroySound;


    private ScoreKeeper Score;


    private void Start()
    {
        Score = GameObject.FindObjectOfType<ScoreKeeper>();
    }


    private void Update()
    {
        float probability = Time.deltaTime * LaserFireRate;
        if (Random.value < probability)
            Fire();
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
        {
            Destroy(gameObject);
            Score.SetScore(ScoreValue);
            AudioSource.PlayClipAtPoint(DestroySound, transform.position,1f);

        }
    }

    void Fire()
    {
        Vector3 LaserPosition = transform.position + new Vector3(0, LaserPosition_Y, 0);
        GameObject LaserClone = Instantiate(Laser, LaserPosition, Quaternion.identity);
        LaserClone.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -LaserSpeed);
        LaserClone.GetComponent<Rigidbody2D>().gravityScale = 0;
        GetComponent<AudioSource>().Play();


    }
}
