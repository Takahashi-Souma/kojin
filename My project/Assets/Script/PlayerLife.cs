using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    public GameObject gameOverPanel;

    private bool isDead = false;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Enemy") && !isDead)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        isDead = true;

        // プレイヤー消す
        gameObject.SetActive(false);

        // ゲーム停止
        Time.timeScale = 0f;

        // パネル表示
        gameOverPanel.SetActive(true);
    }

    // リスタートボタンから呼び出す
    public void RestartGame()
    {
        Time.timeScale = 1f; // 時間を元に戻す
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}