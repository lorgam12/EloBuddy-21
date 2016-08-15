using EloBuddy;
using EloBuddy.SDK;
using pEzreal.Extensions;

namespace pEzreal.Modes
{
    internal class Active
    {
        public static void Initialize()
        {
            if (Config.MyHero.IsRecalling() || Config.MyHero.IsDead) return;

            Killsteal.Execute();
            if (Config.UseQSS) Cleanse();
            if (Config.TearStacking && Config.MyHero.IsInShopRange()) TearStacking();
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

        private static void TearStacking()
        {
            if (Spells.Manamune.IsOwned() || Spells.TearOfTheGoddess.IsOwned())
            {
                Spells.Q.Cast(Game.CursorPos);
                Spells.W.Cast(Game.CursorPos);
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