using EloBuddy;
using pEzreal.Extensions;

namespace pEzreal.Modes
{
    internal class Active
    {
        public static void Initialize()
        {
            Killsteal.Execute();
            if (Config.UseQSS) Cleanse();
        }

        private static void Cleanse()
        {
            if (!IsImmobile(Config.MyHero)) return;

            if (Spells.QSS.IsOwned() && Spells.QSS.IsReady())
            {
                Spells.QSS.Cast();
            }
            else if (Spells.Mercurial.IsOwned() && Spells.Mercurial.IsReady())
            {
                Spells.Mercurial.Cast();
            }
        }

        private static bool IsImmobile(Obj_AI_Base target)
        {
            return target.HasBuffOfType(BuffType.Stun) || target.HasBuffOfType(BuffType.Snare) ||
                   target.HasBuffOfType(BuffType.Knockup) || target.HasBuffOfType(BuffType.Charm) ||
                   target.HasBuffOfType(BuffType.Fear) || target.HasBuffOfType(BuffType.Knockback) ||
                   target.HasBuffOfType(BuffType.Taunt) || target.HasBuffOfType(BuffType.Suppression) ||
                   target.IsStunned;
        }
    }
}