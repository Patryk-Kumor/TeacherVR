﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsManager : MonoBehaviour
{
    public List<Events> ListOfEvents = new List<Events>();

    private Events currentEvent;

    public void StartNextEvent()
    {
        currentEvent = ListOfEvents[0];
        currentEvent.StartEvent();
        ListOfEvents.RemoveAt(0);
    }

    public void AbortCurrentEvent()
    {
        currentEvent.AbortEvent();
        currentEvent = null;
    }

    public void AddEvent(Events e)
    {
        ListOfEvents.Add(e);
    }

    public Events.Status CheckCurrentEventStatus()
    {
        return currentEvent.status;
    }
}
