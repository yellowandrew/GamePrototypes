using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class AppLauncher : MonoBehaviour
{
  
    UnityApp app;
    void Awake()
    {
        Application.runInBackground = true;
        Application.targetFrameRate = 30;
        QualitySettings.vSyncCount = 0;

        app = new UnityApp();
        
    }

    private void Start()
    {
        app.Mono = this;
        app.Start();
    }
   
    void Update()
    {

        app?.Update();
    }

    void FixedUpdate()
    {

        app?.FixedUpdate();
    }

    void OnApplicationQuit()
    {

        app?.Exit();
    }
}
