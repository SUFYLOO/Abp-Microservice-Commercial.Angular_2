import type { FullAuditedEntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface GetTradeOrdersInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  keyId?: string;
  orderNumber?: string;
  dateOrderMin?: string;
  dateOrderMax?: string;
  dateNeedMin?: string;
  dateNeedMax?: string;
  dateDeliveryMin?: string;
  dateDeliveryMax?: string;
  deliveryMethodCode?: string;
  deliveryZipCode?: string;
  deliveryCityCode?: string;
  deliveryAreaCode?: string;
  deliveryAddress?: string;
  deliveryFeeMin?: number;
  deliveryFeeMax?: number;
  userName?: string;
  orderStateCode?: string;
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

export interface TradeOrderCreateDto {
  keyId?: string;
  orderNumber: string;
  dateOrder?: string;
  dateNeed?: string;
  dateDelivery?: string;
  deliveryMethodCode?: string;
  deliveryZipCode?: string;
  deliveryCityCode?: string;
  deliveryAreaCode?: string;
  deliveryAddress?: string;
  deliveryFee?: number;
  userName?: string;
  orderStateCode: string;
  extendedInformation?: string;
  dateA?: string;
  dateD?: string;
  sort?: number;
  note?: string;
  status?: string;
}

export interface TradeOrderDto extends FullAuditedEntityDto<string> {
  keyId?: string;
  orderNumber: string;
  dateOrder?: string;
  dateNeed?: string;
  dateDelivery?: string;
  deliveryMethodCode?: string;
  deliveryZipCode?: string;
  deliveryCityCode?: string;
  deliveryAreaCode?: string;
  deliveryAddress?: string;
  deliveryFee?: number;
  userName?: string;
  orderStateCode: string;
  extendedInformation?: string;
  dateA?: string;
  dateD?: string;
  sort?: number;
  note?: string;
  status?: string;
  concurrencyStamp?: string;
}

export interface TradeOrderExcelDownloadDto {
  downloadToken?: string;
  filterText?: string;
  name?: string;
}

export interface TradeOrderUpdateDto {
  keyId?: string;
  orderNumber: string;
  dateOrder?: string;
  dateNeed?: string;
  dateDelivery?: string;
  deliveryMethodCode?: string;
  deliveryZipCode?: string;
  deliveryCityCode?: string;
  deliveryAreaCode?: string;
  deliveryAddress?: string;
  deliveryFee?: number;
  userName?: string;
  orderStateCode: string;
  extendedInformation?: string;
  dateA?: string;
  dateD?: string;
  sort?: number;
  note?: string;
  status?: string;
  concurrencyStamp?: string;
}
