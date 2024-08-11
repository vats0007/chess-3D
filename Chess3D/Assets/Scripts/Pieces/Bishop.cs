using System.Collections;
using System.Collections.Generic;
using Chess.Scripts.Core;
using UnityEngine;

public class Bishop : Piece
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
        IJPlaneMoves();
        JKPlaneMoves();
        IKPlaneMoves();
    }

    void GetMyPosition()
    {
        _a = _chessPlayerHandler.i;
        _b = _chessPlayerHandler.j;
        _c = _chessPlayerHandler.k;
    }

    void IJPlaneMoves()
    {
        for (int i = _a + 1, j = _b + 1; i < 8 && j < 8; i++, j++)
        {
            ChessBoard.Instance.Highlight(i, j, _c);
        }
        
        for (int i = _a + 1, j = _b - 1; i < 8 && j >= 0; i++, j--)
        {
            ChessBoard.Instance.Highlight(i, j, _c);
        }
        
        for (int i = _a - 1, j = _b + 1; i >= 0 && j < 8; i--, j++)
        {
            ChessBoard.Instance.Highlight(i, j, _c);
        }
        
        for (int i = _a - 1, j = _b - 1; i >= 0 && j >= 0; i--, j--)
        {
            ChessBoard.Instance.Highlight(i, j, _c);
        }
    }

    void JKPlaneMoves()
    {
        for (int j = _b + 1, k = _c + 1; j < 8 && k < 8; j++, k++)
        {
            ChessBoard.Instance.Highlight(_a, j, k);
        }

        for (int j = _b + 1, k = _c - 1; j < 8 && k >= 0; j++, k--)
        {
            ChessBoard.Instance.Highlight(_a, j, k);
        }

        for (int j = _b - 1, k = _c + 1; j >= 0 && k < 8; j--, k++)
        {
            ChessBoard.Instance.Highlight(_a, j, k);
        }

        for (int j = _b - 1, k = _c - 1; j >= 0 && k >= 0; j--, k--)
        {
            ChessBoard.Instance.Highlight(_a, j, k);
        }
    }
    void IKPlaneMoves()
    {
        for (int i = _a + 1, k = _c + 1; i < 8 && k < 8; i++, k++)
        {
            ChessBoard.Instance.Highlight(i, _b, k);
        }

        for (int i = _a + 1, k = _b - 1; i < 8 && k >= 0; i++, k--)
        {
            ChessBoard.Instance.Highlight(i, _b, k);
        }

        for (int i = _a - 1, k = _b + 1; i >= 0 && k < 8; i--, k++)
        {
            ChessBoard.Instance.Highlight(i, _b, k);
        }

        for (int i = _a - 1, k = _b - 1; i >= 0 && k >= 0; i--, k--)
        {
            ChessBoard.Instance.Highlight(i, _b, k);
        }
    }
}
