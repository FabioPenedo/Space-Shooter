using UnityEngine;

public abstract class ShotBaseController : MonoBehaviour
{
    [SerializeField] protected float speed = 10f;
    [SerializeField] protected int damage = 1;

    protected Rigidbody2D rb;

    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = new Vector2(0f, speed);
    }

    protected abstract bool ShouldDestroy();

    protected virtual void Update()
    {
        if (ShouldDestroy())
        {
            Destroy(gameObject);
        }
    }

    protected abstract void OnHit(Collider2D collision);

    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnHit(collision);
    }
}
