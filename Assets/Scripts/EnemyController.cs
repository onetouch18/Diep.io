using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public int orderInCollection;
    public int startingHealth;
    public int experienceValue;
    public Slider healthSlider;
    public AnimationClip enemyDeathClip;

    float currentHealth;


    void Awake()
    {
        currentHealth = startingHealth;
        healthSlider.maxValue = startingHealth;
    }

    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "Bullet")
        {
            TakeDamage(collider.gameObject.GetComponent<Bullet>().power);
        }
            

    }
    public void TakeDamage(float amount)
    {
        currentHealth -= amount;

        healthSlider.value = currentHealth;
        healthSlider.gameObject.SetActive(true);

        if (currentHealth <= 0)
        {
            Death();
        }
    }


    void Death()
    {
        GetComponent<Collider2D>().enabled = false;
        ExperienceManager.experience += experienceValue;
        GameObject gameManager = GameObject.Find("GameManager");
        gameManager.GetComponent<EnemyGenerator>().GenerateEnemy(orderInCollection);
        GetComponent<Animator>().Play(enemyDeathClip.name);
        Destroy(gameObject, enemyDeathClip.length);
    }
}
