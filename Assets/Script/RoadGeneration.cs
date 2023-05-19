using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadGeneration : MonoBehaviour,IGameUpdateListener,IGameStartListener
{
    [SerializeField] private float _zOffset;
    [SerializeField] private Transform[] _roadPosition;
    [SerializeField] private Transform _obstacleParent;
    [SerializeField] private GameObject _prefabRoad;
    [SerializeField] private GameObject _prefabObstacle;
    [SerializeField] private float _timeToGenerationRoad;//время для генерации новых дорог и удаления старых
    [SerializeField] private float _timeToGenerationObstacle;


    private int _countStartGenerationRoad = 20;
    private int _countStartObstacle = 20;
    private Queue<GameObject> _roadGenerationQueue = new();
    private Queue<GameObject> _obstacleQueue = new();


    private float _lastSpawnRoad;
    private float _lastSpawnObstacle;
    private int _lastZOffset;

    //private void Start() 
    //{
    //    _lastSpawnRoad = _timeToGenerationRoad;
    //    _lastSpawnObstacle =_timeToGenerationObstacle;
    //    for (int j = 0; j < _countStartGenerationRoad; j++)
    //    {
    //        for (int i = 0; i < _roadPosition.Length; i++)
    //        {
    //            //GameObject road = Instantiate(_prefabRoad, _roadPosition[i].position + (Vector3.forward * (_zOffset*j)),Quaternion.identity, _roadPosition[i]);
    //            //_roadGenerationQueue.Enqueue(road);
    //            GenerationRoadInPosition(_roadPosition[i].position + (Vector3.forward * (_zOffset * j)), _roadPosition[i]);
    //        }
    //    }
    //    InitObstacleQueue();
    //    _lastZOffset = _countStartGenerationRoad;
    //}
    private void InitObstacleQueue() 
    {
        for (int i = 0; i < _countStartObstacle; i++)
        {
            GameObject obstacle = Instantiate(_prefabObstacle, _obstacleParent);
            obstacle.SetActive(false);
            _obstacleQueue.Enqueue(obstacle);
        }
    }
    private void GenerationObstacle() 
    {
        _lastSpawnObstacle = _timeToGenerationObstacle;

        int road = Random.Range(0, _roadPosition.Length);

        GameObject obstacle = _obstacleQueue.Dequeue();
        obstacle.SetActive(true);

        obstacle.transform.position = _roadPosition[road].position + (Vector3.forward * (_zOffset * _lastZOffset)) + Vector3.up;
        _obstacleQueue.Enqueue(obstacle);

    }
    private void GenerationRoadInPosition(Vector3 offset,Transform parent) 
    {
        GameObject road = Instantiate(_prefabRoad, offset, Quaternion.identity, parent);
       
        _roadGenerationQueue.Enqueue(road);
    }
    private void GenerationRoadInPosition() 
    {
        _lastSpawnRoad = _timeToGenerationRoad;

        for (int i = 0; i < _roadPosition.Length; i++)
        {
            GameObject road = _roadGenerationQueue.Dequeue();
            road.transform.position = _roadPosition[i].position + (Vector3.forward * (_zOffset * _lastZOffset ));
            _roadGenerationQueue.Enqueue(road);
        }
        _lastZOffset++;
    }
    //private void Update()
    //{
    //    _lastSpawnRoad -= Time.deltaTime;
    //    _lastSpawnObstacle -= Time.deltaTime;
    //    if (_lastSpawnRoad <= 0 )
    //    {
    //        GenerationRoadInPosition();
    //    }
    //    if (_lastSpawnObstacle <=0) 
    //    {
    //        GenerationObstacle();

    //    }
    //}

    public void OnStartGame()
    {
        _lastSpawnRoad = _timeToGenerationRoad;
        _lastSpawnObstacle = _timeToGenerationObstacle;
        for (int j = 0; j < _countStartGenerationRoad; j++)
        {
            for (int i = 0; i < _roadPosition.Length; i++)
            {
                //GameObject road = Instantiate(_prefabRoad, _roadPosition[i].position + (Vector3.forward * (_zOffset*j)),Quaternion.identity, _roadPosition[i]);
                //_roadGenerationQueue.Enqueue(road);
                GenerationRoadInPosition(_roadPosition[i].position + (Vector3.forward * (_zOffset * j)), _roadPosition[i]);
            }
        }
        InitObstacleQueue();
        _lastZOffset = _countStartGenerationRoad;
    }

    public void OnUpdate(float deltaTime)
    {
        _lastSpawnRoad -= deltaTime;
        _lastSpawnObstacle -= deltaTime;
        if (_lastSpawnRoad <= 0)
        {
            GenerationRoadInPosition();
        }
        if (_lastSpawnObstacle <= 0)
        {
            GenerationObstacle();

        }
    }

    

   
}
