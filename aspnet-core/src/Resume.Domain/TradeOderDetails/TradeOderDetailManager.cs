using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Resume.TradeOderDetails
{
    public class TradeOderDetailManager : DomainService
    {
        private readonly ITradeOderDetailRepository _tradeOderDetailRepository;

        public TradeOderDetailManager(ITradeOderDetailRepository tradeOderDetailRepository)
        {
            _tradeOderDetailRepository = tradeOderDetailRepository;
        }

        public async Task<TradeOderDetail> CreateAsync(
        Guid tradeOrderId, Guid tradeProductId, decimal unitPrice, int quantity, string orderDetailStateCode, string extendedInformation = null, DateTime? dateA = null, DateTime? dateD = null, int? sort = null, string note = null, string status = null)
        {
            Check.NotNullOrWhiteSpace(orderDetailStateCode, nameof(orderDetailStateCode));
            Check.Length(orderDetailStateCode, nameof(orderDetailStateCode), TradeOderDetailConsts.OrderDetailStateCodeMaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), TradeOderDetailConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), TradeOderDetailConsts.NoteMaxLength);
            Check.Length(status, nameof(status), TradeOderDetailConsts.StatusMaxLength);

            var tradeOderDetail = new TradeOderDetail(
             GuidGenerator.Create(),
             tradeOrderId, tradeProductId, unitPrice, quantity, orderDetailStateCode, extendedInformation, dateA, dateD, sort, note, status
             );

            return await _tradeOderDetailRepository.InsertAsync(tradeOderDetail);
        }

        public async Task<TradeOderDetail> UpdateAsync(
            Guid id,
            Guid tradeOrderId, Guid tradeProductId, decimal unitPrice, int quantity, string orderDetailStateCode, string extendedInformation = null, DateTime? dateA = null, DateTime? dateD = null, int? sort = null, string note = null, string status = null
        )
        {
            Check.NotNullOrWhiteSpace(orderDetailStateCode, nameof(orderDetailStateCode));
            Check.Length(orderDetailStateCode, nameof(orderDetailStateCode), TradeOderDetailConsts.OrderDetailStateCodeMaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), TradeOderDetailConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), TradeOderDetailConsts.NoteMaxLength);
            Check.Length(status, nameof(status), TradeOderDetailConsts.StatusMaxLength);

            var tradeOderDetail = await _tradeOderDetailRepository.GetAsync(id);

            tradeOderDetail.TradeOrderId = tradeOrderId;
            tradeOderDetail.TradeProductId = tradeProductId;
            tradeOderDetail.UnitPrice = unitPrice;
            tradeOderDetail.Quantity = quantity;
            tradeOderDetail.OrderDetailStateCode = orderDetailStateCode;
            tradeOderDetail.ExtendedInformation = extendedInformation;
            tradeOderDetail.DateA = dateA;
            tradeOderDetail.DateD = dateD;
            tradeOderDetail.Sort = sort;
            tradeOderDetail.Note = note;
            tradeOderDetail.Status = status;

            return await _tradeOderDetailRepository.UpdateAsync(tradeOderDetail);
        }

    }
}