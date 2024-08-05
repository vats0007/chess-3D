using System;
using System.Collections;
using System.Diagnostics.CodeAnalysis;
using UnityEditor;
using UnityEngine;

public sealed class ChessBoard : MonoBehaviour
{
    [SerializeField] private GameObject[,,] _chessBoard;
    [SerializeField] private GameObject _posPrefab;
    [SerializeField] private GameObject _parentPrefab;
    [SerializeField] private GameObject _highlightPrefab;
    internal static ChessBoard Instance;

    private void Awake()
    {
        Instance = this;
        GenerateArray();
    }

    private void Start()
    {
        StartCoroutine(Testing());
    }

    private void GenerateArray()
    {
        _chessBoard = new GameObject[8, 8, 8];
        GameObject parent = _parentPrefab;

        for (int i = 0; i < 8; i++)
        {
            GameObject iParent = new GameObject($"i_{i}");
            iParent.transform.SetParent(parent.transform);

            for (int j = 0; j < 8; j++)
            {
                GameObject jParent = new GameObject($"j_{j}");
                jParent.transform.SetParent(iParent.transform);

                for (int k = 0; k < 8; k++)
                {
                    _chessBoard[i, j, k] = Instantiate(_posPrefab, new Vector3(i, j, k), Quaternion.identity);
                    _chessBoard[i, j, k].name = $"k_{k}";  // Assign name based on k index
                    _chessBoard[i, j, k].transform.SetParent(jParent.transform);
                }
            }
        }
    }

    internal GameObject GetTile(int i, int j,int k)
    {
        try
        {
            return _chessBoard[i, j, k];
        }
        catch (Exception)
        {
            Debug.LogError("Invalid row or column.");
            return null;
        }
    }

    internal void Highlight(int i, int j, int k)
    {
        var tile = GetTile(i, j, k).transform;
        if (tile == null)
        {
            Debug.LogError("Invalid row or column.");
            return;
        }

        Instantiate(_highlightPrefab, tile.transform.position, Quaternion.identity, tile.transform);
    }

    internal void ClearHighlights()
    {
        for (var i = 0; i < 8; i++)
        {
            for (var j = 0; j < 8; j++)
            {
                for(var k = 0; k < 8; k++)
                {
                    var tile = GetTile(i, j, k);
                    if (tile.transform.childCount <= 0) continue;
                    foreach (Transform childTransform in tile.transform)
                    {
                        Destroy(childTransform.gameObject);
                    }
                }
            }
        }
    }



    private IEnumerator Testing()
    {
        Highlight(2, 7, 1);
        yield return new WaitForSeconds(3f);

        ClearHighlights();
        Highlight(2, 7, 2);
        Highlight(2, 7, 3);
        Highlight(2, 5, 4);
        Highlight(2, 7, 7);
        yield return new WaitForSeconds(3f);

        ClearHighlights();
        Highlight(7, 7, 0);
        Highlight(2, 7, 0);
        yield return new WaitForSeconds(3f);
    }

}
