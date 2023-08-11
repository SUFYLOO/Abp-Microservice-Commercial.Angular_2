import type { GetTradeOderDetailsInput, TradeOderDetailCreateDto, TradeOderDetailDto, TradeOderDetailExcelDownloadDto, TradeOderDetailUpdateDto } from './models';
import { RestService, Rest } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { DownloadTokenResultDto } from '../shared/models';

@Injectable({
  providedIn: 'root',
})
export class TradeOderDetailService {
  apiName = 'Default';
  

  create = (input: TradeOderDetailCreateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, TradeOderDetailDto>({
      method: 'POST',
      url: '/api/app/trade-oder-details',
      body: input,
    },
    { apiName: this.apiName,...config });
  

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/trade-oder-details/${id}`,
    },
    { apiName: this.apiName,...config });
  

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, TradeOderDetailDto>({
      method: 'GET',
      url: `/api/app/trade-oder-details/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getDownloadToken = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, DownloadTokenResultDto>({
      method: 'GET',
      url: '/api/app/trade-oder-details/download-token',
    },
    { apiName: this.apiName,...config });
  

  getList = (input: GetTradeOderDetailsInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<TradeOderDetailDto>>({
      method: 'GET',
      url: '/api/app/trade-oder-details',
      params: { filterText: input.filterText, tradeOrderId: input.tradeOrderId, tradeProductId: input.tradeProductId, unitPriceMin: input.unitPriceMin, unitPriceMax: input.unitPriceMax, quantityMin: input.quantityMin, quantityMax: input.quantityMax, orderDetailStateCode: input.orderDetailStateCode, extendedInformation: input.extendedInformation, dateAMin: input.dateAMin, dateAMax: input.dateAMax, dateDMin: input.dateDMin, dateDMax: input.dateDMax, sortMin: input.sortMin, sortMax: input.sortMax, note: input.note, status: input.status, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName,...config });
  

  getListAsExcelFile = (input: TradeOderDetailExcelDownloadDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, Blob>({
      method: 'GET',
      responseType: 'blob',
      url: '/api/app/trade-oder-details/as-excel-file',
      params: { downloadToken: input.downloadToken, filterText: input.filterText, name: input.name },
    },
    { apiName: this.apiName,...config });
  

  update = (id: string, input: TradeOderDetailUpdateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, TradeOderDetailDto>({
      method: 'PUT',
      url: `/api/app/trade-oder-details/${id}`,
      body: input,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
