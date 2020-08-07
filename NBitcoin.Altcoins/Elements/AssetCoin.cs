﻿using System;

namespace NBitcoin.Altcoins.Elements
{
	public class AssetCoin : ICoin
	{
		private readonly ICoin innerCoin;

		public AssetCoin(AssetMoney assetMoney, ICoin innerCoin)
		{
			if (assetMoney == null)
				throw new ArgumentNullException(nameof(assetMoney));
			if (innerCoin == null)
				throw new ArgumentNullException(nameof(innerCoin));
			Money = assetMoney;
			this.innerCoin = innerCoin;
		}

		public AssetMoney Money { get; }
		IMoney ICoin.Amount => Money;

		public OutPoint OutPoint
		{
			get
			{
				return innerCoin.Outpoint;
			}
		}

		public TxOut TxOut => innerCoin.TxOut;

		public bool CanGetScriptCode => innerCoin.CanGetScriptCode;

		public OutPoint Outpoint => innerCoin.Outpoint;

		public HashVersion GetHashVersion()
		{
			return innerCoin.GetHashVersion();
		}

		public Script GetScriptCode()
		{
			return innerCoin.GetScriptCode();
		}

		public void OverrideScriptCode(Script scriptCode)
		{
			innerCoin.OverrideScriptCode(scriptCode);
		}
	}
}
