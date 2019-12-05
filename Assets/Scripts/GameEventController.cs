using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameEventController : AutoCleanSingleton<GameEventController>
{
    private List<Enemy> enemies = new List<Enemy>();
    [SerializeField] public TextMeshProUGUI enemiesCountText;
    private Damagable player;
    [SerializeField] private GameObject panelDead;

    private void Start()
    {
        if (player == null)
        {
            player = GameObject.FindWithTag("Player").GetComponent<Damagable>();
        }
    }

    private void Update()
    {
        Debug.Log(player.IsDead);
        if (player.IsDead)
        {
            panelDead.SetActive(true);
            Invoke("GoMenu", 2f);
        }
    }

    public void GoMenu()
    {
        panelDead.SetActive(false);
        GameObject.Find("SceneController").GetComponent<SceneController>().Load(0);
    }

    public void AddEnemy(Enemy e)
    {
        enemies.Add(e);
        enemiesCountText.text = enemies.Count.ToString();
    }

    public void RemoveEnemy(Enemy e)
    {
        enemies.Remove(e);
        enemiesCountText.text = enemies.Count.ToString();
    }

    private void WinGame()
    {
        if (enemies.Count < 1)
        {
            SceneController.Instance.Load(0);
        }
    }
}