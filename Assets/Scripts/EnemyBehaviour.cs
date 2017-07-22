using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public float Health = 300;
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
