namespace NPCs
{
    public enum Characters
    {
        Fairy,
        Merchant,
        OldMan,
        OldWoman,
        Zelda
    }

    public enum Enemies
    {
        [Health(3)]
        Armos,
        [Health()]
        Boulder,
        [Health()]
        Bubble,
        [Health()]
        BubbleBlue,
        [Health()]
        BubbleRed,
        [Health(4)]
        Darknut,
        [Health(8)]
        DarknutBlue,
        [Health(1)]
        Gel,
        [Health(11)]
        Ghini,
        [Health(6, 4, 2)]
        Gibdo,
        GleeokHead,
        [Health(3)]
        Goriya,
        // TODO: This needs to round up when multiplier is 2
        [Health(5)]
        GoriyaBlue,
        [Health(1)]
        Keese,
        [Health(1)]
        KeeseBlue,
        [Health(1)]
        KeeseRed,
        // Always takes 4 hits to kill
        [Health(4, 4, 4)]
        Lanmola,
        // Always takes 4 hits to kill
        [Health(4, 4, 4)]
        LanmolaBlue,
        [Health(2)]
        Leever,
        [Health(4)]
        LeeverBlue,
        [Health(10)]
        LikeLike,
        [Health(4)]
        Lynel,
        [Health(6)]
        LynelBlue,
        [Health(2)]
        Moblin,
        [Health(3)]
        MoblinBlue,
        // Always takes 5 hits to kill
        [Health(5, 5, 5)]
        Moldorm,
        [Health(1)]
        Octorok,
        [Health(2)]
        OctorokBlue,
        [Health(10)]
        Patra,
        [Health(2)]
        Peahat,
        [Health(10)]
        PolsVoice,
        [Health(1)]
        Rope,
        [Health(4)]
        RopeBlue,
        [Health(2)]
        Stalfos,
        [Health(1)]
        Tektite,
        [Health(1)]
        TektiteBlue,
        [Health()]
        Trap,
        // Health is 1, however, when it's hit without magical sword, it turns into 2 Keese
        [Health(1)]
        Vire,
        [Health(3)]
        Wallmaster,
        [Health(3)]
        Wizzrobe,
        [Health(5)]
        WizzrobeBlue,
        [Health(1)]
        Zol,
        [Health(2)]
        Zora
    }

    public enum Bosses
    {
        /// <summary>
        /// 1st Quest B: 1 and 7
        /// 2nd Quest B: 1
        /// 2nd Quest E: 4 and 8
        /// 
        /// Other health:
        /// Bombs - 2 hits
        /// Bow - 3 hits
        /// Wand - 3 hits
        /// </summary>
        [Health(6)]
        Aquamentus,
        /// <summary>
        /// 1st Quest B: 5
        /// 1st Quest E: 7 (total 7 x 1 x 2 pairs of 3)
        /// 2nd Quest B: 4 (total 3 x 1 pair)
        /// 2nd Quest E: 4 (total 3 x 1 pair) and 8 (total 6 x 2 pairs)
        /// 
        /// Other health:
        /// First requires Flute to be played
        /// The health listed here is for individual Digdogger heads
        /// Bombs kill in 2 hits, same as magical sword
        /// Bow and Wand kill in 4 hits, same as white sword
        /// </summary>
        [Health(8)]
        Digdogger,
        /// <summary>
        /// 1st Quest B: 2 (total 1)
        /// 1st Quest E: 5 (total 3 x 1 pair) and 7 (total 6 x 2 pairs)
        /// 2nd Quest B: 3 (total 3 x 1 pair) and 8 (total 3 x 1 pair)
        /// 2nd Quest E: 1 (total 1), 4 (total 4 x 1 x 1 pair), 8 (total 9 x 3 pairs)
        /// 
        /// Other health:
        /// If bomb is placed on its back, you can attack with sword for 1 hit kill
        /// </summary>
        [Health(2, 2, 2)]
        Dodongo,
        /// <summary>
        /// Final Boss
        /// 
        /// Other health:
        /// Must be defeated by silver arrow, and if he's not hit in the stunned state, then he will regain full health
        /// </summary>
        [Health(16)]
        Ganon,
        /// <summary>
        /// 1st Quest B: 4 (2 heads) and 8 (4 heads)
        /// 1st Quest E: 6 (3 heads)
        /// 2nd Quest B: 2 (2 heads), 5 (3 heads), and 7 (4 heads)
        /// 2nd Quest E: 6 (2 heads)
        /// 
        /// Other health:
        /// The health shown here is for each head
        /// Wand will take out head in 4 hits... same damage as white sword
        /// </summary>
        [Health(8)]
        Gleeok,
        /// <summary>
        /// Takes 1 arrow to kill
        /// 1st Quest B: 6
        /// 
        /// Other health:
        /// Must have eye open to hurt
        /// </summary>
        [Health(1)]
        Gohma,
        /// <summary>
        /// Takes 3 arrows to kill
        /// 1st Quest E: 8 (total 2)
        /// 2nd Quest B: 6
        /// 2nd Quest E: 5 and 7
        /// 
        /// Other health:
        /// Must have eye open to hurt
        /// </summary>
        [Health(3, 3, 3)]
        GohmaBlue,
        /// <summary>
        /// 1st Quest B: 3
        /// 1st Quest E: 4 (total 1) and 8 (total 3)
        /// 2nd Quest E: 2 (total 1), 5 (total 1), 6 (total 1), and 7 (total 2)
        /// 
        /// Other health:
        /// Each tentacle requires that many hits, so it's [4, 2, 1] x 4 tentacles
        /// If a tentacle is hit with 1 bomb, it's destroyed... blast radius could destroy multiple
        /// </summary>
        [Health(4, 2, 1)]
        Manhandla
    }
}