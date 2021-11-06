using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Effect {
    Kick, Bounce, Goal, Win
}

public class EffectPooler : Singleton<EffectPooler> {

    #region Global Variables

    [System.Serializable]
    public class EffectGroup {
        public Effect name;
        public ParticleSystem particle;
        public Queue<ParticleSystem> queue = new Queue<ParticleSystem>();
    }
    [Header("REFERENCES")]
    [SerializeField]
    private EffectGroup[] effects;
    private Dictionary<Effect, ParticleSystem> effectDict = new Dictionary<Effect, ParticleSystem>();
    private Dictionary<Effect, Queue<ParticleSystem>> queueDict= new Dictionary<Effect, Queue<ParticleSystem>>();

    #endregion

    #region Main

    void Awake() {
        foreach (EffectGroup effect in effects) {
            effectDict.Add(effect.name, effect.particle);
            queueDict.Add(effect.name, effect.queue);
        }
    }

    #endregion

    #region Functions

    /// <summary>
    /// 이펙트 생성하기
    /// </summary>
    public void SpawnEffect(Effect name, Vector2 position, Vector3 rotEuler) {
        if (queueDict[name].Count < 1) {
            InstantiateEffect(name);
        }
        ParticleSystem particle = queueDict[name].Dequeue();
        particle.transform.position = position;
        particle.transform.eulerAngles = rotEuler;
        //particle.transform.rotation = rotEuler;
        particle.gameObject.SetActive(true);
        particle.Play();
        StartCoroutine(FinishEffectRoutine(name, particle));
    }

    private IEnumerator FinishEffectRoutine(Effect name, ParticleSystem particle) {
        while (particle.isPlaying) {
            yield return null;
        }
        ReturnToPool(name, particle);
        yield break;
    }

    /// <summary>
    /// 이펙트 풀에다 다시 넣기
    /// </summary>
    /// <param name="name"></param>
    /// <param name="particle"></param>
    public void ReturnToPool(Effect name, ParticleSystem particle) {
        particle.gameObject.SetActive(false);
        queueDict[name].Enqueue(particle);
    }

    private void InstantiateEffect(Effect name) {
        ParticleSystem particle = Instantiate(effectDict[name], transform);
        particle.gameObject.SetActive(false);
        queueDict[name].Enqueue(particle);
    }

    #endregion
}
