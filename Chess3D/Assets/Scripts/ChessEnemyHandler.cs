using System;
using UnityEngine;

namespace Chess.Scripts.Core
{
    public class ChessEnemyHandler : MonoBehaviour
    {
        [SerializeField] public int i, j, k;

        private void Start()
        {
            transform.position = ChessBoard.Instance.GetTile(i, j, k).transform.position;
        }
        private void Update()
        {
            transform.position = ChessBoard.Instance.GetTile(i, j, k).transform.position;
        }
    }
}