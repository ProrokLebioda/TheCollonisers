using System.Collections;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public enum State { MENU, INIT, PLAY, MAPCOMPLETED, LOADMAP, GAMEOVER }
    State _state;
    bool _isSwitchingState;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        SwitchState(State.INIT);
    }

    public void SwitchState(State newState, float delay = 0)
    {
        StartCoroutine(SwitchDelay(newState, delay));
    }

    IEnumerator SwitchDelay(State newState, float delay)
    {
        _isSwitchingState = true;
        yield return new WaitForSeconds(delay);
        EndState();
        _state = newState;
        BeginState(newState);
        _isSwitchingState = false;
    }

    void BeginState(State newState)
    {
        switch (newState)
        {
            case State.MENU:
                break;
            case State.INIT:
                break;
            case State.PLAY:
                break;
            case State.MAPCOMPLETED:
                break;
            case State.LOADMAP:
                break;
            case State.GAMEOVER:
                Invoke("ReturnToMenu", 2.0f);
                break;
        }
    }

    void ReturnToMenu()
    {
    }

    // Update is called once per frame
    void Update()
    {
        switch (_state)
        {
            case State.MENU:
                break;
            case State.INIT:
                break;
            case State.PLAY:
                break;
            case State.MAPCOMPLETED:
                break;
            case State.LOADMAP:
                break;
            case State.GAMEOVER:
                break;
        }
    }

    void EndState()
    {
        switch (_state)
        {
            case State.MENU:
                break;
            case State.INIT:
                break;
            case State.PLAY:
                break;
            case State.MAPCOMPLETED:
                break;
            case State.LOADMAP:
                break;
            case State.GAMEOVER:
                break;
        }
    }
}
