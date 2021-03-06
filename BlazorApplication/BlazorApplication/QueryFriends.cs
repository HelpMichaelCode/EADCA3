﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace BlazorApplication
{
    public class QueryFriends
    {
        [DataType(DataType.Text)]
        public string CharacterInputValue { get; set; } // Input value for character filter and keyword filter

        [DataType(DataType.Text)]
        public string KeywordInputValue { get; set; } // Input value for character filter and keyword filter
        private bool isSortedAscending;
        private string activeSortColumn;

        public List<FriendsResponseData> listOfQuotes;

        public void SortTable(string columnName)
        {
            // Checking for the current activeSortColumn name clicked on
            if (columnName != activeSortColumn)
            {
                // If the column name is not equals to the active column name 
                // Then order the list collection from ascending to descending
                listOfQuotes = listOfQuotes.OrderBy(name => name.character).ToList();

                // Set the isSortedAscending to true 
                isSortedAscending = true;

                // Set the activeSortColumn to the passed in column name 
                activeSortColumn = columnName;
            }
            // If the column name is already == activeSortColumn 
            else
            {
                // If the column is already sorted
                if (isSortedAscending)
                {
                    // Then have the list collection in descending order
                    listOfQuotes = listOfQuotes.OrderByDescending(name => name.character).ToList();
                }
                else
                {
                    listOfQuotes = listOfQuotes.OrderBy(name => name.character).ToList();
                }
                // Reset sorting 
                isSortedAscending = !isSortedAscending;
            }
        }

        public bool FilterByQuote(FriendsResponseData friends)
        {
            if (string.IsNullOrEmpty(KeywordInputValue))
                return true;

            // Checks if the input value matches any value within the collection and ignoring the letter case sensitive
            if (friends.quote.Contains(KeywordInputValue, StringComparison.OrdinalIgnoreCase))
                return true;

            return false;
        }

        public bool FilterByCharacter(FriendsResponseData friends)
        {
            if (string.IsNullOrEmpty(CharacterInputValue))
                return true;

            // Checks if the input value matches any value within the collection and ignoring the letter case sensitive
            if (friends.character.Contains(CharacterInputValue, StringComparison.OrdinalIgnoreCase))
                return true;

            return false;
        }
    }
}
