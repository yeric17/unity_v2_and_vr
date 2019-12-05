using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameEventController : AutoCleanSingleton<GameEventController>
{
    private static List<Enemy> enemies = new List<Enemy>();
    [SerializeField] static TextMeshProUGUI enemiesCountText;

    [SerializeField]


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Destroy(enemies[0].gameObject);
        }
    }

    public static void AddEnemy(Enemy e)
    {
        enemies.Add(e);
//        enemiesCountText.text = enemies.Count.ToString();
    }

    public static void RemoveEnemy(Enemy e)
    {
        enemies.Remove(e);
//        enemiesCountText.text = enemies.Count.ToString();
    }

    private void WinGame()
    {
        if (enemies.Count < 1)
        {
            SceneController.Instance.Load(0);
        }
    }
}