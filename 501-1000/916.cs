using System;
using System.Collections.Generic;

public class Solution {
    public IList<string> WordSubsets(string[] words1, string[] words2) {
        // Initialize the maximum frequency required for each character
        int[] maxFrequencies = new int[26]; // For letters 'a' to 'z'
        HashSet<int> lettersNeeded = new HashSet<int>(); // Track letters needed

        // Function to count character frequencies in a word
        int[] CountFrequencies(string word) {
            int[] frequencies = new int[26];
            foreach (char c in word) {
                int idx = c - 'a';
                frequencies[idx]++;
            }
            return frequencies;
        }

        // Compute maximum frequencies from words2
        foreach (string word in words2) {
            int[] wordFrequencies = CountFrequencies(word);
            for (int i = 0; i < 26; i++) {
                if (wordFrequencies[i] > maxFrequencies[i]) {
                    maxFrequencies[i] = wordFrequencies[i];
                    lettersNeeded.Add(i);
                }
            }
        }

        // Convert lettersNeeded to a list for faster iteration
        List<int> lettersNeededList = new List<int>(lettersNeeded);

        // List to store universal words
        List<string> universalWords = new List<string>();

        // Check each word in words1
        foreach (string word in words1) {
            int[] wordFrequencies = CountFrequencies(word);
            bool isUniversal = true;
            foreach (int i in lettersNeededList) {
                if (wordFrequencies[i] < maxFrequencies[i]) {
                    isUniversal = false;
                    break;
                }
            }
            if (isUniversal) {
                universalWords.Add(word);
            }
        }

        return universalWords;
    }
}
