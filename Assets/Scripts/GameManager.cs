using System.Collections.Generic;
using Ebac.Core.Singleton;
using UnityEngine;
using DG.Tweening;

public class GameManager : Singleton<GameManager>
{

    [Header("Player Animation")]
    public float duration = .2f;
    public float delay = .05f;
    public Ease ease = Ease.OutBack;

    [Header("Player")]
    public GameObject playerPFB;

    [Header("Enemies")]
    public List<GameObject> enemies;

    [Header("References")]
    public Transform playerStartPoint;

    private GameObject _currentPlayer;

    public void Init()
    {
        SpawnPlayer();
    }

    private void Start()
    {
        Init();
    }

    private void SpawnPlayer()
    {
        _currentPlayer = Instantiate(playerPFB);
        _currentPlayer.transform.position = playerStartPoint.transform.position;
        _currentPlayer.transform.DOScale(0, duration).SetEase(ease).From().SetDelay(delay);
        // playerPFB.SetActive(true);
    }




}
