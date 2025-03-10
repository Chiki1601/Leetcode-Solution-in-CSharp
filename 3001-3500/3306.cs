public class Solution {
    public long CountOfSubstrings(string word, int k) {
        int[,] frequencies = new int[2, 128];
        foreach (char vowel in "aeiou")
            frequencies[0, vowel] = 1;

        long response = 0;
        int currentK = 0, vowels = 0, extraLeft = 0;

        for (int right = 0, left = 0; right < word.Length; right++) {
            char rightChar = word[right];

            if (frequencies[0, rightChar] == 1) {
                if (++frequencies[1, rightChar] == 1) vowels++;
            } else {
                currentK++;
            }

            while (currentK > k) {
                char leftChar = word[left];
                if (frequencies[0, leftChar] == 1) {
                    if (--frequencies[1, leftChar] == 0) vowels--;
                } else {
                    currentK--;
                }
                left++;
                extraLeft = 0;
            }

            while (vowels == 5 && currentK == k && left < right && frequencies[0, word[left]] == 1 && frequencies[1, word[left]] > 1) {
                extraLeft++;
                frequencies[1, word[left]]--;
                left++;
            }

            if (currentK == k && vowels == 5) {
                response += (1 + extraLeft);
            }
        }

        return response;
    }
}
