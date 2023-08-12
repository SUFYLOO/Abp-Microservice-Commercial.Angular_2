import { ABP, downloadBlob, ListService, PagedResultDto, TrackByService } from '@abp/ng.core';
import { Confirmation, ConfirmationService } from '@abp/ng.theme.shared';
import { DateAdapter } from '@abp/ng.theme.shared/extensions';
import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbDateAdapter } from '@ng-bootstrap/ng-bootstrap';
import { filter, finalize, switchMap, tap } from 'rxjs/operators';
import type { GetTradeProductsInput, TradeProductDto } from '../../../proxy/trade-products/models';
import { TradeProductService } from '../../../proxy/trade-products/trade-product.service';
@Component({
  selector: 'app-trade-product',
  changeDetection: ChangeDetectionStrategy.Default,
  providers: [ListService, { provide: NgbDateAdapter, useClass: DateAdapter }],
  templateUrl: './trade-product.component.html',
  styles: [],
})
export class TradeProductComponent implements OnInit {
  data: PagedResultDto<TradeProductDto> = {
    items: [],
    totalCount: 0,
  };

  filters = {} as GetTradeProductsInput;

  form: FormGroup;

  isFiltersHidden = true;

  isModalBusy = false;

  isModalOpen = false;

  isExportToExcelBusy = false;

  selected?: TradeProductDto;

  constructor(
    public readonly list: ListService,
    public readonly track: TrackByService,
    public readonly service: TradeProductService,
    private confirmation: ConfirmationService,
    private fb: FormBuilder
  ) {}

  ngOnInit() {
    const getData = (query: ABP.PageQueryParams) =>
      this.service.getList({
        ...query,
        ...this.filters,
        filterText: query.filter,
      });

    const setData = (list: PagedResultDto<TradeProductDto>) => (this.data = list);

    this.list.hookToQuery(getData).subscribe(setData);
  }

  clearFilters() {
    this.filters = {} as GetTradeProductsInput;
  }

  buildForm() {
    const {
      name,
      contents,
      productCategoryCode,
      unitPrice,
      unitPricePromotions,
      unitCode,
      quantityStock,
      quantityOrdered,
      quantitySafetyStock,
      extendedInformation,
      dateA,
      dateD,
      sort,
      orderStateCode,
      status,
    } = this.selected || {};

    this.form = this.fb.group({
      name: [name ?? null, [Validators.required, Validators.maxLength(50)]],
      contents: [contents ?? null, [Validators.maxLength(500)]],
      productCategoryCode: [
        productCategoryCode ?? null,
        [Validators.required, Validators.maxLength(50)],
      ],
      unitPrice: [unitPrice ?? null, []],
      unitPricePromotions: [unitPricePromotions ?? null, []],
      unitCode: [unitCode ?? null, [Validators.required, Validators.maxLength(50)]],
      quantityStock: [quantityStock ?? null, []],
      quantityOrdered: [quantityOrdered ?? null, []],
      quantitySafetyStock: [quantitySafetyStock ?? null, []],
      extendedInformation: [extendedInformation ?? null, [Validators.maxLength(500)]],
      dateA: [dateA ? new Date(dateA) : null, []],
      dateD: [dateD ? new Date(dateD) : null, []],
      sort: [sort ?? null, []],
      orderStateCode: [orderStateCode ?? null, [Validators.maxLength(500)]],
      status: [status ?? null, [Validators.maxLength(50)]],
    });
  }

  hideForm() {
    this.isModalOpen = false;
    this.form.reset();
  }

  showForm() {
    this.buildForm();
    this.isModalOpen = true;
  }

  submitForm() {
    if (this.form.invalid) return;

    const request = this.selected
      ? this.service.update(this.selected.id, {
          ...this.form.value,
          concurrencyStamp: this.selected.concurrencyStamp,
        })
      : this.service.create(this.form.value);

    this.isModalBusy = true;

    request
      .pipe(
        finalize(() => (this.isModalBusy = false)),
        tap(() => this.hideForm())
      )
      .subscribe(this.list.get);
  }

  create() {
    this.selected = undefined;
    this.showForm();
  }

  update(record: TradeProductDto) {
    this.selected = record;
    this.showForm();
  }

  delete(record: TradeProductDto) {
    this.confirmation
      .warn('::DeleteConfirmationMessage', '::AreYouSure', { messageLocalizationParams: [] })
      .pipe(
        filter(status => status === Confirmation.Status.confirm),
        switchMap(() => this.service.delete(record.id))
      )
      .subscribe(this.list.get);
  }

  exportToExcel() {
    this.isExportToExcelBusy = true;
    this.service
      .getDownloadToken()
      .pipe(
        switchMap(({ token }) =>
          this.service.getListAsExcelFile({ downloadToken: token, filterText: this.list.filter })
        ),
        finalize(() => (this.isExportToExcelBusy = false))
      )
      .subscribe(result => {
        downloadBlob(result, 'TradeProduct.xlsx');
      });
  }
}
