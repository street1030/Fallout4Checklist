using Fallout4Checklist.Entities;
using System;
using System.Collections.Generic;

namespace Fallout4Checklist
{
    public static class FalloutExtensions
    {
        public static List<QuestStage> GetNextStages(this QuestStage stage)
        {
            var stages = new List<QuestStage>();

            foreach (var chain in stage.NextQuestStages)
                stages.Add(chain.NextQuestStage);

            return stages;
        }

        public static IEnumerable<TSource> DistinctBy<TSource, TKey>
            (this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            HashSet<TKey> seenKeys = new HashSet<TKey>();
            foreach (TSource element in source)
            {
                if (seenKeys.Add(keySelector(element)))
                {
                    yield return element;
                }
            }
        }
    }
}
