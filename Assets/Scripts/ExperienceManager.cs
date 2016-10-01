using UnityEngine;
using UnityEngine.UI;

public class ExperienceManager : MonoBehaviour
{
    public static int experience;
    public static int currentLevel;

    public int[] levelRanks;
    public Text textLevel, textExperience;


    void Awake ()
    {
        currentLevel = 1;
        experience = 0;
    }


    void Update ()
    {
        CheckLevel();
        DisplayText();
    }

    void DisplayText()
    {
        textLevel.text = "Level: " + currentLevel;
        textExperience.text = "Experience: " + experience;
    }

    void CheckLevel()
    {
        for (int i = 0; i < levelRanks.Length; i++)
        {
            if (experience >= levelRanks[i])
            {
                currentLevel = i + 2;
            }
        }
    }
}
