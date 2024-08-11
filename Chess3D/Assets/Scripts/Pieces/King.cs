using System.Collections;
using System.Collections.Generic;
using Chess.Scripts.Core;
using UnityEngine;

public class King : Piece
{
    private int _a,_b,_c;//Defines Piece Position
    private ChessPlayerHandler _chessPlayerHandler;


    // Start is called before the first frame update
    void Start()
    {
        _chessPlayerHandler = GetComponent<ChessPlayerHandler>();
        GetMyPosition();
        CalculatePossibleMoves();
    }

    public override void CalculatePossibleMoves()
    {
        for (int i = _a - 1; i <= _a + 1; i++) 
        {
            for(int j = _b - 1; j <= _b + 1; j++)
            {
                for(int k = _c - 1; k <= _c + 1; k++)
                {
                    if(i >= 0 && i < 8 && j >= 0 && j < 8 && k >=0 && k < 8 && !(i == _a && j == _b && k == _c))
                    {
                        ChessBoard.Instance.Highlight(i, j, k);
                    }
                }
            }
        }
    }

    //public override void CheckForEnemyPieces()
    //{
    //    throw new System.NotImplementedException();
    //}

    public override void CheckForFriendlyPieces()
    {
        
    }


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
