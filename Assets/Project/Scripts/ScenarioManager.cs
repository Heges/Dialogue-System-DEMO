using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenarioManager : MonoBehaviour
{
    public static ScenarioManager instance;

    public bool play = false;

    [SerializeField] private List<Speech> speeches;

    private Scenario currentScenario;

    private Queue<Scenario> scenarios;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        scenarios = new Queue<Scenario>();
    }

    private void OnEnable()
    {
        DialogSystem.OnDialogOver += Process;
    }

    private void OnDisable()
    {
        DialogSystem.OnDialogOver -= Process;
    }

    public void Initialize()
    {
        foreach (var scenario in speeches)
        {
            Scenario newScenario = new Scenario(scenario.background, scenario);
            scenarios.Enqueue(newScenario);
        }
        Debug.Log("SCENARIS WAS INITIALIZED");
    }

    public void StartScenario()
    {
        Process();
    }

    public void Process()
    {
        if (currentScenario == null && scenarios.Count > 0)
        {
            currentScenario = scenarios.Dequeue();
            SceneTransition.instance.SetTransition(() => { play = true; Process(); }, currentScenario.Background);
        }
        else
        {
            Debug.Log("ITS OVER");
        }

        if (play && !DialogSystem.instance.IsSpeaking && !currentScenario.IsOver)
        {
            currentScenario.Process();
        }
        else if (play && !DialogSystem.instance.IsSpeaking && currentScenario.IsOver)
        {
            DialogSystem.instance.Hide();
            play = false;
            currentScenario = null;
        }
    }
}
