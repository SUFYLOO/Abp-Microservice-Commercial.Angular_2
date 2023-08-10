import type { GetTradeProductsInput, TradeProductCreateDto, TradeProductDto, TradeProductExcelDownloadDto, TradeProductUpdateDto } from './models';
import { RestService, Rest } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';
import type { DownloadTokenResultDto } from '../shared/models';

@Injectable({
  providedIn: 'root',
})
export class TradeProductService {
  apiName = 'Default';
  

  create = (input: TradeProductCreateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, TradeProductDto>({
      method: 'POST',
      url: '/api/app/trade-products',
      body: input,
    },
    { apiName: this.apiName,...config });
  

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/trade-products/${id}`,
    },
    { apiName: this.apiName,...config });
  

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, TradeProductDto>({
      method: 'GET',
      url: `/api/app/trade-products/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getDownloadToken = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, DownloadTokenResultDto>({
      method: 'GET',
      url: '/api/app/trade-products/download-token',
    },
    { apiName: this.apiName,...config });
  

  getList = (input: GetTradeProductsInput, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<TradeProductDto>>({
      method: 'GET',
      url: '/api/app/trade-products',
      params: { filterText: input.filterText, name: input.name, contents: input.contents, productCategoryCode: input.productCategoryCode, unitPriceMin: input.unitPriceMin, unitPriceMax: input.unitPriceMax, unitPricePromotionsMin: input.unitPricePromotionsMin, unitPricePromotionsMax: input.unitPricePromotionsMax, unitCode: input.unitCode, quantityStockMin: input.quantityStockMin, quantityStockMax: input.quantityStockMax, quantityOrderedMin: input.quantityOrderedMin, quantityOrderedMax: input.quantityOrderedMax, quantitySafetyStockMin: input.quantitySafetyStockMin, quantitySafetyStockMax: input.quantitySafetyStockMax, extendedInformation: input.extendedInformation, dateAMin: input.dateAMin, dateAMax: input.dateAMax, dateDMin: input.dateDMin, dateDMax: input.dateDMax, sortMin: input.sortMin, sortMax: input.sortMax, orderStateCode: input.orderStateCode, status: input.status, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName,...config });
  

  getListAsExcelFile = (input: TradeProductExcelDownloadDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, Blob>({
      method: 'GET',
      responseType: 'blob',
      url: '/api/app/trade-products/as-excel-file',
      params: { downloadToken: input.downloadToken, filterText: input.filterText, name: input.name },
    },
    { apiName: this.apiName,...config });
  

  update = (id: string, input: TradeProductUpdateDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, TradeProductDto>({
      method: 'PUT',
      url: `/api/app/trade-products/${id}`,
      body: input,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
