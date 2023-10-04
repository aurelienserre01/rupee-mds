using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RupeeManager : MonoBehaviour
{
    public Transform container;
    public Transform spawner;
    public Rupee rupeePrefab;

    private List<Rupee> _rupees = new List<Rupee>();

    private Coroutine _spawnCoroutine;
    // Start is called before the first frame update
    void Start()
    {
        StartSpwaning();
    }

    private void StartSpwaning()
    {
        _spawnCoroutine = StartCoroutine(SpawnCoroutine());
    }

    private void StopCoroutine()
    {
        if (_spawnCoroutine != null)
        {
            StopCoroutine(_spawnCoroutine);
            _spawnCoroutine = null;
        }
    }
    
    private IEnumerator SpawnCoroutine()
    {
        Spawn();
        yield return new WaitForSeconds(1f);
        StartSpwaning();
    }
    private void Spawn()
    {
        Rupee rupee = Instantiate(rupeePrefab, spawner.position, Quaternion.identity, container);
        rupee.OnCollected += RupeeCollectedHandler;
        _rupees.Add(rupee);
    }

    private void RupeeCollectedHandler(Rupee rupee)
    {
        rupee.OnCollected -= RupeeCollectedHandler;
        _rupees.Remove(rupee);
        Destroy(rupee.gameObject);
    }
}
