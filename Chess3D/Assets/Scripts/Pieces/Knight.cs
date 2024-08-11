using System.Collections;
using System.Collections.Generic;
using Chess.Scripts.Core;
using UnityEngine;

public class Knight : Piece
{
    private int _a, _b, _c;//Defines Piece Position
    private ChessPlayerHandler _chessPlayerHandler;

    int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        _chessPlayerHandler = GetComponent<ChessPlayerHandler>();
        GetMyPosition();
        CalculatePossibleMoves();
        Debug.Log(count);
    }

    public override void CalculatePossibleMoves()
    {
        int[,] knightMoveAdder = new int[,]
{
    { 2, 1, 0 }, { 2, -1, 0 }, { -2, 1, 0 }, { -2, -1, 0 },
    { 1, 2, 0 }, { 1, -2, 0 }, { -1, 2, 0 }, { -1, -2, 0 },

    { 2, 0, 1 }, { 2, 0, -1 }, { -2, 0, 1 }, { -2, 0, -1 },
    { 1, 0, 2 }, { 1, 0, -2 }, { -1, 0, 2 }, { -1, 0, -2 },

    { 0, 2, 1 }, { 0, 2, -1 }, { 0, -2, 1 }, { 0, -2, -1 },
    { 0, 1, 2 }, { 0, 1, -2 }, { 0, -1, 2 }, { 0, -1, -2 }
};

        count = 0;
        for (int i = 0; i < knightMoveAdder.GetLength(0); i++)
        {
            int newI = _a + knightMoveAdder[i, 0];
            int newJ = _b + knightMoveAdder[i, 1];
            int newK = _c + knightMoveAdder[i, 2];

            if (newI < 0 || newI >= 8 || newJ < 0 || newJ >= 8 || newK < 0 || newK >= 8) continue;
            ChessBoard.Instance.Highlight(newI, newJ, newK);
            count++;
        }
    }

    //public override void CheckForEnemyPieces()
    //{
    //    throw new System.NotImplementedException();
    //}

    //public override void CheckForFriendlyPieces()
    //{
    //    throw new System.NotImplementedException();
    //}


    // Update is called once per frame
    void Update()
    {

    }

    void GetMyPosition()
    {
        _a = _chessPlayerHandler.i;
        _b = _chessPlayerHandler.j;
        _c = _chessPlayerHandler.k;
    }
}
