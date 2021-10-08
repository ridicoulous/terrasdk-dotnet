﻿using System.Collections.Generic;
using Newtonsoft.Json;
using TerraSdk.Common.Serialization;
using TerraSdk.Core;

namespace TerraSdk.Client.Models
{
    public class MsgDeposit : Msg
    {
        /// <summary>
        /// ID of the proposal.
        /// </summary>
        [JsonProperty("proposal_id")]
        [JsonConverter(typeof(StringNumberConverter))]
        public ulong ProposalId { get; set; }
        
        /// <summary>
        /// Address of the depositor.
        /// </summary>
        [JsonProperty("depositor")]
        public string Depositor { get; set; } = null!;

        /// <summary>
        /// Coins to add to the proposal's deposit.
        /// </summary>
        [JsonProperty("amount")]
        public IList<Coin> Amount { get; set; } = null!;

        public MsgDeposit()
        {
        }

        public MsgDeposit(ulong proposalId, string depositor, IList<Coin> amount)
        {
            ProposalId = proposalId;
            Depositor = depositor;
            Amount = amount;
        }

        public object SignBytesObject()
        {
            return this;
        }
    }
}