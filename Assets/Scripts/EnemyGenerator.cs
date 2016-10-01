using UnityEngine;

public class EnemyGenerator : MonoBehaviour {

    public GameObject[] clone;
    public Transform levelResolution;
    public int NumberOfEachEnemy;

    float level_width, level_height;
    float x, y;

    void Start()
    {
        level_width = levelResolution.localScale.x;
        level_height = levelResolution.localScale.y;
        InitializeEnemies();
    }

    void InitializeEnemies()
    {
        for (int i = 0; i < NumberOfEachEnemy; i++)
        {
            for (int j = 0; j < clone.Length; j++)
            {
                GenerateEnemy(j);
            }
        }
    }

    public void GenerateEnemy(int type)
    {
        x = levelResolution.position.x + Random.Range(-level_width, level_width);
        y = levelResolution.position.y + Random.Range(-level_width, level_height);

       Instantiate(clone[type], new Vector3(x, y, 0.0f), Quaternion.Euler(0, x, 0));
    }
}
