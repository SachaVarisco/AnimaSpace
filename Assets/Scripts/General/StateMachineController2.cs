using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine2 : MonoBehaviour
{
    [Header("States")]
    public MonoBehaviour[] stateArray;
    private MonoBehaviour actualState;
    private bool stateInProgress = false;

    [SerializeField] private MonoBehaviour stunnedState;
    [SerializeField] private GameObject stateIndicator;

    [Header("OrbSpawns")]
    [SerializeField] private GameObject orb;

    [Header("Audio")]
    private AudioSource audioSource;
    [SerializeField] private AudioClip attack;
    [SerializeField] private AudioClip damaged;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Debug.LogWarning("maquina de estado");
        ActivateNextState();
    }

    public void ActivateNextState()
    {
        if (stateInProgress)
        {
            Debug.LogWarning("Estado en progreso. No se puede activar otro estado.");
            return;
        }

        // Verifica que no hay estados activos
        foreach (var state in stateArray)
        {
            if (state.enabled)
            {
                Debug.LogWarning($"{state.GetType().Name} todavía está activo. Desactivándolo.");
                state.enabled = false; // Desactiva cualquier otro estado que esté activo
            }
        }

        // Desactiva el estado anterior si existe
        if (actualState != null)
        {
            Debug.LogWarning($"Desactivando estado anterior: {actualState.GetType().Name}");
            actualState.enabled = false;
        }

        // Selecciona un nuevo estado aleatorio que no sea el mismo que el anterior
        int nextStateIndex = Random.Range(0, stateArray.Length);
        while (stateArray[nextStateIndex] == actualState)
        {
            nextStateIndex = Random.Range(0, stateArray.Length);
        }

        actualState = stateArray[nextStateIndex];
        Debug.LogWarning($"Activando nuevo estado: {actualState.GetType().Name}");
        actualState.enabled = true;

        stateInProgress = true;
        Debug.LogWarning($"Estado en progreso: {actualState.GetType().Name}");
    }

    public void FinishState()
    {
        Debug.LogWarning($"Terminando estado: {actualState.GetType().Name}");
        stateInProgress = false;
    }

    public void PassState()
    {
        if (actualState != null)
        {
            Debug.LogWarning($"Pasando estado: Desactivando {actualState.GetType().Name}");
            actualState.enabled = false;
        }

        stateInProgress = false; // Aseguramos que se puede pasar al siguiente estado
        ActivateNextState();
        Debug.LogWarning("Activa el siguiente estado");
    }
}
