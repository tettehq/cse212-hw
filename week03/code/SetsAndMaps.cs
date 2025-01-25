using System.Text.Json;
using System.Linq;

public static class SetsAndMaps
{
    /// <summary>
    /// The words parameter contains a list of two character 
    /// words (lower case, no duplicates). Using sets, find an O(n) 
    /// solution for returning all symmetric pairs of words.  
    ///
    /// For example, if words was: [am, at, ma, if, fi], we would return :
    ///
    /// ["am & ma", "if & fi"]
    ///
    /// The order of the array does not matter, nor does the order of the specific words in each string in the array.
    /// at would not be returned because ta is not in the list of words.
    ///
    /// As a special case, if the letters are the same (example: 'aa') then
    /// it would not match anything else (remember the assumption above
    /// that there were no duplicates) and therefore should not be returned.
    /// </summary>
    /// <param name="words">An array of 2-character words (lowercase, no duplicates)</param>
    public static string[] FindPairs(string[] words)
    {
        // TODO Problem 1 - ADD YOUR CODE HERE
        // create a list to store the pairs result named matches
        // create a hashset to get all unique values in the word list and enable fast lookups
        // reverse each word in the word list using the Array.Reverse method
        // check if each reversed word exists in the hashset
        // if reversed word is in hashset, add both reversed word and original word to result list and delete the word from the hashset.
        // return result list
        List<string> matches = new();
        var unique = new HashSet<string> (words);
        foreach (var word in words) {
            char[] charArray = word.ToCharArray();
            Array.Reverse(charArray);
            string reversed = new(charArray);

            if (unique.Contains(reversed) && word != reversed) {
                string match = $"{reversed} & {word}";
                matches.Add(match);
                unique.Remove(word);
                unique.Remove(word);

            }
        }
        return matches.ToArray();
    }

    /// <summary>
    /// Read a census file and summarize the degrees (education)
    /// earned by those contained in the file.  The summary
    /// should be stored in a dictionary where the key is the
    /// degree earned and the value is the number of people that 
    /// have earned that degree.  The degree information is in
    /// the 4th column of the file.  There is no header row in the
    /// file.
    /// </summary>
    /// <param name="filename">The name of the file to read</param>
    /// <returns>fixed array of divisors</returns>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();
        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");
            // TODO Problem 2 - ADD YOUR CODE HERE

            // return the degree names and store them as keys in the dictionary
            // conditional statement checks if the degree name is already stored as a key, and increments the value by 1
            if (degrees.ContainsKey(fields[3])) {
                degrees[fields[3]]++;
            }
            // if degree name is not found as a key in the dictionary, it is then stored as one and initialized with a value of 1
            else {
                degrees[fields[3]] = 1;
            }
        }

        return degrees;
    }

    /// <summary>
    /// Determine if 'word1' and 'word2' are anagrams.  An anagram
    /// is when the same letters in a word are re-organized into a 
    /// new word.  A dictionary is used to solve the problem.
    /// 
    /// Examples:
    /// is_anagram("CAT","ACT") would return true
    /// is_anagram("DOG","GOOD") would return false because GOOD has 2 O's
    /// 
    /// Important Note: When determining if two words are anagrams, you
    /// should ignore any spaces.  You should also ignore cases.  For 
    /// example, 'Ab' and 'Ba' should be considered anagrams
    /// 
    /// Reminder: You can access a letter by index in a string by 
    /// using the [] notation.
    /// </summary>
    public static bool IsAnagram(string word1, string word2)
    {
        // create a dictionary to hold character counts.
        var anagramDict = new Dictionary<char, int>();

        // clean up input words by removing spaces and converting to lowercase.
        string cleanWord1 = word1.Replace(" ", "").ToLower();
        string cleanWord2 = word2.Replace(" ", "").ToLower();

        // check if the cleaned words have the same length.
        if (cleanWord1.Length != cleanWord2.Length)
        {
            return false;
        }


        // populate the dictionary with character counts from cleanWord1.
        foreach (char c in cleanWord1)
        {
            if (anagramDict.ContainsKey(c))
            {
                anagramDict[c]++;
            }
            else
            {
                anagramDict[c] = 1;
            }
        }

        // decrement character counts based on cleanWord2.
        foreach (char c in cleanWord2)
        {
            if (!anagramDict.ContainsKey(c)) // exit and return false if character in cleanWord2 is not found in dictionary
            {
                return false;
            }
            anagramDict[c]--;

            // exit early if character count goes lower than zero
            if (anagramDict[c] < 0) {
                return false;
            }
        }

        // at this point, all counts are zero, so the words are anagrams.
        return true;
    }

    /// <summary>
    /// This function will read JSON (Javascript Object Notation) data from the 
    /// United States Geological Service (USGS) consisting of earthquake data.
    /// The data will include all earthquakes in the current day.
    /// 
    /// JSON data is organized into a dictionary. After reading the data using
    /// the built-in HTTP client library, this function will return a list of all
    /// earthquake locations ('place' attribute) and magnitudes ('mag' attribute).
    /// Additional information about the format of the JSON data can be found 
    /// at this website:  
    /// 
    /// https://earthquake.usgs.gov/earthquakes/feed/v1.0/geojson.php
    /// 
    /// </summary>
    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);
        var json = reader.ReadToEnd();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

        // TODO Problem 5:
        // 1. Add code in FeatureCollection.cs to describe the JSON using classes and properties 
        // on those classes so that the call to Deserialize above works properly.
        // 2. Add code below to create a string out each place a earthquake has happened today and its magitude.
        // 3. Return an array of these string descriptions.

        // keeps the length of the featureCollection.features to use to declare the result array
        var Size = featureCollection.Features.Length;
        string[] resultArray = new string[Size]; // create array to store results
        int index = 0; // index will be used to add items to the resultArray

        // create a loop that gets the magnitude and place of an earthquake and formats it as a string
        // then adds the result to the resultArray
        foreach (var feature in featureCollection.Features)
        {
            string result = $"{feature.Properties.Place} - Mag {feature.Properties.Magnitude}";
            resultArray[index++] = result;
        }

        // return results
        return resultArray;
    }
}