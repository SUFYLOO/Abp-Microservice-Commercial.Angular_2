import type { FullAuditedEntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface GetTradeOderDetailsInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  tradeOrderId?: string;
  tradeProductId?: string;
  unitPriceMin?: number;
  unitPriceMax?: number;
  quantityMin?: number;
  quantityMax?: number;
  orderDetailStateCode?: string;
  extendedInformation?: string;
  dateAMin?: string;
  dateAMax?: string;
  dateDMin?: string;
  dateDMax?: string;
  sortMin?: number;
  sortMax?: number;
  note?: string;
  status?: string;
}

export interface TradeOderDetailCreateDto {
  tradeOrderId?: string;
  tradeProductId?: string;
  unitPrice?: number;
  quantity?: number;
  orderDetailStateCode: string;
  extendedInformation?: string;
  dateA?: string;
  dateD?: string;
  sort?: number;
  note?: string;
  status?: string;
}

export interface TradeOderDetailDto extends FullAuditedEntityDto<string> {
  tradeOrderId?: string;
  tradeProductId?: string;
  unitPrice?: number;
  quantity?: number;
  orderDetailStateCode: string;
  extendedInformation?: string;
  dateA?: string;
  dateD?: string;
  sort?: number;
  note?: string;
  status?: string;
}

export interface TradeOderDetailExcelDownloadDto {
  downloadToken?: string;
  filterText?: string;
  name?: string;
}

export interface TradeOderDetailUpdateDto {
  tradeOrderId?: string;
  tradeProductId?: string;
  unitPrice?: number;
  quantity?: number;
  orderDetailStateCode: string;
  extendedInformation?: string;
  dateA?: string;
  dateD?: string;
  sort?: number;
  note?: string;
  status?: string;
}
