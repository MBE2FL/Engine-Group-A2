using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.AI;

public class CameraControl : MonoBehaviour
{
    private NavMeshSurface _navMeshSurface;


    private void Start()
    {
        _navMeshSurface = GameObject.Find("Ground").GetComponent<NavMeshSurface>();

        play();
    }

    public void play()
    {
        Cursor.lockState = CursorLockMode.Locked;


        EnemySpawner.spawnersActive(true);

        _navMeshSurface.BuildNavMesh();
    }
}
