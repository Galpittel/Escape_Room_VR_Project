using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

/// <summary>
/// Central entry point to play single use SFX (e.g. contact sound). Through a single function call, PlaySFX, allow to
/// play a given clip at a given point with the given parameters.
/// The system also support using ID for event, which allow to avoid 2 event with the same ID to play too soon (e.g.
/// contact sound would overlapping when the object collide multiple time in a second)
/// </summary>
public class SFXPlayer : MonoBehaviour
{
    public struct PlayParameters
    {
        public float Pitch;
        public float Volume;
        public int SourceID;
    }

    public class PlayEvent
    {
        public float Time;
    }

    static SFXPlayer s_Instance;
    public static SFXPlayer Instance => s_Instance;

    public AudioSource SFXReferenceSource;
    public int SFXSourceCount;

    Dictionary<int, PlayEvent> m_PlayEvents = new Dictionary<int, PlayEvent>();
    List<int> m_PlayingSources = new List<int>();

    AudioSource[] m_SFXSourcePool;
    //CCSource[] m_CcSources;

    int m_UsedSource = 0;

    void Awake()
    {
        if (s_Instance != null)
        {
            Destroy(this);
            return;
        }

        s_Instance = this;

        m_SFXSourcePool = new AudioSource[SFXSourceCount];

        m_SFXSourcePool[0] = Instantiate(SFXReferenceSource);
        m_SFXSourcePool[0].gameObject.SetActive(false);

    }

    void Update()
    {
        List<int> IDToRemove = new List<int>();
        foreach (var playEvent in m_PlayEvents)
        {
            playEvent.Value.Time -= Time.deltaTime;

            if (playEvent.Value.Time <= 0.0f)
                IDToRemove.Add(playEvent.Key);
        }

        foreach (var id in IDToRemove)
        {
            m_PlayEvents.Remove(id);
        }

        for (int i = 0; i < m_PlayingSources.Count; ++i)
        {
            int id = m_PlayingSources[i];
            if (!m_SFXSourcePool[id].isPlaying)
            {
                m_SFXSourcePool[id].gameObject.SetActive(false);
            }

            m_PlayingSources.RemoveAt(i);
            i--;
        }
    }

    public void PlaySFX(AudioClip clip, Vector3 position, PlayParameters parameters, float cooldownTime = 0.5f)
    {
        if (clip == null)
            return;

        //can't play this sound again as the previous one with the same source was too early
        if (m_PlayEvents.ContainsKey(parameters.SourceID))
            return;

        AudioSource s = m_SFXSourcePool[m_UsedSource];

        m_PlayingSources.Add(m_UsedSource);

        m_UsedSource = m_UsedSource + 1;
        if (m_UsedSource >= m_SFXSourcePool.Length) m_UsedSource = 0;

        s.gameObject.SetActive(true);
        s.transform.position = position;
        s.clip = clip;

        s.volume = parameters.Volume;
        s.pitch = parameters.Pitch;

        m_PlayEvents.Add(parameters.SourceID, new PlayEvent() { Time = cooldownTime });

        s.Play();
    }
}
