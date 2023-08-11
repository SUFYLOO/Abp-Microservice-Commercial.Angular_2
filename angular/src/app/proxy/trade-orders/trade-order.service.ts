import type { GetTradeOrdersInput, TradeOrderCreateDto, TradeOrderDto, TradeOrderExcelDownloadDto, TradeOrderUpdateDto } from './models';
import { RestService, Rest } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { DownloadTokenResultDto } from '../shared/models';

@Injectable({
  providedIn: 'root',
})
export class TradeOrderService {
  apiName = 'Default';
  

  create = (input: TradeOrderCreateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, TradeOrderDto>({
      method: 'POST',
      url: '/api/app/trade-orders',
      body: input,
    },
    { apiName: this.apiName,...config });
  

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/trade-orders/${id}`,
    },
    { apiName: this.apiName,...config });
  

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, TradeOrderDto>({
      method: 'GET',
      url: `/api/app/trade-orders/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getDownloadToken = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, DownloadTokenResultDto>({
      method: 'GET',
      url: '/api/app/trade-orders/download-token',
    },
    { apiName: this.apiName,...config });
  

  getList = (input: GetTradeOrdersInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<TradeOrderDto>>({
      method: 'GET',
      url: '/api/app/trade-orders',
      params: { filterText: input.filterText, keyId: input.keyId, orderNumber: input.orderNumber, dateOrderMin: input.dateOrderMin, dateOrderMax: input.dateOrderMax, dateNeedMin: input.dateNeedMin, dateNeedMax: input.dateNeedMax, dateDeliveryMin: input.dateDeliveryMin, dateDeliveryMax: input.dateDeliveryMax, deliveryMethodCode: input.deliveryMethodCode, deliveryZipCode: input.deliveryZipCode, deliveryCityCode: input.deliveryCityCode, deliveryAreaCode: input.deliveryAreaCode, deliveryAddress: input.deliveryAddress, deliveryFeeMin: input.deliveryFeeMin, deliveryFeeMax: input.deliveryFeeMax, userName: input.userName, orderStateCode: input.orderStateCode, extendedInformation: input.extendedInformation, dateAMin: input.dateAMin, dateAMax: input.dateAMax, dateDMin: input.dateDMin, dateDMax: input.dateDMax, sortMin: input.sortMin, sortMax: input.sortMax, note: input.note, status: input.status, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName,...config });
  

  getListAsExcelFile = (input: TradeOrderExcelDownloadDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, Blob>({
      method: 'GET',
      responseType: 'blob',
      url: '/api/app/trade-orders/as-excel-file',
      params: { downloadToken: input.downloadToken, filterText: input.filterText, name: input.name },
    },
    { apiName: this.apiName,...config });
  

  update = (id: string, input: TradeOrderUpdateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, TradeOrderDto>({
      method: 'PUT',
      url: `/api/app/trade-orders/${id}`,
      body: input,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
