using System;

public class Solution
{
    private static readonly int PLACEHOLDER_VALUE_FOR_FREE_TIME_BEFORE_FIRST_MEETING = -1;

    private int[]? eventTimeRange;
    private int totalNumberOfMeetings;

    public int MaxFreeTime(int totalEventTime, int maxNumberOfMeetingsToReschedule, int[] startTime, int[] endTime)
    {
        eventTimeRange = new int[] { 0, totalEventTime };
        totalNumberOfMeetings = startTime.Length;

        int maxFreeTime = 0;
        int currentFreeTime = startTime[0];
        int numberOfFreeTimeIntervals = startTime[0] > eventTimeRange[0] ? 1 : 0;

        int frontIndex = 0;
        int backIndex = startTime[0] > eventTimeRange[0] ? PLACEHOLDER_VALUE_FOR_FREE_TIME_BEFORE_FIRST_MEETING : 0;

        while (frontIndex < totalNumberOfMeetings)
        {

            if (numberOfFreeTimeIntervals < maxNumberOfMeetingsToReschedule + 1)
            {
                currentFreeTime += GetValueToExpandFreeTime(startTime, endTime, frontIndex);
                ++frontIndex;
                ++numberOfFreeTimeIntervals;
            }

            maxFreeTime = Math.Max(maxFreeTime, currentFreeTime);

            if (numberOfFreeTimeIntervals == maxNumberOfMeetingsToReschedule + 1)
            {
                currentFreeTime -= GetValueToShrinkFreeTime(startTime, endTime, backIndex);
                ++backIndex;
                --numberOfFreeTimeIntervals;
            }
        }
        return maxFreeTime;
    }

    private int GetValueToExpandFreeTime(int[] startTime, int[] endTime, int frontIndex)
    {
        if (frontIndex + 1 < totalNumberOfMeetings)
        {
            return startTime[frontIndex + 1] - endTime[frontIndex];
        }
        return eventTimeRange![1] - endTime[frontIndex];
    }

    private int GetValueToShrinkFreeTime(int[] startTime, int[] endTime, int backIndex)
    {
        if (backIndex == PLACEHOLDER_VALUE_FOR_FREE_TIME_BEFORE_FIRST_MEETING)
        {
            return startTime[0];
        }
        return startTime[backIndex + 1] - endTime[backIndex];
    }
}
