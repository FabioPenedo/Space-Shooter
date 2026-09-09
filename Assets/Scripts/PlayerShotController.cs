using UnityEngine;

public class PlayerShotController : ShotBaseController
{
    [SerializeField] private GameObject shotImpact;

    protected override void Start()
    {
        speed = 10f;
        base.Start();
    }

    protected override bool ShouldDestroy()
    {
        return transform.position.y > Camera.main.orthographicSize;
    }

    protected override void OnHit(Collider2D collision)
    {
        if (!collision.CompareTag("Enemy"))
            return;

        InimigoController enemy = collision.GetComponent<InimigoController>();
        enemy.TakeDamage(damage);
        Instantiate(shotImpact, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}