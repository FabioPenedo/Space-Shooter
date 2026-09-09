using UnityEngine;

public class InimigoShotController : ShotBaseController
{
    protected override void Start()
    {
        speed = -10f;
        base.Start();
    }

    protected override bool ShouldDestroy()
    {
        return transform.position.y < -Camera.main.orthographicSize;
    }

    protected override void OnHit(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
            return;

        PlayerController player = collision.GetComponent<PlayerController>();
        player.TakeDamage(damage);
        Destroy(gameObject);
    }
}