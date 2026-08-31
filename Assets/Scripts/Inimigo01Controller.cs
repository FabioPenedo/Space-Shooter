using UnityEngine;

public class Inimigo01Controller : MonoBehaviour
{
    [SerializeField] private float speed = -3f;

    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = new Vector2(0f, speed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
