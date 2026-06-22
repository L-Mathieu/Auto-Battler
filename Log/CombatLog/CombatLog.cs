using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto_Battler.Log.CombatLog
{
    public class CombatLog
    {
        private readonly List<CombatEvent> _entries;

        public CombatLog(CombatEvent entries)
        {
            _entries = new List<CombatEvent>();
        }

        public void Add(CombatEvent entry)
        {
            _entries.Add(entry);
        }
    }
}
