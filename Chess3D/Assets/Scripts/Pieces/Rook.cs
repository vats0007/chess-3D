using System.Collections;
using System.Collections.Generic;
using Chess.Scripts.Core;
using UnityEngine;

public class Rook : Piece
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

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void CalculatePossibleMoves()
    {
        //in i 
        for (int i = _a + 1; i < 8; i++)
        {
            ChessBoard.Instance.Highlight(i, _b, _c); 
        }

        for (int i = _a - 1; i >= 0; i--)
        {
            ChessBoard.Instance.Highlight(i, _b, _c);
        }

        //in j
        for (int j = _b + 1; j < 8; j++)
        {
            ChessBoard.Instance.Highlight(_a, j, _c);
        }

        for (int j = _b - 1; j >= 0; j--)
        {
            ChessBoard.Instance.Highlight(_a, j, _c);
        }

        //in k
        for (int k = _c + 1; k < 8; k++)
        {
            ChessBoard.Instance.Highlight(_a, _b, k);
        }

        for (int k = _c - 1; k >= 0; k--)
        {
            ChessBoard.Instance.Highlight(_a, _b, k);
        }
    }

    void GetMyPosition()
    {
        _a = _chessPlayerHandler.i;
        _b = _chessPlayerHandler.j;
        _c = _chessPlayerHandler.k;
    }
}
