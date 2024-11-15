using UnityEngine;

public class Main : MonoBehaviour
{
    public GameObject kiem; // Prefab c?a ki?m
    public float speed = 5f;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private Vector2 movement;
    public GameObject position; // V? tr� xu?t hi?n ki?m

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float inputX = 0f;
        float inputY = 0f;

        // Nh?n ?i?u khi?n t? ng??i ch?i
        if (Input.GetKey(KeyCode.W))
        {
            inputY = 1f;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            inputY = -1f;
        }

        if (Input.GetKey(KeyCode.D))
        {
            inputX = 1f;
            spriteRenderer.flipX = false;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            inputX = -1f;
            spriteRenderer.flipX = true;
        }

        // T?o ki?m khi nh?n ph�m Space
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(kiem, position.transform.position, Quaternion.identity);
        }

        // Di chuy?n nh�n v?t
        movement = new Vector2(inputX, inputY).normalized;
        rb.linearVelocity = movement * speed;

        // Ch?y animation
        animator.SetBool("run", inputX != 0 || inputY != 0);
    }

    // H?y nh�n v?t khi ch?m v�o k? ??ch
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            Destroy(gameObject);
        }
    }
}
