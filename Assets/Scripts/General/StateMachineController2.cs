using System.Collections;
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
        ActivateNextState();
        Debug.LogWarning("a");
    }

    public void ActivateNextState()
    {
        // Si hay un estado en progreso, no hacemos nada y esperamos a que termine
        if (stateInProgress)
        {
            return;
        }

        // Desactiva el estado anterior si existe
        if (actualState != null)
        {
            actualState.enabled = false;
        }

        // Selecciona un nuevo estado aleatorio que no sea el mismo que el anterior
        int nextStateIndex = Random.Range(0, stateArray.Length);
        while (stateArray[nextStateIndex] == actualState)
        {
            nextStateIndex = Random.Range(0, stateArray.Length);
        }

        // Obtiene y activa el nuevo estado
        actualState = stateArray[nextStateIndex];
        actualState.enabled = true;

        // Marca que hay un estado en progreso
        stateInProgress = true;
    }

    public void FinishState()
    {
        // Marca que el estado ha terminado
        stateInProgress = false;
    }

    public void PassState()
    {
        // Desactiva el estado actual (si está activo)
        if (actualState != null)
        {
            actualState.enabled = false;
        }

        // Activa el siguiente estado
        ActivateNextState();
    }
}
