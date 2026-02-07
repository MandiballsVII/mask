using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using System.IO;

public class ChartRecorder : MonoBehaviour
{
    public InputActionReference[] laneInputs;

    private List<NoteData> recorded = new();

    public InputActionReference saveAction;

    private void OnEnable()
    {
        foreach (var a in laneInputs)
        {
            a.action.Enable();
            a.action.performed += Record;
            saveAction.action.Enable();
            saveAction.action.performed += OnSave;
        }
    }

    private void OnDisable()
    {
        foreach (var a in laneInputs)
        {
            a.action.performed -= Record;
            a.action.Disable();
            saveAction.action.performed -= OnSave;
            saveAction.action.Disable();
        }
    }

    private void Record(InputAction.CallbackContext ctx)
    {
        int lane = -1;

        for (int i = 0; i < laneInputs.Length; i++)
        {
            if (laneInputs[i].action == ctx.action)
            {
                lane = i;
                break;
            }
        }

        if (lane == -1)
        {
            Debug.LogWarning("Lane no encontrada");
            return;
        }

        float time = AudioManager.instance.GetMusicTime();

        int timeDS = Mathf.RoundToInt(time * 10f);

        // redondeo (luego explico)
        time = Mathf.Round(time * 10f) / 10f;

        recorded.Add(new NoteData { timeDS = timeDS, lane = lane });

        Debug.Log($"Nota grabada {lane} @ {time}");
    }
    private void OnSave(InputAction.CallbackContext ctx)
    {
        Save();
    }

    public void Save()
    {
        string json = JsonUtility.ToJson(
            new ChartData { notes = recorded },
            true
        );

        File.WriteAllText(Application.dataPath + "/Charts/song1.json", json);
        Debug.Log("Chart guardado: " + json);
    }
}
