using System;

public class Solution
{
    private record Step(int row, int column, int timeFromStart) { }

    private static readonly int[] UP = { -1, 0 };
    private static readonly int[] DOWN = { 1, 0 };
    private static readonly int[] LEFT = { 0, -1 };
    private static readonly int[] RIGHT = { 0, 1 };
    private static readonly int[][] MOVES = { UP, DOWN, LEFT, RIGHT };

    private int rows;
    private int columns;

    private int startRow;
    private int startColumn;

    private int targetRow;
    private int targetColumn;

    public int MinTimeToReach(int[][] moveTime)
    {
        rows = moveTime.Length;
        columns = moveTime[0].Length;

        startRow = 0;
        startColumn = 0;

        targetRow = rows - 1;
        targetColumn = columns - 1;

        return DijkstraSearchForPathWithMinTime(moveTime);
    }

    private int DijkstraSearchForPathWithMinTime(int[][] moveTime)
    {
        PriorityQueue<Step, int> minHeapForTime = new PriorityQueue<Step, int>(
            Comparer<int>.Create((x, y) => x - y));

        minHeapForTime.Enqueue(new Step(startRow, startColumn, 0), 0);

        int[][] minTimeMatrix = new int[rows][];
        for (int row = 0; row < rows; ++row)
        {
            minTimeMatrix[row] = new int[columns];
            Array.Fill(minTimeMatrix[row], int.MaxValue);
        }
        minTimeMatrix[startRow][startColumn] = 0;

        while (minHeapForTime.Count > 0)
        {
            Step current = minHeapForTime.Dequeue();
            if (current.row == targetRow && current.column == targetColumn)
            {
                break;
            }

            foreach (int[] move in MOVES)
            {
                int nextRow = current.row + move[0];
                int nextColumn = current.column + move[1];
                if (!IsInMatrix(nextRow, nextColumn))
                {
                    continue;
                }

                int nextValueForTime = Math.Max(1 + current.timeFromStart, 1 + moveTime[nextRow][nextColumn]);
                if (minTimeMatrix[nextRow][nextColumn] > nextValueForTime)
                {
                    minTimeMatrix[nextRow][nextColumn] = nextValueForTime;
                    minHeapForTime.Enqueue(new Step(nextRow, nextColumn, nextValueForTime), nextValueForTime);
                }
            }
        }

        return minTimeMatrix[targetRow][targetColumn];
    }

    private bool IsInMatrix(int row, int column)
    {
        return row >= 0 && row < rows && column >= 0 && column < columns;
    }
}
