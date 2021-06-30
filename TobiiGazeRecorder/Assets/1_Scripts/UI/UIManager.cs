using System;
using System.Collections;
using System.Collections.Generic;
using Elie.Tobii;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private RecordManager recordManager = default;
    [SerializeField] private SetupManager setupManager = default;
    [SerializeField] private StopManager stopManager = default;

    private void Awake()
    {
        Application.runInBackground = true;
    }

    public void StartRecord()
    {
        recordManager.StartRecord(setupManager.filePath);
    }

    public void StopRecord()
    {
        recordManager.StopRecord();
    }

    public void Quit()
    {
        StartCoroutine(QuitRoutine());
    }

    private IEnumerator QuitRoutine()
    {
        StopRecord();

        yield return null;
        yield return null;

        Application.Quit();
    }
}
