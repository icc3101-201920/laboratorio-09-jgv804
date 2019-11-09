using Laboratorio_8_OOP_201920.Cards;
using Laboratorio_8_OOP_201920.Enums;
using System.Collections.Generic;

namespace Laboratorio_8_OOP_201920
{
    public static class Effect
    {
        private static Dictionary<EnumType, List<Card>>[] playedCards;

        private static Dictionary<EnumEffect, string> effectDescriptions = new Dictionary<EnumEffect, string>()
        {
            { EnumEffect.bitingFrost, "Sets the strength of all melee cards to 1 for both players" },
            { EnumEffect.impenetrableFog, "Sets the strength of all range cards to 1 for both players" },
            { EnumEffect.torrentialRain, "Sets the strength of all longRange cards to 1 for both players" },
            { EnumEffect.clearWeather, "Removes all Weather Card (Biting Frost, Impenetrable Fog and Torrential Rain) effects" },
            { EnumEffect.moraleBoost, "Adds +1 to all units in the row (excluding itself)" },
            { EnumEffect.spy, "Place on your opponent's battlefield (counts towards opponent's total) and draw 2 cards from your deck" },
            { EnumEffect.tightBond, "Place next to a card with the same name to double the strength of both cards" },
            { EnumEffect.buff, "Doubles the strength of all unit cards in that row. Limited to 1 per row" },
            { EnumEffect.none, "None" },
        };

        public static string GetEffectDescription(EnumEffect e)
        {
            return effectDescriptions[e];
        }

        public static void ApplyEffect(Card playedCard, Player activePlayer, Player opponent, Board board)
        {
            if(playedCard.CardEffect == EnumEffect.bitingFrost)
            {
                
                for (int i = 0; i < 2; i++)
                {
                    if (board.PlayerCards[i].ContainsKey(EnumType.melee))
                    {
                        foreach (CombatCard card in board.PlayerCards[i][EnumType.melee])
                        {
                            CombatCard p = new CombatCard(card.Name, card.Type, card.CardEffect,card.AttackPoints, false);
                            playedCards[i][EnumType.melee].Add(p); 

                            card.AttackPoints=1;
                        }
                    }
                }
            }
            if (playedCard.CardEffect == EnumEffect.impenetrableFog)
            {
                for (int i = 0; i < 2; i++)
                {
                    if (board.PlayerCards[i].ContainsKey(EnumType.range))
                    {
                        foreach (CombatCard card in board.PlayerCards[i][EnumType.range])
                        {
                            CombatCard p = new CombatCard(card.Name, card.Type, card.CardEffect, card.AttackPoints, false);
                            playedCards[i][EnumType.range].Add(p);

                            card.AttackPoints = 1;
                        }
                    }
                }

            }
            if (playedCard.CardEffect == EnumEffect.torrentialRain)
            {
                for (int i = 0; i < 2; i++)
                {
                    if (board.PlayerCards[i].ContainsKey(EnumType.longRange))
                    {
                        foreach (CombatCard card in board.PlayerCards[i][EnumType.longRange])
                        {
                            CombatCard p = new CombatCard(card.Name, card.Type, card.CardEffect, card.AttackPoints, false);
                            playedCards[i][EnumType.longRange].Add(p);

                            card.AttackPoints = 1;
                        }
                    }
                }

            }
            if (playedCard.CardEffect == EnumEffect.clearWeather)
            {
                int counter = 0;
                for (int i = 0; i < 2; i++)
                {
                    if (board.PlayerCards[i].ContainsKey(EnumType.longRange))
                    {
                        foreach (CombatCard card in board.PlayerCards[i][EnumType.longRange])
                        {

                            CombatCard c = playedCards[i][EnumType.longRange][counter] as CombatCard;

                            card.AttackPoints = c.AttackPoints;
                            counter += 1;
                        }
                        counter = 0;
                    }
                    if (board.PlayerCards[i].ContainsKey(EnumType.range))
                    {
                        foreach (CombatCard card in board.PlayerCards[i][EnumType.range])
                        {

                            CombatCard c = playedCards[i][EnumType.range][counter] as CombatCard;

                            card.AttackPoints = c.AttackPoints;
                            counter += 1;
                        }
                        counter = 0;
                    }
                    if (board.PlayerCards[i].ContainsKey(EnumType.melee))
                    {
                        foreach (CombatCard card in board.PlayerCards[i][EnumType.melee])
                        {

                            CombatCard c = playedCards[i][EnumType.melee][counter] as CombatCard;

                            card.AttackPoints = c.AttackPoints;
                            counter += 1;

                        }
                        counter = 0;
                    }



                }


            }
        }
    }
}
