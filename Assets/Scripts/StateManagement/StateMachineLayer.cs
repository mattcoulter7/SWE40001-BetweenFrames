﻿using UnityEngine;
using System;
using System.Collections.Generic;

[System.Serializable]
public class StateMachineLayer
{
    public string name = "New Layer";
    public string defaultState;
    private List<State> history = new List<State> { null };
    public State currentState
    {
        get
        {
            if (history.Count == 0) history.Add(null);
            return history[0];
        }
        set
        {
            if (history.Count == 0) history.Add(null);
            history[0] = value;
        }
    }
    Dictionary<string, State> states = new Dictionary<string, State>();
    public void Start()
    {
        if (defaultState != "") ChangeState(defaultState);
    }

    public void Update()
    {
        if (currentState != null) currentState.HandleInput();
        if (currentState != null) currentState.HandleShouldChangeState();
        if (currentState != null) currentState.LogicUpdate();
    }

    public void FixedUpdate()
    {
        if (currentState != null) currentState.PhysicsUpdate();
    }

    public void ChangeState(State stateObj) // overrides the current state
    {
        if (currentState == stateObj) return; // can't re-enter the current state

        if (currentState != null) currentState.Exit();
        currentState = stateObj;
        if (currentState != null) currentState.Enter();
    }
    public void ChangeState(string state) // overrides the current state
    {
        State stateObj = state == "" ? null : states[state];
        ChangeState(stateObj);
    }

    public void AddState(string state) // adds to front of history
    {
        if (currentState != null) currentState.Exit();

        State stateObj = states[state];
        if (currentState == stateObj) return; // can't re-enter the current state
        if (currentState == null) currentState = stateObj;
        else history.Insert(0, stateObj);

        currentState.Enter();
    }

    public void RemoveState() // removes from of history
    {
        if (currentState != null)
        {
            currentState.Exit();
            history.RemoveAt(0);

            if (currentState != null) currentState.Enter();
        }
    }
    public void RegisterState(string value, State obj)
    {
        states[value] = obj;
    }
}