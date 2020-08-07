using NBitcoin.Altcoins.Elements;
using Encoders = NBitcoin.DataEncoders.Encoders;
using System;
using System.Reflection;
using System.Collections.Generic;
using System.Text;

namespace NBitcoin.Altcoins

{
    public class Makana : NetworkSetBase
    {
        public class MakanaRegtest { }
        static Makana()
        {

            //ElementsParams<Makana>.PeggedAssetId = new uint256("6f0279e9ed041c3d710a9f57d0c02928416460c4b722ae3457a11eec381c526d");
            //ElementsParams<Makana>.SignedBlocks = true;
            //ElementsParams<Makana>.BlockHeightInHeader = true;
            ElementsParams<MakanaRegtest>.PeggedAssetId = new uint256("5f4f1f82ee1bb9adf5f29d98f9c7a67a9f62bbcd7ba1c18c48d5e65e97154f2b");
            ElementsParams<MakanaRegtest>.SignedBlocks = true;
            ElementsParams<MakanaRegtest>.BlockHeightInHeader = true;

        }
        public override string CryptoCode => "MKNA";
        public static Makana Instance { get; } = new Makana();

        protected override NetworkBuilder CreateMainnet()
        {
            return null;
        }

        protected override NetworkBuilder CreateTestnet()
        {
            return null;
        }

        protected override NetworkBuilder CreateRegtest()
        {
            var builder = new NetworkBuilder();
            builder.SetConsensus(new Consensus()
            {
                SubsidyHalvingInterval = 150,
                MajorityEnforceBlockUpgrade = 51,
                MajorityRejectBlockOutdated = 75,
                MajorityWindow = 144,
                PowLimit = new Target(new uint256("7fffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff")),
                //PowTargetTimespan = TimeSpan.FromSeconds(3.5 * 24 * 60 * 60),
                //PowTargetSpacing = TimeSpan.FromSeconds(10 * 60),
                PowAllowMinDifficultyBlocks = true,
                MinimumChainWork = uint256.Zero,
                PowNoRetargeting = true,
                RuleChangeActivationThreshold = 108,
                MinerConfirmationWindow = 2016,
                CoinbaseMaturity = 100,
                LitecoinWorkCalculation = true,
                //SupportTestMempoolAccept = true,
                ConsensusFactory = ElementsConsensusFactory<MakanaRegtest>.Instance
            })
            .SetNetworkStringParser(new ElementsStringParser())
            .SetBase58Bytes(Base58Type.PUBKEY_ADDRESS, new byte[] { (235) })
            .SetBase58Bytes(Base58Type.SCRIPT_ADDRESS, new byte[] { (75) })
            .SetBase58Bytes(Base58Type.SECRET_KEY, new byte[] { (239) })
            .SetBase58Bytes(Base58Type.EXT_PUBLIC_KEY, new byte[] { (0x04), (0x35), (0x87), (0xCF) })
            .SetBase58Bytes(Base58Type.EXT_SECRET_KEY, new byte[] { (0x04), (0x35), (0x83), (0x94) })
            .SetBase58Bytes(Base58Type.BLINDED_ADDRESS, new byte[] { 4 })
            .SetBech32(Bech32Type.WITNESS_PUBKEY_ADDRESS, Encoders.Bech32("ert"))
            .SetBech32(Bech32Type.WITNESS_SCRIPT_ADDRESS, Encoders.Bech32("ert"))
            .SetBech32(Bech32Type.BLINDED_ADDRESS, NBitcoin.Altcoins.Elements.ElementsEncoders.Blech32("el"))
            .SetMagic(0xdab5bffa)
            .SetPort(19444)
            .SetRPCPort(18884)
            .SetName("mkna-reg")
            .AddAlias("mkna-regtest")
            .AddAlias("makana-reg")
            .AddAlias("makana-regtest")
            .SetGenesis("010000000000000000000000000000000000000000000000000000000000000000000000365581e7c9dd46a127066d8a99ee9a4024a0efc628fc45c7cfc41963ca1674cfdae5494d0000000047522103d00ed7434d50b4da20e25fb3df0b9d92c5cf1afa903479bda2c9c4b6cc409ec42102034580792483208b2a0365e06a10999ba9c9198a7aa65e1beb6849b33cb6564352ae00010100000000010000000000000000000000000000000000000000000000000000000000000000ffffffff2120a95ba6d90cbc401e2323857e39e1c29477f5bd7500ee247db2a589fd09596779ffffffff0101000000000000000000000000000000000000000000000000000000000000000001000000000000000000016a00000000");
            return builder;
        }

        protected override void PostInit()
        {
            RegisterDefaultCookiePath("Makana", new FolderName() { RegtestFolder = "makanaregtest" });
        }
    }

}
