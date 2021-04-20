using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Comma_Sprinkler
{
    internal class VM : INotifyPropertyChanged
    {
        readonly List<string> wordsWithPreceedingCommas = new List<string>();
        readonly List<string> wordsWithSucceedingCommas = new List<string>();

        #region Singleton
        private static VM vm;
        public static VM Instance
        {
            get
            {
                vm ??= null;
                return new VM();
            }
        }
        #endregion

        #region Properties
        private string textInput;
        public string TextInput
        {
            get { return textInput; }
            set { textInput = value; notifyChange(); }
        }

        private string output;

        public string Output
        {
            get { return output; }
            set { output = value; notifyChange(); }
        }

        private string fileName;

        public string FileName
        {
            get { return fileName; }
            set { fileName = value; notifyChange(); }
        }
        #endregion

        #region Methods
        public void SprinkleComma(string input)
        {
            Output = "";

            string[] sentences = input.Split(new string[] { ". ", "." }, StringSplitOptions.RemoveEmptyEntries);
            string previousInput = input;
            string currentInput;

            foreach (string sentence in sentences)
                PopulateWordsToApplyRulesLists(sentence);
          
            foreach (string foundWord in wordsWithSucceedingCommas)
            {
                for (int i = 0; i < sentences.Length; i++)
                {
                    string[] words = sentences[i].Split(new char[] { ' ' });
                    string[] modifiedWords = ApplyIfWordSucceededByComma(words, foundWord);
                    sentences[i] = String.Join(" ", modifiedWords);
                }
            }

            foreach (string foundWord in wordsWithPreceedingCommas)
            {
                for (int i = 0; i < sentences.Length; i++)
                {
                    string[] words = sentences[i].Split(new char[] { ' ' });
                    string[] modifiedWords = ApplyIfWordPreceededByComma(words, foundWord);
                    sentences[i] = String.Join(" ", modifiedWords);
                }
            }
            
            currentInput = String.Join(". ", sentences) + ".";

            //This recursively calls the function by comparing the current and previous inputs.
            if (currentInput != previousInput)
                SprinkleComma(currentInput);
            else
            {
                wordsWithPreceedingCommas.Clear();
                wordsWithSucceedingCommas.Clear();
                Output = currentInput;
            }
        }

        private string[] ApplyIfWordSucceededByComma(string[] words, string foundWord)
        {
            for (int i = 0; i < words.Length - 1; i++)
            {               
                string currentWord = words[i];

                if (foundWord == currentWord && i != words.Length - 1)
                    words[i] = currentWord + ",";
            }
              
            return words;               
        }

        private string[] ApplyIfWordPreceededByComma(string[] words, string foundWord)
        {
            string firstWord = words[0];

            for (int i = 1; i < words.Length ; i++)
            {
                string currentWord = words[i];
                string previousWord = words[i - 1];
               
                if (!HasSucceedingComma(previousWord) && (currentWord == foundWord || currentWord == foundWord + ","))
                    words[i - 1] = previousWord + ",";                  
            }

            if (words[1] == foundWord  && !HasSucceedingComma(firstWord))
                words[0] = firstWord  + ",";

            return words;
        }

        private void PopulateWordsToApplyRulesLists(string sentence)
        {
            if (sentence.Contains(','))
            {
                string[] words = sentence.Split(new char[] { ' ' });

                for (int i = 0; i < words.Length - 1; i++) 
                {
                    string currentWord = words[i];
                    string nextWord = words[i + 1];

                    if (HasSucceedingComma(currentWord))
                    {
                        if (!wordsWithSucceedingCommas.Contains(RemoveLastChar(currentWord)))
                            wordsWithSucceedingCommas.Add(RemoveLastChar(currentWord));

                        if (!wordsWithPreceedingCommas.Contains(nextWord))
                            wordsWithPreceedingCommas.Add(nextWord);
                    }
                }
            }
        }

        private bool HasSucceedingComma(string word)
        {
            return word.EndsWith(",");
        }

        private string RemoveLastChar(string input)
        {
            return input.Remove(input.Length - 1, 1);
        }
        #endregion

        #region Property Changed
        public event PropertyChangedEventHandler PropertyChanged;

        private void notifyChange([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
