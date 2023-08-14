import type { FullAuditedEntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface GetTradeProductsInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  name?: string;
  contents?: string;
  productCategoryCode?: string;
  unitPriceMin?: number;
  unitPriceMax?: number;
  unitPricePromotionsMin?: number;
  unitPricePromotionsMax?: number;
  unitCode?: string;
  quantityStockMin?: number;
  quantityStockMax?: number;
  quantityOrderedMin?: number;
  quantityOrderedMax?: number;
  quantitySafetyStockMin?: number;
  quantitySafetyStockMax?: number;
  extendedInformation?: string;
  dateAMin?: string;
  dateAMax?: string;
  dateDMin?: string;
  dateDMax?: string;
  sortMin?: number;
  sortMax?: number;
  orderStateCode?: string;
  status?: string;
}

export interface TradeProductCreateDto {
  name: string;
  contents?: string;
  productCategoryCode: string;
  unitPrice?: number;
  unitPricePromotions?: number;
  unitCode: string;
  quantityStock?: number;
  quantityOrdered?: number;
  quantitySafetyStock?: number;
  extendedInformation?: string;
  dateA?: string;
  dateD?: string;
  sort?: number;
  orderStateCode?: string;
  status?: string;
}

export interface TradeProductDto extends FullAuditedEntityDto<string> {
  name: string;
  contents?: string;
  productCategoryCode: string;
  unitPrice?: number;
  unitPricePromotions?: number;
  unitCode: string;
  quantityStock?: number;
  quantityOrdered?: number;
  quantitySafetyStock?: number;
  extendedInformation?: string;
  dateA?: string;
  dateD?: string;
  sort?: number;
  orderStateCode?: string;
  status?: string;
}

export interface TradeProductExcelDownloadDto {
  downloadToken?: string;
  filterText?: string;
  name?: string;
}

export interface TradeProductUpdateDto {
  name: string;
  contents?: string;
  productCategoryCode: string;
  unitPrice?: number;
  unitPricePromotions?: number;
  unitCode: string;
  quantityStock?: number;
  quantityOrdered?: number;
  quantitySafetyStock?: number;
  extendedInformation?: string;
  dateA?: string;
  dateD?: string;
  sort?: number;
  orderStateCode?: string;
  status?: string;
}
