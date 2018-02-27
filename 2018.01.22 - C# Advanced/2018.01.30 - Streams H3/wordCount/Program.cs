using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace wordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader wordReader = new StreamReader("../../words.txt"))
            {
                List<string> words = new List<string>();
                string singleWord = wordReader.ReadLine();
                while (singleWord != null)
                {
                    words.Add(singleWord);
                    singleWord = wordReader.ReadLine();
                }
                using (StreamReader textReader = new StreamReader("../../text.txt"))
                {
                    List<string> sentanses = new List<string>();
                    string singleSentanse = textReader.ReadLine();
                    while (singleSentanse != null)
                    {
                        sentanses.Add(singleSentanse.ToLower());
                        singleSentanse = textReader.ReadLine();
                    }
                    Dictionary<string, int> resultData = new Dictionary<string, int>();
                    for (int word = 0; word < words.Count; word++)
                    {
                    Regex regex = new Regex($@"\W{words[word]}\W");
                        for (int i = 0; i < sentanses.Count; i++)
                        {
                            MatchCollection matches = regex.Matches(sentanses[i]);
                            if (resultData.ContainsKey(words[word]) && matches.Count != 0)
                            {
                                resultData[words[word]] += matches.Count;
                            }
                            if (!resultData.ContainsKey(words[word]) && matches.Count != 0)
                            {
                                resultData.Add(words[word], matches.Count);
                            }
                        }
                    }
                    using (StreamWriter writer = new StreamWriter("../../result.txt"))
                    {
                        foreach (var word in resultData.OrderByDescending(x => x.Value))
                            {
                                writer.WriteLine($"{word.Key} - {word.Value}");
                            }
                        }
                    }
                }

            }
        }
    }
