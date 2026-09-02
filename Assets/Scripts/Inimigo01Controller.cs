using UnityEngine;

public class Inimigo01Controller : MonoBehaviour
{
    [SerializeField] private float speed = -3f;
    [SerializeField] private GameObject shot;

    [SerializeField] private float minFireInterval = 0.5f;
    [SerializeField] private float maxFireInterval = 2f;
    [SerializeField] private int life = 2;

    [SerializeField] private Transform posicaoTiro;

    private Rigidbody2D rb;
    private Renderer enemyRenderer;
    private float fireTimer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        enemyRenderer = GetComponentInChildren<SpriteRenderer>();

        rb.linearVelocity = new Vector2(0f, speed);

        fireTimer = GetRandomFireInterval();
    }

    void Update()
    {
        // Se o inimigo ainda não estiver visível na câmera, não atira
        if (!enemyRenderer.isVisible)
            return;

        fireTimer -= Time.deltaTime;

        if (fireTimer <= 0f)
        {
            OnFire();
            fireTimer = GetRandomFireInterval();
        }
    }

    private void OnFire()
    {
        Instantiate(shot, posicaoTiro.position, Quaternion.identity);
    }

    private float GetRandomFireInterval()
    {
        return Random.Range(minFireInterval, maxFireInterval);
    }

    public void TakeDamage(int damage)
    {
        life -= damage;
        if (life <= 0)
        {
            Destroy(gameObject);
        }
    }
}