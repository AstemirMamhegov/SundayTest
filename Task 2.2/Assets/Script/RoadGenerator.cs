using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadGenerator : MonoBehaviour
{
    private List<GameObject> _readyRoad = new List<GameObject>();

    [SerializeField, Header("Все участки дорог")] private GameObject[] _road;
    [SerializeField] private bool[] _roadNumbers;

    [Header("Текущая длина дороги")] public int currentRoadLength = 0;

    [Header("Максимальная длина дороги")] public int maximumRoadLength = 6;

    [Header("Дистанция между дорогами")] public float distanceBetweenRoads;

    [Header("Скорость перемещения дороги")] public float speedRoad = 5;

    [Header("Позиция Z при которой исчезает дорога")] public float maximumPositionZ = -15;

    [Header("Зона ожидания")] public Vector3 waitingZona = new Vector3 (0, 0, -40);

    private int _currentRoadNumber = -1;
    private int _lastRoadNumber = -1;

    [Header("Статус генерации")] public string roadGenerationStatus = "Generation";

    private void FixedUpdate()
    {
        if (roadGenerationStatus == "Generation")
        {
            if (currentRoadLength != maximumRoadLength)
            {
                _currentRoadNumber = Random.Range(0, _road.Length);

                if (_currentRoadNumber != _lastRoadNumber)
                {
                    if (_currentRoadNumber < _road.Length / 2)
                    {
                        if (_roadNumbers[_currentRoadNumber] != true)
                        {
                            if (_lastRoadNumber != (_road.Length / 2) + _currentRoadNumber)
                            {
                                RoadCreation();
                            }
                            else if (_lastRoadNumber == (_road.Length / 2) + _currentRoadNumber && currentRoadLength == _road.Length - 1)
                            {
                                RoadCreation();
                            }
                        }
                    }
                    else if (_currentRoadNumber >= _road.Length / 2)
                    {
                        if (_roadNumbers[_currentRoadNumber] != true)
                        {
                            if (_lastRoadNumber != _currentRoadNumber - (_road.Length / 2))
                            {
                                RoadCreation();
                            }
                            else if (_lastRoadNumber == _currentRoadNumber - (_road.Length / 2) && currentRoadLength == _road.Length / 2)
                            {
                                RoadCreation();
                            }
                        }

                    }
                }
            }

            MovingRoad();

            if (_readyRoad.Count != 0)
            {
                RemovingRoad();
            }
        }
    }

    private void MovingRoad()
    {
        foreach (GameObject readyRoad in _readyRoad)
        {
            readyRoad.transform.localPosition -= new Vector3(0f, 0f, speedRoad * Time.fixedDeltaTime);
        }
    }

    private void RemovingRoad()
    {
        if (_readyRoad[0].transform.localPosition.z < maximumPositionZ)
        {
            int i;
            i = _readyRoad[0].GetComponent<Road>().number;
            _roadNumbers[i] = false;
            _readyRoad[0].transform.localPosition = waitingZona;
            _readyRoad.RemoveAt(0);
            currentRoadLength--;
        }
    }

    private void RoadCreation()
    {
        if (_readyRoad.Count > 0)
        {
            _road[_currentRoadNumber].transform.localPosition = _readyRoad[_readyRoad.Count - 1].transform.position + new Vector3(0f, 0f, distanceBetweenRoads);
        }
        else if (_readyRoad.Count == 0)
        {
            _road[_currentRoadNumber].transform.localPosition = new Vector3(0f, 0f, 0f);
        }

        _road[_currentRoadNumber].GetComponent<Road>().number = _currentRoadNumber;

        _roadNumbers[_currentRoadNumber] = true;

        _lastRoadNumber = _currentRoadNumber;

        _readyRoad.Add(_road[_currentRoadNumber]);

        currentRoadLength++;
    }
}
