using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EnemyAI : MonoBehaviour
{
    private Transform player;
    private Rigidbody rb;

    public float speed = 3f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Playerタグを探す
        GameObject obj = GameObject.FindWithTag("Player");
        if (obj != null)
        {
            player = obj.transform;
        }
    }

    void FixedUpdate() // 物理計算はFixedUpdate
    {
        if (player == null) return;

        Vector3 dir = (player.position - transform.position).normalized;

        // Rigidbodyで移動
        rb.MovePosition(rb.position + dir * speed * Time.fixedDeltaTime);

        // 向きだけ変更
        transform.LookAt(player);
    }
}