using System;

public class Solution
{
    public long CountSubarrays(int[] input, int minFrequencyForMaxValue)
    {
        int maxValue = input.Max();
        foreach (int value in input)
        {
            maxValue = Math.Max(maxValue, value);
        }

        int left = 0;
        int right = 0;
        int frequencyMaxValue = 0;
        long countSubarrays = 0;

        while (right < input.Length)
        {
            frequencyMaxValue += (input[right] == maxValue) ? 1 : 0;

            while (frequencyMaxValue == minFrequencyForMaxValue)
            {
                frequencyMaxValue -= (input[left] == maxValue) ? 1 : 0;
                ++left;
            }
            ++right;

            countSubarrays += left;
        }

        return countSubarrays;

    }
}
