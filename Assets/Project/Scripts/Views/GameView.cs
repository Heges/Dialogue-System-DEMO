using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameView : BaseView
{
    public static bool IsGameOn => isGameOn;
    private static bool isGameOn;

    public override void Initialize()
    {
        ScenarioManager.instance.Initialize();
    }

    private void OnEnable()
    {
        isGameOn = true;
    }

    private void OnDisable()
    {
        isGameOn = false;
    }

    private void Update()
    {
        if (isGameOn)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Debug.Log("ESC");
                ViewManager.Show<MenuView>();
            }

            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("GameView mouse click");
                DialogSystem.StopSpeak();
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                Debug.Log("Transite Scenario");
                ScenarioManager.instance.StartScenario();
            }
        }
    }
}
