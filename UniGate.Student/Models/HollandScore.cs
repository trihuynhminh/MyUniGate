using System.Collections.Generic;

namespace UniGate.Student.Models
{
    /// <summary>
    /// Lưu điểm của 1 nhóm Holland (R, I, A, S, E, C)
    /// </summary>
    public class HollandScore
    {
        public char Group { get; set; }   // 'R','I','A','S','E','C'
        public int Score { get; set; }
    }

    /// <summary>
    /// Helper: Chuyển Dictionary<string,int> sang List<HollandScore>
    /// </summary>
    public static class HollandScoreHelper
    {
        public static List<HollandScore> FromDictionary(Dictionary<string, int> dict)
        {
            var list = new List<HollandScore>();

            void Add(char g)
            {
                dict.TryGetValue(g.ToString(), out var v);
                list.Add(new HollandScore
                {
                    Group = g,
                    Score = v
                });
            }

            Add('R');
            Add('I');
            Add('A');
            Add('S');
            Add('E');
            Add('C');

            return list;
        }
    }
}
