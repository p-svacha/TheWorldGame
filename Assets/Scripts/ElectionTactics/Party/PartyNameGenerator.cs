﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ElectionTactics
{
    public static class PartyNameGenerator
    {
        private static List<string> Adjectives = new List<string>() // A
        {
            "Revolutionary",
            "Socialist",
            "Anarchist",
            "Conservative",
            "Anti-Fascist",
            "Fascist",
            "Nationalist",
            "Social",
            "Democratic",
            "Communist",
            "Republican",
            "Civic",
            "Progressive",
            "Liberal",
            "Libertarian",
            "Christian",
            "Islamist",
            "Muslim",
            "United",
            "Eastern",
            "Western",
            "Northern",
            "Southern",
            "Radical",
            "Red",
            "Black",
            "Blue",
            "Yellow",
            "Green",
            "Orange",
            "White",
            "Purple",
            "Brown",
            "Left",
            "Right",
            "Reformist",
            "Anti-Capitalist"
        };

        private static List<string> PartyTypeNouns = new List<string>() // T
        {
            "People's",
            "Labour",
            "Worker",
            "Patriot",
            "Justice",
            "Development",
            "Common Man's",
            "Regeneration",
            "Mobilization",
            "Liberty",
            "Constitution",
            "Resurgence",
            "Order",
            "Law",
            "Freedom"
        };

        private static List<string> PartyNouns = new List<string>() // P
        {
            "Party",
            "Movement",
            "Union",
            "League",
            "Alliance",
            "Front",
            "Action",
            "Organisation",
            "Association",
            "Treaty",
            "Pact",
            "Bloc",
            "Federation",
            "Coalition",
            "Faction",
            "Militia"
        };

        private static Dictionary<char, List<string>> ListDict = new Dictionary<char, List<string>>()
        {
            {'A', Adjectives },
            {'T', PartyTypeNouns },
            {'P', PartyNouns }
        };

        private static List<string> NameLanguage = new List<string>() // This list defines which combinations of the above lists are allowed
        {
            "TP",
            "AP",

            "ATP",
            "AAP",

            "AATP",
            "AAAP",

            "AAATP"
        };

        private static List<Color> Colors = new List<Color>()
        {
            new Color(0.80f, 0.80f, 0.80f), // 0 - White
            new Color(0.28f, 0.53f, 0.22f), // 1 - Green
            new Color(0.20f, 0.40f, 0.60f), // 2 - Blue
            new Color(0.80f, 0.20f, 0.25f), // 3 - Red
            new Color(0.80f, 0.75f, 0.15f), // 4 - Yellow
            new Color(0.05f, 0.05f, 0.05f), // 5 - Black
            new Color(0.75f, 0.50f, 0.16f), // 6 - Orange
            new Color(0.55f, 0.16f, 0.55f), // 7 - Purple
            new Color(0.46f, 0.30f, 0.14f), // 8 - Brown
        };


        public static string GetRandomPartyName()
        {
            string name = "";

            string nameType = NameLanguage[Random.Range(0, NameLanguage.Count)];
            //string nameType = GetRandomNameLanguage();
            foreach(char c in nameType)
            {
                if (c == 'A')
                {
                    name += (GetRandomAdjective(name) + " ");
                }
                else
                {
                    List<string> list = ListDict[c];
                    string word = list[Random.Range(0, list.Count)];
                    name += (word + " ");
                }
            }
            name = name.Trim(' ');

            return name;
        }

        public static Color GetPartyColor(string partyName, List<Color> alreadyTaken)
        {
            if (partyName.Contains("White") && !alreadyTaken.Contains(Colors[0])) return Colors[0];
            if (partyName.Contains("Green") && !alreadyTaken.Contains(Colors[1])) return Colors[1];
            if (partyName.Contains("Blue") && !alreadyTaken.Contains(Colors[2])) return Colors[2];
            if (partyName.Contains("Red") && !alreadyTaken.Contains(Colors[3])) return Colors[3];
            if (partyName.Contains("Yellow") && !alreadyTaken.Contains(Colors[4])) return Colors[4];
            if (partyName.Contains("Black") && !alreadyTaken.Contains(Colors[5])) return Colors[5];
            if (partyName.Contains("Orange") && !alreadyTaken.Contains(Colors[6])) return Colors[6];
            if (partyName.Contains("Purple") && !alreadyTaken.Contains(Colors[7])) return Colors[7];
            if (partyName.Contains("Brown") && !alreadyTaken.Contains(Colors[8])) return Colors[8];
            else return GetRandomColor(alreadyTaken);
        }

        private static Color GetRandomColor(List<Color> forbiddenColors)
        {
            Color c = Colors[Random.Range(0, Colors.Count)];
            while(forbiddenColors.Contains(c))
            {
                c = Colors[Random.Range(0, Colors.Count)];
            }
            return c;
        }

        private static string GetRandomNameLanguage()
        {
            string lang = "";

            int numAdjectives = Random.Range(0, 4);
            for (int i = 0; i < numAdjectives; i++) lang += 'A';

            if (numAdjectives == 0 || Random.value > 0.5f) lang += "T";
            lang += "P"; 

            return lang;
        }

        private static string GetRandomAdjective(string lang)
        {
            string adj = Adjectives[Random.Range(0, Adjectives.Count)];
            while(lang.Contains(adj))
            {
                adj = Adjectives[Random.Range(0, Adjectives.Count)];
            }
            return adj;
        }
    }


}