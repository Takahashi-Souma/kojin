using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EnemyAI : MonoBehaviour
{
    private Transform player;
    private Rigidbody rb;

    public float speed = 3f;
    public float acceleration = 0.1f; // 1ïbÇ†ÇΩÇËÇÃâ¡ë¨ìx
    public float maxSpeed = 10f;      // ç≈çÇë¨ìx

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        GameObject obj = GameObject.FindWithTag("Player");
        if (obj != null)
        {
            player = obj.transform;
        }
    }

    void FixedUpdate()
    {
        if (player == null) return;

        // èôÅXÇ…â¡ë¨
        speed += acceleration * Time.fixedDeltaTime;
        speed = Mathf.Min(speed, maxSpeed);

        Vector3 dir = (player.position - transform.position).normalized;

        rb.MovePosition(rb.position + dir * speed * Time.fixedDeltaTime);

        transform.LookAt(player);
    }
}