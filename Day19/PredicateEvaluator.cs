using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day19
{

    internal class PredicateEvaluator
    {
        public int Result { get; }

        private string _targetAfterExpression;
        private bool _resultExpression;
        private KeyValuePair<string, string[]> _allPredicatesForEntry;
        private Func<int,int,bool> _predicate;

        public PredicateEvaluator(string currentEntry, Dictionary<string, string[]> allWorkflows)
        {
            _allPredicatesForEntry = allWorkflows;
            _predicate = ConvertStringToPredicate(_allPredicatesForEntry);
        }

        private Func<int, int, bool> ConvertStringToPredicate(string predicateString)
        {
            throw new NotImplementedException();
        }
    }
}
