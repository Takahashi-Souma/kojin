using UnityEngine;

public class Target : MonoBehaviour
{
    public int health = 2;

    public void TakeDamage(int damage)
    {
        health -= damage;

        Debug.Log("ダメージ: " + damage + " 残りHP: " + health);

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        GameManager.Instance.AddKill(); // キル数追加
        Destroy(gameObject);
    }
}